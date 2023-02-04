using Eco.Shared.Math;
using Eco.Simulation;
using Eco.Simulation.Agents;
using Eco.Simulation.Types;
using Eco.Simulation.WorldLayers;
using Eco.Simulation.WorldLayers.Pushers;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;

namespace Eco.EM.Building.Greenhousing
{
    public class EMPlantGrower : PlantGrower
    {
        private readonly PlantSpecies species;
        public EMPlantGrower(PlantSpecies species) : base(species) { this.species = species; }

        public override void Apply(WorldArea area, float[] layerValues, WorldLayerNeighborInfo[] neighborValues, int length)
        {
            // Prevents NAN from getting into Yield
            if (layerValues[0] == 0f) return;

            var juvenilePlants = new List<Plant>();
            EcoSim.PlantSim.EnumerableOfArea(area, this.species).ForEach(juvenilePlants, (plant, context) =>
            {
                if (plant.GrowthPercent < 1f && !plant.GrowthBlocked && plant.Alive)
                    context.Add(plant);
            });

            // Grow all the almost-adult plants to adulthood, then distribute the remaining total growth evenly amongst the rest
            juvenilePlants.Sort((plant1, plant2) => -plant1.GrowthPercent.CompareTo(plant2.GrowthPercent));
            var remainingTotalGrowth = layerValues[0] * area.Area * GrowthRateModifier;
            for (var juvenileIndex = 0; juvenileIndex < juvenilePlants.Count; juvenileIndex++)
            {
                var juvenilePlant = juvenilePlants[juvenileIndex];
                var availableGrowth = 1 - juvenilePlant.GrowthPercent;
                var actualGrowth = Math.Min(availableGrowth, remainingTotalGrowth / (juvenilePlants.Count - juvenileIndex));
                remainingTotalGrowth -= actualGrowth;
                var prevGrowth = juvenilePlant.GrowthPercent;
                juvenilePlant.GrowthPercent += actualGrowth;

                juvenilePlant.YieldPercent += GreenhousingExtensions.VaildGreenhouse(juvenilePlant.Position.XYZi(), out _) ? actualGrowth : layerValues[1] * actualGrowth;

                // when plants become big enough to hinder movement update cached data
                if (juvenilePlant.GrowthPercent > 0.5f && prevGrowth <= 0.5f)
                    PlantBecomeMature.Invoke(juvenilePlant.Position.XYZi());
            }
        }
    }
}
