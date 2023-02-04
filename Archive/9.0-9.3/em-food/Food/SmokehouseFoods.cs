using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Food
{
    [Serialized]
    [Weight(300)]
    [MaxStackSize(100)]
    [LocDisplayName("Jerky")]
    public partial class JerkyItem : FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Lean, salty and dry.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 5, Fat = 5, Protein = 10, Vitamins = 5};
        public override float Calories                          => 700;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class JerkyRecipe : RecipeFamily
    {
        private string rName = "Jerky";
        private Type skillBase = typeof(CookingSkill);
        private Type ingTalent = typeof(CookingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) };
        
        public JerkyRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(RawSausageItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(CamasPasteItem), 5, skillBase, ingTalent),
                },
                 new CraftingElement<JerkyItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(25f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 5f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SmokehouseObject), this);           
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[Serialized]
    [Weight(1000)]
    [MaxStackSize(100)]
    [LocDisplayName("Meat Pizza")]
    public partial class MeatFiredPizzaItem : FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Heart attack on a round base");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 10, Fat = 7, Protein = 9, Vitamins = 3};
        public override float Calories                          => 1250;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 4)]    
    public partial class MeatFiredPizzaRecipe : RecipeFamily
    {
        private string rName = "Meat Pizza";
        private Type skillBase = typeof(CookingSkill);
        private Type ingTalent = typeof(CookingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) };

        public MeatFiredPizzaRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(FlatbreadItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(SmokedBaconItem), 4, skillBase, ingTalent),
                    new IngredientElement(typeof(FriedTomatoesItem), 4, skillBase, ingTalent),
                },
                 new CraftingElement<MeatFiredPizzaItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(25f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 10f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SmokehouseObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Smoked Bacon")]
    public partial class SmokedBaconItem : FoodItem            
    {
        public override LocString DisplayNamePlural             => Localizer.DoStr("Smoked Bacon");
        public override LocString DisplayDescription            => Localizer.DoStr("Bacon! Bacon! Bacon!.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 15, Protein = 17, Vitamins = 0};
        public override float Calories                          => 500;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 3)]    
    public partial class SmokedBaconRecipe : RecipeFamily
    {
        private string rName = "Smoked Bacon";
        private Type skillBase = typeof(CookingSkill);
        private Type ingTalent = typeof(CookingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) };

        public SmokedBaconRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(RawBaconItem), 1, false),
                },
                 new CraftingElement<SmokedBaconItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(25f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SmokehouseObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[Serialized]
    [Weight(150)]
    [MaxStackSize(100)]
    [LocDisplayName("Smoked Vegetable Kabob")]
    public partial class SmokedVegetableKabobItem : FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Smoked Vegetable Kabob");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 5, Fat = 5, Protein = 5, Vitamins = 5};
        public override float Calories                          => 650;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 1)]    
    public partial class SmokedVegetableKabobRecipe : RecipeFamily
    {
        private string rName = "Smoked Vegetable Kabob";
        private Type skillBase = typeof(CookingSkill);
        private Type ingTalent = typeof(CookingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) };

        public SmokedVegetableKabobRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BeetItem), 10, skillBase, ingTalent),
                    new IngredientElement(typeof(CriminiMushroomsItem), 10, skillBase, ingTalent),
                    new IngredientElement(typeof(TomatoItem), 10, skillBase, ingTalent),
                },
                 new CraftingElement<SmokedVegetableKabobItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(25f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SmokehouseObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Smoked Fish")]
    public partial class SmokedFishItem : FoodItem            
    {
        public override LocString DisplayNamePlural             => Localizer.DoStr("Smoked Fish");
        public override LocString DisplayDescription            => Localizer.DoStr("Smoke me a kipper, I'll be back for breakfast.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 8, Protein = 12, Vitamins = 0};
        public override float Calories                          => 400;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 1)]    
    public partial class SmokedFishRecipe : RecipeFamily
    {
        private string rName = "Smoked Fish";
        private Type skillBase = typeof(CookingSkill);
        private Type ingTalent = typeof(CookingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) };

        public SmokedFishRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(RawFishItem), 1, false),
                },
                 new CraftingElement<SmokedFishItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(25f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SmokehouseObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Weight(1000)]
    [MaxStackSize(100)]
    [LocDisplayName("Smoked Hare Surprise")]
    public partial class SmokedHareSurpriseItem : FoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("A smokin' hot bunny with twist.");

        private static Nutrients nutrition = new Nutrients() { Carbs = 5, Fat = 7, Protein = 7, Vitamins = 5 };
        public override float Calories => 600;
        public override Nutrients Nutrition => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 4)]    
    public partial class SmokedHareSurpriseRecipe : RecipeFamily
    {
        private string rName = "Smoked Hare Surprise";
        private Type skillBase = typeof(CookingSkill);
        private Type ingTalent = typeof(CookingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) };

        public SmokedHareSurpriseRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(PrimeCutItem), 2, skillBase, ingTalent),
                    new IngredientElement(typeof(VegetableJerkyItem), 4, skillBase, ingTalent),
                    new IngredientElement(typeof(HareCarcassItem), 1, false),
                },
                 new CraftingElement<SmokedHareSurpriseItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(50f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 30f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SmokehouseObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[Serialized]
    [Weight(1000)]
    [MaxStackSize(100)]
    [LocDisplayName("Smoked Turkey Surprise")]
    public partial class SmokedTurkeySurpriseItem : FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("A smokin' hot bird with twist.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 5, Fat = 7, Protein = 7, Vitamins = 5};
        public override float Calories                          => 600;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 4)]    
    public partial class SmokedTurkeySurpriseRecipe : RecipeFamily
    {
        private string rName = "Smoked Turkey Surprise";
        private Type skillBase = typeof(CookingSkill);
        private Type ingTalent = typeof(CookingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) };

        public SmokedTurkeySurpriseRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(TurkeyCarcassItem), 1, false),
                    new IngredientElement(typeof(VegetableJerkyItem), 4, skillBase, ingTalent),
                    new IngredientElement(typeof(PrimeCutItem), 8, skillBase, ingTalent),
                },
                 new CraftingElement<SmokedTurkeySurpriseItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(50f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 30f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SmokehouseObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[Serialized]
    [Weight(300)]
    [MaxStackSize(100)]
    [LocDisplayName("Turkey Jerky")]
    public partial class TurkeyJerkyItem : FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Rich, salty and dry.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 5, Fat = 10, Protein = 10, Vitamins = 5};
        public override float Calories                          => 500;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 3)]    
    public partial class TurkeyJerkyRecipe : RecipeFamily
    {
        private string rName = "Turkey Jerky";
        private Type skillBase = typeof(CookingSkill);
        private Type ingTalent = typeof(CookingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) };

        public TurkeyJerkyRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(TurkeyCarcassItem), 1, false),
                    new IngredientElement(typeof(CamasPasteItem), 10, skillBase, ingTalent),
                },
                 new CraftingElement<TurkeyJerkyItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(25f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SmokehouseObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[Serialized]
    [Weight(1000)]
    [MaxStackSize(100)]
    [LocDisplayName("Vegetable Pizza")]
    public partial class VegetableFiredPizzaItem : FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("A pizza, say no more.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 10, Fat = 5, Protein = 5, Vitamins = 10};
        public override float Calories                          => 800;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 4)]    
    public partial class VegetableFiredPizzaRecipe : RecipeFamily
    {
        private string rName = "Vegetable Pizza";
        private Type skillBase = typeof(CookingSkill);
        private Type ingTalent = typeof(CookingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) };

        public VegetableFiredPizzaRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(FlatbreadItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(VegetableMedleyItem), 4, skillBase, ingTalent),
                    new IngredientElement(typeof(FriedTomatoesItem), 4, skillBase, ingTalent),
                },
                 new CraftingElement<VegetableFiredPizzaItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(25f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 10f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SmokehouseObject), this);       
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[Serialized]
    [Weight(300)]
    [MaxStackSize(100)]
    [LocDisplayName("Vegetable Jerky")]
    public partial class VegetableJerkyItem : FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Vegetarian, salty and dry.");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 0, Protein = 0, Vitamins = 12};
        public override float Calories                          => 400;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 2)]    
    public partial class VegetableJerkyRecipe : RecipeFamily
    {
        private string rName = "Vegetable Jerky";
        private Type skillBase = typeof(CookingSkill);
        private Type ingTalent = typeof(CookingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent) };

        public VegetableJerkyRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BeanPasteItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(CriminiMushroomsItem), 5, skillBase, ingTalent),
                    new IngredientElement(typeof(CamasPasteItem), 5, skillBase, ingTalent),
                },
                 new CraftingElement<VegetableJerkyItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(25f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SmokehouseObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}