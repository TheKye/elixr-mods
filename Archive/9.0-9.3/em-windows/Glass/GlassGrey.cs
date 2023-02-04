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
    public partial class GreyGlassRecipe : RecipeFamily
    {
        public GreyGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Grey Glass",
                    Localizer.DoStr("Grey Glass"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(GreyDyeItem), 2, typeof(GlassworkingSkill)),
                        new IngredientElement(typeof(GlassItem), 6, typeof(GlassworkingSkill))
                    },
                    new CraftingElement<GlassGreyItem>(6)
                    )
            };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreyGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Grey Glass"), typeof(GreyGlassRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(GlassworkingSkill), 0)]
    public partial class AltGreyGlassRecipe : Recipe
    {
        public AltGreyGlassRecipe()
        {
            var product = new Recipe(
            "Grey Glass - Sand",
            Localizer.DoStr("Grey Glass - Sand"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(SandItem), 6),
                new IngredientElement(typeof(GreyDyeItem), 1)
            },
            new CraftingElement[]
            {
                new CraftingElement<GlassGreyItem>(3),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreyGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class GreyGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassGreyItem); } }
    }

    [Serialized]
    [MaxStackSize(20)]
    [Tier(2)]
    [Currency]
    [Weight(10000)]
    [LocDisplayName("Grey Glass")]
    public partial class GlassGreyItem : BlockItem<GreyGlassBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Tinted Glass used for building windows."); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(GreyGlassStacked1Block),
            typeof(GreyGlassStacked2Block),
            typeof(GreyGlassStacked3Block),
            typeof(GreyGlassStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassGreyItem))]
    public partial class GreyGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassGreyItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassGreyItem))]
    public partial class GreyGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassGreyItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassGreyItem))]
    public partial class GreyGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassGreyItem); } }
    }

    [Serialized, Solid] public class GreyGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreyGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreyGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreyGlassStacked4Block : PickupableBlock { }
}