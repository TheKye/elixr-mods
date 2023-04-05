using Eco.Core.Items;
using Eco.EM.Framework.Extentsions;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.World.Blocks;
using System;
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
                new EMCraftable("BrownGlassItem", 6),
            },
            BaseExperienceOnCraft = 0.5f,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "GlassworksItem",
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
                new EMCraftable("BrownGlassItem"),
            },
            CraftingStation = "GlassworksItem",
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
    [Currency]
    [Weight(10000)]
    [Tag("Colored Glass")]
    [LocDisplayName("Brown Glass")]
    public partial class BrownGlassItem : BlockItem<BrownGlassBlock>
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
    public partial class BrownGlassBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownGlassItem);

        public override Type BaseType => typeof(GlassBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(WindowFormType), typeof(BrownGlassItem))]
    public partial class BrownGlassWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownGlassItem);
        public override Type BaseType => typeof(GlassWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(CubeFormType), typeof(BrownGlassItem))]
    public partial class BrownGlassCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownGlassItem);
        public override Type BaseType => typeof(GlassCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(FlatRoofFormType), typeof(BrownGlassItem))]
    public partial class BrownGlassFlatRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownGlassItem);
        public override Type BaseType => typeof(GlassFlatRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinFloorTopFormType), typeof(BrownGlassItem))]
    public partial class BrownGlassThinFloorTopBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownGlassItem);
        public override Type BaseType => typeof(GlassThinFloorTopBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinFloorBottomFormType), typeof(BrownGlassItem))]
    public partial class BrownGlassThinFloorBottomBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BrownGlassItem);
        public override Type BaseType => typeof(GlassThinFloorBottomBlock);
    }

    [RotatedVariants(typeof(BrownGlassThinWallStraightBlock), typeof(BrownGlassThinWallStraight90Block), typeof(BrownGlassThinWallStraight180Block), typeof(BrownGlassThinWallStraight270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinWallStraightFormType), typeof(BrownGlassItem))]
    public partial class BrownGlassThinWallStraightBlock : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraightBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassThinWallStraight90Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassThinWallStraight180Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassThinWallStraight270Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight270Block);
    }

    [RotatedVariants(typeof(BrownGlassThinWallCornerBlock), typeof(BrownGlassThinWallCorner90Block), typeof(BrownGlassThinWallCorner180Block), typeof(BrownGlassThinWallCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(ThinWallCornerFormType), typeof(BrownGlassItem))]
    public partial class BrownGlassThinWallCornerBlock : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassThinWallCorner90Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassThinWallCorner180Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassThinWallCorner270Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner270Block);
    }

    [RotatedVariants(typeof(BrownGlassEdgeWallBlock), typeof(BrownGlassEdgeWall90Block), typeof(BrownGlassEdgeWall180Block), typeof(BrownGlassEdgeWall270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(EdgeWallFormType), typeof(BrownGlassItem))]
    public partial class BrownGlassEdgeWallBlock : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassEdgeWall90Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassEdgeWall180Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassEdgeWall270Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall270Block);
    }

    [RotatedVariants(typeof(BrownGlassEdgeWallTurnBlock), typeof(BrownGlassEdgeWallTurn90Block), typeof(BrownGlassEdgeWallTurn180Block), typeof(BrownGlassEdgeWallTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [IsForm(typeof(EdgeWallTurnFormType), typeof(BrownGlassItem))]
    public partial class BrownGlassEdgeWallTurnBlock : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassEdgeWallTurn90Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassEdgeWallTurn180Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    public partial class BrownGlassEdgeWallTurn270Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn270Block);
    }

    [Serialized, Solid] public class BrownGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BrownGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BrownGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BrownGlassStacked4Block : PickupableBlock { }

}