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
    public partial class CopperFragmentsRecipe : Recipe
    {
        public CopperFragmentsRecipe()
        {
            this.Products = new CraftingElement[]
            {
            new CraftingElement<CopperFragmentsItem>(10),          
            new CraftingElement<SlagItem>(4)

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TailingsItem>(10)
            };
            this.ExperienceOnCraft = 2;  

            this.CraftMinutes = CreateCraftTimeValue(typeof(CopperFragmentsRecipe), Item.Get<CopperFragmentsItem>().UILink(), 25, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Copper Fragments"), typeof(CopperFragmentsRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }

    [Serialized]
    [Weight(10)]
    [Currency]
    [MaxStackSize(500)]
    public partial class CopperFragmentsItem :
    Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Copper Fragment"); } }
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Copper Fragments"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Shards Of Copper Produced From Tailings."); } }
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]
    public partial class CopperFragmentsToCopperRecipe : Recipe
    {
        public CopperFragmentsToCopperRecipe()
        {
            this.Products = new CraftingElement[]
            {
            new CraftingElement<CopperIngotItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CopperFragmentsItem>(100)
            };
            this.ExperienceOnCraft = 2;

            this.CraftMinutes = CreateCraftTimeValue(typeof(CopperFragmentsToCopperRecipe), Item.Get<CopperIngotItem>().UILink(), 25, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent)); ;
            this.Initialize(Localizer.DoStr("Copper Fragments To Copper"), typeof(CopperFragmentsRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }

}