namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
    using System;
    using Eco.EM.Components;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]              
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class DoorObject :
       AutoDoors.AutoDoor
    {
         public override LocString DisplayName { get { return Localizer.DoStr("Door"); } } 

        public virtual Type RepresentedItemType { get { return typeof(DoorItem); } } 

        public override bool HasTier { get { return true; } } 
        public override int Tier { get { return 1; } } 


        protected override void Initialize()
        {   

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [ItemTier(1)]                                      
    public partial class DoorItem :
        WorldObjectItem<DoorObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Door"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A sturdy wooden door. Can be locked for certain players."); } }

        static DoorItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(HewingSkill), 0)]      
    public partial class DoorRecipe : Recipe
    {
        public DoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(HewingSkill), 12, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent)),          
            };
            this.ExperienceOnCraft = 2;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(DoorRecipe), Item.Get<DoorItem>().UILink(), 5, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Door"), typeof(DoorRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}