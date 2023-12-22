using System.ComponentModel;
using Eco.Core.Items;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Plants;
using Eco.Shared.Math;
using Eco.Simulation;
using Eco.Shared.Serialization;
using Eco.Simulation.WorldLayers;
using System.Text;
using Eco.Shared.Localization;
using Eco.Mods.TechTree;
using Eco.Shared.SharedTypes;
using Eco.Gameplay.Players;
using Eco.Gameplay.Interactions.Interactors;

namespace Eco.EM.Building.Greenhousing
{
    [Serialized, LocDisplayName("Greenhousing Kit"), Weight(1000), Category("Tools")]
    [Tag("Tool"), Ecopedia("Items", "Tools", createAsSubPage: true)]
    [LocDescription("Kit specifically for testing greenhouse conditions.")]
    public class GreenhouseKitItem : SoilSamplerItem
    {
        
        public void TestGreenhouse(Player context, InteractionTarget target, InteractionTriggerInfo triggerInfo)
        {
            if (target.IsBlock)
            {
                var targets = target.BlockPosition.Value;
                var plantPosition = target.Block() is PlantBlock ? target.BlockPosition.Value : target.BlockPosition.Value + Vector3i.Up;
                var plant = EcoSim.PlantSim.GetPlant(plantPosition);
                var title         = new StringBuilder();
                var text          = new StringBuilder();

                if (!GreenhousingExtensions.VaildGreenhouse(targets, out string fail))
                {
                    context.ErrorLocStr($"This location is not inside a Greenhouse, {fail}\n");
                }

                text.AppendLine($"This location is inside a Greenhouse.\n");

                if (plant != null)
                {
                    title.Append($"{plant.Species.DisplayName} {target.BlockPosition}");
                    text.Append(plant.GetGreenhouseSystemInfo() + "\n");
                }
                else
                {
                    title.Append(target.Block().GetType().Name + " " + target.BlockPosition.ToString());                  
                }
                
                text.AppendLine(WorldLayerManager.Obj.DescribePos(target.BlockPosition.Value.XZ));
                context.LargeInfoBox(Localizer.DoStr(title.ToString()), Localizer.DoStr(text.ToString()));

                BurnCaloriesNow(context);
            }

        }
    }
}
