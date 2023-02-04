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
    public partial class OrangeGlassRecipe : RecipeFamily
    {
        public OrangeGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Orange Glass",
                    Localizer.DoStr("Orange Glass"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(OrangeDyeItem), 2, typeof(GlassworkingSkill)),
                        new IngredientElement(typeof(GlassItem), 6, typeof(GlassworkingSkill))
                    },
                    new CraftingElement<GlassOrangeItem>(6)
                    )
            };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(OrangeGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Orange Glass"), typeof(OrangeGlassRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(GlassworkingSkill), 0)]
    public partial class AltOrangeGlassRecipe : Recipe
    {
        public AltOrangeGlassRecipe()
        {
            var product = new Recipe(
            "Orange Glass - Sand",
            Localizer.DoStr("Orange Glass - Sand"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(SandItem), 6),
                new IngredientElement(typeof(OrangeDyeItem), 1)
            },
            new CraftingElement[]
            {
                new CraftingElement<GlassOrangeItem>(3),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(OrangeGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [MaxStackSize(20)]
    [Tier(2)]
    [Currency]
    [Weight(10000)]
    [LocDisplayName("Orange Glass")]
    public partial class GlassOrangeItem : BlockItem<OrangeGlassBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Orange Glass used for building windows."); } }

        private static Type[] blockTypes = new Type[] {
            typeof(OrangeGlassStacked1Block),
            typeof(OrangeGlassStacked2Block),
            typeof(OrangeGlassStacked3Block),
            typeof(OrangeGlassStacked4Block)
        };

        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class OrangeGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassOrangeItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassOrangeItem))]
    public partial class OrangeGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassOrangeItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassOrangeItem))]
    public partial class OrangeGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassOrangeItem); } }
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassOrangeItem))]
    public partial class OrangeGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(GlassOrangeItem); } }
    }

    [Serialized, Solid] public class OrangeGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class OrangeGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class OrangeGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class OrangeGlassStacked4Block : PickupableBlock { }
}