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
    public partial class PurpleGlassRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PurpleGlassRecipe).Name,
            Assembly = typeof(PurpleGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Purple Glass",
            LocalizableName = Localizer.DoStr("Purple Glass"),
            IngredientList = new()
            {
                new EMIngredient("GlassItem", false, 6, true),
            },
            ProductList = new()
            {
                new EMCraftable("GlassPurpleItem", 6),
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

        static PurpleGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PurpleGlassRecipe()
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
    public partial class AltPurpleGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AltPurpleGlassRecipe).Name,
            Assembly = typeof(AltPurpleGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Purple Glass - Sand",
            LocalizableName = Localizer.DoStr("Purple Glass - Sand"),
            IngredientList = new()
            {
                new EMIngredient("SandItem", false, 4),
                new EMIngredient("CrushedLimestoneItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("GlassPurpleItem"),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 1,
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static AltPurpleGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltPurpleGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(PurpleGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [Tier(2)]
    [Currency]
    [Weight(10000)]
    [LocDisplayName("Purple Glass")]
    public partial class GlassPurpleItem : BlockItem<PurpleGlassBlock>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Purple Glass used for building windows.");

        private static Type[] blockTypes = new Type[] {
            typeof(PurpleGlassStacked1Block),
            typeof(PurpleGlassStacked2Block),
            typeof(PurpleGlassStacked3Block),
            typeof(PurpleGlassStacked4Block)
        };

        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class PurpleGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassPurpleItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassPurpleItem))]
    public partial class PurpleGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassPurpleItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassPurpleItem))]
    public partial class PurpleGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassPurpleItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassPurpleItem))]
    public partial class PurpleGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassPurpleItem);
    }

    [Serialized, Solid] public class PurpleGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class PurpleGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class PurpleGlassStacked4Block : PickupableBlock { }
}