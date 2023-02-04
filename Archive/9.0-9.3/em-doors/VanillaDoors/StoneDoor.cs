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
    public partial class StoneDoorObject :
        AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Stone Door"); } } 

        public virtual Type RepresentedItemType { get { return typeof(StoneDoorItem); } } 

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
    public partial class StoneDoorItem :
        WorldObjectItem<StoneDoorObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Stone Door"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A heavy stone door."); } }

        static StoneDoorItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(MortaringSkill), 1)]      
    public partial class StoneDoorRecipe : Recipe
    {
        public StoneDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<StoneDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(MortaringSkill), 50, MortaringSkill.MultiplicativeStrategy, typeof(MortaringLavishResourcesTalent)),          
            };
            this.ExperienceOnCraft = 3;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(StoneDoorRecipe), Item.Get<StoneDoorItem>().UILink(), 3, typeof(MortaringSkill), typeof(MortaringFocusedSpeedTalent), typeof(MortaringParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Stone Door"), typeof(StoneDoorRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
} 