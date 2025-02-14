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
                new EMCraftable("GreenGlassItem", 6),
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

        static GreenGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreenGlassRecipe()
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
                new EMCraftable("GreenGlassItem"),
            },
            CraftingStation = "GlassworksItem",
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
    [Currency]
    [Weight(10000)]
    [Tag("Colored Glass")]
    [Tag("Constructable")]
    [LocDisplayName("Green Glass")]
    [LocDescription("A Green Glass used for building windows.")]
    public partial class GreenGlassItem : BlockItem<GreenGlassBlock>
    {

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
    [Tag("Constructable")]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class GreenGlassBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenGlassItem);

        public override Type BaseType => typeof(GlassBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowFormType), typeof(GreenGlassItem))]
    public partial class GreenGlassWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenGlassItem);
        public override Type BaseType => typeof(GlassWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(CubeFormType), typeof(GreenGlassItem))]
    public partial class GreenGlassCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenGlassItem);
        public override Type BaseType => typeof(GlassCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FlatRoofFormType), typeof(GreenGlassItem))]
    public partial class GreenGlassFlatRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenGlassItem);
        public override Type BaseType => typeof(GlassFlatRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinFloorTopFormType), typeof(GreenGlassItem))]
    public partial class GreenGlassThinFloorTopBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenGlassItem);
        public override Type BaseType => typeof(GlassThinFloorTopBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinFloorBottomFormType), typeof(GreenGlassItem))]
    public partial class GreenGlassThinFloorBottomBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(GreenGlassItem);
        public override Type BaseType => typeof(GlassThinFloorBottomBlock);
    }

    [RotatedVariants(typeof(GreenGlassThinWallStraightBlock), typeof(GreenGlassThinWallStraight90Block), typeof(GreenGlassThinWallStraight180Block), typeof(GreenGlassThinWallStraight270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinWallStraightFormType), typeof(GreenGlassItem))]
    public partial class GreenGlassThinWallStraightBlock : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraightBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassThinWallStraight90Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassThinWallStraight180Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassThinWallStraight270Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight270Block);
    }

    [RotatedVariants(typeof(GreenGlassThinWallCornerBlock), typeof(GreenGlassThinWallCorner90Block), typeof(GreenGlassThinWallCorner180Block), typeof(GreenGlassThinWallCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinWallCornerFormType), typeof(GreenGlassItem))]
    public partial class GreenGlassThinWallCornerBlock : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassThinWallCorner90Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassThinWallCorner180Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassThinWallCorner270Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner270Block);
    }

    [RotatedVariants(typeof(GreenGlassEdgeWallBlock), typeof(GreenGlassEdgeWall90Block), typeof(GreenGlassEdgeWall180Block), typeof(GreenGlassEdgeWall270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(EdgeWallFormType), typeof(GreenGlassItem))]
    public partial class GreenGlassEdgeWallBlock : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassEdgeWall90Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassEdgeWall180Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassEdgeWall270Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall270Block);
    }

    [RotatedVariants(typeof(GreenGlassEdgeWallTurnBlock), typeof(GreenGlassEdgeWallTurn90Block), typeof(GreenGlassEdgeWallTurn180Block), typeof(GreenGlassEdgeWallTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(EdgeWallTurnFormType), typeof(GreenGlassItem))]
    public partial class GreenGlassEdgeWallTurnBlock : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassEdgeWallTurn90Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassEdgeWallTurn180Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class GreenGlassEdgeWallTurn270Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn270Block);
    }

    [Serialized, Solid] public class GreenGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GreenGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GreenGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class GreenGlassStacked4Block : PickupableBlock { }

}