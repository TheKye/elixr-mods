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
    public partial class WhiteGlassRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WhiteGlassRecipe).Name,
            Assembly = typeof(WhiteGlassRecipe).AssemblyQualifiedName,
            HiddenName = "White Glass",
            LocalizableName = Localizer.DoStr("White Glass"),
            IngredientList = new()
            {
                new EMIngredient("GlassItem", false, 6, true),
            },
            ProductList = new()
            {
                new EMCraftable("GlassWhiteItem", 6),
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

        static WhiteGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WhiteGlassRecipe()
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
    public partial class AltWhiteGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AltWhiteGlassRecipe).Name,
            Assembly = typeof(AltWhiteGlassRecipe).AssemblyQualifiedName,
            HiddenName = "White Glass - Sand",
            LocalizableName = Localizer.DoStr("White Glass - Sand"),
            IngredientList = new()
            {
                new EMIngredient("SandItem", false, 4),
                new EMIngredient("CrushedLimestoneItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("GlassWhiteItem"),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 1,
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static AltWhiteGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltWhiteGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(WhiteGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Currency]
    [Tier(2)]
    [LocDisplayName("White Glass")]
    public partial class GlassWhiteItem : BlockItem<WhiteGlassBlock>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A White Glass used for building windows.");

        private static Type[] blockTypes = new Type[] {
            typeof(WhiteGlassStacked1Block),
            typeof(WhiteGlassStacked2Block),
            typeof(WhiteGlassStacked3Block),
            typeof(WhiteGlassStacked4Block)
        };

        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class WhiteGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassWhiteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassWhiteItem))]
    public partial class WhiteGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassWhiteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassWhiteItem))]
    public partial class WhiteGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassWhiteItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassWhiteItem))]
    public partial class WhiteGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassWhiteItem);
    }

    [Serialized, Solid] public class WhiteGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class WhiteGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class WhiteGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class WhiteGlassStacked4Block : PickupableBlock { }
}