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

namespace Eco.EM.Building.Tools
{
    [Serialized]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class ToolShedObject : WorldObject, IRepresentsItem, ILinkRadiusObject, IStorageSlotObject
    {
        public override LocString DisplayName => Localizer.DoStr("Tool Shed");
        public virtual Type RepresentedItemType => typeof(ToolShedItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        private static readonly LinkModel LinkDefaults = new(typeof(ToolShedObject)) { LinkRadius = 7, };
        private static readonly StorageSlotModel SlotDefaults = new(typeof(ToolShedObject)) { StorageSlots = 24, };

        static ToolShedObject()
        {
            EMLinkRadiusResolver.AddDefaults(LinkDefaults);
            EMStorageSlotResolver.AddDefaults(SlotDefaults);

            // Occupancy
            AddOccupancy<ToolShedObject>(
                new List<BlockOccupancy>(){
                    //XY
                    new BlockOccupancy(new Vector3i(0, 0, 0)),
                    new BlockOccupancy(new Vector3i(-1, 0, 0)),
                    new BlockOccupancy(new Vector3i(-2, 0, 0)),
                    new BlockOccupancy(new Vector3i(-3, 0, 0)),

                    new BlockOccupancy(new Vector3i(0, 1, 0)),
                    new BlockOccupancy(new Vector3i(-1, 1, 0)),
                    new BlockOccupancy(new Vector3i(-2, 1, 0)),
                    new BlockOccupancy(new Vector3i(-3, 1, 0)),

                    new BlockOccupancy(new Vector3i(0, 2, 0)),
                    new BlockOccupancy(new Vector3i(-1, 2, 0)),
                    new BlockOccupancy(new Vector3i(-2, 2, 0)),
                    new BlockOccupancy(new Vector3i(-3, 2, 0)),
                    
                    //XZY
                    new BlockOccupancy(new Vector3i(0, 0, -1)),
                    new BlockOccupancy(new Vector3i(-1, 0, -1)),
                    new BlockOccupancy(new Vector3i(-2, 0, -1)),
                    new BlockOccupancy(new Vector3i(-3, 0, -1)),
                                                          
                    new BlockOccupancy(new Vector3i(0, 1, -1)),
                    new BlockOccupancy(new Vector3i(-1, 1, -1)),
                    new BlockOccupancy(new Vector3i(-2, 1, -1)),
                    new BlockOccupancy(new Vector3i(-3, 1, -1)),
                                                          
                    new BlockOccupancy(new Vector3i(0, 2, -1)),
                    new BlockOccupancy(new Vector3i(-1, 2, -1)),
                    new BlockOccupancy(new Vector3i(-2, 2, -1)),
                    new BlockOccupancy(new Vector3i(-3, 2, -1))
                });
        }

        protected override void Initialize()
        {
            GetComponent<PublicStorageComponent>().Initialize(EMStorageSlotResolver.Obj.ResolveSlots(this));
            GetComponent<LinkComponent>().Initialize(EMLinkRadiusResolver.Obj.ResolveLinkRadius(this));
            GetComponent<PublicStorageComponent>().Inventory.AddInvRestriction(new ToolLimitRestriction());
        }
        protected override void PostInitialize() { }

        public override void Destroy() => base.Destroy();
    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Tool Shed")]
    public partial class ToolShedItem : WorldObjectItem<ToolShedObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A shed for your tools");
        static ToolShedItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class ToolShedRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ToolShedRecipe).Name,
            Assembly = typeof(ToolShedRecipe).AssemblyQualifiedName,
            HiddenName = "ToolShed",
            LocalizableName = Localizer.DoStr("Tool Shed"),
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

        static ToolShedRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ToolShedRecipe()
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