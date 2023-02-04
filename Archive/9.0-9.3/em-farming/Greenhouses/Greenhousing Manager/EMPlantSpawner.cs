// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Simulation.WorldLayers.Pushers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Eco.EM.Greenhousing;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Types;
    using Eco.Simulation.WorldLayers.Layers;
    using Eco.World;
    using Eco.World.Blocks;

    public sealed class EMPlantSpawner : WorldLayerPusher<float>, IWorldLayerPusher, IPostWorldGenWorldLayerPusher
    {
        /// <summary> Layers layout info for <see cref="EMPlantSpawner"/> dependencies. </summary>
        private sealed class LayersInfo
        {
            public int MaxVoxelsPerEntry;
            public int MinVoxelsPerEntry;
            public WorldLayer TrampledLayer;
            public (int VoxelsPerEntry, PlantLayer[] Layers)[] PlantLayerGroups;
            public WorldLayer[] CapacityLayers;
            public string[] CapacityLayerNames;
        }

        private class Capacity
        {
            private readonly float[] tempCapacities;
            private readonly float cellArea;
            public readonly float[] AvailableCapacities;
            public readonly string[] LayerNames;
            public readonly int VoxelsPerEntry;

            public Capacity(string[] layerNames, float[] availableCapacities, int voxelsPerEntry)
            {
                this.LayerNames = layerNames;
                this.AvailableCapacities = availableCapacities;
                this.VoxelsPerEntry = voxelsPerEntry;
                this.cellArea = voxelsPerEntry * voxelsPerEntry;
                this.tempCapacities = new float[availableCapacities.Length];
            }

            /// <summary> Returns size of capacities slice for <paramref name="voxelsPerEntry"/> resolution. </summary>
            public int GetSliceSize(int voxelsPerEntry)
            {
                var scale = voxelsPerEntry / this.VoxelsPerEntry;
                return scale * scale * this.LayerNames.Length;
            }

            private System.Range GetSpeciesRange(PlantSpecies species, int offset)
            {
                var sliceSize = this.GetSliceSize(species.VoxelsPerEntry);
                // reduce to capacities available for this species (aligned to sliceSize)
                var normalizedOffset = offset / sliceSize * sliceSize;
                return new System.Range(normalizedOffset, normalizedOffset + sliceSize);
            }

            /// <summary> Tries to consume available capacity for <paramref name="count"/> of plant <paramref name="species"/>. Returns <c>true</c> if succeed. </summary>
            public bool TryConsume(PlantSpecies species, int count, int offset)
            {
                var speciesRange = this.GetSpeciesRange(species, offset);
                var tempCapacities = this.tempCapacities.AsSpan(speciesRange);
                var availableCapacities = this.AvailableCapacities.AsSpan(speciesRange);
                availableCapacities.CopyTo(tempCapacities);
                if (!this.ConsumeInternal(species, count, tempCapacities))
                    return false;

                // if all capacities satisfies then commit changes
                tempCapacities.CopyTo(availableCapacities);
                return true;
            }

            public void Consume(PlantSpecies species, int count, int offset) => this.ConsumeInternal(species, count, this.AvailableCapacities.AsSpan(this.GetSpeciesRange(species, offset)));

            /// <summary> Consumes from <see cref="AvailableCapacities"/> capacities required for the <paramref name="count"/> of <paramref name="species"/>. Returns <c>true</c> if enough <see cref="AvailableCapacities"/>. </summary>
            private bool ConsumeInternal(PlantSpecies species, int count, Span<float> availableCapacities)
            {
                var populationPerCapacityCell = count / this.cellArea;
                var capacityLayersCount = this.LayerNames.Length;
                // optimized path for one cell
                if (availableCapacities.Length == capacityLayersCount) return this.ConsumeCapacityForOneCell(species, populationPerCapacityCell, availableCapacities);
                var cellsCount = availableCapacities.Length / capacityLayersCount;
                // fist check and remember required capacities
                foreach (var constraint in species.CapacityConstraints)
                {
                    var required = populationPerCapacityCell * constraint.ConsumedCapacityPerPop;
                    if (required < WorldLayer.Epsilon) continue;

                    var capacityIndex = Array.IndexOf(this.LayerNames, constraint.CapacityLayerName);
                    var availableShares = cellsCount;
                    while (true)
                    {
                        var shareAmount = required / availableShares;
                        availableShares = 0;
                        for (var index = capacityIndex; index < availableCapacities.Length; index += capacityLayersCount)
                        {
                            var available = availableCapacities[index];
                            if (shareAmount < available)
                            {
                                availableCapacities[index] -= shareAmount;
                                required -= shareAmount;
                                ++availableShares;
                            }
                            else
                            {
                                availableCapacities[index] -= available;
                                required -= available;
                            }
                        }

                        if (required < WorldLayer.Epsilon) break;
                        if (availableShares == 0) return false;
                    }
                }

                return true;
            }

            /// <summary> Optimized version of <see cref="Consume"/> for one cell with same resolution as capacity. </summary>
            private bool ConsumeCapacityForOneCell(PlantSpecies species, float population, Span<float> cellCapacities)
            {
                var enoughCapacity = true;
                foreach (var constraint in species.CapacityConstraints)
                {
                    var index = Array.IndexOf(this.LayerNames, constraint.CapacityLayerName);
                    var consumed = population * constraint.ConsumedCapacityPerPop;
                    if (consumed > cellCapacities[index])
                    {
                        enoughCapacity = false;
                        cellCapacities[index] = 0;
                    }
                    else
                        cellCapacities[index] -= consumed;
                }

                return enoughCapacity;
            }
        }

        private const int MinTreeDistance = 5;
        private const float PlantKillThreshold = 0.9f;    // this value is fraction of plant which will preserve plant from killing to avoid spawning/killing plants every tick if population value insignificantly changes due to spread or negative growth rate.

        private readonly Lazy<LayersInfo> layersInfo;
        public override string[] DependencyLayerNames => Array.Empty<string>();

        public EMPlantSpawner() => this.layersInfo = new Lazy<LayersInfo>(this.BuildLayersInfo);

        /// <summary> Builds <see cref="LayersInfo"/> which contains all info about dependency layers. </summary>
        private LayersInfo BuildLayersInfo()
        {
            var plantLayers = WorldLayerManager.Obj.Layers.OfType<PlantLayer>().ToArray();
            var capacityLayers = plantLayers.SelectMany(layer => layer.Species.CapacityConstraints).Select(constraint => constraint.CapacityLayerName).Distinct().Select(WorldLayerManager.Obj.GetLayer).ToArray();
            var info = new LayersInfo();
            info.CapacityLayers = capacityLayers;
            info.CapacityLayerNames = capacityLayers.Select(it => it.Name).ToArray();
            info.PlantLayerGroups = plantLayers.GroupBy(it => it.Settings.VoxelsPerEntry).OrderByDescending(it => it.Key).Select(it => (it.Key, it.ToArray())).ToArray();
            info.TrampledLayer = WorldLayerManager.Obj.GetLayer(LayerNames.TrampledSpread);
            info.MinVoxelsPerEntry = info.PlantLayerGroups[^1].VoxelsPerEntry;
            info.MaxVoxelsPerEntry = info.PlantLayerGroups[0].VoxelsPerEntry;
            return info;
        }

        int IWorldLayerPusher.VoxelsPerEntry => this.layersInfo.Value.MaxVoxelsPerEntry;

        /// <summary>
        /// Synchronizes the plant layer values and the World plant counts in the <paramref name="area"/>.
        /// <paramref name="availableCapacity"/> contains capacities for <paramref name="area"/> and will be consumed by world plants, so after call you will have <paramref name="availableCapacity"/> for new plants.
        /// It returns desired plants to spawn as list of <see cref="PlantLayer"/>. It may have repeatable entries for multiple plants of same species.
        /// </summary>
        private List<PlantLayer> SyncPlants(LayersInfo layersInfo, WorldArea area, Span<PlantLayer> plantLayers, Capacity availableCapacity, int capacityOffset)
        {
            var voxelsPerEntry = area.Width;
            var layerPosition = new LayerPosition(area.MinInclusive / voxelsPerEntry, voxelsPerEntry);

            var temperature = WorldLayerManager.Obj.GetLayer(LayerNames.Temperature).GetValue(layerPosition);
            var moisture = WorldLayerManager.Obj.GetLayer(LayerNames.Rainfall).GetValue(layerPosition);
            var pollution = WorldLayerManager.Obj.GetLayer(LayerNames.GroundPollutionSpread).GetValue(layerPosition);
            var saltwater = WorldLayerManager.Obj.GetLayer(LayerNames.SaltWater).GetValue(layerPosition);

            // TODO trampling needs to change - should reduce the carrying capacity of the species in the area instead of just directly preventing spawning
            // TODO spatial spawning constraints need to change - limited spawning space should affect carrying capacity, not block spawning (except in edge/error cases obviously)
            var trampledValue = layersInfo.TrampledLayer.GetValue(layerPosition);
            var plantLayerValues = this.GetLayerValues(plantLayers, layerPosition);

            // Create a list of all the plants that want to spawn here and how many of each.
            var desiredSpawnAtPos = new List<PlantLayer>();
            // Only process existing plants before current world layer tick, so it won't accidentally remove plants seeded after tick started.
            // It also will correctly spawn new plants based on data from tick start even if new plants was seeded since that.
            var existingPlants = EcoSim.PlantSim.PlantsInArea(area).Where(plant => plant.Alive && plant.BornTime <= WorldLayerManager.Obj.LastTickTime).ToLookup(plant => plant.Species);
            for (var plantLayerIndex = 0; plantLayerIndex < plantLayerValues.Length; plantLayerIndex++)
            {
                var layer = plantLayers[plantLayerIndex];
                var plantSpecies = layer.Species;
                var existingOfSpecies = existingPlants[plantSpecies].ToArray();
                var worldVal = existingOfSpecies.Length;
                var layerValue = Mathf.Clamp01(plantLayerValues[plantLayerIndex]); // clamp because it may go out of [0; 1] range due to Spread interaction
                var targetVal = layerValue * layer.CellArea;
                // actualize value with added/removed plants delta during the world tick
                var delta = plantSpecies.PopulationPuller.PopulationDelta(area);
                // if some plant was removed then reduce targetVal by this delta (because they already counted for worldVal) to avoid spawn "missing" plants for not applied destroyed plants and remove plants next tick when value actualized
                if (delta < 0)
                    targetVal = Math.Max(worldVal, targetVal + delta);
                var targetNumPlants = Mathf.FloorToInt(targetVal, WorldLayer.Epsilon);
                // if we're going to kill existing plant then check if fraction of plant less than PlantKillThreshold and if not then assume this plant is still alive
                if (worldVal > targetNumPlants && targetVal - targetNumPlants >= PlantKillThreshold)
                    ++targetNumPlants;

                if (targetNumPlants < worldVal)
                {
                    if (worldVal > 0)
                    {
                        var killTended = plantSpecies.HabitabilityModifier(temperature, moisture, pollution, saltwater) <= 0;
                        var plantsToRemove = worldVal - targetNumPlants;
                        var plantsRemoved = KillPlants(existingOfSpecies, plantsToRemove, DeathType.Ecosystem, killTended);
                        worldVal -= plantsRemoved;
                        Interlocked.Add(ref layer.RemovedFromWorld, plantsRemoved);
                        // have to re-add plants not killed to the layer
                        if (plantsToRemove != plantsRemoved)
                        {
                            if (targetNumPlants < 0) // recover from negative target plants
                                layerValue = 0f;
                            else
                                layerValue += (float)(plantsToRemove - plantsRemoved) / area.Area;
                        }
                    }
                    else
                        layerValue = 0f;
                }
                else if (targetNumPlants > worldVal && trampledValue < 0.5)
                {
                    var trampleModifiedDelta = (targetVal - worldVal) * ((0.5f - trampledValue) / 0.5f);
                    // If plants want to grow, accumulate a list.
                    var numPlants = Mathf.FloorToInt(trampleModifiedDelta, WorldLayer.Epsilon);
                    for (var i = 0; i < numPlants; i++) desiredSpawnAtPos.Add(layer);
                }
                layer[layerPosition.Position] = layerValue; // sync layer value
                // reduce available capacity by amount of capacity consumed by existing world plants
                if (worldVal > 0)
                    availableCapacity.Consume(plantSpecies, worldVal, capacityOffset);
            }
            return desiredSpawnAtPos;
        }

        private float[] GetLayerValues<T>(Span<T> layers, LayerPosition layerPosition) where T : WorldLayer
        {
            var values = new float[layers.Length];
            this.GetLayerValues(layers, layerPosition, values);
            return values;
        }

        private void GetLayerValues<T>(Span<T> layers, LayerPosition layerPosition, Span<float> outputValues) where T : WorldLayer
        {
            var index = 0;
            foreach (var layer in layers)
                outputValues[index++] = layer.GetValue(layerPosition);
        }

        private Capacity GetAvailableCapacities(WorldArea area, LayersInfo layersInfo)
        {
            var voxelsPerEntry = layersInfo.MinVoxelsPerEntry;
            var capacityLayers = layersInfo.CapacityLayers;
            var baseLayerPosition = area.MinInclusive / voxelsPerEntry;
            var size = area.Width / voxelsPerEntry;
            var availableCapacities = new float[size * size * capacityLayers.Length];
            var offset = 0;
            for (var y = 0; y < size; ++y)
            {
                for (var x = 0; x < size; ++x)
                {
                    var layerPosition = new LayerPosition(baseLayerPosition + new Vector2i(x, y), voxelsPerEntry);
                    this.GetLayerValues<WorldLayer>(capacityLayers, layerPosition, availableCapacities.AsSpan(offset));
                    offset += capacityLayers.Length;
                }
            }

            return new Capacity(layersInfo.CapacityLayerNames, availableCapacities, voxelsPerEntry);
        }

        /// <inheritdoc cref="IWorldLayerPusher.Apply"/>
        public override void Apply(WorldArea area, float[] unused, WorldLayerNeighborInfo[] neighborValues)
        {
            var layersInfo = this.layersInfo.Value;
            var availableCapacity = this.GetAvailableCapacities(area, layersInfo);
            this.SpawnPlantGroups(layersInfo, area, layersInfo.PlantLayerGroups, new List<PlantLayer>(), availableCapacity, 0);
        }

        private Dictionary<PlantLayer, int> SpawnPlantGroups(LayersInfo layersInfo, WorldArea area, ReadOnlySpan<(int, PlantLayer[])> plantGroups, List<PlantLayer> spawnAtPos, Capacity availableCapacities, int baseCapacityOffset)
        {
            var (voxelsPerEntry, plantLayers) = plantGroups[0];
            var min = area.MinInclusive / voxelsPerEntry;
            var size = area.Size / voxelsPerEntry;
            var capacityStep = availableCapacities.GetSliceSize(voxelsPerEntry);

            // iterate for every sub group cell in random order, it allowing to randomly spread parent group plants between sub groups (i.e. randomly spawn trees within small plants cells)
            foreach (var (xOffset, yOffset) in size.XYIter().Shuffle())
            {
                var capacityOffset = baseCapacityOffset + (((yOffset * size.x) + xOffset) * capacityStep); // offset within capacities array corresponding to start of subgroup capacities
                var pos = new Vector2i(min.x + xOffset, min.y + yOffset);                       // plants sub group layer position
                var cellArea = WorldLayer.LayerPosToWorldArea(pos, voxelsPerEntry);                  // area of plants sub group
                spawnAtPos.AddRange(this.SyncPlants(layersInfo, cellArea, plantLayers, availableCapacities, capacityOffset));
                Dictionary<PlantLayer, int> overflow;
                if (plantGroups.Length == 1)
                    overflow = this.SpawnPlantsInArea(cellArea, spawnAtPos, availableCapacities, capacityOffset);
                else
                    overflow = this.SpawnPlantGroups(layersInfo, cellArea, plantGroups.Slice(1), spawnAtPos, availableCapacities, capacityOffset);
                if (overflow != null)
                {
                    spawnAtPos.Clear();
                    // process overflow plants (modify layers and stats)
                    foreach (var (overflowLayer, count) in overflow)
                    {
                        // only remove it if has same VoxelsPerEntry
                        if (overflowLayer.Species.VoxelsPerEntry == voxelsPerEntry)
                        {
                            overflowLayer[pos] -= (float)count / overflowLayer.CellArea; // reduce layer value by not spawned (overflow) plants count
                            Interlocked.Add(ref overflowLayer.NoRoomForPlants, count);
                        }
                        else
                        {
                            // otherwise re-add to schedule, because it is from parent and shared between multiple cells
                            for (var i = 0; i < count; ++i)
                                spawnAtPos.Add(overflowLayer);
                        }
                    }
                }
            }
            return spawnAtPos.Count > 0 ? spawnAtPos.GroupBy(it => it).ToDictionary(it => it.Key, it => it.Count()) : null;
        }

        private Dictionary<PlantLayer, int> SpawnPlantsInArea(WorldArea area, List<PlantLayer> desiredSpawnAtPos, Capacity availableCapacities, int capacityOffset)
        {
            // Now choose at random from all the plants that wanted to grow here.
            if (desiredSpawnAtPos.Count == 0) return null;
            var overflow = new Dictionary<PlantLayer, int>();
            var fertileSpaces = EcoSim.PlantSim.AllFertileSpaces(area).Shuffle().ToList();
            var toSpawn = desiredSpawnAtPos.Shuffle();
            var existingTrees = EcoSim.PlantSim.PlantsInArea(area.Expand(MinTreeDistance)).OfType<Tree>().ToList();
            this.SpawnPlants(toSpawn, fertileSpaces, existingTrees, availableCapacities, capacityOffset, overflow);
            return overflow;
        }

        private int SpawnPlants(IEnumerable<PlantLayer> desiredSpawn, List<Vector3i> spaces, List<Tree> existingTrees, Capacity availableCapacities, int capacityOffset, Dictionary<PlantLayer, int> overflow)
        {
            var overcapacitySpecies = new HashSet<PlantSpecies>();                    // remember species which already failed capacity check for faster checks
            var spawned = 0;
            foreach (var layer in desiredSpawn)
            {
                var plantSpecies = layer.Species;
                // check if this plant has enough capacity to consume
                if (spaces.Count > 0 && !overcapacitySpecies.Contains(plantSpecies) && this.TryFindGoodPlaceAndConsumeCapacity(plantSpecies, spaces, existingTrees, availableCapacities, capacityOffset, out var space))
                {
                    // Spawn the next layer in line.
                    spawned++;

                    var spawnedPlant = EcoSim.PlantSim.SpawnPlant(plantSpecies, space + Vector3i.Up, false);
                    if (spawnedPlant is Tree tree) existingTrees.Add(tree);
                    Interlocked.Increment(ref layer.AddedOrganismsToWorld);
                }
                else
                {
                    overcapacitySpecies.Add(plantSpecies);
                    overflow.AddOrUpdate(layer, 1, (oldVal, newVal) => oldVal + newVal);
                }
            }

            return spawned;
        }

        /// <summary> Checks both capacity and placement for <paramref name="plantSpecies"/>. It will return first good place in <paramref name="space"/> output parameter. No space or capacity will be used if check fail. </summary>
        private bool TryFindGoodPlaceAndConsumeCapacity(PlantSpecies plantSpecies, List<Vector3i> spaces, List<Tree> existingTrees, Capacity availableCapacities, int capacityOffset, out Vector3i space)
        {
            if (!this.TryFindGoodPlace(spaces, plantSpecies, existingTrees, out space)) return false;
            if (!availableCapacities.TryConsume(plantSpecies, 1, capacityOffset))
            {
                spaces.Add(space);
                return false;
            }

            return true;
        }

        /// <summary> Tries to find good place for <paramref name="plantSpecies"/> for <paramref name="spaces"/>. </summary>
        private bool TryFindGoodPlace(List<Vector3i> spaces, PlantSpecies plantSpecies, List<Tree> existingTrees, out Vector3i goodPlace)
        {
            for (var index = spaces.Count - 1; index >= 0; --index)
            {
                var space = spaces[index];
                if (plantSpecies.Water != World.IsUnderwater(space.XZ)) continue;

                var spaceAbove = space + Vector3i.Up;
                var existingPlant = EcoSim.PlantSim.GetPlant(spaceAbove);
                if (existingPlant != null && existingPlant.Alive) continue;
                if (World.GetBlock(spaceAbove).Is<Occupied>()) continue;
                if (!plantSpecies.IsGoodPlacement(spaceAbove)) continue;

                if (plantSpecies is TreeSpecies && existingTrees.Any(t => (t.Position.XZ - space.XZ).MagnitudeSq < MinTreeDistance * MinTreeDistance)) continue;

                goodPlace = space;
                spaces.RemoveAt(index);
                return true;
            }

            goodPlace = default;
            return false;
        }

        private static int KillPlants(Plant[] patch, int toRemove, DeathType deathType, bool killTended = false)
        {
            var plantsKilled = 0;

            List<Plant> unprotected = new List<Plant>();
            foreach (var plant in patch)
            {
                if (!GreenhousingExtensions.VaildGreenhouse(plant.Position.XYZi, out _))
                    unprotected.Add(plant);
            }

            if (unprotected.FirstOrDefault() is Tree) //destroy if tree
                unprotected.Where(x => killTended || !x.Tended).Shuffle().Take(toRemove).ForEach(plant => { EcoSim.PlantSim.DestroyPlant(plant, deathType, false); ++plantsKilled; });                       
            else           
                unprotected.Where(x => killTended || !x.Tended).Shuffle().Take(toRemove).ForEach(plant => { EcoSim.PlantSim.KillPlant(plant, deathType, false); ++plantsKilled; });
                    
            return plantsKilled;
        }

        public override string DescribeGeneral { get; }

        protected override float DescribeSpecific(WorldArea area, float[] layerValues, WorldLayerNeighborInfo[] neighborValues)
        {
            return 0f; // TODO do something intelligent here
        }

        protected override string DescribeAggregated(IEnumerable<float> intermediateDescriptions)
        {
            return string.Empty; // TODO do something intelligent here
        }

        /// <inheritdoc cref="IPostWorldGenWorldLayerPusher.PostWorldGenPush"/>
        public void PostWorldGenPush(WorldArea area, float[] unused, WorldLayerNeighborInfo[] neighborValues) => this.Apply(area, unused, neighborValues);
    }
}
