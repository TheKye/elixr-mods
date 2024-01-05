using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Building.Greenhousing
{
    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(3)]
    [DoesntEncase]
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class GreenhouseGlassBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenhouseGlassItem);
    }

    [Serialized]
    [LocDisplayName("Greenhouse Glass")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true)]
    [Currency][Tag("Currency")]
    [Tag("Constructable", 1)]
    [Tier(3)]
    public partial class GreenhouseGlassItem : BlockItem<GreenhouseGlassBlock>
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Greenhouse Glass");
        public override LocString DisplayDescription => Localizer.DoStr("A special treated glass just for building Greenhouses, ");

        public override bool CanStickToWalls => false;

        private readonly static Type[] blockTypes = new Type[] {
            typeof(GreenhouseGlassStacked1Block),
            typeof(GreenhouseGlassStacked2Block),
            typeof(GreenhouseGlassStacked3Block),
            typeof(GreenhouseGlassStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;
    }

    [RequiresSkill(typeof(GlassworkingSkill), 4)]
    public partial class GreenhouseGlassRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreenhouseGlassRecipe).Name,
            Assembly = typeof(GreenhouseGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Greenhouse Glass",
            LocalizableName = Localizer.DoStr("Greenhouse Glass"),
            IngredientList = new()
            {
                new EMIngredient("GlassItem", false, 1),
                new EMIngredient("SteelBarItem", false, 1),
            },
            ProductList = new()
            {
                new EMCraftable("GreenhouseGlassItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent) },
        };

        static GreenhouseGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreenhouseGlassRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized, Solid] public class GreenhouseGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreenhouseGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreenhouseGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreenhouseGlassStacked4Block : PickupableBlock { } //Only a wall if it's all 4 GreenhouseGlass

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(FloorFormType), typeof(GreenhouseGlassItem))]
    public partial class GreenhouseGlassFloorBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenhouseGlassItem); 
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WindowFormType), typeof(GreenhouseGlassItem))]
    public partial class GreenhouseGlassWallBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenhouseGlassItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(RoofFormType), typeof(GreenhouseGlassItem))]
    public partial class GreenhouseGlassRoofBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenhouseGlassItem);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(3)]
    [IsForm(typeof(WallCornerFormType), typeof(GreenhouseGlassItem))]
    public partial class GreenhouseGlassWallCornersBlock : Block, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenhouseGlassItem);
    }

    public partial class WallCornerFormType : WindowFormType
    {
        public override string Name => "WallCorner";
        public override LocString DisplayName => Localizer.DoStr("Wall Corner");
        public override LocString DisplayDescription => Localizer.DoStr("A Wall Corner for certain Types of building");
        public override Type GroupType => typeof(ThinFormGroup);
        public override int SortOrder => 12;
        public override int MinTier => 1;
    }
}
