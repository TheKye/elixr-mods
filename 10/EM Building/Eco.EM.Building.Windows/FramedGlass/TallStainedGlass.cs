using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using System;
using System.Linq;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Items.Recipes;

namespace Eco.EM.Building.Windows
{
    #region Grey [Default]
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallGreyStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall Grey Stained Glass");
        public Type RepresentedItemType => typeof(TallGreyStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static TallGreyStainedGlassObject()
        {
            AddOccupancy<TallGreyStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Grey Stained Glass")]
    [LocDescription("Decorative 2x1 Grey Stained Glass Window.")]
    public partial class TallGreyStainedGlassItem : WorldObjectItem<TallGreyStainedGlassObject>
    {

        static TallGreyStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class TallGreyStainedGlassRecipe : RecipeFamily, IConfigurableRecipe
    {

        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallGreyStainedGlassRecipe).Name,
            Assembly = typeof(TallGreyStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Grey Stained Glass",
            LocalizableName = Localizer.DoStr("Tall Grey Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("GreyGlassItem", false, 16),
                new EMIngredient("TallFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("TallGreyStainedGlassItem", 6),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static TallGreyStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallGreyStainedGlassRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
    #endregion
    #region Blue
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallBlueStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall Blue Stained Glass");
        public Type RepresentedItemType => typeof(TallBlueStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static TallBlueStainedGlassObject()
        {
            AddOccupancy<TallBlueStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }


    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Blue Stained Glass")]
    [LocDescription("Decorative 2x1 Tall Blue Stained Glass Window.")]
    public partial class TallBlueStainedGlassItem : WorldObjectItem<TallBlueStainedGlassObject>
    {

        static TallBlueStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class TallBlueStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallBlueStainedGlassRecipe).Name,
            Assembly = typeof(TallBlueStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Blue Stained Glass",
            LocalizableName = Localizer.DoStr("Tall Blue Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BlueGlassItem", false, 16),
                new EMIngredient("TallFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("TallBlueStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static TallBlueStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallBlueStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(TallGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Black
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallBlackStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall Black Stained Glass");
        public Type RepresentedItemType => typeof(TallBlackStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static TallBlackStainedGlassObject()
        {
            AddOccupancy<TallBlackStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Black Stained Glass")]
    [LocDescription("Decorative 2x1 Black Stained Glass Window.")]
    public partial class TallBlackStainedGlassItem : WorldObjectItem<TallBlackStainedGlassObject>
    {

        static TallBlackStainedGlassItem() { }
    }


    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallBlackStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallBlackStainedGlassRecipe).Name,
            Assembly = typeof(TallBlackStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Black Stained Glass",
            LocalizableName = Localizer.DoStr("Tall Black Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BlackGlassItem", false, 16),
                new EMIngredient("TallFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("TallBlackStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static TallBlackStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallBlackStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(TallGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Brown
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallBrownStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall Brown Stained Glass");
        public Type RepresentedItemType => typeof(TallBrownStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static TallBrownStainedGlassObject()
        {
            AddOccupancy<TallBrownStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Brown Stained Glass")]
    [LocDescription("Decorative 2x1 Brown Stained Glass Window.")]
    public partial class TallBrownStainedGlassItem : WorldObjectItem<TallBrownStainedGlassObject>
    {

        static TallBrownStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallBrownStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallBrownStainedGlassRecipe).Name,
            Assembly = typeof(TallBrownStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Brown Stained Glass",
            LocalizableName = Localizer.DoStr("Tall Brown Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BrownGlassItem", false, 16),
                new EMIngredient("TallFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("TallBrownStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static TallBrownStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallBrownStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(TallGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Green
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallGreenStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall Green Stained Glass");
        public Type RepresentedItemType => typeof(TallGreenStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static TallGreenStainedGlassObject()
        {
            AddOccupancy<TallGreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Green Stained Glass")]
    [LocDescription("Decorative 2x1 Green Stained Glass Window.")]
    public partial class TallGreenStainedGlassItem : WorldObjectItem<TallGreenStainedGlassObject>
    {

        static TallGreenStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class TallGreenStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallGreenStainedGlassRecipe).Name,
            Assembly = typeof(TallGreenStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Green Stained Glass",
            LocalizableName = Localizer.DoStr("Tall Green Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("GreenGlassItem", false, 16),
                new EMIngredient("TallFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("TallGreenStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static TallGreenStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallGreenStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(TallGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Orange
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallOrangeStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall Orange Stained Glass");
        public Type RepresentedItemType => typeof(TallOrangeStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static TallOrangeStainedGlassObject()
        {
            AddOccupancy<TallOrangeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Orange Stained Glass")]
    [LocDescription("Decorative 2x1 Orange Stained Glass Window.")]
    public partial class TallOrangeStainedGlassItem : WorldObjectItem<TallOrangeStainedGlassObject>
    {

        static TallOrangeStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallOrangeStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallOrangeStainedGlassRecipe).Name,
            Assembly = typeof(TallOrangeStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Orange Stained Glass",
            LocalizableName = Localizer.DoStr("Tall Orange Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("OrangeGlassItem", false, 16),
                new EMIngredient("TallFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("TallOrangeStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static TallOrangeStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallOrangeStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(TallGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    #endregion
    #region Pink
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallPinkStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall Pink Stained Glass");
        public Type RepresentedItemType => typeof(TallPinkStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize()
        {

        }

        static TallPinkStainedGlassObject()
        {
            AddOccupancy<TallPinkStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Pink Stained Glass")]
    [LocDescription("Decorative 2x1 Pink Stained Glass Window.")]
    public partial class TallPinkStainedGlassItem : WorldObjectItem<TallPinkStainedGlassObject>
    {

        static TallPinkStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallPinkStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallPinkStainedGlassRecipe).Name,
            Assembly = typeof(TallPinkStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Pink Stained Glass",
            LocalizableName = Localizer.DoStr("Tall Pink Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("PinkGlassItem", false, 16),
                new EMIngredient("TallFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("TallPinkStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static TallPinkStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallPinkStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(TallGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Purple
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallPurpleStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall Purple Stained Glass");
        public Type RepresentedItemType => typeof(TallPurpleStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static TallPurpleStainedGlassObject()
        {
            AddOccupancy<TallPurpleStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Purple Stained Glass")]
    [LocDescription("Decorative 2x1 Purple Stained Glass Window.")]
    public partial class TallPurpleStainedGlassItem : WorldObjectItem<TallPurpleStainedGlassObject>
    {

        static TallPurpleStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallPurpleStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallPurpleStainedGlassRecipe).Name,
            Assembly = typeof(TallPurpleStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Purple Stained Glass",
            LocalizableName = Localizer.DoStr("Tall Purple Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("PurpleGlassItem", false, 16),
                new EMIngredient("TallFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("TallPurpleStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static TallPurpleStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallPurpleStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(TallGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Red
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallRedStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall Red Stained Glass");
        public Type RepresentedItemType => typeof(TallRedStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static TallRedStainedGlassObject()
        {
            AddOccupancy<TallRedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Red Stained Glass")]
    [LocDescription("Decorative 2x1 Red Stained Glass Window.")]
    public partial class TallRedStainedGlassItem : WorldObjectItem<TallRedStainedGlassObject>
    {

        static TallRedStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class TallRedStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallRedStainedGlassRecipe).Name,
            Assembly = typeof(TallRedStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Red Stained Glass",
            LocalizableName = Localizer.DoStr("Tall Red Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("RedGlassItem", false, 16),
                new EMIngredient("TallFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("TallRedStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static TallRedStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallRedStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(TallGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region White
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallWhiteStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall White Stained Glass");
        public Type RepresentedItemType => typeof(TallWhiteStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static TallWhiteStainedGlassObject()
        {
            AddOccupancy<TallWhiteStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall White Stained Glass")]
    [LocDescription("Decorative 2x1 White Stained Glass Window.")]
    public partial class TallWhiteStainedGlassItem : WorldObjectItem<TallWhiteStainedGlassObject>
    {

        static TallWhiteStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallWhiteStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallWhiteStainedGlassRecipe).Name,
            Assembly = typeof(TallWhiteStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Tall White Stained Glass",
            LocalizableName = Localizer.DoStr("Tall White Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("WhiteGlassItem", false, 16),
                new EMIngredient("TallFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("TallWhiteStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static TallWhiteStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallWhiteStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(TallGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Yellow
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallYellowStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Tall Yellow Stained Glass");
        public Type RepresentedItemType => typeof(TallYellowStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static TallYellowStainedGlassObject()
        {
            AddOccupancy<TallYellowStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Yellow Stained Glass")]
    [LocDescription("Decorative 2x1 Yellow Stained Glass Window.")]
    public partial class TallYellowStainedGlassItem : WorldObjectItem<TallYellowStainedGlassObject>
    {

        static TallYellowStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class TallYellowStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(TallYellowStainedGlassRecipe).Name,
            Assembly = typeof(TallYellowStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Tall Yellow Stained Glass",
            LocalizableName = Localizer.DoStr("Tall Yellow Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("YellowGlassItem", false, 16),
                new EMIngredient("TallFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("TallYellowStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static TallYellowStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public TallYellowStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(TallGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
}