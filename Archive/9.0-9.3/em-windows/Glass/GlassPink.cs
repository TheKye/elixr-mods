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
    public partial class PinkGlassRecipe : RecipeFamily
    {
        public PinkGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Pink Glass",
                    Localizer.DoStr("Pink Glass"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(PinkDyeItem), 2, typeof(GlassworkingSkill)),
                        new IngredientElement(typeof(GlassItem), 6, typeof(GlassworkingSkill))
                    },
                    new CraftingElement<GlassPinkItem>(6)
                    )
            };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PinkGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Pink Glass"), typeof(PinkGlassRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(GlassworkingSkill), 0)]
    public partial class AltPinkGlassRecipe : Recipe
    {
        public AltPinkGlassRecipe()
        {
            var product = new Recipe(
            "Pink Glass - Sand",
            Localizer.DoStr("Pink Glass - Sand"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(SandItem), 6),
                new IngredientElement(typeof(PinkDyeItem), 1)
            },
            new CraftingElement[]
            {
                new CraftingElement<GlassPinkItem>(3),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(PinkGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Currency]
    [Tier(2)]
    [LocDisplayName("Pink Glass")]
    public partial class GlassPinkItem : BlockItem<PinkGlassBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Pink Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(PinkGlassStacked1Block),
            typeof(PinkGlassStacked2Block),
            typeof(PinkGlassStacked3Block),
            typeof(PinkGlassStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class PinkGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassPinkItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassPinkItem))]
    public partial class PinkGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassPinkItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassPinkItem))]
    public partial class PinkGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassPinkItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassPinkItem))]
    public partial class PinkGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassPinkItem); } }
    }

    [Serialized, Solid] public class PinkGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class PinkGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class PinkGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class PinkGlassStacked4Block : PickupableBlock { }
}