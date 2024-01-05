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

namespace Eco.EM.Building.Windows
{
    #region Grey [Default]
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeGreyStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Large Grey Stained Glass");
        public Type RepresentedItemType => typeof(LargeGreyStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LargeGreyStainedGlassObject()
        {
            AddOccupancy<LargeGreyStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Grey Stained Glass")]
    public partial class LargeGreyStainedGlassItem : WorldObjectItem<LargeGreyStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 2x2 Grey Stained Glass Window.");

        static LargeGreyStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 6)]
    public partial class LargeGreyStainedGlassRecipe : RecipeFamily, IConfigurableRecipe
    {

        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargeGreyStainedGlassRecipe).Name,
            Assembly = typeof(LargeGreyStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Large Grey Stained Glass",
            LocalizableName = Localizer.DoStr("Large Grey Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("GreyGlassItem", false, 26),
                new EMIngredient("LargeFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LargeGreyStainedGlassItem", 6),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 6,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LargeGreyStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargeGreyStainedGlassRecipe()
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
    public partial class LargeBlueStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Large Blue Stained Glass");
        public Type RepresentedItemType => typeof(LargeBlueStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LargeBlueStainedGlassObject()
        {
            AddOccupancy<LargeBlueStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }


    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Blue Stained Glass")]
    public partial class LargeBlueStainedGlassItem : WorldObjectItem<LargeBlueStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 2x2 Large Blue Stained Glass Window.");

        static LargeBlueStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 6)]
    public partial class LargeBlueStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargeBlueStainedGlassRecipe).Name,
            Assembly = typeof(LargeBlueStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Large Blue Stained Glass",
            LocalizableName = Localizer.DoStr("Large Blue Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BlueGlassItem", false, 26),
                new EMIngredient("LargeFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LargeBlueStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 6,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LargeBlueStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargeBlueStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LargeGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Black
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeBlackStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Large Black Stained Glass");
        public Type RepresentedItemType => typeof(LargeBlackStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LargeBlackStainedGlassObject()
        {
            AddOccupancy<LargeBlackStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Black Stained Glass")]
    public partial class LargeBlackStainedGlassItem : WorldObjectItem<LargeBlackStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 2x2 Black Stained Glass Window.");

        static LargeBlackStainedGlassItem() { }
    }


    [RequiresSkill(typeof(GlassworkingSkill), 6)]
    public partial class LargeBlackStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargeBlackStainedGlassRecipe).Name,
            Assembly = typeof(LargeBlackStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Large Black Stained Glass",
            LocalizableName = Localizer.DoStr("Large Black Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BlackGlassItem", false, 26),
                new EMIngredient("LargeFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LargeBlackStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 6,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LargeBlackStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargeBlackStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LargeGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Brown
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeBrownStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Large Brown Stained Glass");
        public Type RepresentedItemType => typeof(LargeBrownStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LargeBrownStainedGlassObject()
        {
            AddOccupancy<LargeBrownStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Brown Stained Glass")]
    public partial class LargeBrownStainedGlassItem : WorldObjectItem<LargeBrownStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 2x2 Brown Stained Glass Window.");

        static LargeBrownStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 6)]
    public partial class LargeBrownStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargeBrownStainedGlassRecipe).Name,
            Assembly = typeof(LargeBrownStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Large Brown Stained Glass",
            LocalizableName = Localizer.DoStr("Large Brown Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BrownGlassItem", false, 26),
                new EMIngredient("LargeFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LargeBrownStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 6,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LargeBrownStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargeBrownStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LargeGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Green
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeGreenStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Large Green Stained Glass");
        public Type RepresentedItemType => typeof(LargeGreenStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LargeGreenStainedGlassObject()
        {
            AddOccupancy<LargeGreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Green Stained Glass")]
    public partial class LargeGreenStainedGlassItem : WorldObjectItem<LargeGreenStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 2x2 Green Stained Glass Window.");

        static LargeGreenStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 6)]
    public partial class LargeGreenStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargeGreenStainedGlassRecipe).Name,
            Assembly = typeof(LargeGreenStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Large Green Stained Glass",
            LocalizableName = Localizer.DoStr("Large Green Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("GreenGlassItem", false, 26),
                new EMIngredient("LargeFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LargeGreenStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 6,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LargeGreenStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargeGreenStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LargeGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Orange
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeOrangeStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Large Orange Stained Glass");
        public Type RepresentedItemType => typeof(LargeOrangeStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LargeOrangeStainedGlassObject()
        {
            AddOccupancy<LargeOrangeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public LargeOrangeStainedGlassObject() { }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Orange Stained Glass")]
    public partial class LargeOrangeStainedGlassItem : WorldObjectItem<LargeOrangeStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 2x2 Orange Stained Glass Window.");

        static LargeOrangeStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 6)]
    public partial class LargeOrangeStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargeOrangeStainedGlassRecipe).Name,
            Assembly = typeof(LargeOrangeStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Large Orange Stained Glass",
            LocalizableName = Localizer.DoStr("Large Orange Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("OrangeGlassItem", false, 26),
                new EMIngredient("LargeFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LargeOrangeStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 6,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LargeOrangeStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargeOrangeStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LargeGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    #endregion
    #region Pink
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargePinkStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Large Pink Stained Glass");
        public Type RepresentedItemType => typeof(LargePinkStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LargePinkStainedGlassObject()
        {
            AddOccupancy<LargePinkStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Pink Stained Glass")]
    public partial class LargePinkStainedGlassItem : WorldObjectItem<LargePinkStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 2x2 Pink Stained Glass Window.");

        static LargePinkStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 6)]
    public partial class LargePinkStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargePinkStainedGlassRecipe).Name,
            Assembly = typeof(LargePinkStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Large Pink Stained Glass",
            LocalizableName = Localizer.DoStr("Large Pink Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("PinkGlassItem", false, 26),
                new EMIngredient("LargeFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LargePinkStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 6,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LargePinkStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargePinkStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LargeGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Purple
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargePurpleStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Large Purple Stained Glass");
        public Type RepresentedItemType => typeof(LargePurpleStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LargePurpleStainedGlassObject()
        {
            AddOccupancy<LargePurpleStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Purple Stained Glass")]
    public partial class LargePurpleStainedGlassItem : WorldObjectItem<LargePurpleStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 2x2 Purple Stained Glass Window.");

        static LargePurpleStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 6)]
    public partial class LargePurpleStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargePurpleStainedGlassRecipe).Name,
            Assembly = typeof(LargePurpleStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Large Purple Stained Glass",
            LocalizableName = Localizer.DoStr("Large Purple Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("PurpleGlassItem", false, 26),
                new EMIngredient("LargeFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LargePurpleStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 6,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LargePurpleStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargePurpleStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LargeGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Red
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeRedStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Large Red Stained Glass");
        public Type RepresentedItemType => typeof(LargeRedStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LargeRedStainedGlassObject()
        {
            AddOccupancy<LargeRedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Red Stained Glass")]
    public partial class LargeRedStainedGlassItem : WorldObjectItem<LargeRedStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 2x2 Red Stained Glass Window.");

        static LargeRedStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 6)]
    public partial class LargeRedStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargeRedStainedGlassRecipe).Name,
            Assembly = typeof(LargeRedStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Large Red Stained Glass",
            LocalizableName = Localizer.DoStr("Large Red Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("RedGlassItem", false, 26),
                new EMIngredient("LargeFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LargeRedStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 6,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LargeRedStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargeRedStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LargeGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region White
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeWhiteStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Large White Stained Glass");
        public Type RepresentedItemType => typeof(LargeWhiteStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LargeWhiteStainedGlassObject()
        {
            AddOccupancy<LargeWhiteStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large White Stained Glass")]
    public partial class LargeWhiteStainedGlassItem : WorldObjectItem<LargeWhiteStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 2x2 White Stained Glass Window.");

        static LargeWhiteStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 6)]
    public partial class LargeWhiteStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargeWhiteStainedGlassRecipe).Name,
            Assembly = typeof(LargeWhiteStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Large White Stained Glass",
            LocalizableName = Localizer.DoStr("Large White Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("WhiteGlassItem", false, 26),
                new EMIngredient("LargeFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LargeWhiteStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 6,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LargeWhiteStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargeWhiteStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LargeGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Yellow
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeYellowStainedGlassObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Large Yellow Stained Glass");
        public Type RepresentedItemType => typeof(LargeYellowStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LargeYellowStainedGlassObject()
        {
            AddOccupancy<LargeYellowStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }


    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Yellow Stained Glass")]
    public partial class LargeYellowStainedGlassItem : WorldObjectItem<LargeYellowStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 2x2 Yellow Stained Glass Window.");

        static LargeYellowStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 6)]
    public partial class LargeYellowStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LargeYellowStainedGlassRecipe).Name,
            Assembly = typeof(LargeYellowStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Large Yellow Stained Glass",
            LocalizableName = Localizer.DoStr("Large Yellow Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("YellowGlassItem", false, 26),
                new EMIngredient("LargeFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LargeYellowStainedGlassItem", 6),
            },
            CraftingStation = "GlassworksItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 6,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LargeYellowStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LargeYellowStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LargeGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
}