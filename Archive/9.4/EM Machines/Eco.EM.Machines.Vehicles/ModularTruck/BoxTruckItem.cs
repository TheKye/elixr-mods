using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Core.Items;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.Pipes;
using Eco.Mods.TechTree;

namespace Eco.EM.Machines.Vehicles.ModularTruck
{
    [RequiresSkill(typeof(MechanicsSkill), 1)]
    public partial class BoxTruckRecipe : RecipeFamily
    {
        public BoxTruckRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "BoxTruck",  //noloc
                Localizer.DoStr("Modular Truck - Box Truck Attachment"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronPlateItem), 12, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                    new IngredientElement(typeof(ScrewsItem), 12, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                    new IngredientElement(typeof(IronPipeItem), 8, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BoxTruckItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 10;
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BoxTruckRecipe), 6, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modular Truck - Box Truck Attachment"), typeof(BoxTruckRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Modular Truck - Box Truck Attachment")]
    [Weight(10000)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BoxTruckItem : VehicleToolItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("An attachment for the Modular Truck For Storing Lots of items."); } }
    }
}
