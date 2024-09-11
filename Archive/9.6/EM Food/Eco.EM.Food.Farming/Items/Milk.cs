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

namespace Eco.EM.Food.Farming
{

    [Serialized]
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Full Cream Milk")]
    [Tag("Milk")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class FullCreamMilkItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription   => Localizer.DoStr("Full Cream Milk, Fresh From The Farm!");

        private static readonly FoodItemModel defaults = new(typeof(FullCreamMilkItem), "Full Cream Milk", shelflife: 24, calories: 250, carbs: 5, fat: 3, protein: 3, vitamins: 6);

        public override float Calories                 => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition            => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override int BaseShelfLife => throw new NotImplementedException();

        static FullCreamMilkItem()                     => EMFoodItemResolver.AddDefaults(defaults);
    }
}