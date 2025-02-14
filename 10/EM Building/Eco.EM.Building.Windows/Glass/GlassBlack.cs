﻿using Eco.Core.Items;
using Eco.EM.Framework.Extentsions;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
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
    public partial class BlackGlassRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlackGlassRecipe).Name,
            Assembly = typeof(BlackGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Black Glass",
            LocalizableName = Localizer.DoStr("Black Glass"),
            IngredientList = new()
            {
                new EMIngredient("GlassItem", false, 6, true),
            },
            ProductList = new()
            {
                new EMCraftable("BlackGlassItem", 6),
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

        static BlackGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlackGlassRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class AltBlackGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AltBlackGlassRecipe).Name,
            Assembly = typeof(AltBlackGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Black Glass - Sand",
            LocalizableName = Localizer.DoStr("Black Glass - Sand"),
            IngredientList = new()
            {
                new EMIngredient("SandItem", false, 4),
                new EMIngredient("CrushedLimestoneItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BlackGlassItem"),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 1,
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static AltBlackGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltBlackGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(BlackGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [Currency]
    [Weight(10000)]
    [Tag("Colored Glass")]
    [Tag("Constructable")]
    [LocDisplayName("Black Glass")]
    [LocDescription("A Black Glass used for building windows.")]
    public partial class BlackGlassItem : BlockItem<BlackGlassBlock>
    {
        
        private static Type[] blockTypes = new Type[] {
            typeof(BlackGlassStacked1Block),
            typeof(BlackGlassStacked2Block),
            typeof(BlackGlassStacked3Block),
            typeof(BlackGlassStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class BlackGlassBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackGlassItem);

        public override Type BaseType => typeof(GlassBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowFormType), typeof(BlackGlassItem))]
    public partial class BlackGlassWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackGlassItem);
        public override Type BaseType => typeof(GlassWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(CubeFormType), typeof(BlackGlassItem))]
    public partial class BlackGlassCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackGlassItem);
        public override Type BaseType => typeof(GlassCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FlatRoofFormType), typeof(BlackGlassItem))]
    public partial class BlackGlassFlatRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackGlassItem);
        public override Type BaseType => typeof(GlassFlatRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinFloorTopFormType), typeof(BlackGlassItem))]
    public partial class BlackGlassThinFloorTopBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackGlassItem);
        public override Type BaseType => typeof(GlassThinFloorTopBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinFloorBottomFormType), typeof(BlackGlassItem))]
    public partial class BlackGlassThinFloorBottomBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlackGlassItem);
        public override Type BaseType => typeof(GlassThinFloorBottomBlock);
    }

    [RotatedVariants(typeof(BlackGlassThinWallStraightBlock), typeof(BlackGlassThinWallStraight90Block), typeof(BlackGlassThinWallStraight180Block), typeof(BlackGlassThinWallStraight270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinWallStraightFormType), typeof(BlackGlassItem))]
    public partial class BlackGlassThinWallStraightBlock : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraightBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassThinWallStraight90Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassThinWallStraight180Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassThinWallStraight270Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight270Block);
    }

    [RotatedVariants(typeof(BlackGlassThinWallCornerBlock), typeof(BlackGlassThinWallCorner90Block), typeof(BlackGlassThinWallCorner180Block), typeof(BlackGlassThinWallCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinWallCornerFormType), typeof(BlackGlassItem))]
    public partial class BlackGlassThinWallCornerBlock : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassThinWallCorner90Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassThinWallCorner180Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassThinWallCorner270Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner270Block);
    }

    [RotatedVariants(typeof(BlackGlassEdgeWallBlock), typeof(BlackGlassEdgeWall90Block), typeof(BlackGlassEdgeWall180Block), typeof(BlackGlassEdgeWall270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(EdgeWallFormType), typeof(BlackGlassItem))]
    public partial class BlackGlassEdgeWallBlock : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassEdgeWall90Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassEdgeWall180Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassEdgeWall270Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall270Block);
    }

    [RotatedVariants(typeof(BlackGlassEdgeWallTurnBlock), typeof(BlackGlassEdgeWallTurn90Block), typeof(BlackGlassEdgeWallTurn180Block), typeof(BlackGlassEdgeWallTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(EdgeWallTurnFormType), typeof(BlackGlassItem))]
    public partial class BlackGlassEdgeWallTurnBlock : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassEdgeWallTurn90Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassEdgeWallTurn180Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlackGlassEdgeWallTurn270Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn270Block);
    }

    [Serialized, Solid] public class BlackGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BlackGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BlackGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BlackGlassStacked4Block : PickupableBlock { }

}