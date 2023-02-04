namespace Eco.Mods.TechTree
{

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
    using Eco.World;
	

    [Serialized]    
    public partial class GreenStainedGlassObject : 
        WorldObject    
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Green Stained Glass"); } }

        protected override void Initialize()
        {                             

        }

		static GreenStainedGlassObject()
		{
            WorldObject.AddOccupancy<GreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(GreenStainedGlassObjectBlock)),
                });
        }
		
        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [ItemTier(2)]
    [Weight(600)]
    [MaxStackSize(10)]
    public partial class GreenStainedGlassItem : WorldObjectItem<GreenStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Green Stained Glass"); } } 
        public override LocString DisplayDescription { get { return  Localizer.DoStr("Green Decorative Stained Glass."); } }

        static GreenStainedGlassItem()
        {
            
        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 1)] 
    public partial class GreenStainedGlassRecipe : Recipe
    {
        public GreenStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GreenStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<GreenDyeItem>(2),
                new CraftingElement<FrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreenStainedGlassRecipe), Item.Get<GreenStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass - Green"), typeof(GreenStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }

    [Serialized]
    [Wall, Solid, Constructed]
    public class GreenStainedGlassObjectBlock : BuildingWorldObjectBlock
    {
        public GreenStainedGlassObjectBlock(WorldObject obj)
            : base(obj)
        { }

        protected GreenStainedGlassObjectBlock()
        { }
    }
}