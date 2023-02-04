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

namespace Eco.EM.Windows
{
    #region Grey [Default]
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeGreyStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Grey Stained Glass"); } }

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

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Grey Stained Glass")]
    public partial class LargeGreyStainedGlassItem : WorldObjectItem<LargeGreyStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("2x2 Decorative Grey Stained Glass Window."); } }

        static LargeGreyStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LargeGreyStainedGlassRecipe : RecipeFamily
    {
        public LargeGreyStainedGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Large Grey Stained Glass",
                    Localizer.DoStr("Large Grey Stained Glass"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(GlassGreyItem), 10, typeof(GlassworkingSkill)),
                        new IngredientElement(typeof(LargeFrameItem), 1, true)
                    },
                    new CraftingElement<LargeGreyStainedGlassItem>(6)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeGreyStainedGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Large Stained Glass"), typeof(LargeGreyStainedGlassRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Blue
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeBlueStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Blue Stained Glass"); } }

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

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Blue Stained Glass")]
    public partial class LargeBlueStainedGlassItem : WorldObjectItem<LargeBlueStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x2 Large Blue Stained Glass Window."); } }

        static LargeBlueStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LargeBlueStainedGlassRecipe : Recipe
    {
        public LargeBlueStainedGlassRecipe()
        {
            var product = new Recipe(
            "Large Blue Stained Glass",
            Localizer.DoStr("Large Blue Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassBlueItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LargeFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LargeBlueStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LargeGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Black
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeBlackStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Black Stained Glass"); } }

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

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Black Stained Glass")]
    public partial class LargeBlackStainedGlassItem : WorldObjectItem<LargeBlackStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x2 Black Stained Glass Window."); } }

        static LargeBlackStainedGlassItem() { }
    }


    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LargeBlackStainedGlassRecipe : Recipe
    {
        public LargeBlackStainedGlassRecipe()
        {
            var product = new Recipe(
            "Large Black Stained Glass",
            Localizer.DoStr("Large Black Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassBlackItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LargeFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LargeBlackStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LargeGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Brown
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeBrownStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Brown Stained Glass"); } }

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

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Brown Stained Glass")]
    public partial class LargeBrownStainedGlassItem : WorldObjectItem<LargeBrownStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x2 Brown Stained Glass Window."); } }

        static LargeBrownStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LargeBrownStainedGlassRecipe : Recipe
    {
        public LargeBrownStainedGlassRecipe()
        {
            var product = new Recipe(
            "Large Brown Stained Glass",
            Localizer.DoStr("Large Brown Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassBrownItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LargeFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LargeBrownStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LargeGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Green
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeGreenStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Green Stained Glass"); } }

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

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Green Stained Glass")]
    public partial class LargeGreenStainedGlassItem : WorldObjectItem<LargeGreenStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("2x2 Decorative Green Stained Glass Window."); } }

        static LargeGreenStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LargeGreenStainedGlassRecipe : Recipe
    {
        public LargeGreenStainedGlassRecipe()
        {
            var product = new Recipe(
            "Large Green Stained Glass",
            Localizer.DoStr("Large Green Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassGreenItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LargeFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LargeGreenStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LargeGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Orange
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeOrangeStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Orange Stained Glass"); } }

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

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Orange Stained Glass")]
    public partial class LargeOrangeStainedGlassItem : WorldObjectItem<LargeOrangeStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x2 Orange Stained Glass Window."); } }

        static LargeOrangeStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LargeOrangeStainedGlassRecipe : Recipe
    {
        public LargeOrangeStainedGlassRecipe()
        {
            var product = new Recipe(
            "Large Orange Stained Glass",
            Localizer.DoStr("Large Orange Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassOrangeItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LargeFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LargeOrangeStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LargeGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Pink
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargePinkStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Pink Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LargePinkStainedGlassObject()
        {
            AddOccupancy<LargePinkStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Pink Stained Glass")]
    public partial class LargePinkStainedGlassItem : WorldObjectItem<LargePinkStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x2 Pink Stained Glass Window."); } }

        static LargePinkStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LargePinkStainedGlassRecipe : Recipe
    {
        public LargePinkStainedGlassRecipe()
        {
            var product = new Recipe(
            "Large Pink Stained Glass",
            Localizer.DoStr("Large Pink Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassPinkItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LargeFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LargePinkStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LargeGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Purple
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargePurpleStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Purple Stained Glass"); } }

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

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Purple Stained Glass")]
    public partial class LargePurpleStainedGlassItem : WorldObjectItem<LargePurpleStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x2 Purple Stained Glass Window."); } }

        static LargePurpleStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LargePurpleStainedGlassRecipe : Recipe
    {
        public LargePurpleStainedGlassRecipe()
        {
            var product = new Recipe(
            "Large Purple Stained Glass",
            Localizer.DoStr("Large Purple Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassPurpleItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LargeFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LargePurpleStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LargeGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Red
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeRedStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Red Stained Glass"); } }

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

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Red Stained Glass")]
    public partial class LargeRedStainedGlassItem : WorldObjectItem<LargeRedStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("2x2 Decorative Red Stained Glass Window."); } }

        static LargeRedStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LargeRedStainedGlassRecipe : Recipe
    {
        public LargeRedStainedGlassRecipe()
        {
            var product = new Recipe(
            "Large Red Stained Glass",
            Localizer.DoStr("Large Red Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassRedItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LargeFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LargeRedStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LargeGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region White
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeWhiteStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large White Stained Glass"); } }

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

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large White Stained Glass")]
    public partial class LargeWhiteStainedGlassItem : WorldObjectItem<LargeWhiteStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x2 White Stained Glass Window."); } }

        static LargeWhiteStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LargeWhiteStainedGlassRecipe : Recipe
    {
        public LargeWhiteStainedGlassRecipe()
        {
            var product = new Recipe(
            "Large White Stained Glass",
            Localizer.DoStr("Large White Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassWhiteItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LargeFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LargeWhiteStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LargeGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Yellow
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeYellowStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Yellow Stained Glass"); } }

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

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Large Yellow Stained Glass")]
    public partial class LargeYellowStainedGlassItem : WorldObjectItem<LargeYellowStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Yellow 2x2 Stained Glass Window."); } }

        static LargeYellowStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LargeYellowStainedGlassRecipe : Recipe
    {
        public LargeYellowStainedGlassRecipe()
        {
            var product = new Recipe(
            "Large Yellow Stained Glass",
            Localizer.DoStr("Large Yellow Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassYellowItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LargeFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LargeYellowStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LargeGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
}