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
    public partial class BlueGlassRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlueGlassRecipe).Name,
            Assembly = typeof(BlueGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Blue Glass",
            LocalizableName = Localizer.DoStr("Blue Glass"),
            IngredientList = new()
            {
                new EMIngredient("GlassItem", false, 6, true),
            },
            ProductList = new()
            {
                new EMCraftable("BlueGlassItem", 6),
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

        static BlueGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlueGlassRecipe()
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
    public partial class AltBlueGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AltBlueGlassRecipe).Name,
            Assembly = typeof(AltBlueGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Blue Glass - Sand",
            LocalizableName = Localizer.DoStr("Blue Glass - Sand"),
            IngredientList = new()
            {
                new EMIngredient("SandItem", false, 4),
                new EMIngredient("CrushedLimestoneItem", false, 1, true),
            },
            ProductList = new()
            {
                new EMCraftable("BlueGlassItem"),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 1,
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static AltBlueGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AltBlueGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(BlueGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [MaxStackSize(20)]
    [Currency]
    [Weight(10000)]
    [Tag("Colored Glass")]
    [Tag("Constructable")]
    [LocDisplayName("Blue Glass")]
    [LocDescription("A Blue Glass used for building windows.")]
    public partial class BlueGlassItem : BlockItem<BlueGlassBlock>
    {

        private static Type[] blockTypes = new Type[] {
            typeof(BlueGlassStacked1Block),
            typeof(BlueGlassStacked2Block),
            typeof(BlueGlassStacked3Block),
            typeof(BlueGlassStacked4Block)
        };
        public override Type[] BlockTypes => blockTypes;

    }

    [Serialized]
    [Solid, Wall, Constructed, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [DoesntEncase]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class BlueGlassBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueGlassItem);

        public override Type BaseType => typeof(GlassBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(WindowFormType), typeof(BlueGlassItem))]
    public partial class BlueGlassWindowBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueGlassItem);
        public override Type BaseType => typeof(GlassWindowBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(CubeFormType), typeof(BlueGlassItem))]
    public partial class BlueGlassCubeBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueGlassItem);
        public override Type BaseType => typeof(GlassCubeBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(FlatRoofFormType), typeof(BlueGlassItem))]
    public partial class BlueGlassFlatRoofBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueGlassItem);
        public override Type BaseType => typeof(GlassFlatRoofBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinFloorTopFormType), typeof(BlueGlassItem))]
    public partial class BlueGlassThinFloorTopBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueGlassItem);
        public override Type BaseType => typeof(GlassThinFloorTopBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinFloorBottomFormType), typeof(BlueGlassItem))]
    public partial class BlueGlassThinFloorBottomBlock : NBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(BlueGlassItem);
        public override Type BaseType => typeof(GlassThinFloorBottomBlock);
    }

    [RotatedVariants(typeof(BlueGlassThinWallStraightBlock), typeof(BlueGlassThinWallStraight90Block), typeof(BlueGlassThinWallStraight180Block), typeof(BlueGlassThinWallStraight270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinWallStraightFormType), typeof(BlueGlassItem))]
    public partial class BlueGlassThinWallStraightBlock : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraightBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassThinWallStraight90Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassThinWallStraight180Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassThinWallStraight270Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallStraight270Block);
    }

    [RotatedVariants(typeof(BlueGlassThinWallCornerBlock), typeof(BlueGlassThinWallCorner90Block), typeof(BlueGlassThinWallCorner180Block), typeof(BlueGlassThinWallCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(ThinWallCornerFormType), typeof(BlueGlassItem))]
    public partial class BlueGlassThinWallCornerBlock : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCornerBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassThinWallCorner90Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassThinWallCorner180Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassThinWallCorner270Block : NBlock
    {
        public override Type BaseType => typeof(GlassThinWallCorner270Block);
    }

    [RotatedVariants(typeof(BlueGlassEdgeWallBlock), typeof(BlueGlassEdgeWall90Block), typeof(BlueGlassEdgeWall180Block), typeof(BlueGlassEdgeWall270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(EdgeWallFormType), typeof(BlueGlassItem))]
    public partial class BlueGlassEdgeWallBlock : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassEdgeWall90Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassEdgeWall180Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassEdgeWall270Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWall270Block);
    }

    [RotatedVariants(typeof(BlueGlassEdgeWallTurnBlock), typeof(BlueGlassEdgeWallTurn90Block), typeof(BlueGlassEdgeWallTurn180Block), typeof(BlueGlassEdgeWallTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    [IsForm(typeof(EdgeWallTurnFormType), typeof(BlueGlassItem))]
    public partial class BlueGlassEdgeWallTurnBlock : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurnBlock);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassEdgeWallTurn90Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn90Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassEdgeWallTurn180Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn180Block);
    }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption]
    [BlockTier(2)]
    [Tag("Constructable")]
    public partial class BlueGlassEdgeWallTurn270Block : NBlock
    {
        public override Type BaseType => typeof(GlassEdgeWallTurn270Block);
    }

    [Serialized, Solid] public class BlueGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BlueGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BlueGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid, Wall] public class BlueGlassStacked4Block : PickupableBlock { }

}