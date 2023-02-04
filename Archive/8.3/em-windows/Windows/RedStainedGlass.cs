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
    public partial class RedStainedGlassObject : 
        WorldObject    
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Red Stained Glass"); } }

        protected override void Initialize()
        {                             

        }

		static RedStainedGlassObject()
		{
            WorldObject.AddOccupancy<RedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(RedStainedGlassObjectBlock)),
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
    public partial class RedStainedGlassItem : WorldObjectItem<RedStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Red Stained Glass"); } } 
        public override LocString DisplayDescription { get { return  Localizer.DoStr("Decorative Red Stained Glass."); } }

        static RedStainedGlassItem()
        {
            
        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 1)] 
    public partial class RedStainedGlassRecipe : Recipe
    {
        public RedStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RedStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<RedDyeItem>(2),
                new CraftingElement<FrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RedStainedGlassRecipe), Item.Get<RedStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass - Red"), typeof(RedStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }

    [Serialized]
    [Wall, Solid, Constructed]
    public class RedStainedGlassObjectBlock : BuildingWorldObjectBlock
    {
        public RedStainedGlassObjectBlock(WorldObject obj)
            : base(obj)
        { }

        protected RedStainedGlassObjectBlock()
        { }
    }
}