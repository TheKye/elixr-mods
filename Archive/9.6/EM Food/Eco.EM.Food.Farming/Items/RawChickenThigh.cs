using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [Tag("Chicken")]
    [LocDisplayName("Raw Chicken Thighs")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class RawChickenThighItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Raw Chicken Thighs, This butcher is good.");

        private static readonly FoodItemModel defaults = new(typeof(RawChickenThighItem), "Raw Chicken Thighs", shelflife: 24, calories: -100, carbs: 0, fat: 0, protein: 0, vitamins: 0);

        public override float Calories => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);

        protected override int BaseShelfLife => throw new NotImplementedException();

        static RawChickenThighItem() => EMFoodItemResolver.AddDefaults(defaults);
    }
}
