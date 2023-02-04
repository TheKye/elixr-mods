using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;

namespace Eco.EM.Artistry
{
    #region Primary colors
    #region Black
    [Serialized]
    [Currency]
    [MaxStackSize(100)]
    [LocDisplayName("Black Dye")]
    public partial class BlackDyeItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Black Dye used for dying certain items."); } }

        static BlackDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class BlackDyeRecipe : RecipeFamily
    {
        public BlackDyeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dye Base - Black",
                    Localizer.DoStr("Dye Base - Black"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(CoalItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
                    },
                 new CraftingElement<BlackDyeItem>(4),
                new CraftingElement<BucketItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlackDyeRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Base - Black"), typeof(BlackDyeRecipe));
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
    [LocDisplayName("Yellow Dye")]
    public partial class YellowDyeItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Yellow Dye Used for Dying Certain Items."); } }

        static YellowDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class YellowDyeRecipe : RecipeFamily
    {
        public YellowDyeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dye Base - Yellow",
                    Localizer.DoStr("Dye Base - Yellow"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PineappleItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
                    },
                 new CraftingElement<YellowDyeItem>(4),
                new CraftingElement<BucketItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(YellowDyeRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Base - Yellow"), typeof(YellowDyeRecipe));
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
    [LocDisplayName("Blue Dye")]
    public partial class BlueDyeItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Blue Dye Used for Dying Certain Items."); } }

        static BlueDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class BlueDyeRecipe : RecipeFamily
    {
        public BlueDyeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dye Base - Blue",
                    Localizer.DoStr("Dye Base - Blue"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(HuckleberriesItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
                    },
                 new CraftingElement<BlueDyeItem>(4),
                new CraftingElement<BucketItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlueDyeRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Base - Blue"), typeof(BlueDyeRecipe));
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
    [LocDisplayName("Red Dye")]
    public partial class RedDyeItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Red Dye Used for Dying Certain Items."); } }

        static RedDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class RedDyeRecipe : RecipeFamily
    {
        public RedDyeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dye Base - Red",
                    Localizer.DoStr("Dye Base - Red"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(TomatoItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
                    },
                 new CraftingElement<RedDyeItem>(4),
                new CraftingElement<BucketItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(RedDyeRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Base - Red"), typeof(RedDyeRecipe));
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
    [LocDisplayName("White Dye")]
    public partial class WhiteDyeItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("White Dye Used for Dying Certain Items."); } }

        static WhiteDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 1)]
    public partial class WhiteDyeRecipe : RecipeFamily
    {
        public WhiteDyeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dye Base - White",
                    Localizer.DoStr("Dye Base - White"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
                    },
                 new CraftingElement<WhiteDyeItem>(4),
                new CraftingElement<BucketItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(WhiteDyeRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Base - White"), typeof(WhiteDyeRecipe));
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
    [LocDisplayName("Purple Dye")]
    public partial class PurpleDyeItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Purple Dye Used for Dying Certain Items."); } }

        static PurpleDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class PurpleDyeRecipe : RecipeFamily
    {
        public PurpleDyeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dye Mix - Purple",
                    Localizer.DoStr("Dye Mix - Purple"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(BlueDyeItem), 1, true),
                new IngredientElement(typeof(RedDyeItem), 1, true),
                    },
                 new CraftingElement<PurpleDyeItem>(2)
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(PurpleDyeRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Mix - Purple"), typeof(PurpleDyeRecipe));
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
    [LocDisplayName("Green Dye")]
    public partial class GreenDyeItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Green Dye Used for Dying Certain Items."); } }

        static GreenDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class GreenDyeRecipe : RecipeFamily
    {
        public GreenDyeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dye Mix - Green",
                    Localizer.DoStr("Dye Mix - Green"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(YellowDyeItem), 1, true),
                new IngredientElement(typeof(BlueDyeItem), 1, true)
                    },
                 new CraftingElement<GreenDyeItem>(2)
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreenDyeRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Mix - Green"), typeof(GreenDyeRecipe));
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
    [LocDisplayName("Brown Dye")]
    public partial class BrownDyeItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Brown Dye Used for Dying Certain Items."); } }

        static BrownDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class BrownDyeRecipe : RecipeFamily
    {
        public BrownDyeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dye Mix - Brown",
                    Localizer.DoStr("Dye Mix - Brown"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(BlueDyeItem), 1, true),
                new IngredientElement(typeof(RedDyeItem), 1, true),
                new IngredientElement(typeof(YellowDyeItem), 1, true)
                    },
                 new CraftingElement<BrownDyeItem>(3)
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(BrownDyeRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Mix - Brown"), typeof(BrownDyeRecipe));
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
    [LocDisplayName("Orange Dye")]
    public partial class OrangeDyeItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Orange Dye Used for Dying Certain Items."); } }

        static OrangeDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class OrangeDyeRecipe : RecipeFamily
    {
        public OrangeDyeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dye Mix - Orange",
                    Localizer.DoStr("Dye Mix - Orange"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(RedDyeItem), 1, true),
                new IngredientElement(typeof(YellowDyeItem), 1, true)
                    },
                 new CraftingElement<OrangeDyeItem>(2)
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(OrangeDyeRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Mix - Orange"), typeof(OrangeDyeRecipe));
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
    [LocDisplayName("Grey Dye")]
    public partial class GreyDyeItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Grey Dye Used for Dying Certain Items."); } }

        static GreyDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class GreyDyeRecipe : RecipeFamily
    {
        public GreyDyeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dye Mix - Grey",
                    Localizer.DoStr("Dye Mix - Grey"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(BlackDyeItem), 1, true),
                new IngredientElement(typeof(WhiteDyeItem), 1, true)
                    },
                 new CraftingElement<GreyDyeItem>(2)
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreyDyeRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Mix - Grey"), typeof(GreyDyeRecipe));
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
    [LocDisplayName("Pink Dye")]
    public partial class PinkDyeItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Pink Dye Used for Dying Certain Items."); } }

        static PinkDyeItem()
        {

        }
    }

    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class PinkDyeRecipe : RecipeFamily
    {
        public PinkDyeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Dye Mix - Pink",
                    Localizer.DoStr("Dye Mix - Pink"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(RedDyeItem), 1, true),
                new IngredientElement(typeof(WhiteDyeItem), 1, true)
                    },
                 new CraftingElement<PinkDyeItem>(2)
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaintingSkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(PinkDyeRecipe), 2, typeof(PaintingSkill), typeof(PaintingFocusedSpeedTalent), typeof(PaintingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dye Mix - Pink"), typeof(PinkDyeRecipe));
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

    #region Primary Colors Recipe Variants
    #region Black
    //Black(Coal, Crushed Shale)
    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class BlackDye2Recipe : Recipe
    {
        public BlackDye2Recipe()
        {
            var product = new Recipe(
            "Dye Base - Black - Alt",
            Localizer.DoStr("Dye Base - Black - Alt"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(CrushedShaleItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<BlackDyeItem>(4),
                new CraftingElement<BucketItem>()
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(DyeTableObject), typeof(BlackDyeRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Yellow
    //Yellow(Pineapple, Corn, Sand)
    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class YellowDye2Recipe : Recipe
    {
        public YellowDye2Recipe()
        {
            var product = new Recipe(
            "Dye Base - Yellow - Alt",
            Localizer.DoStr("Dye Base - Yellow - Alt"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(CornItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<YellowDyeItem>(4),
                new CraftingElement<BucketItem>()
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(DyeTableObject), typeof(YellowDyeRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class YellowDye3Recipe : Recipe
    {
        public YellowDye3Recipe()
        {
            var product = new Recipe(
            "Dye Base - Yellow - Alt 2",
            Localizer.DoStr("Dye Base - Yellow - Alt 2"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(SandItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<YellowDyeItem>(4),
                new CraftingElement<BucketItem>()
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(DyeTableObject), typeof(YellowDyeRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Blue
    //Blue(Huckleberries, Camas, Crushed Basalt)
    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class BlueDye2Recipe : Recipe
    {
        public BlueDye2Recipe()
        {
            var product = new Recipe(
            "Dye Base - Blue - Alt",
            Localizer.DoStr("Dye Base - Blue - Alt"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(CamasBulbItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<BlueDyeItem>(4),
                new CraftingElement<BucketItem>()
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(DyeTableObject), typeof(BlueDyeRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class BlueDye3Recipe : Recipe
    {
        public BlueDye3Recipe()
        {
            var product = new Recipe(
            "Dye Base - Blue - Alt 2",
            Localizer.DoStr("Dye Base - Blue - Alt 2"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(CrushedBasaltItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<BlueDyeItem>(4),
                new CraftingElement<BucketItem>()
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(DyeTableObject), typeof(BlueDyeRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region Red
    //Red (Tomatoes, Beets, Crushed Sandstone)
    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class RedDye2Recipe : Recipe
    {
        public RedDye2Recipe()
        {
            var product = new Recipe(
            "Dye Base - Red - Alt",
            Localizer.DoStr("Dye Base - Red - Alt"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BeetItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<RedDyeItem>(4),
                new CraftingElement<BucketItem>()
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(DyeTableObject), typeof(RedDyeRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class RedDye3Recipe : Recipe
    {
        public RedDye3Recipe()
        {
            var product = new Recipe(
            "Dye Base - Red - Alt 2",
            Localizer.DoStr("Dye Base - Red - Alt 2"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(CrushedSandstoneItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<RedDyeItem>(4),
                new CraftingElement<BucketItem>()
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(DyeTableObject), typeof(RedDyeRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion

    #region White
    //White(Paper, Crushed Limestone)
    [RequiresSkill(typeof(PaintingSkill), 2)]
    public partial class WhiteDye2Recipe : Recipe
    {
        public WhiteDye2Recipe()
        {
            var product = new Recipe(
            "Dye Base - White - Alt",
            Localizer.DoStr("Dye Base - White - Alt"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(ClothItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(CrushedLimestoneItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(PlantFibersItem), 25, typeof(PaintingSkill)),
                new IngredientElement(typeof(PaperItem), 5, typeof(PaintingSkill)),
                new IngredientElement(typeof(BucketOfWaterItem), 1, true)
            },
            new CraftingElement[]
            {
                new CraftingElement<WhiteDyeItem>(4),
                new CraftingElement<BucketItem>()
            }
            );
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(DyeTableObject), typeof(WhiteDyeRecipe), product);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
    #endregion
    #endregion
}
