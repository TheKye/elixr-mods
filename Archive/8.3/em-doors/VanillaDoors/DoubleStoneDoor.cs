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
    public partial class DoubleStoneDoorObject :
        AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Double Stone Door"); } } 

        public virtual Type RepresentedItemType { get { return typeof(DoubleStoneDoorItem); } } 

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
    public partial class DoubleStoneDoorItem :
        WorldObjectItem<DoubleStoneDoorObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Double Stone Door"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A heavy double stone door."); } }

        static DoubleStoneDoorItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(MortaringSkill), 1)]      
    public partial class DoubleStoneDoorRecipe : Recipe
    {
        public DoubleStoneDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DoubleStoneDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(MortaringSkill), 100, MortaringSkill.MultiplicativeStrategy, typeof(MortaringLavishResourcesTalent)),          
            };
            this.ExperienceOnCraft = 3;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(DoubleStoneDoorRecipe), Item.Get<DoubleStoneDoorItem>().UILink(), 3, typeof(MortaringSkill), typeof(MortaringFocusedSpeedTalent), typeof(MortaringParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Double Stone Door"), typeof(DoubleStoneDoorRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
} 