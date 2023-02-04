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
    public partial class BrownGlassRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BrownGlassRecipe).Name,
            Assembly = typeof(BrownGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Brown Glass",
            LocalizableName = Localizer.DoStr("Brown Glass"),
            IngredientList = new()
            {
                new EMIngredient("GlassItem", false, 6, true),
            },
            ProductList = new()
            {
                new EMCraftable("GlassBrownItem", 6),
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

        static BrownGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BrownGlassRecipe()
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
    public partial class AltBrownGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AltBrownGlassRecipe).Name,
            Assembly = typeof(AltBrownGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Brown Glass - Sand",
            LocalizableName = Localizer.DoStr("Brown Glass - Sand"),
            IngredientList = new()
            {
                new EMIngredient("SandItem", false, 4),
                new EMIngredient("CrushedLimestoneItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("GlassBrownItem"),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 1,
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static AltBrownGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltBrownGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(BrownGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [Tier(2)]
    [Currency]
    [Weight(10000)]
    [LocDisplayName("Brown Glass")]
    public partial class GlassBrownItem : BlockItem<BrownGlassBlock>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Brown Glass used for building windows.");

        private static Type[] blockTypes = new Type[] {
            typeof(BrownGlassStacked1Block),
            typeof(BrownGlassStacked2Block),
            typeof(BrownGlassStacked3Block),
            typeof(BrownGlassStacked4Block)
        };

        public override Type[] BlockTypes => blockTypes;
    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class BrownGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassBrownItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(GlassBrownItem))]
    public partial class BrownGlassWindowBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassBrownItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(GlassBrownItem))]
    public partial class BrownGlassCubeBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassBrownItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(GlassBrownItem))]
    public partial class BrownGlassFlatRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GlassBrownItem);
    }

    [Serialized, Solid] public class BrownGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BrownGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BrownGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BrownGlassStacked4Block : PickupableBlock { }
}