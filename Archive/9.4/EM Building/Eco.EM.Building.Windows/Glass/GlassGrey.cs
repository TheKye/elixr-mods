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
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using System.Linq;

namespace Eco.EM.Building.Windows
{
    [RequiresSkill(typeof(GlassworkingSkill), 0)]
    public partial class GreyGlassRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreyGlassRecipe).Name,
            Assembly = typeof(GreyGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Grey Glass",
            LocalizableName = Localizer.DoStr("Grey Glass"),
            IngredientList = new()
            {
                new EMIngredient("GlassItem", false, 6, true),
            },
            ProductList = new()
            {
                new EMCraftable("GlassGreyItem", 6),
            },
            BaseExperienceOnCraft = 0.5f,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 0,
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static GreyGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreyGlassRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class AltGreyGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AltGreyGlassRecipe).Name,
            Assembly = typeof(AltGreyGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Grey Glass - Sand",
            LocalizableName = Localizer.DoStr("Grey Glass - Sand"),
            IngredientList = new()
            {
                new EMIngredient("SandItem", false, 4),
                new EMIngredient("CrushedLimestoneItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("GlassGreyItem"),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 1,
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static AltGreyGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltGreyGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class GreyGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassGreyItem);
    }

    [Serialized]
    [MaxStackSize(20)]
    [Tier(2)]
    [Currency]
    [Weight(10000)]
    [LocDisplayName("Grey Glass")]
    public partial class GlassGreyItem : BlockItem<GreyGlassBlock>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Tinted Glass used for building windows.");

        public override bool CanStickToWalls => false;

        private static Type[] blockTypes = new Type[] {
            typeof(GreyGlassStacked1Block),
            typeof(GreyGlassStacked2Block),
            typeof(GreyGlassStacked3Block),
            typeof(GreyGlassStacked4Block)
        };

        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassGreyItem))]
    public partial class GreyGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassGreyItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassGreyItem))]
    public partial class GreyGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassGreyItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassGreyItem))]
    public partial class GreyGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassGreyItem);
    }

    [Serialized, Solid] public class GreyGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreyGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreyGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreyGlassStacked4Block : PickupableBlock { }
}