using System;
using System.Collections.Generic;
using Eco.EM.Framework;
using Eco.EM.Framework.Resolvers;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
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
    public partial class ShippingCrateObject : WorldObject, IRepresentsItem, IStorageSlotObject, ILinkRadiusObject
    {
        [Serialized] public bool OpenDoors { get; set; }
        public override LocString DisplayName => Localizer.DoStr("Shipping Crate");
        public virtual Type RepresentedItemType => typeof(ShippingCrateItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        private static readonly LinkModel LinkDefaults = new(typeof(ShippingCrateObject)) { LinkRadius = 7, };
        private static readonly StorageSlotModel SlotDefaults = new(typeof(ShippingCrateObject)) { StorageSlots = 36, };

        static ShippingCrateObject()
        {
            EMLinkRadiusResolver.AddDefaults(LinkDefaults);
            EMStorageSlotResolver.AddDefaults(SlotDefaults);

            var BlockOccupancyList = new List<BlockOccupancy>
            {
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, -1), typeof(WorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, -1), typeof(WorldObjectBlock))
            };

            AddOccupancy<ShippingCrateObject>(BlockOccupancyList);
        }

        protected override void Initialize()
        {
            GetComponent<PublicStorageComponent>().Initialize(EMStorageSlotResolver.Obj.ResolveSlots(this));
            GetComponent<PublicStorageComponent>().Inventory.AddInvRestriction(new NotCarriedRestriction());
            GetComponent<LinkComponent>().Initialize(EMLinkRadiusResolver.Obj.ResolveLinkRadius(this));
            GetComponent<StockpileComponent>().Initialize(new Vector3i(3, 3, 6));
        }
        protected override void PostInitialize() { }

        public override InteractResult OnActRight(InteractionContext context)
        {
            if (context.SelectedItem != null && context.SelectedItem.Type == typeof(ShippingCrateItem))
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

            return base.OnActRight(context);
        }

        public override void Tick()
        {
            base.Tick();
            SetAnimatedState("Doors", OpenDoors);
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(5000), MaxStackSize(10)]
    [LocDisplayName("Shipping Crate")]
    public partial class ShippingCrateItem : WorldObjectItem<ShippingCrateObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A simple shipping crate");
        static ShippingCrateItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class ShippingCrateRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ShippingCrateRecipe).Name,
            Assembly = typeof(ShippingCrateRecipe).AssemblyQualifiedName,
            HiddenName = "Shipping Crate",
            LocalizableName = Localizer.DoStr("Shipping Crate"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 15, true),
            },
            ProductList = new()
            {
                new EMCraftable("ShippingCrateItem", 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "WorkbenchItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };
        static ShippingCrateRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ShippingCrateRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}