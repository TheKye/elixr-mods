using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Zymology
{
    [Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Low Fat Milk")]
    [Tag("Milk")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class LightMilkItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Low Fat Milk, Reduced Fat, Same Great Taste!");

        private static readonly FoodItemModel defaults = new(
            typeof(LightMilkItem), 
            "Low Fat Milk",
            shelflife: 24,
            calories: 200, 
            carbs: 5, 
            fat: 1, 
            protein: 3, 
            vitamins: 2
            );

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override float BaseShelfLife => throw new NotImplementedException();

        static LightMilkItem()                         => EMFoodItemResolver.AddDefaults(defaults);
    }

    //Todo Add Recipe to get Light Milk from Full Cream Milk via processing
}