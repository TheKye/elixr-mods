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
    public partial class FermentingBarrelObject : 
        WorldObject    
    {
        public override LocString DisplayName { get { return Localizer.DoStr("FermentingBarrel"); } } 


        protected override void Initialize()
        {

        }

		static FermentingBarrelObject()
		{
            WorldObject.AddOccupancy<FermentingBarrelObject>(new List<BlockOccupancy>(){
				new BlockOccupancy(new Vector3i(0, 2, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 0, 0)),
				new BlockOccupancy(new Vector3i(0, 2, -1)),
                new BlockOccupancy(new Vector3i(0, 1, -1)),
                new BlockOccupancy(new Vector3i(0, 0, -1)),
				new BlockOccupancy(new Vector3i(0, 2, -2)),
                new BlockOccupancy(new Vector3i(0, 1, -2)),
                new BlockOccupancy(new Vector3i(0, 0, -2)),
				new BlockOccupancy(new Vector3i(1, 2, 0)),
                new BlockOccupancy(new Vector3i(1, 1, 0)),
                new BlockOccupancy(new Vector3i(1, 0, 0)),
				new BlockOccupancy(new Vector3i(1, 2, -1)),
                new BlockOccupancy(new Vector3i(1, 1, -1)),
                new BlockOccupancy(new Vector3i(1, 0, -1)),
				new BlockOccupancy(new Vector3i(1, 2, -2)),
                new BlockOccupancy(new Vector3i(1, 1, -2)),
                new BlockOccupancy(new Vector3i(1, 0, -2)),
                });
        }
		
        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class FermentingBarrelItem : WorldObjectItem<FermentingBarrelObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Fermenting Barrel"); } } 
        public override LocString DisplayDescription  { get { return  Localizer.DoStr("Fermenting Barrel Is Used To Distill Products."); } }

        static FermentingBarrelItem()
        {
            
        }

    }


    [RequiresSkill(typeof(HewingSkill), 2)]
    public partial class FermentingBarrelRecipe : Recipe
    {
        public FermentingBarrelRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FermentingBarrelItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(HewingSkill), 10, HewingSkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(HewingSkill), 20, HewingSkill.MultiplicativeStrategy),
                new CraftingElement<PlantFibersItem>(typeof(HewingSkill), 20, HewingSkill.MultiplicativeStrategy),  
				new CraftingElement<IronIngotItem>(typeof(HewingSkill), 5, HewingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FermentingBarrelRecipe), Item.Get<FermentingBarrelItem>().UILink(), 15, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("FermentingBarrel"), typeof(FermentingBarrelRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}