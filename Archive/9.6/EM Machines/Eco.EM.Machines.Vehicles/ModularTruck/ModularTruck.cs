using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;

namespace Eco.EM.Machines.Vehicles.ModularTruck
{
    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    [RequireComponent(typeof(ModularVehicleComponent))]
    [RequireComponent(typeof(SelectionStorageComponent))]
    public partial class ModularTruckObject : PhysicsWorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Modular Truck");

        static ModularTruckObject()
        {
            WorldObject.AddOccupancy<ModularTruckObject>(new List<BlockOccupancy>(0));
        }

        private static readonly string[] FuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private ModularTruckObject() { }

        private static readonly Type[] SegmentTypeList = Array.Empty<Type>();
        private static readonly Type[] AttachmentTypeList = new Type[]
        {
            typeof(BoxTruckItem), typeof(MiningTruckItem), typeof(GarbageTruckItem)
        };

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<SelectionStorageComponent>().CreateInventory(50, 25000000, new ModularInvRestriction(AttachmentTypeList, this));
            this.GetComponent<CustomTextComponent>().Initialize(200);
            this.GetComponent<FuelSupplyComponent>().Initialize(2, FuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(25);
            this.GetComponent<AirPollutionComponent>().Initialize(0.5f);
            this.GetComponent<VehicleComponent>().Initialize(15, 1, 2);
            this.GetComponent<VehicleComponent>().HumanPowered(2);
            this.GetComponent<ModularVehicleComponent>().Initialize(0, 1, SegmentTypeList, AttachmentTypeList);
        }

    }

    public class ModularInvRestriction : InventoryRestriction
    {
        public virtual int MaxItems { get; protected set; }
        public LocString nMessage { get; set; }

        public virtual bool Enabled => this.MaxItems > 0;

        public Type[] Module { get; protected set; }

        public WorldObject obj { get; protected set; }

        public override LocString Message => nMessage;

        public ModularInvRestriction(Type[] module, WorldObject obj)
        {
            this.MaxItems = 1;
            this.Module = module;
            this.obj = obj;
        }

        public override int MaxAccepted(Item item, int currentQuantity)
        {
            var attachment = obj.GetComponent<ModularVehicleComponent>();
            foreach(var m in Module)
            {
                if (attachment.AttachmentTypesString.Split(",")[0].Contains(m.GetLocDisplayName()) && m == typeof(BoxTruckItem))
                {
                    return item switch
                    {
                        FoodItem => 1000,
                        BlockItem => 5,
                        WorldObjectItem => (int)(item.MaxStackSize * 1.5),
                        Item => item.MaxStackSize,
                        _ => 0,
                    };
                }
                if(attachment.AttachmentTypesString.Split(",")[2].Contains(m.GetLocDisplayName()) && m == typeof(GarbageTruckItem))
                {
                    if (item is GarbageItem)
                    {
                        return item.MaxStackSize;
                    }
                    else
                        return 0;
                }
                if (attachment.AttachmentTypesString.Split(",")[1].Contains(m.GetLocDisplayName()) && m == typeof(MiningTruckItem))
                {
                    if (item is BlockItem)
                    {
                        return item.MaxStackSize;
                    }
                    else
                        return 0;
                }
                else
                    return 0;
            }
            return 0;
        }
    }

    [Serialized]
    [LocDisplayName("Modular Truck")]
    [Weight(25000)]
    [AirPollution(0.05f)]
    [Ecopedia("Crafted Objects", "Vehicles", createAsSubPage: true)]
    public partial class ModularTruckItem : WorldObjectItem<ModularTruckObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Modular Truck."); } }
    }


    [RequiresSkill(typeof(MechanicsSkill), 2)]
    public partial class ModularTruckRecipe : RecipeFamily
    {
        public ModularTruckRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "ModularTruck",  //noloc
                Localizer.DoStr("Modular Truck"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronPlateItem), 12, typeof(MechanicsSkill)),
                    new IngredientElement(typeof(IronPipeItem), 8, typeof(MechanicsSkill)),
                    new IngredientElement(typeof(ScrewsItem), 24, typeof(MechanicsSkill)),
                    new IngredientElement(typeof(LeatherHideItem), 20, typeof(MechanicsSkill)),
                    new IngredientElement("Lumber", 30, typeof(MechanicsSkill)), //noloc
                    new IngredientElement(typeof(PortableSteamEngineItem), 1, true),
                    new IngredientElement(typeof(IronWheelItem), 4, true),
                    new IngredientElement(typeof(IronAxleItem), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<ModularTruckItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 25;
            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModularTruckRecipe), 10, typeof(MechanicsSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modular Truck"), typeof(ModularTruckRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}