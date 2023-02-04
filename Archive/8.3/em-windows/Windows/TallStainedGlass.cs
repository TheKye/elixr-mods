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
    public partial class TallStainedGlassObject : 
        WorldObject    
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Stained Glass"); } }

        protected override void Initialize()
        {                             

        }

		static TallStainedGlassObject()
		{
            WorldObject.AddOccupancy<TallStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
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
    public partial class TallStainedGlassItem : WorldObjectItem<TallStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Stained Glass"); } } 
        public override LocString DisplayDescription { get { return  Localizer.DoStr("Decorative 1x2 Stained Glass Window."); } }

        static TallStainedGlassItem()
        {
            
        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)] 
    public partial class TallStainedGlassRecipe : Recipe
    {
        public TallStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<TallFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallStainedGlassRecipe), Item.Get<TallStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Tall Stained Glass"), typeof(TallStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Blue
    [Serialized]
    public partial class TallBlueStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Blue Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static TallBlueStainedGlassObject()
        {
            WorldObject.AddOccupancy<TallBlueStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
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
    public partial class TallBlueStainedGlassItem : WorldObjectItem<TallBlueStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Blue Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Blue Stained Glass Window."); } }

        static TallBlueStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallBlueStainedGlassRecipe : Recipe
    {
        public TallBlueStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallBlueStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BlueStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<TallFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallBlueStainedGlassRecipe), Item.Get<TallBlueStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Tall Stained Glass - Blue"), typeof(TallBlueStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }

    #endregion
    #region Red
    [Serialized]
    public partial class TallRedStainedGlassObject :
       WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Red Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static TallRedStainedGlassObject()
        {
            WorldObject.AddOccupancy<TallRedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
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
    public partial class TallRedStainedGlassItem : WorldObjectItem<TallRedStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Red Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Red Stained Glass Window."); } }

        static TallRedStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallRedStainedGlassRecipe : Recipe
    {
        public TallRedStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallRedStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RedStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<TallFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallRedStainedGlassRecipe), Item.Get<TallRedStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Tall Stained Glass - Red"), typeof(TallRedStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Green
    [Serialized]
    public partial class TallGreenStainedGlassObject :
       WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Green Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static TallGreenStainedGlassObject()
        {
            WorldObject.AddOccupancy<TallGreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
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
    public partial class TallGreenStainedGlassItem : WorldObjectItem<TallGreenStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Green Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Green Stained Glass Window."); } }

        static TallGreenStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallGreenStainedGlassRecipe : Recipe
    {
        public TallGreenStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallGreenStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GreenStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<TallFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallGreenStainedGlassRecipe), Item.Get<TallGreenStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Tall Stained Glass - Green"), typeof(TallGreenStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Yellow
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
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
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
    public partial class TallYellowStainedGlassItem : WorldObjectItem<TallYellowStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Yellow Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Yellow Stained Glass Window."); } }

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
    #endregion
    #region Orange
    [Serialized]
    public partial class TallOrangeStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Orange Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static TallOrangeStainedGlassObject()
        {
            WorldObject.AddOccupancy<TallOrangeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
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
    public partial class TallOrangeStainedGlassItem : WorldObjectItem<TallOrangeStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Orange Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Orange Stained Glass Window."); } }

        static TallOrangeStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallOrangeStainedGlassRecipe : Recipe
    {
        public TallOrangeStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallOrangeStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<OrangeStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<TallFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallOrangeStainedGlassRecipe), Item.Get<TallOrangeStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Tall Stained Glass - Orange"), typeof(TallOrangeStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Brown
    [Serialized]
    public partial class TallBrownStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Brown Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static TallBrownStainedGlassObject()
        {
            WorldObject.AddOccupancy<TallBrownStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
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
    public partial class TallBrownStainedGlassItem : WorldObjectItem<TallBrownStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Brown Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Brown Stained Glass Window."); } }

        static TallBrownStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallBrownStainedGlassRecipe : Recipe
    {
        public TallBrownStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallBrownStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BrownStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<TallFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallBrownStainedGlassRecipe), Item.Get<TallBrownStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Tall Stained Glass - Brown"), typeof(TallBrownStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Purple
    [Serialized]
    public partial class TallPurpleStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Purple Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static TallPurpleStainedGlassObject()
        {
            WorldObject.AddOccupancy<TallPurpleStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
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
    public partial class TallPurpleStainedGlassItem : WorldObjectItem<TallPurpleStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Purple Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Purple Stained Glass Window."); } }

        static TallPurpleStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallPurpleStainedGlassRecipe : Recipe
    {
        public TallPurpleStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallPurpleStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PurpleStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<TallFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallPurpleStainedGlassRecipe), Item.Get<TallPurpleStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Tall Stained Glass - Purple"), typeof(TallPurpleStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Black
    [Serialized]
    public partial class TallBlackStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Black Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static TallBlackStainedGlassObject()
        {
            WorldObject.AddOccupancy<TallBlackStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
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
    public partial class TallBlackStainedGlassItem : WorldObjectItem<TallBlackStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tall Black Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Black Stained Glass Window."); } }

        static TallBlackStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class TallBlackStainedGlassRecipe : Recipe
    {
        public TallBlackStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallBlackStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BlackStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<TallFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallBlackStainedGlassRecipe), Item.Get<TallBlackStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Tall Stained Glass - Black"), typeof(TallBlackStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
}