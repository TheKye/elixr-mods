// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Simulation.WorldLayers.Pushers
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Eco.EM.Building.Greenhousing;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Types;
    using Eco.Simulation.WorldLayers.Internal;
    using Eco.Simulation.WorldLayers.Layers;
    using Eco.World;
    using Eco.World.Blocks;
    using NetFabric.Hyperlinq;

    public sealed class EMPlantSpawner : WorldLayerPusher<float>, IWorldLayerPusher, IPostWorldGenWorldLayerPusher
    {
        /// <summary> Layers layout info for <see cref="PlantSpawner"/> dependencies. </summary>
        sealed class LayersInfo
        {
            public int MaxVoxelsPerEntry;
            public int MinVoxelsPerEntry;
            public WorldLayer TrampledLayer;
            public (int VoxelsPerEntry, PlantLayer[] Layers)[] PlantLayerGroups;
            public WorldLayer[] CapacityLayers;
            public string[] CapacityLayerNames;
        }

        /// <summary>
        /// <see cref="Capacity"/> class holds information about available capacity for <see cref="LayerNames"/> with <see cref="VoxelsPerEntry"/> granularity.
        /// <see cref="AvailableCapacities"/> has flatten 2D array structure of [[availableCapacitiesPerLayerForCell1], [availableCapacitiesPerLayerForCell2], .., [availableCapacitiesPerLayerForCellN]].
        /// Each such cell is for <see cref="VoxelsPerEntry"/> dimension. In each cell it has LayerNames.Count entries one value per capacity layer with same index as in LayerNames.
        /// We need to have multiple cells in available capacities because of some plants like trees may use multiple capacity cells and should consume capacity from all of them evenly if possible.
        /// Small plants usually consume capacity only from one capacity cell.
        /// It is up to constructor calling code how to order cells, but usually it has Y groups of X size and offset of each cell may be calculated as (Y * xSize + X) * LayerNames.Count.
        /// Capacity may be consumed in two ways:
        /// <p>- Consume as much as possible with <see cref="Consume"/>, it will ignore unconsumed capacity;</p>
        /// <p>- Either fully consume all requested capacities or not consume at all with <see cref="TryConsume"/></p>
        /// </summary>
        class Capacity
        {
            readonly float[] tempCapacities;              // temp capacities used in TryConsume for transaction (to avoid corrupt state if consume may not be fully completed)
            readonly float cellArea;                    // cellArea pre-calculated for conversions between layer cell area and capacity cell area
            public readonly float[] AvailableCapacities; // array of flatten layer capacities (read more details in class doc)
            public readonly string[] LayerNames;          // capacity layer names for name to index matching
            public readonly int VoxelsPerEntry;      // scale of capacity cells

            public Capacity(string[] layerNames, float[] availableCapacities, int voxelsPerEntry)
            {
                this.LayerNames = layerNames;
                this.AvailableCapacities = availableCapacities;
                this.VoxelsPerEntry = voxelsPerEntry;
                this.cellArea = voxelsPerEntry * voxelsPerEntry;
                this.tempCapacities = new float[availableCapacities.Length];
            }

            /// <summary>Returns size of capacities slice for <paramref name="voxelsPerEntry"/> resolution. Calculated as <c>(voxelsPerEntry * voxelsPerEntry / cellArea) * LayerNames.Length</c>.</summary>
            public int GetSliceSize(int voxelsPerEntry)
            {
                var scale = voxelsPerEntry / this.VoxelsPerEntry;
                return scale * scale * this.LayerNames.Length;
            }

            /// <summary>
            /// Returns range of capacity values for <paramref name="species"/> for given offset. Range calculated based on scale between species VoxelsPreEntry and capacity VoxelsPerEntry and offset.
            /// The offset may be calculated using <c>(Y * xSize + X) * LayerNames.Count</c> formula. (X,Y) is relative capacity cell position.
            /// If species voxel per entry is greater than capacity voxel per entry then it will be aligned to include the offset.
            /// Range length calculated with <see cref="GetSliceSize"/> for species VoxelsPerEntry.
            /// </summary>
            /// <example>
            /// I.e. if we have 2 capacity layers, capacity VoxelsPerEntry is 5, species1 with VoxelPerEntry equal to 10, species2 with VoxelPerEntry equal to 5 and we have 2x2 capacity area (2*5x2*5=10x10 voxels) then
            /// <p>- for (0, 0) normalized offset will be 0 for both species1 and species2;</p>
            /// <p>- for (0, 1) normalized offset will be 0 for species1 and (0*2 + 1)*2 = 2 for species2;</p>
            /// <p>- for (1, 0) normalized offset will be 0 for species1 and (1*2 + 0)*2 = 4 for species2;</p>
            /// <p>- for (1, 1) normalized offset will be 0 for species1 and (1*2 + 1)*2 = 6 for species2;</p>
            /// </example>
            System.Range GetSpeciesRange(PlantSpecies species, int offset)
            {
                var sliceSize = this.GetSliceSize(species.VoxelsPerEntry);
                // reduce to capacities available for this species (aligned to sliceSize)
                var normalizedOffset = offset / sliceSize * sliceSize;
                return new System.Range(normalizedOffset, normalizedOffset + sliceSize);
            }

            /// <summary>Tries to consume (reduce) available capacity for <paramref name="count"/> of plant <paramref name="species"/>. Returns <c>true</c> if succeed. If failed then no modification to capacity happens.</summary>
            public bool TryConsume(PlantSpecies species, int count, int offset)
            {
                var speciesRange = this.GetSpeciesRange(species, offset);
                var tempCapacities = this.tempCapacities.AsSpan(speciesRange);
                var availableCapacities = this.AvailableCapacities.AsSpan(speciesRange);
                availableCapacities.CopyTo(tempCapacities); // copy to temp capacities for calculations, we only use calculation results if able to fully consume capacities for species count
                if (!this.ConsumeInternal(species, count, tempCapacities))
                    return false;

                // if all capacities satisfies then commit changes
                tempCapacities.CopyTo(availableCapacities);
                return true;
            }

            /// <summary>Consumes as much as possible from <see cref="AvailableCapacities"/> for <paramref name="count"/> of plant <paramref name="species"/>. Consuming means that available capacity reduced by consumed capacity amount.</summary>
            public void Consume(PlantSpecies species, int count, int offset) => this.ConsumeInternal(species, count, this.AvailableCapacities.AsSpan(this.GetSpeciesRange(species, offset)));

            /// <summary>Consumes from <see cref="AvailableCapacities"/> capacities required for the <paramref name="count"/> of <paramref name="species"/>. Returns <c>true</c> if enough <see cref="AvailableCapacities"/>.  Consuming means that available capacity reduced by consumed capacity amount.</summary>
            bool ConsumeInternal(PlantSpecies species, int count, Span<float> availableCapacities)
            {
                var populationPerCapacityCell = count / this.cellArea;                            // normalized population for capacity cell size, it may be more than 1. It is fine, because this population will spread between all available cells anyway
                var capacityLayersCount = this.LayerNames.Length;
                // optimized path for one cell
                if (availableCapacities.Length == capacityLayersCount) return this.ConsumeCapacityForOneCell(species, populationPerCapacityCell, availableCapacities);
                var enoughCapacity = true;
                var cellsCount = availableCapacities.Length / capacityLayersCount;                // calculate num of cells in span, one cell contains all capacity layers values
                // fist check and remember required capacities
                foreach (var constraint in species.CapacityConstraints)
                {
                    var required = populationPerCapacityCell * constraint.ConsumedCapacityPerPop; // normalized per capacity cell size required population where 1 is whole capacity of cell, may be more than 1 if VoxelsPerSize for species > VoxelsPerSize for capacity
                    if (required < WorldLayer.Epsilon) continue;

                    var capacityIndex = Array.IndexOf(this.LayerNames, constraint.CapacityLayerName); // index of layer within cell's capacity span
                    var availableShares = cellsCount;                                                   // initial number of shares set to total number of cells in span
                    while (true)
                    {
                        var shareAmount = required / availableShares;                                   // amount of capacity to be consumed from one cell, availableShares says how much cells with known non fully consumed capacity
                        availableShares = 0;                                                            // reset available shares to zero and count only non-fully consumed cells bellow
                        for (var index = capacityIndex; index < availableCapacities.Length; index += capacityLayersCount) // go throw all cells and getting capacity value from capacityIndex
                        {
                            var available = availableCapacities[index];
                            if (shareAmount < available)                                                // if required share less than available
                            {
                                available = shareAmount;                                                // then use it
                                ++availableShares;                                                      // and count this cell to available shares
                            }                                                                           // otherwise it will be fully consumed

                            availableCapacities[index] -= available;                                    // decrease available capacity by either shareAmount or by whole available capacity
                            required -= available;                                    // decrease total required capacity
                        }

                        if (required < WorldLayer.Epsilon) break;                                       // if required capacity bellow epsilon then we done and successfully distributed all required capacity for current constraint
                        if (availableShares == 0)                                                       // otherwise if no more available shares then we not able to distribute it
                        {
                            enoughCapacity = false;                                                     // set as enough capacity to false
                            break;                                                                      // and go to next
                        }
                    }
                }

                return true;
            }

            /// <summary> Optimized version of <see cref="Consume"/> for one cell with same resolution as capacity. </summary>
            bool ConsumeCapacityForOneCell(PlantSpecies species, float population, Span<float> cellCapacities)
            {
                var enoughCapacity = true;
                foreach (var constraint in species.CapacityConstraints)                          // just go through layer capacity constraints
                {
                    var index = Array.IndexOf(this.LayerNames, constraint.CapacityLayerName); // find matching capacity layer index
                    var required = population * constraint.ConsumedCapacityPerPop;               // calculate required capacity for the population [0; 1]
                    if (required > cellCapacities[index])                                        // if consumed more than available
                    {
                        enoughCapacity = false;                                           // set as not enough capacity
                        cellCapacities[index] = 0;                                               // and fully consume it
                    }
                    else
                        cellCapacities[index] -= required;                                       // otherwise just reduce by required
                }

                return enoughCapacity;
            }
        }

        private const float PlantKillThreshold = 0.9f;    // this value is fraction of plant which will preserve plant from killing to avoid spawning/killing plants every tick if population value insignificantly changes due to spread or negative growth rate.

        private readonly Lazy<LayersInfo> layersInfo;
        public override string[] DependencyLayerNames => Array.Empty<string>(); // don't need any dependencies

        public EMPlantSpawner() => this.layersInfo = new Lazy<LayersInfo>(this.BuildLayersInfo);

        /// <summary> Builds <see cref="LayersInfo"/> which contains all info about dependency layers. </summary>
        private LayersInfo BuildLayersInfo()
        {
            var plantLayers = WorldLayerManager.Obj.Layers.OfType<PlantLayer>().ToArray();
            var capacityLayers = plantLayers.SelectMany(layer => layer.Species.CapacityConstraints).Select(constraint => constraint.CapacityLayerName).Distinct().Select(WorldLayerManager.Obj.GetLayer).ToArray();
            var info = new LayersInfo
            {
                CapacityLayers = capacityLayers,
                CapacityLayerNames = capacityLayers.Select(it => it.Name).ToArray(),
                PlantLayerGroups = plantLayers.GroupBy(it => it.Settings.VoxelsPerEntry).OrderByDescending(it => it.Key).Select(it => (it.Key, it.ToArray())).ToArray(),
                TrampledLayer = WorldLayerManager.Obj.GetLayer(LayerNames.TrampledSpread)
            };
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
        List<PlantLayer> SyncPlants(LayersInfo layersInfo, WorldArea area, Span<PlantLayer> plantLayers, Capacity availableCapacity, int capacityOffset)
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
            using (ArrayPool<float>.Shared.RentAndPromiseToReturn(plantLayers.Length, out var plantLayerValues))
            {
                this.GetLayerValues(plantLayers, layerPosition, plantLayerValues);

                // Create a list of all the plants that want to spawn here and how many of each.
                var desiredSpawnAtPos = new List<PlantLayer>();
                // Only process existing plants before current world layer tick, so it won't accidentally remove plants seeded after tick started.
                // It also will correctly spawn new plants based on data from tick start even if new plants was seeded since that.
                var existingPlants = EcoSim.PlantSim.EnumerableOfArea(area, null).Where(plant => plant.Alive && plant.BornTime <= WorldLayerManager.Obj.LastTickTime).ToLookup(plant => plant.Species);
                for (var plantLayerIndex = 0; plantLayerIndex < plantLayers.Length; plantLayerIndex++)
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
        }

        /// <summary>For each layer in <paramref name="layers"/> saves value at <paramref name="layerPosition"/> to <paramref name="outputValues"/>.</summary>
        void GetLayerValues<T>(Span<T> layers, LayerPosition layerPosition, Span<float> outputValues) where T : WorldLayer
        {
            var index = 0;
            foreach (var layer in layers)
                outputValues[index++] = layer.GetValue(layerPosition);
        }

        /// <summary>Returns <see cref="Capacity"/> object with available capacities for <paramref name="area"/>. Capacity layers obtained from <paramref name="layersInfo"/>.</summary>
        Capacity GetAvailableCapacities(WorldArea area, LayersInfo layersInfo)
        {
            var voxelsPerEntry = layersInfo.MinVoxelsPerEntry;                   // should use minimal granularity for capacity cells
            var capacityLayers = layersInfo.CapacityLayers;
            var baseLayerPosition = area.MinInclusive / voxelsPerEntry;             // convert world area position to layer position
            var size = area.Width / voxelsPerEntry;                    // and calculate cell area size, assuming it is always square
            var availableCapacities = new float[size * size * capacityLayers.Length];
            var offset = 0;
            for (var y = 0; y < size; ++y)
            {
                for (var x = 0; x < size; ++x)
                {
                    var layerPosition = new LayerPosition(baseLayerPosition + new Vector2i(x, y), voxelsPerEntry);       // create global layer position for local offset
                    this.GetLayerValues<WorldLayer>(capacityLayers, layerPosition, availableCapacities.AsSpan(offset));  // get layer values at the layer position
                    offset += capacityLayers.Length;                                                                     // adjust offset for next capacity layer values span
                }
            }

            return new Capacity(layersInfo.CapacityLayerNames, availableCapacities, voxelsPerEntry);                     // create capacity object
        }

        /// <inheritdoc cref="IWorldLayerPusher.Apply"/>
        public override void Apply(WorldArea area, float[] unused, WorldLayerNeighborInfo[] neighborValues, int length)
        {
            var layersInfo = this.layersInfo.Value;
            var availableCapacity = this.GetAvailableCapacities(area, layersInfo);
            this.SpawnPlantsInCellsOfDifferentSize(layersInfo, area, layersInfo.PlantLayerGroups, new List<PlantLayer>(), availableCapacity, 0);
        }

        /// <summary>
        /// Spawns all plant groups from <paramref name="plantGroups"/> recursively. Plants grouped by voxelsPerEntry descending.
        /// If this is last plant group then it will just spawn plants with <see cref="SpawnPlantsInArea"/>
        /// otherwise for each cell in the area for group granularity it calls <see cref="SpawnPlantsInCellsOfDifferentSize"/> with all plants from current group in <paramref name="spawnAtPos"/> list.
        /// This way it not only spawns nested group plants, but also spawns bigger granularity group plants in one of nested cells.
        /// </summary>
        /// <example>
        /// I.e. we have [(20, [Birch, Fir]), (5, [Corn, Tomato])] plant groups for (0,0)-(20,20) area.
        /// First call with all plant groups will have only one cell for the area because it is same size as the area.
        /// All trees to spawn collected for this cell. Assume there are [Birch, Birch, Fir].
        /// Then <see cref="SpawnPlantsInCellsOfDifferentSize"/> called with tailing plant groups: [(5, [Corn, Tomato])].
        /// Now, because voxelsPerEntry = 5, it will have 4 cells in the area: (0, 0), (0, 1), (1, 0) and (1, 1).
        /// For each cell it will have own list of plants to spawn like [Tomato, Tomato], [Corn, Corn], [Corn, Tomato], [].
        /// These list will be concatenated with [Birch, Birch, Fir] from previous plant group before spawn.
        /// So it may spawn [Birch, Tomato, Tomato] in first cell, then all not spawned trees ([Birch, Fir]) will be concatenated to next plant spawn list etc.
        /// This way trees will be mixed with small plants and distributed between all sub-cells.
        /// </example>
        /// <param name="layersInfo">Contains shared layers information like all constraint layers, min voxel size for normalization, trampled layer etc.</param>
        /// <param name="area">World area for spawning.</param>
        /// <param name="plantGroups">Plant groups to spawn. Each plant group is pair of (voxelsPerEntry, plantLayersInGroupArray) ordered by voxelsPerEntry descending.</param>
        /// <param name="spawnAtPos">Plants to spawn in the area. Contains all plants from previous group.</param>
        /// <param name="availableCapacities"><see cref="Capacity"/> object will non-consumed capacities. Updates every time when new plant added.</param>
        /// <param name="baseCapacityOffset">Offset for cell capacities. Used because of optimized flatten capacities structure where all cells capacities stored in one array.</param>
        Dictionary<PlantLayer, int> SpawnPlantsInCellsOfDifferentSize(LayersInfo layersInfo, WorldArea area, ReadOnlySpan<(int VoxelsPerEntry, PlantLayer[] Group)> plantGroups, List<PlantLayer> spawnAtPos, Capacity availableCapacities, int baseCapacityOffset)
        {
            var (voxelsPerEntry, plantLayers) = plantGroups[0];
            var min = area.MinInclusive / voxelsPerEntry;
            var size = area.Size / voxelsPerEntry;
            var capacityStep = availableCapacities.GetSliceSize(voxelsPerEntry); // calculate capacity cells slice size for given voxelsPerEntry, each slice contains one ore more capacity cells with all capacity layer values per cell

            // iterate for every sub group cell in random order, it allowing to randomly spread parent group plants between sub groups (i.e. randomly spawn trees within small plants cells)
            foreach (var (xOffset, yOffset) in size.XYIter().Shuffle())
            {
                var capacityOffset = baseCapacityOffset + (((yOffset * size.x) + xOffset) * capacityStep); // offset within capacities array corresponding to start of subgroup capacities
                var pos = new Vector2i(min.x + xOffset, min.y + yOffset);                       // plants sub group layer position
                var cellArea = WorldLayer.LayerPosToWorldArea(pos, voxelsPerEntry);                  // area of plants sub group
                spawnAtPos.AddRange(this.SyncPlants(layersInfo, cellArea, plantLayers, availableCapacities, capacityOffset)); // add plants to spawn from SyncPlants which syncs count from layer value with actual spawned plants count
                Dictionary<PlantLayer, int> overflow;                                                      // overflow list will contain all non-spawned plants (i.e. when not enough capacity or suitable spawn places)
                if (plantGroups.Length == 1)
                    overflow = this.SpawnPlantsInArea(cellArea, spawnAtPos, availableCapacities, capacityOffset); // spawn plants in area for last plant group
                else
                    overflow = this.SpawnPlantsInCellsOfDifferentSize(layersInfo, cellArea, plantGroups.Slice(1), spawnAtPos, availableCapacities, capacityOffset); // recursively call spawn for lower granularity groups
                if (overflow != null)
                {
                    spawnAtPos.Clear(); // clear spawn list and re-add only if voxelsPerEntry doesn't match (these plants from previous plant group which may be spawned in another cell)
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


            var trees = EcoSim.PlantSim.EnumerableOfArea(area).AsValueEnumerable().OfType<Tree>().ToList();
            this.SpawnPlants(toSpawn, fertileSpaces, trees, availableCapacities, capacityOffset, overflow);
            return overflow;
        }

        private int SpawnPlants(IEnumerable<PlantLayer> desiredSpawn, List<Vector3i> spaces, List<Tree> existingTrees, Capacity availableCapacities, int capacityOffset, Dictionary<PlantLayer, int> overflow)
        {
            var overcapacitySpecies = new HashSet<PlantSpecies>();                    // remember species which already failed capacity check for faster checks
            var spawned = 0;

            //First try to spawn plants in groups, then spawn filler plants. This way filler plants wont take spot of groups
            var toSpawnWithGroupCheck = desiredSpawn.Select((plantLayer) => (plantLayer, PlantGrouper.ShouldBeSpanwedAsAGroup(plantLayer.Species))).OrderByDescending(x => x.Item2);

            foreach (var pair in toSpawnWithGroupCheck)
            {
                var plantSpecies = pair.plantLayer.Species;
                var doGroupCheck = pair.Item2;
                // check if this plant has enough capacity to consume
                if (spaces.Count > 0 && !overcapacitySpecies.Contains(plantSpecies) && this.TryFindGoodPlaceAndConsumeCapacity(plantSpecies, doGroupCheck, spaces, existingTrees, availableCapacities, capacityOffset, out var plantSpawnPos))
                {
                    // Spawn the next layer in line.
                    spawned++;

                    var spawnedPlant = EcoSim.PlantSim.SpawnPlant(plantSpecies, (WorldPosition3i)plantSpawnPos, false);
                    if (spawnedPlant is Tree tree) existingTrees.Add(tree);
                    Interlocked.Increment(ref pair.plantLayer.AddedOrganismsToWorld);
                }
                else
                {
                    overcapacitySpecies.Add(plantSpecies);
                    overflow.AddOrUpdate(pair.plantLayer, 1, (oldVal, newVal) => oldVal + newVal);
                }
            }

            return spawned;
        }

        /// <summary> Checks both capacity and placement for <paramref name="plantSpecies"/>. It will return first good place in <paramref name="plantSpawnPos"/> output parameter. No space or capacity will be used if check fail. </summary>
        bool TryFindGoodPlaceAndConsumeCapacity(PlantSpecies plantSpecies, bool doGroupCheck, List<Vector3i> spaces, List<Tree> existingTrees, Capacity availableCapacities, int capacityOffset, out WrappedWorldPosition3i plantSpawnPos)
        {
            if (!this.TryFindGoodPlace(spaces, doGroupCheck, plantSpecies, existingTrees, out plantSpawnPos)) return false;
            if (!availableCapacities.TryConsume(plantSpecies, 1, capacityOffset))
            {
                spaces.Add(((Vector3i)plantSpawnPos).AddY(-1)); // return space back to available spaces if failed to consume
                return false;
            }

            return true;
        }

        /// <summary>Tries to find good place for <paramref name="plantSpecies"/> for one of <paramref name="spaces"/>. If succeed returns <c>true</c> and found place as <paramref name="goodPlace"/>.</summary>
        bool TryFindGoodPlace(List<Vector3i> spaces, bool doGroupCheck, PlantSpecies plantSpecies, List<Tree> existingTrees, out WrappedWorldPosition3i goodPlace)
        {
            for (var index = spaces.Count - 1; index >= 0; --index) // starting from end because we can remove elements
            {
                var space = spaces[index];
                if (plantSpecies.Water != World.IsUnderwater(space.XZ)) continue;              // only use water spaced for water plants
                if (!WrappedWorldPosition3i.TryCreate(space + Vector3i.Up, out var spaceAbove) // if this pos is at top of the world then remove and skip
                    || EcoSim.PlantSim.GetPlant(spaceAbove) is { Alive: true }                 // if space above occupied by another alive plant then remove and skip
                    || World.GetBlock(spaceAbove).Is<Occupied>())                              // if space above occupied by a block or world object then remove and skip
                {
                    // skip already occupied spaces either by block or alive plant, they also may be removed from spaces list because they not suitable for any plant
                    spaces.RemoveAt(index);
                    continue;
                }

                if (!plantSpecies.IsGoodPlacement(spaceAbove)) continue;

                // don't spawn trees too near from each other, there should be at least MinTreeDistance
                if (plantSpecies is TreeSpecies && existingTrees.Any(t => (t.Position.XZ() - space.XZ).MagnitudeSq < EcoSim.Obj.EcoDef.MinTreeSpawnDistanceSq)) continue;

                if (doGroupCheck && !PlantGrouper.TryAddPlantToTheGroup(plantSpecies, space.XZ))
                    continue;
                if (WorldLayerManager.Obj.Initializing == WorldLayerManager.LayerInitOperation.PostWorldgen && !PlantGrouper.BiomeCheck(plantSpecies, space.XZ)) //Biome check only at world gen phase
                    continue;
                goodPlace = spaceAbove; // if all conditions passed then we have a good place

                spaces.RemoveAt(index); // remove it from list of available spaces
                return true;            // and return true
            }

            goodPlace = default;
            return false;               // all spaces was not suitable for spawn
        }

        private static int KillPlants(Plant[] patch, int toRemove, DeathType deathType, bool killTended = false)
        {
            var plantsKilled = 0;
            List<Plant> unprotected = new List<Plant>();
            foreach (var plant in patch)
            {
                if (!GreenhousingExtensions.VaildGreenhouse(plant.Position.XYZi(), out _))
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
        public void PostWorldGenPush(WorldArea area, float[] unused, WorldLayerNeighborInfo[] neighborValues, int length) => this.Apply(area, unused, neighborValues, length);

    }
}
