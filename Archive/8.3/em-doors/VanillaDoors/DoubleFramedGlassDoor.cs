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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class DoubleFramedGlassDoorObject :
    AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Double Framed Glass Door"); } } 

        public virtual Type RepresentedItemType { get { return typeof(DoubleFramedGlassDoorItem); } } 

        public override bool HasTier { get { return true; } } 
        public override int Tier { get { return 4; } } 


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
    [ItemTier(4)]                                      
    public partial class DoubleFramedGlassDoorItem :
        WorldObjectItem<DoubleFramedGlassDoorObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Double Framed Glass Door"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A beautiful glass double door made of steel and glass."); } }

        static DoubleFramedGlassDoorItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(GlassworkingSkill), 1)]      
    public partial class DoubleFramedGlassDoorRecipe : Recipe
    {
        public DoubleFramedGlassDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DoubleFramedGlassDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FramedGlassItem>(typeof(GlassworkingSkill), 24, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),          
            };
            this.ExperienceOnCraft = 3;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(DoubleFramedGlassDoorRecipe), Item.Get<DoubleFramedGlassDoorItem>().UILink(), 20, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Double Framed Glass Door"), typeof(DoubleFramedGlassDoorRecipe));
            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
    }
}