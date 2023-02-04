namespace Eco.EM.GreenEnergy
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    #region Wall Mountable
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    public partial class WallDaylightSensorObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Daylight Sensor (Wall)"); } }
        public float Range = 20f;

        protected override void Initialize()
        {
            base.Initialize();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public override void Tick()
        {
            Sensors.DaylightSensor(this, Range);
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(200)]
    public partial class WallDaylightSensorItem : WorldObjectItem<WallDaylightSensorObject>
    {
        public override LocString DisplayName        { get { return Localizer.DoStr("Daylight Sensor - Wall"); } }
        public override LocString DisplayNamePlural  { get { return Localizer.DoStr("Daylight Sensors"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A sensor that detects when it's day."); } }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 0)]
    public partial class WallDaylightSensorRecipe : Recipe
    {
        public WallDaylightSensorRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<FloorDaylightSensorItem>(),
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<CircuitItem>(typeof(ElectronicsSkill), 7, ElectronicsSkill.MultiplicativeStrategy),
                new CraftingElement<PlasticItem>(typeof(ElectronicsSkill), 15, ElectronicsSkill.MultiplicativeStrategy),
                new CraftingElement<GoldIngotItem>(typeof(ElectronicsSkill), 8, ElectronicsSkill.MultiplicativeStrategy),
            };
            CraftMinutes = CreateCraftTimeValue(typeof(WallDaylightSensorRecipe), Item.Get<WallDaylightSensorItem>().UILink(), 1, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent));
            Initialize(Localizer.DoStr("Daylight Sensor (Wall)"), typeof(WallDaylightSensorRecipe));

            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }
    #endregion

    #region Floor Placed
    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    public partial class FloorDaylightSensorObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Daylight Sensor (Floor)"); } }
        public float Range = 20f;

        protected override void Initialize()
        {
            base.Initialize();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public override void Tick()
        {
            Sensors.DaylightSensor(this, Range);
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(200)]
    public partial class FloorDaylightSensorItem : WorldObjectItem<FloorDaylightSensorObject>
    {
        public override LocString DisplayName        { get { return Localizer.DoStr("Daylight Sensor - Floor"); } }
        public override LocString DisplayNamePlural  { get { return Localizer.DoStr("Daylight Sensors"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A sensor that detects when it's day."); } }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 0)]
    public partial class FloorDaylightSensorRecipe : Recipe
    {
        public FloorDaylightSensorRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<FloorDaylightSensorItem>(),
            };
            Ingredients = new CraftingElement[]
            {
                new CraftingElement<CircuitItem>(1),
                new CraftingElement<PlasticItem>(4),
                new CraftingElement<GoldIngotItem>(3),
            };
            CraftMinutes = CreateCraftTimeValue(typeof(FloorDaylightSensorRecipe), Item.Get<FloorDaylightSensorItem>().UILink(), 1, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent));
            Initialize(Localizer.DoStr("Daylight Sensor (Floor)"), typeof(FloorDaylightSensorRecipe));

            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }
    #endregion

}
