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
    public partial class FramedGlassDoorObject :
    AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Framed Glass Door"); } } 

        public virtual Type RepresentedItemType { get { return typeof(FramedGlassDoorItem); } } 

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
    public partial class FramedGlassDoorItem :
        WorldObjectItem<FramedGlassDoorObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Framed Glass Door"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A beautiful glass door made of steel and glass."); } }

        static FramedGlassDoorItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(GlassworkingSkill), 1)]      
    public partial class FramedGlassDoorRecipe : Recipe
    {
        public FramedGlassDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FramedGlassDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FramedGlassItem>(typeof(GlassworkingSkill), 12, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),          
            };
            this.ExperienceOnCraft = 3;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(FramedGlassDoorRecipe), Item.Get<FramedGlassDoorItem>().UILink(), 20, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Framed Glass Door"), typeof(FramedGlassDoorRecipe));
            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
    }

    [Serialized]
    [Wall, Solid]
    public class FramedGlassDoorBlock : BuildingWorldObjectBlock
    {
        public FramedGlassDoorBlock(WorldObject obj)
            : base(obj)
        { }

        protected FramedGlassDoorBlock()
        { }
    }
}