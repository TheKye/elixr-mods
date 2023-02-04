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
    
    [Serialized]    
    [RequireComponent(typeof(PropertyAuthComponent))]            
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(CraftingComponent))]               
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class ChickenCoopObject : 
        WorldObject    
    {
        public override LocString DisplayName { get { return Localizer.DoStr("ChickenCoop"); } } 


        protected override void Initialize()
        {
        }

		static ChickenCoopObject()
		{
            WorldObject.AddOccupancy<ChickenCoopObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
			new BlockOccupancy(new Vector3i(-1, 0, 0)),
                });
        }
		
        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class ChickenCoopItem : WorldObjectItem<ChickenCoopObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Chicken Coop"); } } 
        public override LocString DisplayDescription  { get { return  Localizer.DoStr("Put Feed in Coop, And you Never Know, Some think could lay an egg."); } }

        static ChickenCoopItem()
        {
            
        }

    }


    [RequiresSkill(typeof(HewingSkill), 2)]
    public partial class ChickenCoopRecipe : Recipe
    {
        public ChickenCoopRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ChickenCoopItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(HewingSkill), 10, HewingSkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(HewingSkill), 20, HewingSkill.MultiplicativeStrategy),
                new CraftingElement<PlantFibersItem>(typeof(HewingSkill), 140, HewingSkill.MultiplicativeStrategy),  
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ChickenCoopRecipe), Item.Get<ChickenCoopItem>().UILink(), 15, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("ChickenCoop"), typeof(ChickenCoopRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}