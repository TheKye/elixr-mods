using Eco.EM.Framework;
using Eco.EM.Framework.Resolvers;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Storage.Stockpiling
{
    [Serialized]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]
    public partial class LogPileMediumObject : WorldObject, IRepresentsItem, ILinkRadiusObject, IStorageSlotObject
    {
        public static readonly Vector3i DefaultDim = new(3, 3, 4);

        public override LocString DisplayName => Localizer.DoStr("Medium Log Pile");
        public virtual Type RepresentedItemType => typeof(LogPileMediumItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        private static readonly StorageSlotModel SlotDefaults = new(typeof(LogPileMediumObject)) { StorageSlots = 16, StackMultiplier = 1f };
        private static readonly LinkModel LinkDefaults = new(typeof(LogPileMediumObject)) { LinkRadius = 12 };

        static LogPileMediumObject()
        {
            EMLinkRadiusResolver.AddDefaults(LinkDefaults);
            EMStorageSlotResolver.AddDefaults(SlotDefaults);

            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = -2; x <= 0; x++)
                for (int y = 0; y <= 3; y++)
                    for (int z = -3; z <= 0; z++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(WorldObjectBlock)));

            AddOccupancy<LogPileMediumObject>(BlockOccupancyList);
        }

        protected override void Initialize() { }
        protected override void PostInitialize()
        {
            base.PostInitialize();
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(EMStorageSlotResolver.Obj.ResolveSlots(this));
            storage.Storage.AddInvRestriction(new TagRestriction(Tag.Wood.Name));
            storage.Inventory.AddInvRestriction(new StackAllLimitRestriction(EMStorageSlotResolver.Obj.ResolveStackMultiplier(this)));
            GetComponent<StockpileComponent>().Initialize(DefaultDim);
            GetComponent<LinkComponent>().Initialize(EMLinkRadiusResolver.Obj.ResolveLinkRadius(this));
        }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Medium Log Pile")]
    public partial class LogPileMediumItem : WorldObjectItem<LogPileMediumObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A medium pile for logs");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
        static LogPileMediumItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 1)]
    public partial class LogPileMediumRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LogPileMediumRecipe).Name,
            Assembly = typeof(LogPileMediumRecipe).AssemblyQualifiedName,
            HiddenName = "Medium Log Pile",
            LocalizableName = Localizer.DoStr("Medium Log Pile"),
            IngredientList = new()
            {
                new EMIngredient("Lumber", true, 20),
                new EMIngredient("NaturalFiber", true, 50)
            },
            ProductList = new()
            {
                new EMCraftable("LogPileMediumItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "SawmillItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static LogPileMediumRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LogPileMediumRecipe()
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
