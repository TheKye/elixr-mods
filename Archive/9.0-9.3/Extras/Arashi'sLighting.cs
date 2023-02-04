namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;

    //CandlePost 01

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Candles_Stand01Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Candle Stand, Single Lantern"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Candles_Stand01Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Candles_Stand01Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Candle Stand - Single Lantern")]
    public partial class Arashi_Lighting_Candles_Stand01Item :
        WorldObjectItem<Arashi_Lighting_Candles_Stand01Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Candle Light Lanterns To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Candles_Stand01Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 5,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Candles_Stand01Recipe : RecipeFamily
    {
        public Arashi_Lighting_Candles_Stand01Recipe()
        {
            this.Initialize(Localizer.DoStr("Candle Stand, Single Lantern"), typeof(Arashi_Lighting_Candles_Stand01Recipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Candle Stand, Single Lantern",
                    Localizer.DoStr("Candle Stand, Single Lantern"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(TallowItem), 20,typeof(SmeltingSkill),typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<Arashi_Lighting_Candles_Stand01Item>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(Arashi_Lighting_Candles_Stand01Recipe), 1, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Candle Stand, Single Lantern"), typeof(Arashi_Lighting_Candles_Stand01Recipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }

    //CandleStand 02

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Candles_Stand02Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Candle Stand, Double Lantern"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Candles_Stand02Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Candles_Stand02Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Candle Stand - Double Lantern")]
    public partial class Arashi_Lighting_Candles_Stand02Item :
        WorldObjectItem<Arashi_Lighting_Candles_Stand02Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Candle Light Lanterns To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Candles_Stand02Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 5,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Candles_Stand02Recipe : Recipe
    {
        public Arashi_Lighting_Candles_Stand02Recipe()
        {
            var product = new Recipe(
                 "Candle Stand, Double Lantern",
                 Localizer.DoStr("Candle Stand, Double Lantern"),
                 new IngredientElement[]
                 {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(TallowItem), 20,typeof(SmeltingSkill),typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                 },
                 new CraftingElement[]
                 {
                    new CraftingElement<Arashi_Lighting_Candles_Stand02Item>()
                 }
                 );

            CraftingComponent.AddTagProduct(typeof(AnvilObject), typeof(Arashi_Lighting_Candles_Stand01Recipe), product);
        }
    }

    //CandleStand 03

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Candles_Stand03Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Candle Stand, Double Lantern 02"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Candles_Stand03Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Candles_Stand03Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Candle Stand - Double Lantern 02")]
    public partial class Arashi_Lighting_Candles_Stand03Item :
        WorldObjectItem<Arashi_Lighting_Candles_Stand03Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Candle Light Lanterns To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Candles_Stand03Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 5,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Candles_Stand03Recipe : Recipe
    {
        public Arashi_Lighting_Candles_Stand03Recipe()
        {
            var product = new Recipe(
                "Candle Stand, Double Lantern 02",
                Localizer.DoStr("Candle Stand, Double Lantern 02"),
                new IngredientElement[]
                {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(TallowItem), 20,typeof(SmeltingSkill),typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement("Wood", 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                },
                new CraftingElement[]
                {
                    new CraftingElement<Arashi_Lighting_Candles_Stand03Item>()
                }
                );
            CraftingComponent.AddTagProduct(typeof(AnvilObject), typeof(Arashi_Lighting_Candles_Stand01Recipe), product);
        }
    }

    //Candle Ceiling Chain 01

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Candles_Ceiling01Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Candle Stand, Ceiling Light"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Candles_Ceiling01Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Candles_Ceiling01Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Candle Stand - Ceiling Light")]
    public partial class Arashi_Lighting_Candles_Ceiling01Item :
        WorldObjectItem<Arashi_Lighting_Candles_Ceiling01Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Lantern To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Candles_Ceiling01Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 5,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Candles_Ceiling01Recipe : RecipeFamily
    {
        public Arashi_Lighting_Candles_Ceiling01Recipe()
        {
            this.Initialize(Localizer.DoStr("Candle Stand, Ceiling Light"), typeof(Arashi_Lighting_Candles_Ceiling01Recipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Candle Stand, Ceiling Light",
                    Localizer.DoStr("Candle Stand, Ceiling Light"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(TallowItem), 20,typeof(SmeltingSkill),typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<Arashi_Lighting_Candles_Ceiling01Item>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(Arashi_Lighting_Candles_Ceiling01Recipe), 1, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Candle Stand, Ceiling Light"), typeof(Arashi_Lighting_Candles_Ceiling01Recipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }

    //Lantern01

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Candles_Lantern01Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Candle Lantern 01"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Candles_Lantern01Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Candles_Lantern01Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Candle Lantern 01")]
    public partial class Arashi_Lighting_Candles_Lantern01Item :
        WorldObjectItem<Arashi_Lighting_Candles_Lantern01Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Lantern To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Candles_Lantern01Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Candles_Lantern01Recipe : RecipeFamily
    {
        public Arashi_Lighting_Candles_Lantern01Recipe()
        {
            this.Initialize(Localizer.DoStr("Candle Lantern 01"), typeof(Arashi_Lighting_Candles_Lantern01Recipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Candle Lantern 01",
                    Localizer.DoStr("Candle Lantern 01"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(TallowItem), 20,typeof(SmeltingSkill),typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<Arashi_Lighting_Candles_Lantern01Item>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(Arashi_Lighting_Candles_Lantern01Recipe), 1, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Candle Lantern 01"), typeof(Arashi_Lighting_Candles_Lantern01Recipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }

    //Lantern02

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Candles_Lantern02Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Candle Lantern 02"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Candles_Lantern02Item); } }


        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Candles_Lantern02Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Candle Lantern 02")]
    public partial class Arashi_Lighting_Candles_Lantern02Item :
        WorldObjectItem<Arashi_Lighting_Candles_Lantern02Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Lantern To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Candles_Lantern02Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Candles_Lantern02Recipe : Recipe
    {
        public Arashi_Lighting_Candles_Lantern02Recipe()
        {
            var product = new Recipe(
            "Candle Lantern 02",
                Localizer.DoStr("Candle Lantern 02"),
                new IngredientElement[]
                {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(TallowItem), 20,typeof(SmeltingSkill),typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                },
                new CraftingElement[]
                {
                    new CraftingElement<Arashi_Lighting_Candles_Lantern02Item>()
                }
                );
            CraftingComponent.AddTagProduct(typeof(AnvilObject), typeof(Arashi_Lighting_Candles_Lantern01Recipe), product);
        }
    }

    //Lantern03

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Candles_Lantern03Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Candle Lantern 03"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Candles_Lantern03Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Candles_Lantern03Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Candle Lantern 03")]
    public partial class Arashi_Lighting_Candles_Lantern03Item :
        WorldObjectItem<Arashi_Lighting_Candles_Lantern03Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Lantern To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Candles_Lantern03Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Candles_Lantern03Recipe : Recipe
    {
        public Arashi_Lighting_Candles_Lantern03Recipe()
        {
            var product = new Recipe(
            "Candle Lantern 03",
                Localizer.DoStr("Candle Lantern 03"),
                new IngredientElement[]
                {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(TallowItem), 20,typeof(SmeltingSkill),typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                },
                new CraftingElement[]
                {
                    new CraftingElement<Arashi_Lighting_Candles_Lantern03Item>()
                }
                );
            CraftingComponent.AddTagProduct(typeof(AnvilObject), typeof(Arashi_Lighting_Candles_Lantern01Recipe), product);
        }
    }

    //Lantern04

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Candles_Lantern04Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Candle Lantern 04"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Candles_Lantern04Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Candles_Lantern04Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Candle Lantern 04")]
    public partial class Arashi_Lighting_Candles_Lantern04Item :
        WorldObjectItem<Arashi_Lighting_Candles_Lantern04Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Lantern To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Candles_Lantern04Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Candles_Lantern04Recipe : Recipe
    {
        public Arashi_Lighting_Candles_Lantern04Recipe()
        {
            var product = new Recipe(
            "Candle Lantern 04",
                Localizer.DoStr("Candle Lantern 04"),
                new IngredientElement[]
                {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(TallowItem), 20,typeof(SmeltingSkill),typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                },
                new CraftingElement[]
                {
                    new CraftingElement<Arashi_Lighting_Candles_Lantern04Item>()
                }
                );
            CraftingComponent.AddTagProduct(typeof(AnvilObject), typeof(Arashi_Lighting_Candles_Lantern01Recipe), product);
        }
    }

    //Lantern05

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Candles_Lantern05Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Candle Lantern 05"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Candles_Lantern05Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Candles_Lantern05Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Candle Lantern 05")]
    public partial class Arashi_Lighting_Candles_Lantern05Item :
        WorldObjectItem<Arashi_Lighting_Candles_Lantern05Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Lantern To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Candles_Lantern05Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Candles_Lantern05Recipe : Recipe
    {
        public Arashi_Lighting_Candles_Lantern05Recipe()
        {
            var product = new Recipe(
            "Candle Lantern 05",
                Localizer.DoStr("Candle Lantern 05"),
                new IngredientElement[]
                {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(TallowItem), 20,typeof(SmeltingSkill),typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                },
                new CraftingElement[]
                {
                    new CraftingElement<Arashi_Lighting_Candles_Lantern05Item>()
                }
                );
            CraftingComponent.AddTagProduct(typeof(AnvilObject), typeof(Arashi_Lighting_Candles_Lantern01Recipe), product);
        }
    }

    //Oil_Lantern01

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Oil_Lantern01Object : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Oil Lantern 1"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Oil_Lantern01Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Oil_Lantern01Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Oil Lantern 1")]
    public partial class Arashi_Lighting_Oil_Lantern01Item :
        WorldObjectItem<Arashi_Lighting_Oil_Lantern01Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Lantern To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Oil_Lantern01Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Oil_Lantern01Recipe : RecipeFamily
    {
        public Arashi_Lighting_Oil_Lantern01Recipe()
        {
            this.Initialize(Localizer.DoStr("Oil Lantern 1"), typeof(Arashi_Lighting_Candles_Stand01Recipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Oil Lantern 1",
                    Localizer.DoStr("Oil Lantern 1"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<Arashi_Lighting_Oil_Lantern01Item>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(Arashi_Lighting_Oil_Lantern01Recipe), 1, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Oil Lantern 1"), typeof(Arashi_Lighting_Oil_Lantern01Recipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }

    //Oil_Lantern02

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Oil_Lantern02Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Oil Lantern 02"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Oil_Lantern02Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Oil_Lantern02Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Oil Lantern 02")]
    public partial class Arashi_Lighting_Oil_Lantern02Item :
        WorldObjectItem<Arashi_Lighting_Oil_Lantern02Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Lantern To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Oil_Lantern02Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Oil_Lantern02Recipe : Recipe
    {
        public Arashi_Lighting_Oil_Lantern02Recipe()
        {
            var product = new Recipe(
            "Oil Lantern 02",
                Localizer.DoStr("Oil Lantern 02"),
                new IngredientElement[]
                {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                },
                new CraftingElement[]
                {
                    new CraftingElement<Arashi_Lighting_Oil_Lantern02Item>()
                }
                );
            CraftingComponent.AddTagProduct(typeof(AnvilObject), typeof(Arashi_Lighting_Oil_Lantern01Recipe), product);
        }
    }

    //Oil_Lamp01

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Oil_Lamp01Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Oil Lamp 01"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Oil_Lamp01Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Oil_Lamp01Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Oil Lamp 01")]
    public partial class Arashi_Lighting_Oil_Lamp01Item :
        WorldObjectItem<Arashi_Lighting_Oil_Lamp01Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Lamp To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Oil_Lamp01Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Oil_Lamp01Recipe : RecipeFamily
    {
        public Arashi_Lighting_Oil_Lamp01Recipe()
        {
            this.Initialize(Localizer.DoStr("Oil Lamp 01"), typeof(Arashi_Lighting_Candles_Stand01Recipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Oil Lamp 01",
                    Localizer.DoStr("Oil Lamp 01"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<Arashi_Lighting_Oil_Lamp01Item>()
                    )
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(Arashi_Lighting_Oil_Lamp01Recipe),1, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Oil Lamp 01"), typeof(Arashi_Lighting_Oil_Lamp01Recipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }

    //Oil_Lamp02

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    public partial class Arashi_Lighting_Oil_Lamp02Object :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Oil Lamp 02"); } }

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Oil_Lamp02Item); } }

        private static string[] fuelTypeList = new string[]
        {
        "Fat"
        };

        protected override void Initialize()
        {


            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Oil_Lamp02Item.HousingVal);

        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [LocDisplayName("Oil Lamp 02")]
    public partial class Arashi_Lighting_Oil_Lamp02Item :
        WorldObjectItem<Arashi_Lighting_Oil_Lamp02Object>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Lamp To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }

        static Arashi_Lighting_Oil_Lamp02Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = HousingValue.RoomCategory.General,
                    Val = 3,
                    TypeForRoomLimit = "Lights",
                    DiminishingReturnPercent = 0.8f
                };
            }
        }

        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } }
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_Oil_Lamp02Recipe : Recipe
    {
        public Arashi_Lighting_Oil_Lamp02Recipe()
        {
            var product = new Recipe(
                "Oil Lamp 02",
                Localizer.DoStr("Oil Lamp 02"),
                new IngredientElement[]
                {
                        new IngredientElement(typeof(IronBarItem), 15, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GlassItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                },
                new CraftingElement[]
                {
                    new CraftingElement<Arashi_Lighting_Oil_Lamp02Item>()
                }
            );
            CraftingComponent.AddTagProduct(typeof(AnvilObject), typeof(Arashi_Lighting_Oil_Lamp02Recipe), product);
        }
    }

    /*

	//Object 1 ====================================================	
		
    [Serialized]    
	[RequireComponent(typeof(OnOffComponent))]   //Remove For Custom Switches 
    [RequireComponent(typeof(AttachmentComponent))] // UNknown?
    [RequireComponent(typeof(PropertyAuthComponent))]
                
    [RequireComponent(typeof(FuelSupplyComponent))]                      
    [RequireComponent(typeof(FuelConsumptionComponent))]                 
    [RequireComponent(typeof(HousingComponent))]                          
    public partial class Arashi_Lighting_VictorianStreetLight01Object : WorldObject, IRepresentsItem
    {
		[Serialized] public bool LightOn = true; //LightOn State For switch
		
		
		public override LocString DisplayName { get { return Localizer.DoStr("Victorian StreetLight"); } }  
	public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_VictorianStreetLight01Item); } } 
	
	
        private static Type[] fuelTypeList = new Type[]
        {
            typeof(OilItem),
        };

        protected override void Initialize()
        {
                                 
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);                           
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);                    
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_VictorianStreetLight01Item.HousingVal);                                
        }
		
		 static Arashi_Lighting_VictorianStreetLight01Object()
    {
        AddOccupancyList(typeof(Arashi_Lighting_VictorianStreetLight01Object), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
    }
		
        public override void Destroy()
        {
            base.Destroy();
        }
       

	   
	   //Custom Interact Script-------------------------------------------
	   public override InteractResult OnActRight(InteractionContext context)
        {
            if (context.Parameters != null && context.Parameters.ContainsKey("Light"))
            {
                LightOn = !LightOn;
                
                return InteractResult.Success;
            }
            return InteractResult.NoOp;
        }
	   
        // send theLight states to clients using Animated States
        // Operating indicates that room/power requirements are fulfilled
	   public override void Tick()
        {
            base.Tick();
            SetAnimatedState("Light", this.Operating && LightOn);
        }
	   
    }
//----------------------------------------------------------------
    [Serialized]
    public partial class Arashi_Lighting_VictorianStreetLight01Item : WorldObjectItem<Arashi_Lighting_VictorianStreetLight01Object>
    {
		public override LocString DisplayName { get { return Localizer.DoStr("Victorian StreetLight"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A StreetLamp To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }
		
		
		static Arashi_Lighting_VictorianStreetLight01Item()
        {
            
        }

        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = HousingValue.RoomCategory.General,
                                                    Val = 5,
                                                    TypeForRoomLimit = "Lights",
                                                    DiminishingReturnPercent = 0.8f
                                                };}}       
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_VictorianStreetLight01Recipe : Recipe
    {
        public Arashi_Lighting_VictorianStreetLight01Recipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<Arashi_Lighting_VictorianStreetLight01Item>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                 new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 20, SmeltingSkill.MultiplicativeStrategy),
                new CraftingElement<GlassItem>(typeof(SmeltingSkill), 12, SmeltingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(Arashi_Lighting_VictorianStreetLight01Recipe), Item.Get<Arashi_Lighting_VictorianStreetLight01Item>().UILink(), 1, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));    
			this.Initialize(Localizer.DoStr("Victorian StreetLight"), typeof(Arashi_Lighting_VictorianStreetLight01Recipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
	
	
	//Object 2 ====================================================
	
	




	
	
	
	
    [Serialized]    
 //   [RequireComponent(typeof(OnOffComponent))]   //Removed For Custom Switches 
    [RequireComponent(typeof(AttachmentComponent))] // UNknown?
    [RequireComponent(typeof(PropertyAuthComponent))]
                
    [RequireComponent(typeof(FuelSupplyComponent))]                      
    [RequireComponent(typeof(FuelConsumptionComponent))]                 
    [RequireComponent(typeof(HousingComponent))]                          
    public partial class Arashi_Lighting_VictorianStreetLight02Object : WorldObject, IRepresentsItem
    {
		[Serialized] public bool LightOn = true; //LightOn State For switch
		
		
		public override LocString DisplayName { get { return Localizer.DoStr("Victorian StreetLight"); } }  
	public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_VictorianStreetLight02Item); } } 
	
	
        private static Type[] fuelTypeList = new Type[]
        {
            typeof(OilItem),
        };

        protected override void Initialize()
        {
                                 
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);                           
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);                    
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_VictorianStreetLight02Item.HousingVal);                                
        }
		
		 static Arashi_Lighting_VictorianStreetLight02Object()
    {
        AddOccupancyList(typeof(Arashi_Lighting_VictorianStreetLight02Object), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
    }
		
        public override void Destroy()
        {
            base.Destroy();
        }
       
	   //Custom Interact Script-------------------------------------------
	   public override InteractResult OnActRight(InteractionContext context)
        {
            if (context.Parameters != null && context.Parameters.ContainsKey("Light"))
            {
                LightOn = !LightOn;
                
                return InteractResult.Success;
            }
            return InteractResult.NoOp;
        }
	   
        // send theLight states to clients using Animated States
        // Operating indicates that room/power requirements are fulfilled
	   public override void Tick()
        {
            base.Tick();
            SetAnimatedState("Light", this.Operating && LightOn);
        }
	   
    }
//----------------------------------------------------------------
    [Serialized]
    public partial class Arashi_Lighting_VictorianStreetLight02Item : WorldObjectItem<Arashi_Lighting_VictorianStreetLight02Object>
    {
		public override LocString DisplayName { get { return Localizer.DoStr("Victorian StreetLight"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A StreetLampTo Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }
		
		
		static Arashi_Lighting_VictorianStreetLight02Item()
        {
            
        }

        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = HousingValue.RoomCategory.General,
                                                    Val = 5,
                                                    TypeForRoomLimit = "Lights",
                                                    DiminishingReturnPercent = 0.8f
                                                };}}       
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_VictorianStreetLight02Recipe : Recipe
    {
        public Arashi_Lighting_VictorianStreetLight02Recipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<Arashi_Lighting_VictorianStreetLight02Item>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                 new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 20, SmeltingSkill.MultiplicativeStrategy),
                new CraftingElement<GlassItem>(typeof(SmeltingSkill), 12, SmeltingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(Arashi_Lighting_VictorianStreetLight02Recipe), Item.Get<Arashi_Lighting_VictorianStreetLight02Item>().UILink(), 1, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));    
			this.Initialize(Localizer.DoStr("Victorian StreetLight"), typeof(Arashi_Lighting_VictorianStreetLight02Recipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
	
	
	
	
	
	//Object 3 ====================================================
	
	
	

		
	
	
	
    [Serialized]    
 //   [RequireComponent(typeof(OnOffComponent))]   //Removed For Custom Switches 
    [RequireComponent(typeof(AttachmentComponent))] // UNknown?
    [RequireComponent(typeof(PropertyAuthComponent))]
                
    [RequireComponent(typeof(FuelSupplyComponent))]                      
    [RequireComponent(typeof(FuelConsumptionComponent))]                 
    [RequireComponent(typeof(HousingComponent))]                          
    public partial class Arashi_Lighting_VictorianStreetLight03Object : WorldObject, IRepresentsItem
    {
		[Serialized] public bool LightOn = true; //LightOn State For switch
		
		
		public override LocString DisplayName { get { return Localizer.DoStr("Victorian StreetLight"); } }  
	public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_VictorianStreetLight03Item); } } 
	
	
        private static Type[] fuelTypeList = new Type[]
        {
            typeof(OilItem),
        };

        protected override void Initialize()
        {
                                 
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);                           
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);                    
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_VictorianStreetLight03Item.HousingVal);                                
        }
		
		 static Arashi_Lighting_VictorianStreetLight03Object()
    {
        AddOccupancyList(typeof(Arashi_Lighting_VictorianStreetLight03Object), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
    }
		
        public override void Destroy()
        {
            base.Destroy();
        }
       
	   //Custom Interact Script-------------------------------------------
	   public override InteractResult OnActRight(InteractionContext context)
        {
            if (context.Parameters != null && context.Parameters.ContainsKey("Light"))
            {
                LightOn = !LightOn;
                
                return InteractResult.Success;
            }
            return InteractResult.NoOp;
        }
	   
        // send theLight states to clients using Animated States
        // Operating indicates that room/power requirements are fulfilled
	   public override void Tick()
        {
            base.Tick();
            SetAnimatedState("Light", this.Operating && LightOn);
        }
	   
    }
//----------------------------------------------------------------
    [Serialized]
    public partial class Arashi_Lighting_VictorianStreetLight03Item : WorldObjectItem<Arashi_Lighting_VictorianStreetLight03Object>
    {
		public override LocString DisplayName { get { return Localizer.DoStr("Victorian StreetLight"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A StreetLamp To Light Your Way. ╠═╬Arashi Studios©╬═╣"); } }
		
		
		static Arashi_Lighting_VictorianStreetLight03Item()
        {
            
        }

        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = HousingValue.RoomCategory.General,
                                                    Val = 5,
                                                    TypeForRoomLimit = "Lights",
                                                    DiminishingReturnPercent = 0.8f
                                                };}}       
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class Arashi_Lighting_VictorianStreetLight03Recipe : Recipe
    {
        public Arashi_Lighting_VictorianStreetLight03Recipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<Arashi_Lighting_VictorianStreetLight03Item>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                 new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 20, SmeltingSkill.MultiplicativeStrategy),
                new CraftingElement<GlassItem>(typeof(SmeltingSkill), 12, SmeltingSkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(Arashi_Lighting_VictorianStreetLight03Recipe), Item.Get<Arashi_Lighting_VictorianStreetLight03Item>().UILink(), 1, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));    
			this.Initialize(Localizer.DoStr("Victorian StreetLight"), typeof(Arashi_Lighting_VictorianStreetLight03Recipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
	
	
	
	
	
//Japanese Streetlamp
   
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]                   
    [RequireComponent(typeof(PropertyAuthComponent))]
                
    [RequireComponent(typeof(FuelSupplyComponent))]                      
    [RequireComponent(typeof(FuelConsumptionComponent))]                 
    [RequireComponent(typeof(HousingComponent))]                  
    public partial class Arashi_Lighting_Japan_StreetLamp01Object : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Japanese Street Lamp"); } } 

        public virtual Type RepresentedItemType { get { return typeof(Arashi_Lighting_Japan_StreetLamp01Item); } } 


        private static Type[] fuelTypeList = new Type[]
        {
            typeof(TallowItem)
        };

        protected override void Initialize()
        {

                                 
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);                           
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);                    
            this.GetComponent<HousingComponent>().Set(Arashi_Lighting_Japan_StreetLamp01Item.HousingVal);                                

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class Arashi_Lighting_Japan_StreetLamp01Item :
        WorldObjectItem<Arashi_Lighting_Japan_StreetLamp01Object> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Japanese Street Lamp"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A fancy Street Lamp To Light Your Way. ╠═╬Arashi Studios©╬═╣."); } }

        static Arashi_Lighting_Japan_StreetLamp01Item()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = HousingValue.RoomCategory.General,
                                                    Val = 5,                                   
                                                    TypeForRoomLimit = "Lights", 
                                                    DiminishingReturnPercent = 0.8f    
        };}}
        
        [Tooltip(7)] private LocString PowerConsumptionTooltip { get { return new LocString(string.Format(Localizer.DoStr("Consumes: {0}w from fuel"), Text.Info(1))); } } 
    }


    [RequiresSkill(typeof(SmeltingSkill), 1)]      
    public partial class Arashi_Lighting_Japan_StreetLamp01Recipe : Recipe
    {
        public Arashi_Lighting_Japan_StreetLamp01Recipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<Arashi_Lighting_Japan_StreetLamp01Item>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 20, SmeltingSkill.MultiplicativeStrategy),
                new CraftingElement<TallowItem>(typeof(SmeltingSkill), 20, SmeltingSkill.MultiplicativeStrategy), new CraftingElement<GlassItem>(typeof(SmeltingSkill), 10, SmeltingSkill.MultiplicativeStrategy),         
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(Arashi_Lighting_Japan_StreetLamp01Recipe), Item.Get<Arashi_Lighting_Japan_StreetLamp01Item>().UILink(), 1, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent));    
            this.Initialize(Localizer.DoStr("Japanese Street Lamp"), typeof(Arashi_Lighting_Japan_StreetLamp01Recipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }

	
	*/





}