using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Artistry
{
    #region Primary colors
    #region Black
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Black Paint")]
    public partial class BlackPaintItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Black Paint Used for Painting Certain Items."); } }

        static BlackPaintItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class BlackPaintRecipe : RecipeFamily
    {
        public BlackPaintRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Base - Black",
                    Localizer.DoStr("Paint Base - Black"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(BlackDyeItem), 2, true),
                new IngredientElement(typeof(PaintBaseItem), 2, typeof(PaintingSkill))
                    },
                 new CraftingElement<BlackPaintItem>(4)

                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlackPaintRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Base - Black"), typeof(BlackPaintRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Yellow
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Yellow Paint")]
    public partial class YellowPaintItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Yellow Paint Used for Painting Certain Items."); } }

        static YellowPaintItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class YellowPaintRecipe : RecipeFamily
    {
        public YellowPaintRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Base - Yellow",
                    Localizer.DoStr("Paint Base - Yellow"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(YellowDyeItem), 2, true),
                new IngredientElement(typeof(PaintBaseItem), 2, typeof(PaintingSkill))
                    },
                 new CraftingElement<YellowPaintItem>(4)

                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(YellowPaintRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Base - Yellow"), typeof(YellowPaintRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Blue
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Blue Paint")]
    public partial class BluePaintItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Blue Paint Used for Painting Certain Items."); } }

        static BluePaintItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class BluePaintRecipe : RecipeFamily
    {
        public BluePaintRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Base - Blue",
                    Localizer.DoStr("Paint Base - Blue"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(BlueDyeItem), 2, true),
                new IngredientElement(typeof(PaintBaseItem), 2, typeof(PaintingSkill))
                    },
                 new CraftingElement<BluePaintItem>(4)

                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BluePaintRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Base - Blue"), typeof(BluePaintRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Red
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Red Paint")]
    public partial class RedPaintItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Red Paint Used for Painting Certain Items."); } }

        static RedPaintItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class RedPaintRecipe : RecipeFamily
    {
        public RedPaintRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Base - Red",
                    Localizer.DoStr("Paint Base - Red"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(RedDyeItem), 2, true),
                new IngredientElement(typeof(PaintBaseItem), 2, typeof(PaintingSkill))
                    },
                 new CraftingElement<RedPaintItem>(4)

                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(RedPaintRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Base - Red"), typeof(RedPaintRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region White
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("White Paint")]
    public partial class WhitePaintItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("White Paint Used for Painting Certain Items."); } }

        static WhitePaintItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class WhitePaintRecipe : RecipeFamily
    {
        public WhitePaintRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Base - White",
                    Localizer.DoStr("Paint Base - White"),
                   new IngredientElement[]
                    {
                new IngredientElement(typeof(WhiteDyeItem), 2, true),
                new IngredientElement(typeof(PaintBaseItem), 2, typeof(PaintingSkill))
                    },
                 new CraftingElement<WhitePaintItem>(4)

                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(WhitePaintRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Base - White"), typeof(WhitePaintRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #endregion

    #region Sub Colors
    #region Purple
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Purple Paint")]
    public partial class PurplePaintItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Purple Paint Used for Painting Certain Items."); } }

        static PurplePaintItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class PurplePaintRecipe : RecipeFamily
    {
        public PurplePaintRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Mix - Purple",
                    Localizer.DoStr("Paint Mix - Purple"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(PurpleDyeItem), 2, true),
                new IngredientElement(typeof(PaintBaseItem), 2, typeof(PaintingSkill))
                    },
                 new CraftingElement<PurplePaintItem>(4)

                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(PurplePaintRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Mix - Purple"), typeof(PurplePaintRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Green
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Green Paint")]
    public partial class GreenPaintItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Green Paint Used for Painting Certain Items."); } }

        static GreenPaintItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class GreenPaintRecipe : RecipeFamily
    {
        public GreenPaintRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Mix - Green",
                    Localizer.DoStr("Paint Mix - Green"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(GreenDyeItem), 2, true),
                new IngredientElement(typeof(PaintBaseItem), 2, typeof(PaintingSkill))
                    },
                 new CraftingElement<GreenPaintItem>(4)

                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreenPaintRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Mix - Green"), typeof(GreenPaintRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Brown
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Brown Paint")]
    public partial class BrownPaintItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Brown Paint Used for Painting Certain Items."); } }

        static BrownPaintItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class BrownPaintRecipe : RecipeFamily
    {
        public BrownPaintRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Mix - Brown",
                    Localizer.DoStr("Paint Mix - Brown"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(BrownDyeItem), 2, true),
                new IngredientElement(typeof(PaintBaseItem), 2, typeof(PaintingSkill))
                    },
                 new CraftingElement<BrownPaintItem>(4)

                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BrownPaintRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Mix - Brown"), typeof(BrownPaintRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Orange
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Orange Paint")]
    public partial class OrangePaintItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Orange Paint Used for Painting Certain Items."); } }

        static OrangePaintItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class OrangePaintRecipe : RecipeFamily
    {
        public OrangePaintRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Mix - Orange",
                    Localizer.DoStr("Paint Mix - Orange"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(OrangeDyeItem), 2, true),
                new IngredientElement(typeof(PaintBaseItem), 2, typeof(PaintingSkill))
                    },
                 new CraftingElement<OrangePaintItem>(4)

                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(OrangePaintRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Mix - Orange"), typeof(OrangePaintRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Grey
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Grey Paint")]
    public partial class GreyPaintItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Grey Paint Used for Painting Certain Items."); } }

        static GreyPaintItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class GreyPaintRecipe : RecipeFamily
    {
        public GreyPaintRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Mix - Grey",
                    Localizer.DoStr("Paint Mix - Grey"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(GreyDyeItem), 2, true),
                new IngredientElement(typeof(PaintBaseItem), 2, typeof(PaintingSkill))
                    },
                 new CraftingElement<GreyPaintItem>(4)

                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreyPaintRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Mix - Grey"), typeof(GreyPaintRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Pink
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Pink Paint")]
    public partial class PinkPaintItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Pink Paint Used for Painting Certain Items."); } }

        static PinkPaintItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class PinkPaintRecipe : RecipeFamily
    {
        public PinkPaintRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Mix - Pink",
                    Localizer.DoStr("Paint Mix - Pink"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(PinkDyeItem), 2, true),
                new IngredientElement(typeof(PaintBaseItem), 2, typeof(PaintingSkill))
                    },
                 new CraftingElement<PinkPaintItem>(4)

                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(PinkPaintRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Mix - Pink"), typeof(PinkPaintRecipe));
            this.ModsPreInitialize();
            CraftingComponent.AddRecipe(typeof(DyeTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #endregion
}
