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

    #region Grey
    [Serialized]    
    public partial class StainedGlassObject : 
        WorldObject    
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Stained Glass Window"); } }

        protected override void Initialize()
        {                             

        }

		static StainedGlassObject()
		{
            WorldObject.AddOccupancy<StainedGlassObject>(new List<BlockOccupancy>(){
                  new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                });
        }
		
        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [ItemTier(3)]
    [Weight(600)]
    [MaxStackSize(10)]
    public partial class StainedGlassItem : WorldObjectItem<StainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Stained Glass Window"); } } 
        public override LocString DisplayDescription { get { return  Localizer.DoStr("Decorative Stained Glass."); } }

        static StainedGlassItem()
        {
            
        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 1)] 
    public partial class StainedGlassRecipe : Recipe
    {
        public StainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<StainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GreyGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<FrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(StainedGlassRecipe), Item.Get<StainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass Window"), typeof(StainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Blue
    [Serialized]
    public partial class BlueStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Blue Stained Glass Window"); } }

        protected override void Initialize()
        {

        }

        static BlueStainedGlassObject()

        {
            WorldObject.AddOccupancy<BlueStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [ItemTier(3)]
    [Weight(600)]
    [MaxStackSize(10)]
    public partial class BlueStainedGlassItem : WorldObjectItem<BlueStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Blue Stained Glass Window"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Blue Stained Glass."); } }

        static BlueStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class BlueStainedGlassRecipe : Recipe
    {
        public BlueStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BlueStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BlueGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<FrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlueStainedGlassRecipe), Item.Get<BlueStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass Window - Blue"), typeof(StainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Green
    [Serialized]
    public partial class GreenStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Green Stained Glass Window"); } }

        protected override void Initialize()
        {

        }

        static GreenStainedGlassObject()
        {
            WorldObject.AddOccupancy<GreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [ItemTier(3)]
    [Weight(600)]
    [MaxStackSize(10)]
    public partial class GreenStainedGlassItem : WorldObjectItem<GreenStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Green Stained Glass Window"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Green Decorative Stained Glass."); } }

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
                new CraftingElement<GreenGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<FrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreenStainedGlassRecipe), Item.Get<GreenStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass Window - Green"), typeof(GreenStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Red
    [Serialized]
    public partial class RedStainedGlassObject :
       WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Red Stained Glass Window"); } }

        protected override void Initialize()
        {

        }

        static RedStainedGlassObject()
        {
            WorldObject.AddOccupancy<RedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [ItemTier(3)]
    [Weight(600)]
    [MaxStackSize(10)]
    public partial class RedStainedGlassItem : WorldObjectItem<RedStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Red Stained Glass Window"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Red Stained Glass."); } }

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
                new CraftingElement<RedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<FrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RedStainedGlassRecipe), Item.Get<RedStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass Window - Red"), typeof(RedStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }

    [Serialized]
    [Wall, Solid, Constructed]
    public class RedBuildingWorldObjectBlock : BuildingWorldObjectBlock
    {
        public RedBuildingWorldObjectBlock(WorldObject obj)
            : base(obj)
        { }

        protected RedBuildingWorldObjectBlock()
        { }
    }
    #endregion
    #region Yellow
    [Serialized]
    public partial class YellowStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Yellow Stained Glass Window"); } }

        protected override void Initialize()
        {

        }

        static YellowStainedGlassObject()
        {
            WorldObject.AddOccupancy<YellowStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [ItemTier(3)]
    [Weight(600)]
    [MaxStackSize(10)]
    public partial class YellowStainedGlassItem : WorldObjectItem<YellowStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Yellow Stained Glass Window"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Yellow Stained Glass."); } }

        static YellowStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class YellowStainedGlassRecipe : Recipe
    {
        public YellowStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<YellowStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<YellowGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<FrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(YellowStainedGlassRecipe), Item.Get<YellowStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass Window - Yellow"), typeof(YellowStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Orange
    [Serialized]
    public partial class OrangeStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Orange Stained Glass Window"); } }

        protected override void Initialize()
        {

        }

        static OrangeStainedGlassObject()
        {
            WorldObject.AddOccupancy<OrangeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [ItemTier(3)]
    [Weight(600)]
    [MaxStackSize(10)]
    public partial class OrangeStainedGlassItem : WorldObjectItem<OrangeStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Orange Stained Glass Window"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Orange Stained Glass Window."); } }

        static OrangeStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class OrangeStainedGlassRecipe : Recipe
    {
        public OrangeStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OrangeStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<OrangeGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<FrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(OrangeStainedGlassRecipe), Item.Get<OrangeStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass Window - Orange"), typeof(OrangeStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Brown
    [Serialized]
    public partial class BrownStainedGlassObject :
       WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Brown Stained Glass Window"); } }

        protected override void Initialize()
        {

        }

        static BrownStainedGlassObject()
        {
            WorldObject.AddOccupancy<BrownStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [ItemTier(3)]
    [Weight(600)]
    [MaxStackSize(10)]
    public partial class BrownStainedGlassItem : WorldObjectItem<BrownStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Brown Stained Glass Window"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Brown Stained Glass Window."); } }

        static BrownStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class BrownStainedGlassRecipe : Recipe
    {
        public BrownStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BrownStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BrownGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<FrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BrownStainedGlassRecipe), Item.Get<BrownStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass Window - Brown"), typeof(BrownStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Purple
    [Serialized]
    public partial class PurpleStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Purple Stained Glass Window"); } }

        protected override void Initialize()
        {

        }

        static PurpleStainedGlassObject()
        {
            WorldObject.AddOccupancy<PurpleStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [ItemTier(3)]
    [Weight(600)]
    [MaxStackSize(10)]
    public partial class PurpleStainedGlassItem : WorldObjectItem<PurpleStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Purple Stained Glass Window"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Purple Stained Glass Window."); } }

        static PurpleStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class PurpleStainedGlassRecipe : Recipe
    {
        public PurpleStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PurpleStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PurpleGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<FrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PurpleStainedGlassRecipe), Item.Get<PurpleStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass Window - Purple"), typeof(PurpleStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Black
    [Serialized]
    public partial class BlackStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Black Stained Glass Window"); } }

        protected override void Initialize()
        {

        }

        static BlackStainedGlassObject()
        {
            WorldObject.AddOccupancy<BlackStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [ItemTier(3)]
    [Weight(600)]
    [MaxStackSize(10)]
    public partial class BlackStainedGlassItem : WorldObjectItem<BlackStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Black Stained Glass Window"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Black Stained Glass Window."); } }

        static BlackStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class BlackStainedGlassRecipe : Recipe
    {
        public BlackStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BlackStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BlackGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<FrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlackStainedGlassRecipe), Item.Get<BlackStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass Window - Black"), typeof(BlackStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
}