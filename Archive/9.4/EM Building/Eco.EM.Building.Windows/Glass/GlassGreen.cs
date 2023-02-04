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
    public partial class GreenGlassRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreenGlassRecipe).Name,
            Assembly = typeof(GreenGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Green Glass",
            LocalizableName = Localizer.DoStr("Green Glass"),
            IngredientList = new()
            {
                new EMIngredient("GlassItem", false, 6, true),
            },
            ProductList = new()
            {
                new EMCraftable("GlassGreenItem", 6),
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

        static GreenGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreenGlassRecipe()
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
    public partial class AltGreenGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AltGreenGlassRecipe).Name,
            Assembly = typeof(AltGreenGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Green Glass - Sand",
            LocalizableName = Localizer.DoStr("Green Glass - Sand"),
            IngredientList = new()
            {
                new EMIngredient("SandItem", false, 4),
                new EMIngredient("CrushedLimestoneItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("GlassGreenItem"),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 1,
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static AltGreenGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltGreenGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreenGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [Tier(2)]
    [Currency]
    [Weight(10000)]
    [LocDisplayName("Green Glass")]
    public partial class GlassGreenItem : BlockItem<GreenGlassBlock>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Green Glass used for building windows.");

        private static Type[] blockTypes = new Type[] {
            typeof(GreenGlassStacked1Block),
            typeof(GreenGlassStacked2Block),
            typeof(GreenGlassStacked3Block),
            typeof(GreenGlassStacked4Block)
        };

        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class GreenGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassGreenItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassGreenItem))]
    public partial class GreenGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassGreenItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassGreenItem))]
    public partial class GreenGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassGreenItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassGreenItem))]
    public partial class GreenGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassGreenItem);
    }

    [Serialized, Solid] public class GreenGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreenGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreenGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreenGlassStacked4Block : PickupableBlock { }
}