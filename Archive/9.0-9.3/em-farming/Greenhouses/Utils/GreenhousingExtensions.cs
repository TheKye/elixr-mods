﻿using Eco.EM.Framework.Utils;
using Eco.Gameplay.Rooms;
using Eco.Mods.TechTree;
using Eco.Shared;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Utils;
using Eco.Simulation.Agents;
using Eco.Simulation.Types;
using Eco.Simulation.WorldLayers;
using Eco.Simulation.WorldLayers.Layers;
using System;
using System.Collections.Generic;
using Range = Eco.Shared.Math.Range;

namespace Eco.EM.Greenhousing
{
    public static class GreenhousingExtensions
    {
        private static List<Type> ValidGreenhouseBlocks = new List<Type>() { typeof(GlassItem), typeof(FramedGlassItem) };

        public static void AddToValidGreenhouseBlocks(Type[] types) => types.ForEach(x => { if (!ValidGreenhouseBlocks.Contains(x)) { ValidGreenhouseBlocks.Add(x); } });

        public static bool VaildGreenhouse(Vector3i pos, out string failReason)
        {
            failReason = "";
            var room = RoomData.Obj.GetNearestRoom(pos + Vector3i.Up);

            if (room == Room.Global || !room.RoomStats.Contained) { failReason = "this location is not inside";                   return false; }
            if (!Heated(room, pos))                               { failReason = "this location is not supported by a Heat Lamp"; return false; }
            if (!Irrigated(room,pos))                             { failReason = "this location is not supported by iirigation" ; return false; }
            if (room.RoomStats.AverageTier() < 1.7)               { failReason = "the average tier of materials must be at least 1.7"; return false; }

            var glassTotal = room.RoomStats.BlockTypeCount(ValidGreenhouseBlocks.ToArray());
            if (glassTotal / (room.RoomStats.WallCount - room.RoomStats.Range.XZIterInc().Count()) < 0.8)
                                                                  { failReason = "the walls and roof of the grenhouse must be at least 80% glass"; return false; }

            return true;
        }

        private static bool Heated(Room room, Vector3i pos)
        {
            if (room == null) return false;

            foreach (var obj in room.RoomStats.ContainedWorldObjects)
                if (obj.HasComponent<HeatLampComponent>() && obj.GetComponent<HeatLampComponent>().IsValid(pos) && obj.Enabled)
                    return true; // Heat Lamp must be above but in range
            
            return false;
        }

        private static bool Irrigated(Room room, Vector3i pos)
        {
            if (room == null) return false;

            foreach (var obj in room.RoomStats.ContainedWorldObjects)
                if (obj.HasComponent<IrrigationComponent>() && obj.GetComponent<IrrigationComponent>().IsValid(pos) & obj.Enabled)
                    return true; // Heat Lamp must be above but in range

            return false;
        }

        public static float GreenhouseHabitability(this PlantSpecies species, float pollution, float saltwater)
        {
            var pollutionModifier = PlantSpecies.RangesToModifier(new Range(0f, species.MaxPollutionDensity), new Range(0, species.PollutionDensityTolerance), pollution);
            var saltwaterModifier = PlantSpecies.RangesToModifier(species.WaterExtremes, species.IdealWaterRange, saltwater);

            return pollutionModifier * saltwaterModifier;
        }

        public static float CheckGreenhouseHabitability(this PlantSpecies species, LayerPosition layerPosition, out float pollution, out float saltwater)
        {
            pollution = WorldLayerManager.Obj.GetLayer(LayerNames.GroundPollutionSpread).GetValue(layerPosition);
            saltwater = WorldLayerManager.Obj.GetLayer(LayerNames.SaltWater).GetValue(layerPosition);
            return species.GreenhouseHabitability(pollution, saltwater);
        }

