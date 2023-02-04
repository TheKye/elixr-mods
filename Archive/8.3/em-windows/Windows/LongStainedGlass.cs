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
    public partial class LongStainedGlassObject : 
        WorldObject    
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Stained Glass"); } }

        protected override void Initialize()
        {                             

        }

		static LongStainedGlassObject()
		{
            WorldObject.AddOccupancy<LongStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
				new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock))
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
    public partial class LongStainedGlassItem : WorldObjectItem<LongStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Stained Glass"); } } 
        public override LocString DisplayDescription { get { return  Localizer.DoStr("Decorative 1x2 Stained Glass Window."); } }

        static LongStainedGlassItem()
        {
            
        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)] 
    public partial class LongStainedGlassRecipe : Recipe
    {
        public LongStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LongStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LongFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LongStainedGlassRecipe), Item.Get<LongStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Long Stained Glass"), typeof(LongStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    
    #endregion
    #region Black
    [Serialized]
    public partial class LongBlackStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Black Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LongBlackStainedGlassObject()
        {
            WorldObject.AddOccupancy<LongBlackStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LongBlackStainedGlassItem : WorldObjectItem<LongBlackStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Black Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Black Stained Glass Window."); } }

        static LongBlackStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongBlackStainedGlassRecipe : Recipe
    {
        public LongBlackStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LongBlackStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BlackStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LongFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LongBlackStainedGlassRecipe), Item.Get<LongBlackStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Long Stained Glass - Black"), typeof(LongBlackStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Blue
    [Serialized]
    public partial class LongBlueStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Blue Stained Glass"); } }


        protected override void Initialize()
        {

        }

        static LongBlueStainedGlassObject()
        {
            WorldObject.AddOccupancy<LongBlueStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LongBlueStainedGlassItem : WorldObjectItem<LongBlueStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Blue Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Blue Stained Glass Window."); } }

        static LongBlueStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongBlueStainedGlassRecipe : Recipe
    {
        public LongBlueStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LongBlueStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BlueStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LongFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LongBlueStainedGlassRecipe), Item.Get<LongBlueStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Long Stained Glass - Blue"), typeof(LongBlueStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Brown
    [Serialized]
    public partial class LongBrownStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Brown Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LongBrownStainedGlassObject()
        {
            WorldObject.AddOccupancy<LongBrownStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LongBrownStainedGlassItem : WorldObjectItem<LongBrownStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Brown Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Brown Stained Glass Window."); } }

        static LongBrownStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongBrownStainedGlassRecipe : Recipe
    {
        public LongBrownStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LongBrownStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BrownStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LongFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LongBrownStainedGlassRecipe), Item.Get<LongBrownStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Long Stained Glass - Brown"), typeof(LongBrownStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Green
    [Serialized]
    public partial class LongGreenStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Green Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LongGreenStainedGlassObject()
        {
            WorldObject.AddOccupancy<LongGreenStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LongGreenStainedGlassItem : WorldObjectItem<LongGreenStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Green Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Blue Stained Glass Window."); } }

        static LongGreenStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongGreenStainedGlassRecipe : Recipe
    {
        public LongGreenStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LongGreenStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GreenStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LongFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LongGreenStainedGlassRecipe), Item.Get<LongGreenStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Long Stained Glass - Green"), typeof(LongGreenStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Orange
    [Serialized]
    public partial class LongOrangeStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Orange Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LongOrangeStainedGlassObject()
        {
            WorldObject.AddOccupancy<LongOrangeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LongOrangeStainedGlassItem : WorldObjectItem<LongOrangeStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Orange Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Orange Stained Glass Window."); } }

        static LongOrangeStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongOrangeStainedGlassRecipe : Recipe
    {
        public LongOrangeStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LongOrangeStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<OrangeStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LongFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LongOrangeStainedGlassRecipe), Item.Get<LongOrangeStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Long Stained Glass - Orange"), typeof(LongOrangeStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Purple
    [Serialized]
    public partial class LongPurpleStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Purple Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LongPurpleStainedGlassObject()
        {
            WorldObject.AddOccupancy<LongPurpleStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LongPurpleStainedGlassItem : WorldObjectItem<LongPurpleStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Purple Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Purple Stained Glass Window."); } }

        static LongPurpleStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongPurpleStainedGlassRecipe : Recipe
    {
        public LongPurpleStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LongPurpleStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PurpleStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LongFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LongPurpleStainedGlassRecipe), Item.Get<LongPurpleStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Long Stained Glass - Purple"), typeof(LongPurpleStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Red
    [Serialized]
    public partial class LongRedStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Red Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LongRedStainedGlassObject()
        {
            WorldObject.AddOccupancy<LongRedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LongRedStainedGlassItem : WorldObjectItem<LongRedStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Red Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Red Stained Glass Window."); } }

        static LongRedStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongRedStainedGlassRecipe : Recipe
    {
        public LongRedStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LongRedStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RedStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LongFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LongRedStainedGlassRecipe), Item.Get<LongRedStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Long Stained Glasss - Red"), typeof(LongRedStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Yellow
    [Serialized]
    public partial class LongYellowStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Yellow Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LongYellowStainedGlassObject()
        {
            WorldObject.AddOccupancy<LongYellowStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LongYellowStainedGlassItem : WorldObjectItem<LongYellowStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Long Yellow Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Yellow Stained Glass Window."); } }

        static LongYellowStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LongYellowStainedGlassRecipe : Recipe
    {
        public LongYellowStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LongYellowStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<YellowStainedGlassItem>(typeof(GlassworkingSkill), 5, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LongFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LongYellowStainedGlassRecipe), Item.Get<LongYellowStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Long Stained Glass - Yellow"), typeof(LongYellowStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
}