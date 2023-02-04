namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Mods.TechTree;

    [RequiresSkill(typeof(CementSkill), 0)]
    public partial class SlagConcreteRecipe : Recipe
    {
        public SlagConcreteRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ConcreteItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(CementSkill), 30, CementSkill.MultiplicativeStrategy),
                new CraftingElement<SlagItem> (typeof(CementSkill), 10, CementSkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SlagConcreteRecipe), Item.Get<ConcreteItem>().UILink(), 2, typeof(CementSkill), typeof(CementFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Concrete"), typeof(SlagConcreteRecipe));

            CraftingComponent.AddRecipe(typeof(CementKilnObject), this);
        }
    }

    [Serialized]
    [Weight(500)]
    public partial class SlagItem : Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Slag"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Slag"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("The bi-product of smelting washed ores."); } }

    }
}