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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]
    public partial class RockPileMediumObject : WorldObject, IRepresentsItem, ILinkRadiusObject, IStorageSlotObject
    {
        public static readonly Vector3i DefaultDim = new(4, 3, 4);

        public override LocString DisplayName => Localizer.DoStr("Medium Rock Pile");
        public virtual Type RepresentedItemType => typeof(RockPileMediumItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        private static readonly StorageSlotModel SlotDefaults = new(typeof(RockPileMediumObject), 16, 1);
        private static readonly LinkModel LinkDefaults = new(typeof(RockPileMediumObject)) { LinkRadius = 12 };

        static RockPileMediumObject()
        {
            EMLinkRadiusResolver.AddDefaults(LinkDefaults);
            EMStorageSlotResolver.AddDefaults(SlotDefaults);

            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = -3; x <= 0; x++)
                for (int y = 0; y <= 3; y++)
                    for (int z = -3; z <= 0; z++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(WorldObjectBlock)));

            AddOccupancy<RockPileMediumObject>(BlockOccupancyList);
        }

        protected override void Initialize() { }
        protected override void PostInitialize()
        {
            base.PostInitialize();
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(EMStorageSlotResolver.Obj.ResolveSlots(this));
            storage.Storage.AddInvRestriction(new TagRestriction("Rock", "Ore", "Coal"));
            storage.Inventory.AddInvRestriction(new StackAllLimitRestriction(EMStorageSlotResolver.Obj.ResolveStackMultiplier(this)));
            GetComponent<StockpileComponent>().Initialize(DefaultDim);
            GetComponent<LinkComponent>().Initialize(EMLinkRadiusResolver.Obj.ResolveLinkRadius(this));
        }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Medium Rock Pile")]
    public partial class RockPileMediumItem : WorldObjectItem<RockPileMediumObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A medium pile for rocks.");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
        static RockPileMediumItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class RockPileMediumRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RockPileMediumRecipe).Name,
            Assembly = typeof(RockPileMediumRecipe).AssemblyQualifiedName,
            HiddenName = "Medium Rock Pile",
            LocalizableName = Localizer.DoStr("Medium Rock Pile"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 20),
                new EMIngredient("IronPlateItem", false, 30),
            },
            ProductList = new()
            {
                new EMCraftable("RockPileMediumItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "AnvilItem",
            RequiredSkillType = typeof(SmeltingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(SmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(SmeltingFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static RockPileMediumRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RockPileMediumRecipe()
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
