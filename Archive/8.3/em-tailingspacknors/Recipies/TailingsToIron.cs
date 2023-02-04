namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
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

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]      
    public partial class IronFragmentsRecipe : Recipe
    {
        public IronFragmentsRecipe()
        {
            this.Products = new CraftingElement[]
            {
            new CraftingElement<IronFragmentsItem>(10),          
            new CraftingElement<SlagsItem>(4)

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TailingsItem>(10)
            };
            this.ExperienceOnCraft = 2;  

            this.CraftMinutes = CreateCraftTimeValue(typeof(IronFragmentsRecipe), Item.Get<IronFragmentsItem>().UILink(), 25, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent)); ;    
            this.Initialize(Localizer.DoStr("Iron Fragments"), typeof(IronFragmentsRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }

    [Serialized]
    [Weight(10)]
    [Currency]
    [MaxStackSize(500)]
    public partial class IronFragmentsItem :
    Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Iron Fragment"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Iron Fragments"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Shards Of Iron Produced From Tailings."); } }
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class IronFragmentsToIronRecipe : Recipe
    {
        public IronFragmentsToIronRecipe()
        {
            this.Products = new CraftingElement[]
            {
            new CraftingElement<IronIngotItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronFragmentsItem>(100)
            };
            this.ExperienceOnCraft = 2;

            this.CraftMinutes = CreateCraftTimeValue(typeof(IronFragmentsToIronRecipe), Item.Get<IronIngotItem>().UILink(), 25, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent)); ;
            this.Initialize(Localizer.DoStr("Iron Fragments To Iron"), typeof(IronFragmentsRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }
}