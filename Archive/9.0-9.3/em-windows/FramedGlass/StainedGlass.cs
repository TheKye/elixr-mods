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
    public partial class GreyStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Grey Stained Glass"); } }

        protected override void Initialize() { }

        static GreyStainedGlassObject()
        {
            AddOccupancy<GreyStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Stained Glass")]
    public partial class GreyStainedGlassItem : WorldObjectItem<GreyStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Grey Stained Glass Window."); } }

        static GreyStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class GreyStainedGlassRecipe : RecipeFamily
    {
        public GreyStainedGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Grey Stained Glass",
                    Localizer.DoStr("Grey Stained Glass"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(GlassGreyItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(FrameItem), 1, true)
                    },
                    new CraftingElement<GreyStainedGlassItem>(6)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreyStainedGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Stained Glass"), typeof(GreyStainedGlassRecipe));
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
    public partial class BlueStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Blue Stained Glass"); } }

        protected override void Initialize() { }

        static BlueStainedGlassObject()
        {
            AddOccupancy<BlueStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Blue Stained Glass")]
    public partial class BlueStainedGlassItem : WorldObjectItem<BlueStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Blue Stained Glass Window."); } }

        static BlueStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class BlueStainedGlassRecipe : Recipe
    {
        public BlueStainedGlassRecipe()
        {
            var product = new Recipe(
                "Blue Stained Glass",
                Localizer.DoStr("Blue Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassBlueItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(FrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BlueStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Black
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class BlackStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Black Stained Glass"); } }

        protected override void Initialize() { }

        static BlackStainedGlassObject()
        {
            AddOccupancy<BlackStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Black Stained Glass")]
    public partial class BlackStainedGlassItem : WorldObjectItem<BlackStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Black Stained Glass Window."); } }

        static BlackStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class BlackStainedGlassRecipe : Recipe
    {
        public BlackStainedGlassRecipe()
        {
            var product = new Recipe(
                "Black Stained Glass",
                Localizer.DoStr("Black Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassBlackItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(FrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BlackStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Brown
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class BrownStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Brown Stained Glass"); } }

        protected override void Initialize() { }

        static BrownStainedGlassObject()
        {
            AddOccupancy<BrownStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Brown Stained Glass")]
    public partial class BrownStainedGlassItem : WorldObjectItem<BrownStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Brown Stained Glass Window."); } }

        static BrownStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class BrownStainedGlassRecipe : Recipe
    {
        public BrownStainedGlassRecipe()
        {
            var product = new Recipe(
                "Brown Stained Glass",
                Localizer.DoStr("Brown Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassBrownItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(FrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BrownStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Green
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class GreenStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Green Stained Glass"); } }
        
        protected override void Initialize() { }

        static GreenStainedGlassObject()
        {
            AddOccupancy<GreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Green Stained Glass")]
    public partial class GreenStainedGlassItem : WorldObjectItem<GreenStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Green Stained Glass Window."); } }

        static GreenStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class GreenStainedGlassRecipe : Recipe
    {
        public GreenStainedGlassRecipe()
        {
            var product = new Recipe(
                "Green Stained Glass",
                Localizer.DoStr("Green Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassGreenItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(FrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<GreenStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Orange
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class OrangeStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Orange Stained Glass"); } }

        protected override void Initialize() { }

        static OrangeStainedGlassObject()
        {
            AddOccupancy<OrangeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Orange Stained Glass")]
    public partial class OrangeStainedGlassItem : WorldObjectItem<OrangeStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Orange Stained Glass Window."); } }

        static OrangeStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class OrangeStainedGlassRecipe : Recipe
    {
        public OrangeStainedGlassRecipe()
        {
            var product = new Recipe(
                "Orange Stained Glass",
                Localizer.DoStr("Orange Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassOrangeItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(FrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<OrangeStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Pink
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class PinkStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Pink Stained Glass"); } }

        protected override void Initialize() { }

        static PinkStainedGlassObject()
        {
            AddOccupancy<PinkStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Pink Stained Glass")]
    public partial class PinkStainedGlassItem : WorldObjectItem<PinkStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Pink Stained Glass Window."); } }

        static PinkStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class PinkStainedGlassRecipe : Recipe
    {
        public PinkStainedGlassRecipe()
        {
            var product = new Recipe(
                "Pink Stained Glass",
                Localizer.DoStr("Pink Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassPinkItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(FrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<PinkStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Purple
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class PurpleStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Purple Stained Glass"); } }

        protected override void Initialize() { }

        static PurpleStainedGlassObject()
        {
            AddOccupancy<PurpleStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Purple Stained Glass")]
    public partial class PurpleStainedGlassItem : WorldObjectItem<PurpleStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Purple Stained Glass Window."); } }

        static PurpleStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class PurpleStainedGlassRecipe : Recipe
    {
        public PurpleStainedGlassRecipe()
        {
            var product = new Recipe(
                "Purple Stained Glass",
                Localizer.DoStr("Purple Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassPurpleItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(FrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<PurpleStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Red
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class RedStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Red Stained Glass"); } }

        protected override void Initialize() { }

        static RedStainedGlassObject()
        {
            AddOccupancy<RedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Red Stained Glass")]
    public partial class RedStainedGlassItem : WorldObjectItem<RedStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Red Stained Glass Window."); } }

        static RedStainedGlassItem() { }
    }
    
    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class RedStainedGlassRecipe : Recipe
    {
        public RedStainedGlassRecipe()
        {
            var product = new Recipe(
                "Red Stained Glass",
                Localizer.DoStr("Red Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassRedItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(FrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<RedStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region White
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WhiteStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("White Stained Glass"); } }

        protected override void Initialize() { }

        static WhiteStainedGlassObject()
        {
            AddOccupancy<WhiteStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("White Stained Glass")]
    public partial class WhiteStainedGlassItem : WorldObjectItem<WhiteStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative White Stained Glass Window."); } }

        static WhiteStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class WhiteStainedGlassRecipe : Recipe
    {
        public WhiteStainedGlassRecipe()
        {
            var product = new Recipe(
                "White Stained Glass",
                Localizer.DoStr("White Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassWhiteItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(FrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<WhiteStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Yellow
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class YellowStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Yellow Stained Glass"); } }

        protected override void Initialize() { }

        static YellowStainedGlassObject()
        {
            AddOccupancy<YellowStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Yellow Stained Glass")]
    public partial class YellowStainedGlassItem : WorldObjectItem<YellowStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Yellow Stained Glass Window."); } }

        static YellowStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class YellowStainedGlassRecipe : Recipe
    {
        public YellowStainedGlassRecipe()
        {
            var product = new Recipe(
                "Yellow Stained Glass",
                Localizer.DoStr("Yellow Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassYellowItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(FrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<YellowStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(GreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
}