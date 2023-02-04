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
    public partial class RedGlassRecipe : RecipeFamily
    {
        public RedGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Red Glass",
                    Localizer.DoStr("Red Glass"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(RedDyeItem), 2, typeof(GlassworkingSkill)),
                        new IngredientElement(typeof(GlassItem), 6, typeof(GlassworkingSkill))
                    },
                    new CraftingElement<GlassRedItem>(6)
                    )
            };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RedGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Red Glass"), typeof(RedGlassRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(GlassworkingSkill), 0)]
    public partial class AltRedGlassRecipe : Recipe
    {
        public AltRedGlassRecipe()
        {
            var product = new Recipe(
            "Red Glass - Sand",
            Localizer.DoStr("Red Glass - Sand"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(SandItem), 6),
                new IngredientElement(typeof(RedDyeItem), 1)
            },
            new CraftingElement[]
            {
                new CraftingElement<GlassRedItem>(3),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(RedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [MaxStackSize(20)]
    [Tier(2)]
    [Currency]
    [Weight(10000)]
    [LocDisplayName("Red Glass")]
    public partial class GlassRedItem : BlockItem<RedGlassBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Red Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(RedGlassStacked1Block),
            typeof(RedGlassStacked2Block),
            typeof(RedGlassStacked3Block),
            typeof(RedGlassStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class RedGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassRedItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassRedItem))]
    public partial class RedGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassRedItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassRedItem))]
    public partial class RedGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassRedItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassRedItem))]
    public partial class RedGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassRedItem); } }
    }

    [Serialized, Solid] public class RedGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class RedGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class RedGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class RedGlassStacked4Block : PickupableBlock { }
}