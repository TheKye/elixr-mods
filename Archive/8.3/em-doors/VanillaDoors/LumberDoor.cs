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
    public partial class LumberDoorObject :
        AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Lumber Door"); } } 

        public virtual Type RepresentedItemType { get { return typeof(LumberDoorItem); } } 

        public override bool HasTier { get { return true; } } 
        public override int Tier { get { return 2; } } 

        
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
    [ItemTier(2)]                                      
    public partial class LumberDoorItem :
        WorldObjectItem<LumberDoorObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Lumber Door"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A door made from finely cut lumber."); } }

        static LumberDoorItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(LumberSkill), 1)]      
    public partial class LumberDoorRecipe : Recipe
    {
        public LumberDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LumberDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberSkill), 20, LumberSkill.MultiplicativeStrategy, typeof(LumberLavishResourcesTalent)),          
            };
            this.ExperienceOnCraft = 3;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(LumberDoorRecipe), Item.Get<LumberDoorItem>().UILink(), 3, typeof(LumberSkill), typeof(LumberFocusedSpeedTalent), typeof(LumberParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Lumber Door"), typeof(LumberDoorRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}