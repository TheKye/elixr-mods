using System;
using System.Collections.Generic;
using Eco.EM.Framework.Resolvers;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Auth;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.IoC;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

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
    public partial class ShippingContainer20Object : WorldObject, IRepresentsItem, ILinkRadiusObject, IStorageSlotObject
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

        public override InteractResult OnActRight(InteractionContext context)
        {

            if (context.SelectedItem != null && context.SelectedItem.Type == typeof(ShippingContainer20Item))
            {
                Vector3i abovePos = Position3i;
                Quaternion playerFace = context.Player.User.FacingDir.Rotate180().ToQuat();
                do
                {
                    abovePos.Y += 1;
                }
                while (WorldUtils.WorldObjectsAtPos(abovePos) != null);
                WorldObjectManager.TryPlaceWorldObject(context.Player, (WorldObjectItem)context.SelectedItem, abovePos, playerFace);
                return InteractResult.Success;
            }
            var isAuthorized = ServiceHolder<IAuthManager>.Obj.IsAuthorized(context);
            if (context.Parameters != null && context.Parameters.ContainsKey("OpenDoors"))
            {
                if (isAuthorized)
                {
                    OpenDoors = !OpenDoors;
                    return InteractResult.Success;
                }
                else
                {
                    context.Player.ErrorLocStr("You Are Not Authorized To Do That");
                    return InteractResult.Fail;
                }
            }

            return base.OnActRight(context);
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
            SetAnimatedState("Doors", OpenDoors);
        }
    }

    [Serialized]
    [Tier(2)]
    [LocDisplayName("20ft Shipping Container")]
    [Weight(20000)]
    [MaxStackSize(10)]
    public partial class ShippingContainer20Item : WorldObjectItem<ShippingContainer20Object>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Large Shipping Container For Storage. I Can hold alot of items.");
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
            this.Initialize(Defaults.LocalizableName, GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}