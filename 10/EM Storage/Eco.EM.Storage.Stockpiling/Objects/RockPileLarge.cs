using Eco.EM.Framework;
using Eco.EM.Framework.Resolvers;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Components.Storage;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
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
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]
    public partial class RockPileLargeObject : WorldObject, IRepresentsItem, ILinkRadiusObject, IStorageSlotObject
    {
        public static readonly Vector3i DefaultDim = new(7, 3, 4);

        public override LocString DisplayName => Localizer.DoStr("Large Rock Pile");
        public virtual Type RepresentedItemType => typeof(RockPileLargeItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        private static readonly StorageSlotModel SlotDefaults = new(typeof(RockPileLargeObject), 28, 1);
        private static readonly LinkModel LinkDefaults = new(typeof(RockPileLargeObject)) { LinkRadius = 16 };

        static RockPileLargeObject()
        {
            EMLinkRadiusResolver.AddDefaults(LinkDefaults);
            EMStorageSlotResolver.AddDefaults(SlotDefaults);

            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = -3; x <= 0; x++)
                for (int y = 0; y <= 3; y++)
                    for (int z = -6; z <= 0; z++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(WorldObjectBlock)));

            AddOccupancy<RockPileLargeObject>(BlockOccupancyList);
        }

        protected override void Initialize() { }
        protected override void PostInitialize()
        {
            base.PostInitialize();
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(EMStorageSlotResolver.Obj.ResolveSlots(this));
            storage.Storage.AddInvRestriction(new TagRestriction("Rock", "Ore", "Coal", "CrushedRock", "ConcentratedOre"));
            storage.Inventory.AddInvRestriction(new StackAllLimitRestriction(EMStorageSlotResolver.Obj.ResolveStackMultiplier(this)));
            GetComponent<StockpileComponent>().Initialize(DefaultDim);
            GetComponent<LinkComponent>().Initialize(EMLinkRadiusResolver.Obj.ResolveLinkRadius(this));
        }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Large Rock Pile")]
    [LocDescription("A Large container for storing all kinds of rocks and stones")]
    public partial class RockPileLargeItem : WorldObjectItem<RockPileLargeObject>
    {
        static RockPileLargeItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(AdvancedSmeltingSkill), 1)]
    public partial class RockPileLargeRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RockPileLargeRecipe).Name,
            Assembly = typeof(RockPileLargeRecipe).AssemblyQualifiedName,
            HiddenName = "Large Rock Pile",
            LocalizableName = Localizer.DoStr("Large Rock Pile"),
            IngredientList = new()
            {
                new EMIngredient("SteelBarItem", false, 8, true),
                new EMIngredient("SteelPlateItem", false, 20),
                new EMIngredient("RivetItem", false, 25),
            },
            ProductList = new()
            {
                new EMCraftable("RockPileLargeItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 350,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "RollingMillItem",
            RequiredSkillType = typeof(AdvancedSmeltingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(AdvancedSmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent) },
        };

        static RockPileLargeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RockPileLargeRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}