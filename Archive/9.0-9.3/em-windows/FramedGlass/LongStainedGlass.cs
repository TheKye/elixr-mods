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
    public partial class LongGreyStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Grey Stained Glass"); } }

        protected override void Initialize() { }

        static LongGreyStainedGlassObject()
        {
            AddOccupancy<LongGreyStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }

    [Serialized, Tier(3), Weight(600), MaxStackSize(10),LocDisplayName("Long Grey Stained Glass")]
    public partial class LongGreyStainedGlassItem : WorldObjectItem<LongGreyStainedGlassObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("2x1 Decorative Grey Stained Glass Window."); } }

        static LongGreyStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongGreyStainedGlassRecipe : RecipeFamily
    {
        public LongGreyStainedGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Long Grey Stained Glass",
                    Localizer.DoStr("Long Grey Stained Glass"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(GlassGreyItem), 10, typeof(GlassworkingSkill)),
                        new IngredientElement(typeof(LongFrameItem), 1, true)
                    },
                    new CraftingElement<LongGreyStainedGlassItem>(6)
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(LongGreyStainedGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Long Stained Glass"), typeof(LongGreyStainedGlassRecipe));
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
    public partial class LongBlueStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Blue Stained Glass"); } }

        protected override void Initialize() { }

        static LongBlueStainedGlassObject()
        {
            AddOccupancy<LongBlueStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
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
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x1 Long Blue Stained Glass Window."); } }

        static LongBlueStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongBlueStainedGlassRecipe : Recipe
    {
        public LongBlueStainedGlassRecipe()
        {
            var product = new Recipe(
            "Long Blue Stained Glass",
            Localizer.DoStr("Long Blue Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassBlueItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LongFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LongBlueStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LongGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Black
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongBlackStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Black Stained Glass"); } }

        protected override void Initialize() { }

        static LongBlackStainedGlassObject()
        {
            AddOccupancy<LongBlackStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
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
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x1 Black Stained Glass Window."); } }

        static LongBlackStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongBlackStainedGlassRecipe : Recipe
    {
        public LongBlackStainedGlassRecipe()
        {
            var product = new Recipe(
            "Long Black Stained Glass",
            Localizer.DoStr("Long Black Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassBlackItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LongFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LongBlackStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LongGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Brown
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongBrownStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Brown Stained Glass"); } }

        protected override void Initialize() { }

        static LongBrownStainedGlassObject()
        {
            AddOccupancy<LongBrownStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
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
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x1 Brown Stained Glass Window."); } }

        static LongBrownStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongBrownStainedGlassRecipe : Recipe
    {
        public LongBrownStainedGlassRecipe()
        {
            var product = new Recipe(
            "Long Brown Stained Glass",
            Localizer.DoStr("Long Brown Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassBrownItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LongFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LongBrownStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LongGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Green
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongGreenStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Green Stained Glass"); } }
        
        protected override void Initialize() { }

        static LongGreenStainedGlassObject()
        {
            AddOccupancy<LongGreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
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
        public override LocString DisplayDescription { get { return Localizer.DoStr("2x1 Decorative Green Stained Glass Window."); } }

        static LongGreenStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongGreenStainedGlassRecipe : Recipe
    {
        public LongGreenStainedGlassRecipe()
        {
            var product = new Recipe(
            "Long Green Stained Glass",
            Localizer.DoStr("Long Green Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassGreenItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LongFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LongGreenStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LongGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Orange
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongOrangeStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Orange Stained Glass"); } }

        protected override void Initialize() { }

        static LongOrangeStainedGlassObject()
        {
            AddOccupancy<LongOrangeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
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
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x1 Orange Stained Glass Window."); } }

        static LongOrangeStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongOrangeStainedGlassRecipe : Recipe
    {
        public LongOrangeStainedGlassRecipe()
        {
            var product = new Recipe(
            "Long Orange Stained Glass",
            Localizer.DoStr("Long Orange Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassOrangeItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LongFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LongOrangeStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LongGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Pink
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongPinkStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Pink Stained Glass"); } }

        protected override void Initialize() { }

        static LongPinkStainedGlassObject()
        {
            AddOccupancy<LongPinkStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
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
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x1 Long Pink Stained Glass Window."); } }

        static LongPinkStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongPinkStainedGlassRecipe : Recipe
    {
        public LongPinkStainedGlassRecipe()
        {
            var product = new Recipe(
            "Long Pink Stained Glass",
            Localizer.DoStr("Long Pink Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassPinkItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LongFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LongPinkStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LongGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Purple
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongPurpleStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Purple Stained Glass"); } }

        protected override void Initialize() { }

        static LongPurpleStainedGlassObject()
        {
            AddOccupancy<LongPurpleStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
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
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x1 Purple Stained Glass Window."); } }

        static LongPurpleStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongPurpleStainedGlassRecipe : Recipe
    {
        public LongPurpleStainedGlassRecipe()
        {
            var product = new Recipe(
            "Long Purple Stained Glass",
            Localizer.DoStr("Long Purple Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassPurpleItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LongFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LongPurpleStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LongGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Red
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongRedStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Red Stained Glass"); } }

        protected override void Initialize() { }

        static LongRedStainedGlassObject()
        {
            AddOccupancy<LongRedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
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
        public override LocString DisplayDescription { get { return Localizer.DoStr("2x1 Decorative Red Stained Glass Window."); } }

        static LongRedStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongRedStainedGlassRecipe : Recipe
    {
        public LongRedStainedGlassRecipe()
        {
            var product = new Recipe(
            "Long Red Stained Glass",
            Localizer.DoStr("Long Red Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassRedItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LongFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LongRedStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LongGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region White
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongWhiteStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long White Stained Glass"); } }

        protected override void Initialize() { }

        static LongWhiteStainedGlassObject()
        {
            AddOccupancy<LongWhiteStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
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
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x1 Long White Stained Glass Window."); } }

        static LongWhiteStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongWhiteStainedGlassRecipe : Recipe
    {
        public LongWhiteStainedGlassRecipe()
        {
            var product = new Recipe(
            "Long White Stained Glass",
            Localizer.DoStr("Long White Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassWhiteItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LongFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LongWhiteStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LongGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #region Yellow
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LongYellowStainedGlassObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Yellow Stained Glass"); } }

        protected override void Initialize() { }

        static LongYellowStainedGlassObject()
        {
            AddOccupancy<LongYellowStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock))
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
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Yellow 2x1 Stained Glass Window."); } }

        static LongYellowStainedGlassItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LongYellowStainedGlassRecipe : Recipe
    {
        public LongYellowStainedGlassRecipe()
        {
            var product = new Recipe(
            "Long Yellow Stained Glass",
            Localizer.DoStr("Long Yellow Stained Glass"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(GlassYellowItem), 10, typeof(GlassworkingSkill)),
                new IngredientElement(typeof(LongFrameItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<LongYellowStainedGlassItem>(6),
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(GlassworkingTableObject), typeof(LongGreyStainedGlassRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
}