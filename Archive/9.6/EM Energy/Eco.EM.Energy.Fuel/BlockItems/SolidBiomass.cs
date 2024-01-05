using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;

namespace Eco.EM.Energy.Fuel
{
    [Serialized]
    [MaxStackSize(100)]
    [Weight(10000)]
    [Tag("Fuel")][Fuel(30000)]
    [Tag("Biomass", 1)]
    [Tag("Burnable Fuel", 1)]
    [Currency][Tag("Currency")]
    [Ecopedia("Items", "Products", createAsSubPage: true)]
    [LocDisplayName("Solid Biomass")]
    public partial class SolidBiomassItem : BlockItem<SolidBiomassBlock>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Solid Lump of Biomass, Lasts Longer then regular biomass.");

        private static Type[] blockTypes = new Type[] {
            typeof(SolidBiomassStacked1Block),
            typeof(SolidBiomassStacked2Block),
            typeof(SolidBiomassStacked3Block),
            typeof(SolidBiomassStacked4Block)
        };

        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized]
    [Solid, Wall]
    [RequiresSkill(typeof(FarmingSkill), 3)]
    public partial class SolidBiomassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(SolidBiomassItem);
    }

    [Serialized, Solid] public class       SolidBiomassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class       SolidBiomassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class       SolidBiomassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class SolidBiomassStacked4Block : PickupableBlock { }

    [RequiresSkill(typeof(FarmingSkill), 3)]
    public partial class SolidBiomassRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SolidBiomassRecipe).Name,
            Assembly = typeof(SolidBiomassRecipe).AssemblyQualifiedName,
            HiddenName = "Solid Biomass",
            LocalizableName = Localizer.DoStr("Solid Biomass"),
            IngredientList = new()
            {
                new EMIngredient("BiomassItem", false, 4, true),
            },
            ProductList = new()
            {
                new EMCraftable("SolidBiomassItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "FarmersTableItem",
            RequiredSkillType = typeof(FarmingSkill),
            RequiredSkillLevel = 3,
        };

        static SolidBiomassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SolidBiomassRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
