using System;
using System.Collections.Generic;
using Eco.Core.Controller;
using Eco.EM.Framework.Resolvers;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Auth;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Components.Storage;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Interactions.Interactors;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Placement;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.NewTooltip;
using Eco.Mods.TechTree;
using Eco.Shared.IoC;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.SharedTypes;
using Eco.Shared.Utils;

namespace Eco.EM.Storage.Shipping
{
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    public partial class ShippingContainer20Object : WorldObject, IRepresentsItem, ILinkRadiusObject, IStorageSlotObject, IHasInteractions
    {
        [Serialized] public bool OpenDoors { get; set; }
        public override LocString DisplayName => Localizer.DoStr("20ft Shipping Container");
        public override TableTextureMode TableTexture => TableTextureMode.Metal;
        public Type RepresentedItemType => typeof(ShippingContainer20Item);

        private static readonly LinkModel LinkDefaults = new(typeof(ShippingContainer20Object)) { LinkRadius = 12, };
        private static readonly StorageSlotModel SlotDefaults = new(typeof(ShippingContainer20Object), 56, 1f);

        static ShippingContainer20Object()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = -2; x <= 0; x++)
                for (int y = 0; y <= 2; y++)
                    for (int z = -6; z <= 0; z++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(WorldObjectBlock)));

            AddOccupancy<ShippingContainer20Object>(BlockOccupancyList);

            EMLinkRadiusResolver.AddDefaults(LinkDefaults);
            EMStorageSlotResolver.AddDefaults(SlotDefaults);
        }

        [Interaction(InteractionTrigger.RightClick, "Place", InteractionModifier.Shift)]
        public void PlaceContainer(Player context, InteractionTriggerInfo triggerInfo, InteractionTarget interactionTarget)
        {
            if (context.User.Inventory.Toolbar.SelectedItem != null && context.User.Inventory.Toolbar.SelectedItem.Type == typeof(ShippingContainer20Item))
            {
                Vector3i abovePos = Position3i;
                Eco.Shared.Math.Quaternion playerFace = context.User.FacingDir.Rotate180().ToQuat();
                do
                {
                    abovePos.Y += 1;
                }
                while (WorldUtils.WorldObjectsAtPos(abovePos) != null);
                WorldObjectPlacementUtils.TryPlaceWorldObjectNow(context, (WorldObjectItem)context.User.Inventory.Toolbar.SelectedItem, context.User.Inventory.Toolbar.SelectedStack, pos: abovePos, rot: playerFace);
                return;
            }
        }

        [Interaction(InteractionTrigger.RightClick, "Open Doors", InteractionModifier.Ctrl)]
        public void OpenDoor(Player context, InteractionTriggerInfo interactionTriggerInfo, InteractionTarget interactionTarget)
        {
            var isAuthorized = ServiceHolder<IAuthManager>.Obj.IsAuthorized(this, context.User);

            if (isAuthorized)
            {
                OpenDoors = !OpenDoors;
            }
            else
            {
                context.ErrorLocStr("You Are Not Authorized To Do That");
                return;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();

            var storage = GetComponent<PublicStorageComponent>();
            storage.Initialize(EMStorageSlotResolver.Obj.ResolveSlots(this));
            storage.Inventory.AddInvRestriction(new StackAllLimitRestriction(EMStorageSlotResolver.Obj.ResolveStackMultiplier(this)));
            GetComponent<LinkComponent>().Initialize(EMLinkRadiusResolver.Obj.ResolveLinkRadius(this));
            GetComponent<StockpileComponent>().Initialize(new Vector3i(3, 3, 6));
            GetComponent<CustomTextComponent>().Initialize(700);
        }



        public override void Tick()
        {
            base.Tick();
            SetAnimatedState("OpenDoor", OpenDoors);
        }
    }

    [Serialized]
    [Tier(2)]
    [LocDisplayName("20ft Shipping Container")]
    [Weight(20000)]
    [MaxStackSize(10)]
    [Currency]
    [LocDescription("A Large Shipping Container For Storage. I Can hold alot of items.")]
    public partial class ShippingContainer20Item : WorldObjectItem<ShippingContainer20Object>, IPersistentData
    {
        [Serialized, SyncToView, NewTooltipChildren(CacheAs.Instance, flags: TTFlags.AllowNonControllerTypeForChildren)] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(MechanicsSkill), 3)]
    public partial class ShippingContainer20Recipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ShippingContainer20Recipe).Name,
            Assembly = typeof(ShippingContainer20Recipe).AssemblyQualifiedName,
            HiddenName = "20ft Shipping Container",
            LocalizableName = Localizer.DoStr("20ft Shipping Container"),
            RequiredSkillType = typeof(MechanicsSkill),
            RequiredSkillLevel = 3,
            SpeedImprovementTalents = new Type[] { typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent) },
            IngredientList = new()
            {
                new EMIngredient("IronPlateItem", false, 100),
                new EMIngredient("ScrewsItem", false, 50),
                new EMIngredient("IronBarItem", false, 30)
            },
            ProductList = new()
            {
                new EMCraftable("ShippingContainer20Item"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "MachinistTableItem",
        };
        static ShippingContainer20Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ShippingContainer20Recipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ModsPreInitialize();
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}