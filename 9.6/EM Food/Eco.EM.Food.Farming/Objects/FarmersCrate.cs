using Eco.EM.Framework;
using Eco.EM.Framework.Resolvers;
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Food.Farming
{

    [Serialized]
    // Components
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(LinkComponent))]
    public partial class FarmersCrateObject : WorldObject, IRepresentsItem, ILinkRadiusObject, IStorageSlotObject
    {
        public override LocString DisplayName => Localizer.DoStr("Farmers Crate");
        public virtual Type RepresentedItemType => typeof(FarmersCrateItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        private static readonly LinkModel LinkDefaults = new(typeof(FarmersCrateObject)) { LinkRadius = 7, };
        private static readonly StorageSlotModel SlotDefaults = new(typeof(FarmersCrateObject), 20, 1f);

        static FarmersCrateObject()
        {
            EMLinkRadiusResolver.AddDefaults(LinkDefaults);
            EMStorageSlotResolver.AddDefaults(SlotDefaults);
            // Occupancy
        }

        protected override void Initialize() { }
        protected override void PostInitialize() 
        {
            base.PostInitialize();
            GetComponent<PublicStorageComponent>().Initialize(EMStorageSlotResolver.Obj.ResolveSlots(this));
            GetComponent<PublicStorageComponent>().Inventory.AddInvRestriction(new NotCarriedRestriction());
            GetComponent<LinkComponent>().Initialize(EMLinkRadiusResolver.Obj.ResolveLinkRadius(this));
        }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Farmers Crate")]
    public partial class FarmersCrateItem : WorldObjectItem<FarmersCrateObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Crate For Farmers to store their goods in");
        static FarmersCrateItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class FarmersCrateRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(FarmersCrateRecipe).Name,
            Assembly = typeof(FarmersCrateRecipe).AssemblyQualifiedName,
            HiddenName = "Farmers Crate",
            LocalizableName = Localizer.DoStr("Farmers Crate"),
            IngredientList = new()
            {
                new EMIngredient(item: "Wood", isTag: true, amount: 20, isStatic: true),
            },
            ProductList = new()
            {
                new EMCraftable(item: "FarmersCrateItem", amount: 1),
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

        static FarmersCrateRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public FarmersCrateRecipe()
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
