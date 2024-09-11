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

namespace Eco.EM.Food.Cafe
{
    [Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Goat Milk")]
    [Tag("Milk")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class GoatMilkItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Goat Milk, Not the best but it will have to do..");

        private static readonly FoodItemModel defaults = new(typeof(GoatMilkItem), "Goat Milk", calories: 55, carbs: 4, fat: 1, protein: 4, shelflife:72, vitamins: 2);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);
        protected override float BaseShelfLife => EMFoodItemResolver.Obj.ResolveShelfLife(this);
        static GoatMilkItem()                          => EMFoodItemResolver.AddDefaults(defaults);
    }
}