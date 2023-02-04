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
    public partial class PurpleGlassRecipe : RecipeFamily
    {
        public PurpleGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Purple Glass",
                    Localizer.DoStr("Purple Glass"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(PurpleDyeItem), 2, typeof(GlassworkingSkill)),
                        new IngredientElement(typeof(GlassItem), 6, typeof(GlassworkingSkill))
                    },
                    new CraftingElement<GlassPurpleItem>(6)
                    )
            };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PurpleGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Purple Glass"), typeof(PurpleGlassRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(GlassworkingSkill), 0)]
    public partial class AltPurpleGlassRecipe : Recipe
    {
        public AltPurpleGlassRecipe()
        {
            var product = new Recipe(
            "Purple Glass - Sand",
            Localizer.DoStr("Purple Glass - Sand"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(SandItem), 6),
                new IngredientElement(typeof(PurpleDyeItem), 1)
            },
            new CraftingElement[]
            {
                new CraftingElement<GlassPurpleItem>(3),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(PurpleGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [MaxStackSize(20)]
    [Tier(2)]
    [Currency]
    [Weight(10000)]
    [LocDisplayName("Purple Glass")]
    public partial class GlassPurpleItem : BlockItem<PurpleGlassBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Purple Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(PurpleGlassStacked1Block),
            typeof(PurpleGlassStacked2Block),
            typeof(PurpleGlassStacked3Block),
            typeof(PurpleGlassStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class PurpleGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassPurpleItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassPurpleItem))]
    public partial class PurpleGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassPurpleItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassPurpleItem))]
    public partial class PurpleGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassPurpleItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassPurpleItem))]
    public partial class PurpleGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassPurpleItem); } }
    }

    [Serialized, Solid] public class PurpleGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class PurpleGlassStacked4Block : PickupableBlock { }
}