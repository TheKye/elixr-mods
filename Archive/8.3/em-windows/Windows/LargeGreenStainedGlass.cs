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
    public partial class LargeGreenStainedGlassObject : 
        WorldObject    
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Green Stained Glass"); } }
        protected override void Initialize()
        {                             

        }

		static LargeGreenStainedGlassObject()
		{
            WorldObject.AddOccupancy<LargeGreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(StainedGlassObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(StainedGlassObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(StainedGlassObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, -1), typeof(StainedGlassObjectBlock)),
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
    public partial class LargeGreenStainedGlassItem : WorldObjectItem<LargeGreenStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Green Stained Glass"); } } 
        public override LocString DisplayDescription { get { return  Localizer.DoStr("A 2x2 Decorative Green Stained Glass Window."); } }

        static LargeGreenStainedGlassItem()
        {
            
        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 3)] 
    public partial class LargeGreenStainedGlassRecipe : Recipe
    {
        public LargeGreenStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeGreenStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GreenStainedGlassItem>(typeof(GlassworkingSkill), 10, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LargeFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeGreenStainedGlassRecipe), Item.Get<LargeGreenStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Large Stained Glass - Green"), typeof(LargeGreenStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
		
}