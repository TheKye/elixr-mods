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
    public partial class BlueGlassRecipe : RecipeFamily
    {
        public BlueGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Blue Glass",
                    Localizer.DoStr("Blue Glass"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(BlueDyeItem), 2, typeof(GlassworkingSkill)),
                        new IngredientElement(typeof(GlassItem), 6, typeof(GlassworkingSkill))
                    },
                    new CraftingElement<GlassBlueItem>(6)
                    )
            };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlueGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Blue Glass"), typeof(BlueGlassRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(GlassworkingSkill), 0)]
    public partial class AltBlueGlassRecipe : Recipe
    {
        public AltBlueGlassRecipe()
        {
            var product = new Recipe(
            "Blue Glass - Sand",
            Localizer.DoStr("Blue Glass - Sand"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(SandItem), 6),
                new IngredientElement(typeof(BlueDyeItem), 1)
            },
            new CraftingElement[]
            {
                new CraftingElement<GlassBlueItem>(3),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(BlueGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Currency]
    [Tier(2)]
    [LocDisplayName("Blue Glass")]
    public partial class GlassBlueItem : BlockItem<BlueGlassBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Blue Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(BlueGlassStacked1Block),
            typeof(BlueGlassStacked2Block),
            typeof(BlueGlassStacked3Block),
            typeof(BlueGlassStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class BlueGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassBlueItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassBlueItem))]
    public partial class BlueGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassBlueItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassBlueItem))]
    public partial class BlueGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassBlueItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassBlueItem))]
    public partial class BlueGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassBlueItem); } }
    }

    [Serialized, Solid] public class BlueGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BlueGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BlueGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BlueGlassStacked4Block : PickupableBlock { }

}