        public static LocString DescribeGreenhouseHabitability(this PlantSpecies species, LayerPosition layerPosition)
        {
            var habitabilityModifier = species.CheckGreenhouseHabitability(layerPosition, out var pollution, out var saltwater);
            var description = new LocStringBuilder();
            description.AppendLineLoc($"This location is a {Text.ColoredPercent(habitabilityModifier)} match for this {species.DisplayName}:");
            description.AppendLine();

            description.AppendLocStr("Pollution: ");
            DescribeMatch(new Range(0, species.MaxPollutionDensity),
                new Range(0, species.PollutionDensityTolerance),
                pollution,
                description,
                WorldLayerManager.Obj.GetLayer(LayerNames.GroundPollutionSpread));

            description.AppendLocStr("Salt Water: ");
            DescribeMatch(species.WaterExtremes,
                species.IdealWaterRange,
                saltwater,
                description,
                WorldLayerManager.Obj.GetLayer(LayerNames.SaltWater));

            if (habitabilityModifier < .4f) description.AppendLoc($"The {species.DisplayName} cannot survive in this {Text.Negative("inhospitable environment")}.");
            else if (habitabilityModifier < .8f) description.AppendLoc($"The {species.DisplayName} could have problems with growth in this {Text.Warning("suboptimal location")}.");

            return description.ToLocString();
        }

        private static void DescribeMatch(Range extremeRange, Range idealRange, float value, LocStringBuilder description, WorldLayer layer)
        {
            var match = PlantSpecies.RangesToModifier(extremeRange, idealRange, value);
            description.AppendLoc($"{Text.Pos(240, Text.ColoredPercent(match))} match.");
            if (value > extremeRange.Max) description.AppendLineLoc($"({layer.ValStringTooltip(value - extremeRange.Max, true)} above maximum)");
            else if (value < extremeRange.Min) description.AppendLineLoc($"({layer.ValStringTooltip(extremeRange.Min - value, true)} below minimum)");
            if (value > idealRange.Max) description.AppendLineLoc($"({layer.ValStringTooltip(value - idealRange.Max, true)} above optimum)");
            else if (value < idealRange.Min) description.AppendLineLoc($"({layer.ValStringTooltip(idealRange.Min - value, true)} below optimum)");
            else description.AppendLine();
        }

        public static LocString GetGreenhouseSystemInfo(this Plant plant)
        {
            var s = new LocStringBuilder();

            s.Append(TextLoc.HeaderLocStr("Plant"));
            s.Append("\n");

            if (plant.Dead)
            {
                s.Append(TextLoc.ErrorLoc($"This plant is dead. {plant.DeadType.GetLocDescription()}"));
            }
            else
            {
                var layerPos = LayerPosition.FromWorldPosition(plant.Position.XZi, plant.Species.VoxelsPerEntry);
                s.AppendLine(plant.Species.DescribeGreenhouseHabitability(layerPos));
                s.AppendLine(plant.Species.DescribeSpace(layerPos));
                s.AppendLoc($"Maturity: {Text.Pos(240, Text.ColoredPercent(plant.GrowthPercent))}");
                var timetillmatures = TimeUtil.DaysToHours((1 - plant.GrowthPercent) * plant.Species.MaturityAgeDays);
                if (timetillmatures > 0)
                {
                    s.AppendLineLoc($" ({Text.Info(timetillmatures.ToString("0.0"))} hours to max{")"}");
                }
                else
                {
                    s.AppendLine();
                }
                if (plant.Species.ResourceRange.Max > 0)
                    s.AppendLineLoc($"Current Yield: {Text.Pos(240, Text.ColoredNum(plant.TryCalculateResourceYield(plant.Species.ResourceRange), plant.Species.ResourceRange.Max * .4f, plant.Species.ResourceRange.Max * .8f, "0"))}\n");
            }
            return s.ToLocString();
        }

        private static int TryCalculateResourceYield(this Plant plant, Range range, float bonusMultiplier = 1f)
        {
            var growthMultiplier = plant.GrowthPercent * plant.GrowthPercent;
            return (int)((Mathf.RoundUp(range.Diff * plant.YieldPercent) + range.Min) * growthMultiplier * bonusMultiplier);
        } 
    }
}
