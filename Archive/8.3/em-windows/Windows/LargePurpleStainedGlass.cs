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
    public partial class LargePurpleStainedGlassObject : 
        WorldObject    
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Purple Stained Glass"); } }

        protected override void Initialize()
        {                             

        }

		static LargePurpleStainedGlassObject()
		{
            WorldObject.AddOccupancy<LargePurpleStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(LargeStainedGlassObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(LargeStainedGlassObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(LargeStainedGlassObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, -1), typeof(LargeStainedGlassObjectBlock)),
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
    public partial class LargePurpleStainedGlassItem : WorldObjectItem<LargePurpleStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Purple Stained Glass"); } } 
        public override LocString DisplayDescription { get { return  Localizer.DoStr("Decorative 1x2 Purple Stained Glass Window."); } }

        static LargePurpleStainedGlassItem()
        {
            
        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)] 
    public partial class LargePurpleStainedGlassRecipe : Recipe
    {
        public LargePurpleStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargePurpleStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PurpleStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LargeFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargePurpleStainedGlassRecipe), Item.Get<LargePurpleStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Large Stained Glass - Purple"), typeof(LargePurpleStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }

}