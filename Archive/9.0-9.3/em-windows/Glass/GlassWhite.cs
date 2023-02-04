using System;
using System.Collections.Generic;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using Eco.World;
using Eco.EM.Artistry;
using Eco.Mods.TechTree;

namespace Eco.EM.Windows
{
    [RequiresSkill(typeof(GlassworkingSkill), 0)]
    public partial class WhiteGlassRecipe : RecipeFamily
    {
        public WhiteGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "White Glass",
                    Localizer.DoStr("White Glass"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(WhiteDyeItem), 2, typeof(GlassworkingSkill)),
                        new IngredientElement(typeof(GlassItem), 6, typeof(GlassworkingSkill))
                    },
                    new CraftingElement<GlassWhiteItem>(6)
                    )
            };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WhiteGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("White Glass"), typeof(WhiteGlassRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(GlassworkingSkill), 0)]
    public partial class AltWhiteGlassRecipe : Recipe
    {
        public AltWhiteGlassRecipe()
        {
            var product = new Recipe(
            "White Glass - Sand",
            Localizer.DoStr("White Glass - Sand"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(SandItem), 6),
                new IngredientElement(typeof(WhiteDyeItem), 1)
            },
            new CraftingElement[]
            {
                new CraftingElement<GlassWhiteItem>(3),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(WhiteGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Currency]
    [Tier(2)]
    [LocDisplayName("White Glass")]
    public partial class GlassWhiteItem : BlockItem<WhiteGlassBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A White Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(WhiteGlassStacked1Block),
            typeof(WhiteGlassStacked2Block),
            typeof(WhiteGlassStacked3Block),
            typeof(WhiteGlassStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class WhiteGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassWhiteItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassWhiteItem))]
    public partial class WhiteGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassWhiteItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassWhiteItem))]
    public partial class WhiteGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassWhiteItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassWhiteItem))]
    public partial class WhiteGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassWhiteItem); } }
    }

    [Serialized, Solid] public class WhiteGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class WhiteGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class WhiteGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class WhiteGlassStacked4Block : PickupableBlock { }
}