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
    public partial class GreenGlassRecipe : RecipeFamily
    {
        public GreenGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Green Glass",
                    Localizer.DoStr("Green Glass"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(GreenDyeItem), 2, typeof(GlassworkingSkill)),
                        new IngredientElement(typeof(GlassItem), 6, typeof(GlassworkingSkill))
                    },
                    new CraftingElement<GlassGreenItem>(6)
                    )
            };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreenGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Green Glass"), typeof(GreenGlassRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(GlassworkingSkill), 0)]
    public partial class AltGreenGlassRecipe : Recipe
    {
        public AltGreenGlassRecipe()
        {
            var product = new Recipe(
            "Green Glass - Sand",
            Localizer.DoStr("Green Glass - Sand"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(SandItem), 6),
                new IngredientElement(typeof(GreenDyeItem), 1)
            },
            new CraftingElement[]
            {
                new CraftingElement<GlassGreenItem>(3),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreenGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [MaxStackSize(20)]
    [Tier(2)]
    [Currency]
    [Weight(10000)]
    [LocDisplayName("Green Glass")]
    public partial class GlassGreenItem : BlockItem<GreenGlassBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Green Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(GreenGlassStacked1Block),
            typeof(GreenGlassStacked2Block),
            typeof(GreenGlassStacked3Block),
            typeof(GreenGlassStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class GreenGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassGreenItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassGreenItem))]
    public partial class GreenGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassGreenItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassGreenItem))]
    public partial class GreenGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassGreenItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassGreenItem))]
    public partial class GreenGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassGreenItem); } }
    }

    [Serialized, Solid] public class GreenGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreenGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreenGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreenGlassStacked4Block : PickupableBlock { }
}