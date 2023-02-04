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
    public partial class LongGreyStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long Grey Stained Glass");
        public Type RepresentedItemType => typeof(LongGreyStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LongGreyStainedGlassObject()
        {
            AddOccupancy<LongGreyStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Long Grey Stained Glass")]
    public partial class LongGreyStainedGlassItem : WorldObjectItem<LongGreyStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 1x2 Grey Stained Glass Window.");

        static LongGreyStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongGreyStainedGlassRecipe : RecipeFamily, IConfigurableRecipe
    {

        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongGreyStainedGlassRecipe).Name,
            Assembly = typeof(LongGreyStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Long Grey Stained Glass",
            LocalizableName = Localizer.DoStr("Long Grey Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("GreyGlassItem", false, 16),
                new EMIngredient("LongFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LongGreyStainedGlassItem", 6),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 2,
            CraftTimeIsStatic = false,
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LongGreyStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongGreyStainedGlassRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
    #endregion
    #region Blue
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongBlueStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long Blue Stained Glass");
        public Type RepresentedItemType => typeof(LongBlueStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LongBlueStainedGlassObject()
        {
            AddOccupancy<LongBlueStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Long Blue Stained Glass")]
    public partial class LongBlueStainedGlassItem : WorldObjectItem<LongBlueStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 1x2 Long Blue Stained Glass Window.");

        static LongBlueStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongBlueStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongBlueStainedGlassRecipe).Name,
            Assembly = typeof(LongBlueStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Long Blue Stained Glass",
            LocalizableName = Localizer.DoStr("Long Blue Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BlueGlassItem", false, 16),
                new EMIngredient("LongFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LongBlueStainedGlassItem", 6),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LongBlueStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongBlueStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LongGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Black
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongBlackStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long Black Stained Glass");
        public Type RepresentedItemType => typeof(LongBlackStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LongBlackStainedGlassObject()
        {
            AddOccupancy<LongBlackStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Long Black Stained Glass")]
    public partial class LongBlackStainedGlassItem : WorldObjectItem<LongBlackStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 1x2 Black Stained Glass Window.");

        static LongBlackStainedGlassItem() { }
    }


    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongBlackStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongBlackStainedGlassRecipe).Name,
            Assembly = typeof(LongBlackStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Long Black Stained Glass",
            LocalizableName = Localizer.DoStr("Long Black Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BlackGlassItem", false, 16),
                new EMIngredient("LongFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LongBlackStainedGlassItem", 6),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LongBlackStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongBlackStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LongGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Brown
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongBrownStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long Brown Stained Glass");
        public Type RepresentedItemType => typeof(LongBrownStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LongBrownStainedGlassObject()
        {
            AddOccupancy<LongBrownStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Long Brown Stained Glass")]
    public partial class LongBrownStainedGlassItem : WorldObjectItem<LongBrownStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 1x2 Brown Stained Glass Window.");

        static LongBrownStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongBrownStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongBrownStainedGlassRecipe).Name,
            Assembly = typeof(LongBrownStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Long Brown Stained Glass",
            LocalizableName = Localizer.DoStr("Long Brown Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("BrownGlassItem", false, 16),
                new EMIngredient("LongFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LongBrownStainedGlassItem", 6),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LongBrownStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongBrownStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LongGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Green
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongGreenStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long Green Stained Glass");
        public Type RepresentedItemType => typeof(LongGreenStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LongGreenStainedGlassObject()
        {
            AddOccupancy<LongGreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Long Green Stained Glass")]
    public partial class LongGreenStainedGlassItem : WorldObjectItem<LongGreenStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 1x2 Green Stained Glass Window.");

        static LongGreenStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongGreenStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongGreenStainedGlassRecipe).Name,
            Assembly = typeof(LongGreenStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Long Green Stained Glass",
            LocalizableName = Localizer.DoStr("Long Green Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("GreenGlassItem", false, 16),
                new EMIngredient("LongFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LongGreenStainedGlassItem", 6),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LongGreenStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongGreenStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LongGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Orange
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongOrangeStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long Orange Stained Glass");
        public Type RepresentedItemType => typeof(LongOrangeStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LongOrangeStainedGlassObject()
        {
            AddOccupancy<LongOrangeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }
        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Long Orange Stained Glass")]
    public partial class LongOrangeStainedGlassItem : WorldObjectItem<LongOrangeStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 1x2 Orange Stained Glass Window.");

        static LongOrangeStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongOrangeStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongOrangeStainedGlassRecipe).Name,
            Assembly = typeof(LongOrangeStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Long Orange Stained Glass",
            LocalizableName = Localizer.DoStr("Long Orange Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("OrangeGlassItem", false, 16),
                new EMIngredient("LongFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LongOrangeStainedGlassItem", 6),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LongOrangeStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongOrangeStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LongGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    #endregion
    #region Pink
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongPinkStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long Pink Stained Glass");
        public Type RepresentedItemType => typeof(LongPinkStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize()
        {

        }

        static LongPinkStainedGlassObject()
        {
            AddOccupancy<LongPinkStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Long Pink Stained Glass")]
    public partial class LongPinkStainedGlassItem : WorldObjectItem<LongPinkStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 1x2 Pink Stained Glass Window.");

        static LongPinkStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongPinkStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongPinkStainedGlassRecipe).Name,
            Assembly = typeof(LongPinkStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Long Pink Stained Glass",
            LocalizableName = Localizer.DoStr("Long Pink Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("PinkGlassItem", false, 16),
                new EMIngredient("LongFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LongPinkStainedGlassItem", 6),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LongPinkStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongPinkStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LongGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Purple
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongPurpleStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long Purple Stained Glass");
        public Type RepresentedItemType => typeof(LongPurpleStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LongPurpleStainedGlassObject()
        {
            AddOccupancy<LongPurpleStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Long Purple Stained Glass")]
    public partial class LongPurpleStainedGlassItem : WorldObjectItem<LongPurpleStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 1x2 Purple Stained Glass Window.");

        static LongPurpleStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongPurpleStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongPurpleStainedGlassRecipe).Name,
            Assembly = typeof(LongPurpleStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Long Purple Stained Glass",
            LocalizableName = Localizer.DoStr("Long Purple Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("PurpleGlassItem", false, 16),
                new EMIngredient("LongFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LongPurpleStainedGlassItem", 6),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LongPurpleStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongPurpleStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LongGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Red
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongRedStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long Red Stained Glass");
        public Type RepresentedItemType => typeof(LongRedStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LongRedStainedGlassObject()
        {
            AddOccupancy<LongRedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Long Red Stained Glass")]
    public partial class LongRedStainedGlassItem : WorldObjectItem<LongRedStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 1x2 Red Stained Glass Window.");

        static LongRedStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongRedStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongRedStainedGlassRecipe).Name,
            Assembly = typeof(LongRedStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Long Red Stained Glass",
            LocalizableName = Localizer.DoStr("Long Red Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("RedGlassItem", false, 16),
                new EMIngredient("LongFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LongRedStainedGlassItem", 6),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LongRedStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongRedStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LongGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region White
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongWhiteStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long White Stained Glass");
        public Type RepresentedItemType => typeof(LongWhiteStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LongWhiteStainedGlassObject()
        {
            AddOccupancy<LongWhiteStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Long White Stained Glass")]
    public partial class LongWhiteStainedGlassItem : WorldObjectItem<LongWhiteStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 1x2 White Stained Glass Window.");

        static LongWhiteStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongWhiteStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongWhiteStainedGlassRecipe).Name,
            Assembly = typeof(LongWhiteStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Long White Stained Glass",
            LocalizableName = Localizer.DoStr("Long White Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("WhiteGlassItem", false, 16),
                new EMIngredient("LongFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LongWhiteStainedGlassItem", 6),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LongWhiteStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongWhiteStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LongGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
    #region Yellow
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongYellowStainedGlassObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Long Yellow Stained Glass");
        public Type RepresentedItemType => typeof(LongYellowStainedGlassItem);
        public override bool HasTier => true;
        public override int Tier => 3;
        protected override void Initialize() { }

        static LongYellowStainedGlassObject()
        {
            AddOccupancy<LongYellowStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Long Yellow Stained Glass")]
    public partial class LongYellowStainedGlassItem : WorldObjectItem<LongYellowStainedGlassObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Decorative 1x2 Yellow Stained Glass Window.");

        static LongYellowStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongYellowStainedGlassRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LongYellowStainedGlassRecipe).Name,
            Assembly = typeof(LongYellowStainedGlassRecipe).AssemblyQualifiedName,
            HiddenName = "Long Yellow Stained Glass",
            LocalizableName = Localizer.DoStr("Long Yellow Stained Glass"),
            IngredientList = new()
            {
                new EMIngredient("YellowGlassItem", false, 16),
                new EMIngredient("LongFrameItem", false, 6, true)
            },
            ProductList = new()
            {
                new EMCraftable("LongYellowStainedGlassItem", 6),
            },
            CraftingStation = "GlassworkingTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static LongYellowStainedGlassRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LongYellowStainedGlassRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(LongGreyStainedGlassRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
}