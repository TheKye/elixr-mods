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
using Eco.Shared.Serialization;
using System;

namespace Eco.EM.Building.Tools
{
    [Serialized]
    // Components
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class ToolRackObject : WorldObject, IRepresentsItem, ILinkRadiusObject, IStorageSlotObject
    {
        public override LocString DisplayName => Localizer.DoStr("Tool Rack");
        public virtual Type RepresentedItemType => typeof(ToolRackItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        private static readonly LinkModel LinkDefaults = new(typeof(ToolRackObject)) { LinkRadius = 7, };
        private static readonly StorageSlotModel SlotDefaults = new(typeof(ToolRackObject)) { StorageSlots = 8, };

        static ToolRackObject()
        {
            EMLinkRadiusResolver.AddDefaults(LinkDefaults);
            EMStorageSlotResolver.AddDefaults(SlotDefaults);
            
            // Occupancy
        }

        protected override void Initialize() 
        {
            GetComponent<PublicStorageComponent>().Initialize(EMStorageSlotResolver.Obj.ResolveSlots(this));
            GetComponent<LinkComponent>().Initialize(EMLinkRadiusResolver.Obj.ResolveLinkRadius(this));
            GetComponent<PublicStorageComponent>().Inventory.AddInvRestriction(new ItemTypeLimiterRestriction(new Type[] { typeof(ToolItem) }, Localizer.DoStr("Tools")));
        }

        protected override void PostInitialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Tool Rack")]
    public partial class ToolRackItem : WorldObjectItem<ToolRackObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A nice tool rack for some of your tools");
        static ToolRackItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class ToolRackRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ToolRackRecipe).Name,
            Assembly = typeof(ToolRackRecipe).AssemblyQualifiedName,
            HiddenName = "Tool Rack",
            LocalizableName = Localizer.DoStr("Tool Rack"),
            IngredientList = new()
            {
                new EMIngredient(item: "LogItem", isTag: false, amount: 1, isStatic: false),
            },
            ProductList = new()
            {
                new EMCraftable(item: "ChiselBagItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static ToolRackRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ToolRackRecipe()
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
