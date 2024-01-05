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

namespace Eco.EM.Building.Greenhousing
{
    [Serialized, LocDisplayName("Greenhousing Kit"), Weight(1000), Category("Tools")]
    [Tag("Tool", 1), Ecopedia("Items", "Tools", createAsSubPage: true)]
    public class GreenhouseKitItem : SoilSamplerItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Kit specifically for testing greenhouse conditions.");
        public override LocString LeftActionDescription => Localizer.DoStr("Test Loacation");

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.HasBlock)
            {
                var target = context.BlockPosition.Value + context.Normal;
                var plantPosition = context.Block is PlantBlock ? context.BlockPosition.Value : context.BlockPosition.Value + Vector3i.Up;
                var plant = EcoSim.PlantSim.GetPlant(plantPosition);
                var title         = new StringBuilder();
                var text          = new StringBuilder();

                if (!GreenhousingExtensions.VaildGreenhouse(target, out string fail))
                {
                    context.Player.ErrorLocStr($"This location is not inside a Greenhouse, {fail}\n");
                    return base.OnActLeft(context); ;
                }

                text.AppendLine($"This location is inside a Greenhouse.\n");

                if (plant != null)
                {
                    title.Append($"{plant.Species.DisplayName} {context.BlockPosition}");
                    text.Append(plant.GetGreenhouseSystemInfo() + "\n");
                }
                else
                {
                    title.Append(context.Block.GetType().Name + " " + context.BlockPosition.ToString());                  
                }
                
                text.AppendLine(WorldLayerManager.Obj.DescribePos(target.Value.XZ));
                context.Player.LargeInfoBox(title.ToString(), text.ToString());

                BurnCaloriesNow(context.Player);
            }

            return InteractResult.NoOp;
        }
    }
}
