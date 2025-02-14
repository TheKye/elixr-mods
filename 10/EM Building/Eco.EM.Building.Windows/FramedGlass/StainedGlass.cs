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
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Occupancy;

namespace Eco.EM.Building.Windows
{
    #region Grey [Default]
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class GreyStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Grey Stained Glass");
        public Type RepresentedItemType => typeof(GreyStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static GreyStainedGlassObject()
        {
            AddOccupancy<GreyStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Grey Stained Glass")]
    [LocDescription("Decorative Grey Stained Glass Window.")]
    public partial class GreyStainedGlassItem : WorldObjectItem<GreyStainedGlassObject>
    {

        static GreyStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class GreyStainedGlassRecipe : RecipeFamily, IConfigurableRecipe
    {

        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreyStainedGlassRecipe).Name,
            Assembly = typeof(GreyStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Grey Stained Glass",
            LocalizableName = Localizer.DoStr("Grey Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("GreyGlassItem", false, 10),
                new EMIngredient("FrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("GreyStainedGlassItem", 6),
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

        static GreyStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreyStainedGlassRecipe()
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
    public partial class BlueStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Blue Stained Glass");
        public Type RepresentedItemType => typeof(BlueStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static BlueStainedGlassObject()
        {
            AddOccupancy<BlueStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }


    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Blue Stained Glass")]
    [LocDescription("Decorative Blue Stained Glass Window.")]
    public partial class BlueStainedGlassItem : WorldObjectItem<BlueStainedGlassObject>
    {

        static BlueStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class BlueStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlueStainedGlassRecipe).Name,
            Assembly = typeof(BlueStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Blue Stained Glass",
            LocalizableName = Localizer.DoStr("Blue Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BlueGlassItem", false, 10),
                new EMIngredient("FrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("BlueStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static BlueStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlueStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Black
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class BlackStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Black Stained Glass");
        public Type RepresentedItemType => typeof(BlackStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static BlackStainedGlassObject()
        {
            AddOccupancy<BlackStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Black Stained Glass")]
    [LocDescription("Decorative Black Stained Glass Window.")]
    public partial class BlackStainedGlassItem : WorldObjectItem<BlackStainedGlassObject>
    {

        static BlackStainedGlassItem() { }
    }


    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class BlackStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlackStainedGlassRecipe).Name,
            Assembly = typeof(BlackStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Black Stained Glass",
            LocalizableName = Localizer.DoStr("Black Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BlackGlassItem", false, 10),
                new EMIngredient("FrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("BlackStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static BlackStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlackStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Brown
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class BrownStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Brown Stained Glass");
        public Type RepresentedItemType => typeof(BrownStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static BrownStainedGlassObject()
        {
            AddOccupancy<BrownStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Brown Stained Glass")]
    [LocDescription("Decorative Brown Stained Glass Window.")]
    public partial class BrownStainedGlassItem : WorldObjectItem<BrownStainedGlassObject>
    {

        static BrownStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class BrownStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BrownStainedGlassRecipe).Name,
            Assembly = typeof(BrownStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Brown Stained Glass",
            LocalizableName = Localizer.DoStr("Brown Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BrownGlassItem", false, 10),
                new EMIngredient("FrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("BrownStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static BrownStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BrownStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Green
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class GreenStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Green Stained Glass");
        public Type RepresentedItemType => typeof(GreenStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static GreenStainedGlassObject()
        {
            AddOccupancy<GreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Green Stained Glass")]
    [LocDescription("Decorative Green Stained Glass Window.")]
    public partial class GreenStainedGlassItem : WorldObjectItem<GreenStainedGlassObject>
    {

        static GreenStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class GreenStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreenStainedGlassRecipe).Name,
            Assembly = typeof(GreenStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Green Stained Glass",
            LocalizableName = Localizer.DoStr("Green Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("GreenGlassItem", false, 10),
                new EMIngredient("FrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("GreenStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static GreenStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreenStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Orange
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class OrangeStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Orange Stained Glass");
        public Type RepresentedItemType => typeof(OrangeStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static OrangeStainedGlassObject()
        {
            AddOccupancy<OrangeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Orange Stained Glass")]
    [LocDescription("Decorative Orange Stained Glass Window.")]
    public partial class OrangeStainedGlassItem : WorldObjectItem<OrangeStainedGlassObject>
    {

        static OrangeStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class OrangeStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(OrangeStainedGlassRecipe).Name,
            Assembly = typeof(OrangeStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Orange Stained Glass",
            LocalizableName = Localizer.DoStr("Orange Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("OrangeGlassItem", false, 10),
                new EMIngredient("FrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("OrangeStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static OrangeStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public OrangeStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    #endregion
    #region Pink
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class PinkStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Pink Stained Glass");
        public Type RepresentedItemType => typeof(PinkStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static PinkStainedGlassObject()
        {
            AddOccupancy<PinkStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Pink Stained Glass")]
    [LocDescription("Decorative Pink Stained Glass Window.")]
    public partial class PinkStainedGlassItem : WorldObjectItem<PinkStainedGlassObject>
    {

        static PinkStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class PinkStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PinkStainedGlassRecipe).Name,
            Assembly = typeof(PinkStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Pink Stained Glass",
            LocalizableName = Localizer.DoStr("Pink Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("PinkGlassItem", false, 10),
                new EMIngredient("FrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("PinkStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static PinkStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PinkStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Purple
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class PurpleStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Purple Stained Glass");
        public Type RepresentedItemType => typeof(PurpleStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static PurpleStainedGlassObject()
        {
            AddOccupancy<PurpleStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Purple Stained Glass")]
    [LocDescription("Decorative Purple Stained Glass Window.")]
    public partial class PurpleStainedGlassItem : WorldObjectItem<PurpleStainedGlassObject>
    {

        static PurpleStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class PurpleStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PurpleStainedGlassRecipe).Name,
            Assembly = typeof(PurpleStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Purple Stained Glass",
            LocalizableName = Localizer.DoStr("Purple Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("PurpleGlassItem", false, 10),
                new EMIngredient("FrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("PurpleStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static PurpleStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PurpleStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Red
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class RedStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Red Stained Glass");
        public Type RepresentedItemType => typeof(RedStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static RedStainedGlassObject()
        {
            AddOccupancy<RedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Red Stained Glass")]
    [LocDescription("Decorative Red Stained Glass Window.")]
    public partial class RedStainedGlassItem : WorldObjectItem<RedStainedGlassObject>
    {

        static RedStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class RedStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RedStainedGlassRecipe).Name,
            Assembly = typeof(RedStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Red Stained Glass",
            LocalizableName = Localizer.DoStr("Red Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("RedGlassItem", false, 10),
                new EMIngredient("FrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("RedStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static RedStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RedStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region White
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WhiteStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("White Stained Glass");
        public Type RepresentedItemType => typeof(WhiteStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static WhiteStainedGlassObject()
        {
            AddOccupancy<WhiteStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("White Stained Glass")]
    [LocDescription("Decorative White Stained Glass Window.")]
    public partial class WhiteStainedGlassItem : WorldObjectItem<WhiteStainedGlassObject>
    {

        static WhiteStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class WhiteStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WhiteStainedGlassRecipe).Name,
            Assembly = typeof(WhiteStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "White Stained Glass",
            LocalizableName = Localizer.DoStr("White Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("WhiteGlassItem", false, 10),
                new EMIngredient("FrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("WhiteStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static WhiteStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WhiteStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Yellow
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class YellowStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Yellow Stained Glass");
        public Type RepresentedItemType => typeof(YellowStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static YellowStainedGlassObject()
        {
            AddOccupancy<YellowStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Yellow Stained Glass")]
    [LocDescription("Decorative Yellow Stained Glass Window.")]
    public partial class YellowStainedGlassItem : WorldObjectItem<YellowStainedGlassObject>
    {

        static YellowStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class YellowStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(YellowStainedGlassRecipe).Name,
            Assembly = typeof(YellowStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Yellow Stained Glass",
            LocalizableName = Localizer.DoStr("Yellow Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("YellowGlassItem", false, 10),
                new EMIngredient("FrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("YellowStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static YellowStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public YellowStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(GreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
}