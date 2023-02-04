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
    public partial class LargeStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LargeStainedGlassObject()
        {
            WorldObject.AddOccupancy<LargeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LargeStainedGlassItem : WorldObjectItem<LargeStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A 2x2 Decorative Stained Glass Window."); } }

        static LargeStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LargeStainedGlassRecipe : Recipe
    {
        public LargeStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StainedGlassItem>(typeof(GlassworkingSkill), 10, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LargeFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeStainedGlassRecipe), Item.Get<LargeStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Large Stained Glass"), typeof(LargeStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    
    }
    #endregion
    #region Blue
    [Serialized]
    public partial class LargeBlueStainedGlassObject :
       WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Blue Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LargeBlueStainedGlassObject()
        {
            WorldObject.AddOccupancy<LargeBlueStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LargeBlueStainedGlassItem : WorldObjectItem<LargeBlueStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Blue Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 2x2 Large Blue Stained Glass Window."); } }

        static LargeBlueStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LargeBlueStainedGlassRecipe : Recipe
    {
        public LargeBlueStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeBlueStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BlueStainedGlassItem>(typeof(GlassworkingSkill), 10, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LargeFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeBlueStainedGlassRecipe), Item.Get<LargeBlueStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Large Stained Glass - Blue"), typeof(LargeBlueStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Black
    [Serialized]
    public partial class LargeBlackStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Black Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LargeBlackStainedGlassObject()
        {
            WorldObject.AddOccupancy<LargeBlackStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LargeBlackStainedGlassItem : WorldObjectItem<LargeBlackStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Black Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Black Stained Glass Window."); } }

        static LargeBlackStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LargeBlackStainedGlassRecipe : Recipe
    {
        public LargeBlackStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeBlackStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BlackStainedGlassItem>(typeof(GlassworkingSkill), 10, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LargeFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeBlackStainedGlassRecipe), Item.Get<LargeBlackStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Large Stained Glass - Black"), typeof(LargeBlackStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Brown
    [Serialized]
    public partial class LargeBrownStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Brown Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LargeBrownStainedGlassObject()
        {
            WorldObject.AddOccupancy<LargeBrownStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LargeBrownStainedGlassItem : WorldObjectItem<LargeBrownStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Brown Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Brown Stained Glass Window."); } }

        static LargeBrownStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LargeBrownStainedGlassRecipe : Recipe
    {
        public LargeBrownStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeBrownStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BrownStainedGlassItem>(typeof(GlassworkingSkill), 10, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LargeFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeBrownStainedGlassRecipe), Item.Get<LargeBrownStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Large Stained Glass - Brown"), typeof(LargeBrownStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Green
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
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LargeGreenStainedGlassItem : WorldObjectItem<LargeGreenStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Green Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A 2x2 Decorative Green Stained Glass Window."); } }

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
    #endregion
    #region Orange
    [Serialized]
    public partial class LargeOrangeStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Orange Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LargeOrangeStainedGlassObject()
        {
            WorldObject.AddOccupancy<LargeOrangeStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LargeOrangeStainedGlassItem : WorldObjectItem<LargeOrangeStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Orange Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Orange Stained Glass Window."); } }

        static LargeOrangeStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 2)]
    public partial class LargeOrangeStainedGlassRecipe : Recipe
    {
        public LargeOrangeStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeOrangeStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<OrangeStainedGlassItem>(typeof(GlassworkingSkill), 10, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LargeFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeOrangeStainedGlassRecipe), Item.Get<LargeOrangeStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Large Stained Glass - Orange"), typeof(LargeOrangeStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Purple
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
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LargePurpleStainedGlassItem : WorldObjectItem<LargePurpleStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Purple Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative 1x2 Purple Stained Glass Window."); } }

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
    #endregion
    #region Red
    [Serialized]
    public partial class LargeRedStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Red Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LargeRedStainedGlassObject()
        {
            WorldObject.AddOccupancy<LargeRedStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LargeRedStainedGlassItem : WorldObjectItem<LargeRedStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Red Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A 2x2 Decorative Red Stained Glass Window."); } }

        static LargeRedStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LargeRedStainedGlassRecipe : Recipe
    {
        public LargeRedStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeRedStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RedStainedGlassItem>(typeof(GlassworkingSkill), 10, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LargeFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeRedStainedGlassRecipe), Item.Get<LargeRedStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Large Stained Glass - Red"), typeof(LargeRedStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
    #region Yellow
    [Serialized]
    public partial class LargeYellowStainedGlassObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Yellow Stained Glass"); } }

        protected override void Initialize()
        {

        }

        static LargeYellowStainedGlassObject()
        {
            WorldObject.AddOccupancy<LargeYellowStainedGlassObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, -1), typeof(BuildingWorldObjectBlock)),
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
    public partial class LargeYellowStainedGlassItem : WorldObjectItem<LargeYellowStainedGlassObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Yellow Stained Glass"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Decorative Yellow 2x2 Stained Glass Window."); } }

        static LargeYellowStainedGlassItem()
        {

        }

    }

    [RequiresModule(typeof(KilnObject))]
    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class LargeYellowStainedGlassRecipe : Recipe
    {
        public LargeYellowStainedGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeYellowStainedGlassItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<YellowStainedGlassItem>(typeof(GlassworkingSkill), 10, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<LargeFrameItem>(1)
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeYellowStainedGlassRecipe), Item.Get<LargeYellowStainedGlassItem>().UILink(), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Large Stained Glass - Yellow"), typeof(LargeYellowStainedGlassRecipe));
            CraftingComponent.AddRecipe(typeof(GlassworkingTableObject), this);
        }
    }
    #endregion
}