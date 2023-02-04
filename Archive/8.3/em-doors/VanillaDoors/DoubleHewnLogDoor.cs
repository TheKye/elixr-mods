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
    public partial class DoubleHewnLogDoorObject :
        AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Double Hewn Log Door"); } } 

        public virtual Type RepresentedItemType { get { return typeof(DoubleHewnLogDoorItem); } } 

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
    public partial class DoubleHewnLogDoorItem :
        WorldObjectItem<DoubleHewnLogDoorObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Double Hewn Log Door"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A double door made from rough hewn logs."); } }

        static DoubleHewnLogDoorItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(HewingSkill), 1)]      
    public partial class DoubleHewnLogDoorRecipe : Recipe
    {
        public DoubleHewnLogDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DoubleHewnLogDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HewnLogItem>(typeof(HewingSkill), 24, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent)),          
            };
            this.ExperienceOnCraft = 3;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(DoubleHewnLogDoorRecipe), Item.Get<DoubleHewnLogDoorItem>().UILink(), 3, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Double Hewn Log Door"), typeof(DoubleHewnLogDoorRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}