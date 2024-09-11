using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Cafe
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Coffee Bean")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class CoffeeBeanItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Mmmmm, Smells good!");

        private static readonly FoodItemModel defaults = new(typeof(CoffeeBeanItem), "Coffee Bean", calories: 400, carbs: 1, fat: 6, protein: 1, shelflife: 102, vitamins: 4);

        public override float Calories => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);
        protected override float BaseShelfLife => EMFoodItemResolver.Obj.ResolveShelfLife(this);
        static CoffeeBeanItem() => EMFoodItemResolver.AddDefaults(defaults);
    }
}
