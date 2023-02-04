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
    public partial class TallYellowStainedGlassObject : 
        WorldObject    
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Yellow Stained Glass"); } }

        protected override void Initialize()
        {                             

        }

		static TallYellowStainedGlassObject()
		{
            WorldObject.AddOccupancy<TallYellowStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(TallStainedGlassObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(TallStainedGlassObjectBlock)),
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
    public partial class TallYellowStainedGlassItem : WorldObjectItem<TallYellowStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Yellow Stained Glass"); } } 
        public override LocString DisplayDescription { get { return  Localizer.DoStr("Decorative 1x2 Yellow Stained Glass Window."); } }

        static TallYellowStainedGlassItem()
        {
            
        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)] 
    public partial class TallYellowStainedGlassRecipe : Recipe
    {
        public TallYellowStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallYellowStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<YellowStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<TallFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallYellowStainedGlassRecipe), Item.Get<TallYellowStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Tall Stained Glass - Yellow"), typeof(TallYellowStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
		
}