using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System.Linq;
using Eco.Gameplay.Components.Auth;
using System.Collections.Generic;
using System.Threading;
using Eco.Core.IoC;
using Eco.Mods.TechTree;
using Eco.Shared.Utils;
using Eco.Core.Controller;

namespace Eco.EM.Industry
{
    [Serialized]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    [RequireComponent(typeof(ItemFilterSlotComponent))]
    [RequireComponent(typeof(StatusComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class MechanicalInventoryInserterObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Inventory Inserter"); } }

        private float simulatedDelay = 0f;
        public Inventory ExtractionInventory { get; set; }
        public Inventory InsertionInventory { get; set; }

        protected override void Initialize()
        {
            this.GetComponent<PowerConsumptionComponent>().Initialize(200);
            this.GetComponent<PowerGridComponent>().Initialize(10, new MechanicalPower());
            this.GetComponent<PropertyAuthComponent>();
            var storage = this.GetComponent<ItemFilterSlotComponent>();
            storage.Initialize(1);
            storage.Storage.AddInvRestriction(new FilterRestriction());
            this.GetComponent<CustomTextComponent>().Initialize(100);
        }

        static MechanicalInventoryInserterObject()
        {
            AddOccupancy<MechanicalInventoryInserterObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, -1)),
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 0, 1)),
                new BlockOccupancy(new Vector3i(-1, 0, -1)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 1)),
                new BlockOccupancy(new Vector3i(0, 1, -1)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 1)),
                new BlockOccupancy(new Vector3i(-1, 1, -1)),
                new BlockOccupancy(new Vector3i(-1, 1, 0)),
                new BlockOccupancy(new Vector3i(-1, 1, 1)),
                });
        }

        public override void Tick()
        {
            ExtractionInventory = ConnectInventory(-(Vector3i)Rotation.Forward - (Vector3i)Rotation.Forward);
            InsertionInventory = ConnectInventory((Vector3i)Rotation.Forward + (Vector3i)Rotation.Forward);
            if (TestExtraction())
                MoveItem(GetFirstItem());
            simulatedDelay += ServiceHolder<IWorldObjectManager>.Obj.TickDeltaTime;
            var storage = this.GetComponent<ItemFilterSlotComponent>();
            var textC = this.GetComponent<CustomTextComponent>();
            foreach (var item in storage.Inventory.Stacks)
            {
                if (item.Item != null)
                {
                    string N = item.Item.Name;
                    string IN = item.Item.DisplayName;

                    string fullText = Localizer.Format($"<size=50%>Filtering...\n <size=25%> " + IN + "\n\n\n <size=100%><ecoicon item=\"" + N + "\"></ecoicon>");
                    textC.TextData.Text = fullText;
                    textC.TextData.Changed(nameof(textC.TextData.Text));
                    textC.Parent.SetDirty();
                }
                else
                {
                    string fullText = "";
                    textC.TextData.Text = ProfanityFilter.Clean(fullText.PercentizeSizeTags().CapLength(100));
                    textC.TextData.Changed(nameof(textC.TextData.Text));
                    textC.Parent.SetDirty();
                }
            }
            base.Tick();
        }

        public override void Destroy() => base.Destroy();

        // Ensure there is a connected extraction invenotry
        private Inventory ConnectInventory(Vector3i vector)
        {
            WorldObject obj = WorldObjectsAtPos(this.Position3i + vector);

            if (obj != null)
            {
                if (obj.HasComponent<ConveyorStorageComponent>())
                    return obj.GetComponent<ConveyorStorageComponent>().Inventory;
                if (obj.HasComponent<PublicStorageComponent>())
                    return obj.GetComponent<PublicStorageComponent>().Inventory;
                if (obj.HasComponent<FuelSupplyComponent>())
                    return obj.GetComponent<FuelSupplyComponent>().Inventory;
            }

            return null;
        }

        // Finds the world object at the position passed in
        public WorldObject WorldObjectsAtPos(Vector3i pos)
        {
            WorldObject objAtPos = null;
            WorldObjectManager.ForEach(worldObject =>
            {
                foreach (Vector3i vector in worldObject.WorldOccupancy)
                {
                    if (vector == pos)
                    {
                        objAtPos = worldObject;
                        break;
                    }
                }
            });
            return objAtPos;
        }

        public bool TestExtraction()
        {
            if (ExtractionInventory == null || InsertionInventory == null || simulatedDelay < 2f || ExtractionInventory.IsEmpty || GetComponent<ItemFilterSlotComponent>().Inventory.IsEmpty || !Operating)
                return false;

            return true;
        }

        private Item GetFirstItem()
        {
            foreach (ItemStack i in ExtractionInventory.NonEmptyStacks)
            {
                if ((ItemAttribute.Has<FilterModuleAttribute>(GetComponent<ItemFilterSlotComponent>().Inventory.NonEmptyStacks.FirstOrDefault().Item.Type)
                    && (GetComponent<ItemFilterSlotComponent>().Inventory.NonEmptyStacks.FirstOrDefault().Item as FilterModuleItem).FilterList.Contains(i.Item)))
                {
                    return i.Item;
                }
                else if ((GetComponent<ItemFilterSlotComponent>().Inventory.NonEmptyStacks.FirstOrDefault().Item == i.Item))
                {
                    return i.Item;
                }
            }
            return null;
        }

        private void MoveItem(Item i)
        {
            if (i == null)
                return;

            TriggerAnimatedEvent("Operating");
            Thread.Sleep(1333);
            if (i.IsCarried)
            {
                ExtractionInventory.MoveAsManyItemsAsPossible(i.Type, 10, InsertionInventory);
            }
            else
            {
                ExtractionInventory.MoveAsManyItemsAsPossible(i.Type, 25, InsertionInventory);
            }
            simulatedDelay = 0f;
        }

    }

    [Serialized]
    [LocDisplayName("Inventory Inserter")]
    [MaxStackSize(5)]
    public partial class MechanicalInventoryInserterItem : WorldObjectItem<MechanicalInventoryInserterObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("One way movement of items between inventories. Face the inserter towards the invenotry you are taking from."); } }

        static MechanicalInventoryInserterItem() { }
    }

    [RequiresSkill(typeof(MechanicsSkill), 1)]
    public partial class MechanicalInventoryInserterRecipe : RecipeFamily
    {
        public MechanicalInventoryInserterRecipe()
        {
            var product = new Recipe(
                "Mechanical Inventory Inserter",
                Localizer.DoStr("Mechanical Inventory Inserter"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(PistonItem), 3,typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                    new IngredientElement(typeof(GearboxItem), 3 ,typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                    new IngredientElement(typeof(IronBarItem), 12 ,typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                },

                 new CraftingElement<MechanicalInventoryInserterItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MechanicalInventoryInserterRecipe), 10f, typeof(MechanicsSkill), typeof(MechanicsParallelSpeedTalent), typeof(MechanicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Mechanical Inventory Inserter"), typeof(MechanicalInventoryInserterRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}