namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.EM.Components;

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]                   
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LargeWindowedLumberDoorObject :
        AutoDoors.LAutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Windowed Lumber Door"); } } 

        public virtual Type RepresentedItemType { get { return typeof(LargeWindowedLumberDoorItem); } } 

        public override bool HasTier { get { return true; } } 
        public override int Tier { get { return 2; } } 


        protected override void Initialize()
        {


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [ItemTier(2)]                                      
    public partial class LargeWindowedLumberDoorItem :
        WorldObjectItem<LargeWindowedLumberDoorObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Windowed Lumber Door"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A large door."); } }

        static LargeWindowedLumberDoorItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(LumberSkill), 3)]      
    public partial class LargeWindowedLumberDoorRecipe : Recipe
    {
        public LargeWindowedLumberDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeWindowedLumberDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberSkill), 20, LumberSkill.MultiplicativeStrategy, typeof(LumberLavishResourcesTalent)),
                new CraftingElement<GlassItem>(typeof(LumberSkill), 20, LumberSkill.MultiplicativeStrategy, typeof(LumberLavishResourcesTalent)),          
            };
            this.ExperienceOnCraft = 5;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeWindowedLumberDoorRecipe), Item.Get<LargeWindowedLumberDoorItem>().UILink(), 30, typeof(LumberSkill), typeof(LumberFocusedSpeedTalent), typeof(LumberParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Large Windowed Lumber Door"), typeof(LargeWindowedLumberDoorRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}