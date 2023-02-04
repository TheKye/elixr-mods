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
    [RequireComponent(typeof(AttachmentComponent))]
    public partial class LargeGraniteArchObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Granite Arch"); } } 

        protected override void Initialize()
        {
                              			
        }

		static LargeGraniteArchObject()
		{
            WorldObject.AddOccupancy<LargeGraniteArchObject>(new List<BlockOccupancy>()
            {
               new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 0, 3), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 3), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 0), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 3), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 3, 0), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 3, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 3, 2), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 3, 3), typeof(BuildingWorldObjectBlock)),
            });
        }
		
        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [Tier(1)]
    [Weight(6000)]
    [MaxStackSize(10)]
    [RequiresTool(typeof(HammerItem))]
    public partial class LargeGraniteArchItem : WorldObjectItem<LargeGraniteArchObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Granite Arch"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Archway Arch For Vehicle Access to WorkShops And Other Storage or making tunnels"); } }

        static LargeGraniteArchItem()
        {
            
        }      
    }

    [RequiresSkill(typeof(MasonrySkill), 5)]   
    public partial class LargeGraniteArchRecipe : RecipeFamily
    {
        public LargeGraniteArchRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeGraniteArchItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MortaredGraniteItem>(typeof(MasonrySkill), 40, MasonrySkill.MultiplicativeStrategy, typeof(MasonryLavishResourcesTalent)),
                new CraftingElement<MortarItem>(typeof(MasonrySkill), 20, MasonrySkill.MultiplicativeStrategy, typeof(MasonryLavishResourcesTalent)),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeGraniteArchRecipe), Item.Get<LargeGraniteArchItem>().UILink(), 15, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Arch - Granite"), typeof(LargeGraniteArchRecipe));

            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
}