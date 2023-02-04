namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;

    [Serialized]
    [Weight(500)]                                          
    public partial class CreamItem :
        FoodItem            
    {
        public override LocString DisplayName                     { get { return Localizer.DoStr("Cream"); } }
        public override LocString DisplayDescription                     { get { return Localizer.DoStr("Fluffy Cream a byproduct of making milk"); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 4, Protein = 2, Vitamins = 4};
        public override float Calories                          { get { return 650; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}