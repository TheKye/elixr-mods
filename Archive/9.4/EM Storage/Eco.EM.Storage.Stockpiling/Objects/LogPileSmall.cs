using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Storage.Stockpiling
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]
    public partial class LogPileSmallObject : WorldObject, IRepresentsItem, ILinkRadiusObject, IStorageSlotObject
    {
        public static readonly Vector3i DefaultDim = new(2, 2, 4);
        public override LocString DisplayName => Localizer.DoStr("Small Log Pile");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public virtual Type RepresentedItemType => typeof(LogPileSmallItem);

        private static readonly StorageSlotModel SlotDefaults = new(typeof(LogPileSmallObject)) { StorageSlots = 8 };
        private static readonly LinkModel LinkDefaults = new(typeof(LogPileSmallObject)) { LinkRadius = 7 };

        static LogPileSmallObject()
        {
            EMLinkRadiusResolver.AddDefaults(LinkDefaults);
            EMStorageSlotResolver.AddDefaults(SlotDefaults);

            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = -1; x <= 0; x++)
                for (int y = 0; y <= 1; y++)
                    for (int z = -3; z <= 0; z++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(WorldObjectBlock)));

            AddOccupancy<LogPileSmallObject>(BlockOccupancyList);
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            StockpileComponent.ClearPlacementArea(this.Creator, this.Position3i, DefaultDim, this.Rotation);
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(EMStorageSlotResolver.Obj.ResolveSlots(this));
            storage.Storage.AddInvRestriction(new TagRestriction(Tag.Wood.Name));
            GetComponent<StockpileComponent>().Initialize(DefaultDim);
            GetComponent<LinkComponent>().Initialize(EMLinkRadiusResolver.Obj.ResolveLinkRadius(this));
        }
    }

    [Serialized]
    [LocDisplayName("Small Log Pile")]
    [Ecopedia("Crafted Objects", "Storage", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class LogPileSmallItem : WorldObjectItem<LogPileSmallObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Designates a 2x2x4 area as storage for logs.");

        static LogPileSmallItem() { }

        public override bool TryPlaceObject(Player player, Vector3i position, Quaternion rotation)
        {
            return this.TryPlaceObjectOnSolidGround(player, position, rotation);
        }
    }

    public partial class LogPileSmallRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LogPileSmallRecipe).Name,
            Assembly = typeof(LogPileSmallRecipe).AssemblyQualifiedName,
            HiddenName = "Small LogPile",
            LocalizableName = Localizer.DoStr("Small LogPile"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 8, true),
                new EMIngredient("NaturalFiber", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("LogPileSmallItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 25,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "WorkbenchItem",
        };
        static LogPileSmallRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LogPileSmallRecipe()
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
