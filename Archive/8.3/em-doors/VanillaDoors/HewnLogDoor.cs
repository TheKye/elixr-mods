namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
    using System;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.EM.Components;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class HewnLogDoorObject :
        AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Hewn Log Door"); } } 

        public virtual Type RepresentedItemType { get { return typeof(HewnLogDoorItem); } } 

        public override bool HasTier { get { return true; } } 
        public override int Tier { get { return 1; } } 


        protected override void Initialize()
        {
            base.Initialize(); 


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [ItemTier(1)]                                      
    public partial class HewnLogDoorItem :
        WorldObjectItem<HewnLogDoorObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Hewn Log Door"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A door made from roughly hewn logs."); } }

        static HewnLogDoorItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(HewingSkill), 1)]      
    public partial class HewnLogDoorRecipe : Recipe
    {
        public HewnLogDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<HewnLogDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(typeof(HewingSkill), 12, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent)),          
            };
            this.ExperienceOnCraft = 3;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(HewnLogDoorRecipe), Item.Get<HewnLogDoorItem>().UILink(), 3, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Hewn Log Door"), typeof(HewnLogDoorRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}