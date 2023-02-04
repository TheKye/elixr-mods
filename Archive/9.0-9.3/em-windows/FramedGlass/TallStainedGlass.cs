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
    public partial class TallGreyStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Stained Glass"); } }

        protected override void Initialize() { }

        static TallGreyStainedGlassObject()
        {
            AddOccupancy<TallGreyStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Stained Glass")]
    public partial class TallGreyStainedGlassItem : WorldObjectItem<TallGreyStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A 1x2 Decorative Stained Glass Window."); } }

        static TallGreyStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class TallGreyStainedGlassRecipe : RecipeFamily
    {
        public TallGreyStainedGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Tall Stained Glass",
                    Localizer.DoStr("Tall Stained Glass"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(GlassGreyItem), 10, typeof(GlassworkingSkill)),
                        new IngredientElement(typeof(TallFrameItem), 1, true)
                    },
                    new CraftingElement<TallGreyStainedGlassItem>(6)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallGreyStainedGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Tall Stained Glass"), typeof(TallGreyStainedGlassRecipe));
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
    public partial class TallBlueStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Blue Stained Glass"); } }

        protected override void Initialize() { }

        static TallBlueStainedGlassObject()
        {
            AddOccupancy<TallBlueStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Blue Stained Glass")]
    public partial class TallBlueStainedGlassItem : WorldObjectItem<TallBlueStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Tall Blue Stained Glass Window."); } }

        static TallBlueStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class TallBlueStainedGlassRecipe : Recipe
    {
        public TallBlueStainedGlassRecipe()
        {
            var product = new Recipe(
                "Tall Blue Stained Glass",
                Localizer.DoStr("Tall Blue Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassBlueItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(TallFrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<TallBlueStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(TallGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Black
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallBlackStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Black Stained Glass"); } }

        protected override void Initialize() { }

        static TallBlackStainedGlassObject()
        {
            AddOccupancy<TallBlackStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Black Stained Glass")]
    public partial class TallBlackStainedGlassItem : WorldObjectItem<TallBlackStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Black Stained Glass Window."); } }

        static TallBlackStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallBlackStainedGlassRecipe : Recipe
    {
        public TallBlackStainedGlassRecipe()
        {
            var product = new Recipe(
                "Tall Black Stained Glass",
                Localizer.DoStr("Tall Black Stained Glass"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GlassBlackItem), 10, typeof(GlassworkingSkill)),
                    new IngredientElement(typeof(TallFrameItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<TallBlackStainedGlassItem>(6),
                }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(TallGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Brown
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallBrownStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Brown Stained Glass"); } }

        protected override void Initialize() { }

        static TallBrownStainedGlassObject()
        {
            AddOccupancy<TallBrownStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Brown Stained Glass")]
    public partial class TallBrownStainedGlassItem : WorldObjectItem<TallBrownStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Brown Stained Glass Window."); } }

        static TallBrownStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallBrownStainedGlassRecipe : Recipe
    {
        public TallBrownStainedGlassRecipe()
        {
            var product = new Recipe(
            "Tall Brown Stained Glass",
            Localizer.DoStr("Tall Brown Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassBrownItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(TallFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<TallBrownStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(TallGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Green
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallGreenStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Green Stained Glass"); } }
        
        protected override void Initialize() { }

        static TallGreenStainedGlassObject()
        {
            AddOccupancy<TallGreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Green Stained Glass")]
    public partial class TallGreenStainedGlassItem : WorldObjectItem<TallGreenStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A 1x2 Decorative Green Stained Glass Window."); } }

        static TallGreenStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class TallGreenStainedGlassRecipe : Recipe
    {
        public TallGreenStainedGlassRecipe()
        {
            var product = new Recipe(
            "Tall Green Stained Glass",
            Localizer.DoStr("Tall Green Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassGreenItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(TallFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<TallGreenStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(TallGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Orange
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallOrangeStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Orange Stained Glass"); } }

        protected override void Initialize() { }

        static TallOrangeStainedGlassObject()
        {
            AddOccupancy<TallOrangeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Orange Stained Glass")]
    public partial class TallOrangeStainedGlassItem : WorldObjectItem<TallOrangeStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Orange Stained Glass Window."); } }

        static TallOrangeStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallOrangeStainedGlassRecipe : Recipe
    {
        public TallOrangeStainedGlassRecipe()
        {
            var product = new Recipe(
            "Tall Orange Stained Glass",
            Localizer.DoStr("Tall Orange Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassOrangeItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(TallFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<TallOrangeStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(TallGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Pink
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallPinkStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Pink Stained Glass"); } }

        protected override void Initialize() { }

        static TallPinkStainedGlassObject()
        {
            AddOccupancy<TallPinkStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Pink Stained Glass")]
    public partial class TallPinkStainedGlassItem : WorldObjectItem<TallPinkStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Pink Stained Glass Window."); } }

        static TallPinkStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallPinkStainedGlassRecipe : Recipe
    {
        public TallPinkStainedGlassRecipe()
        {
            var product = new Recipe(
            "Tall Pink Stained Glass",
            Localizer.DoStr("Tall Pink Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassPinkItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(TallFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<TallPinkStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(TallGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Purple
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallPurpleStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Purple Stained Glass"); } }

        protected override void Initialize() { }

        static TallPurpleStainedGlassObject()
        {
            AddOccupancy<TallPurpleStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Purple Stained Glass")]
    public partial class TallPurpleStainedGlassItem : WorldObjectItem<TallPurpleStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Purple Stained Glass Window."); } }

        static TallPurpleStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallPurpleStainedGlassRecipe : Recipe
    {
        public TallPurpleStainedGlassRecipe()
        {
            var product = new Recipe(
            "Tall Purple Stained Glass",
            Localizer.DoStr("Tall Purple Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassPurpleItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(TallFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<TallPurpleStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(TallGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Red
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallRedStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Red Stained Glass"); } }

        protected override void Initialize() { }

        static TallRedStainedGlassObject()
        {
            AddOccupancy<TallRedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Red Stained Glass")]
    public partial class TallRedStainedGlassItem : WorldObjectItem<TallRedStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A 1x2 Decorative Red Stained Glass Window."); } }

        static TallRedStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class TallRedStainedGlassRecipe : Recipe
    {
        public TallRedStainedGlassRecipe()
        {
            var product = new Recipe(
            "Tall Red Stained Glass",
            Localizer.DoStr("Tall Red Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassRedItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(TallFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<TallRedStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(TallGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region White
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallWhiteStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall White Stained Glass"); } }

        protected override void Initialize() { }

        static TallWhiteStainedGlassObject()
        {
            AddOccupancy<TallWhiteStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall White Stained Glass")]
    public partial class TallWhiteStainedGlassItem : WorldObjectItem<TallWhiteStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 White Stained Glass Window."); } }

        static TallWhiteStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallWhiteStainedGlassRecipe : Recipe
    {
        public TallWhiteStainedGlassRecipe()
        {
            var product = new Recipe(
            "Tall White Stained Glass",
            Localizer.DoStr("Tall White Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassWhiteItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(TallFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<TallWhiteStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(TallGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Yellow
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class TallYellowStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Yellow Stained Glass"); } }

        protected override void Initialize() { }

        static TallYellowStainedGlassObject()
        {
            AddOccupancy<TallYellowStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10), LocDisplayName("Tall Yellow Stained Glass")]
    public partial class TallYellowStainedGlassItem : WorldObjectItem<TallYellowStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Yellow 1x2 Stained Glass Window."); } }

        static TallYellowStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class TallYellowStainedGlassRecipe : Recipe
    {
        public TallYellowStainedGlassRecipe()
        {
            var product = new Recipe(
            "Tall Yellow Stained Glass",
            Localizer.DoStr("Tall Yellow Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassYellowItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(TallFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<TallYellowStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(TallGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
}