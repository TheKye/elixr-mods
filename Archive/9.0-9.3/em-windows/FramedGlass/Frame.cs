using Eco.Gameplay.Components;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using Eco.Mods.TechTree;

namespace Eco.EM.Windows
{
    #region Frame 1x1
    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Frame"), Currency]
    public partial class FrameItem : Item
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Frames"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Small Frame For Stained Glass."); } }
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class FrameRecipe : RecipeFamily
    {
        public FrameRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Frame",
                    Localizer.DoStr("Frame"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Wood", 5)
                    },
                    new CraftingElement<FrameItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FrameRecipe), 2, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Frame"), typeof(FrameRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Frame Long 1x2
    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Long Frame"), Currency]
    public partial class LongFrameItem : Item
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Long Frames"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Wide Frame For Stained Glass"); } }
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class LongFrameRecipe : Recipe
    {
        public LongFrameRecipe()
        {
            var product = new Recipe(
            "Frame - Long",
            Localizer.DoStr("Frame - Long"),
            new IngredientElement[]
            {
                new IngredientElement("Wood", 8)
            },
            new CraftingElement[]
            {
                new CraftingElement<LongFrameItem>(),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(CarpentryTableObject), typeof(FrameRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Frame Large 2x2
    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Large Frame"), Currency]
    public partial class LargeFrameItem : Item
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Large Frames"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Large Frame For Stained Glass."); } }
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class LargeFrameRecipe : Recipe
    {
        public LargeFrameRecipe()
        {
            var product = new Recipe(
            "Frame - Large",
            Localizer.DoStr("Frame - Large"),
            new IngredientElement[]
            {
                new IngredientElement("Wood", 12)
            },
            new CraftingElement[]
            {
                new CraftingElement<LargeFrameItem>(1),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(CarpentryTableObject), typeof(FrameRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Frame Tall 2x1
    [Serialized, Weight(10), MaxStackSize(500), LocDisplayName("Tall Frame"), Currency]
    public partial class TallFrameItem : Item
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Tall Frames"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Tall Frame For Stained Glass."); } }
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class TallFrameRecipe : Recipe
    {
        public TallFrameRecipe()
        {
            var product = new Recipe(
            "Frame - Tall",
            Localizer.DoStr("Frame - Tall"),
            new IngredientElement[]
            {
                new IngredientElement("Wood", 8)
            },
            new CraftingElement[]
            {
                new CraftingElement<TallFrameItem>(),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(CarpentryTableObject), typeof(FrameRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
}
