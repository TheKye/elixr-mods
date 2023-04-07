using System;
using System.Collections.Generic;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class AnimalTroughObject : WorldObject, IRepresentsItem, ILinkRadiusObject, IStorageSlotObject
    {
        public override LocString DisplayName                 => Localizer.DoStr("Animal Trough");
        public virtual Type RepresentedItemType               => typeof(AnimalTroughItem);

        private static readonly LinkModel LinkDefaults        = new(typeof(AnimalTroughObject)) { LinkRadius   = 12, };
        private static readonly StorageSlotModel SlotDefaults = new(typeof(AnimalTroughObject), 4, 1f);

        static AnimalTroughObject() 
        {
            EMLinkRadiusResolver.AddDefaults(LinkDefaults);
            EMStorageSlotResolver.AddDefaults(SlotDefaults);


            AddOccupancy<AnimalTroughObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock)),
            });
        }

        protected override void Initialize() { base.Initialize(); }

        protected override void PostInitialize()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(EMStorageSlotResolver.Obj.ResolveSlots(this));
            storage.Storage.AddInvRestriction(new TagRestriction("Feed")); // can't store anything other then items with the feed tag
            this.GetComponent<LinkComponent>().Initialize(EMLinkRadiusResolver.Obj.ResolveLinkRadius(this));

            UpdateAnimation();
            base.PostInitialize();
        }

        public override void Tick() { UpdateAnimation(); }

        public void UpdateAnimation()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            SetAnimatedState("HasInventory", storage.Inventory.IsEmpty);
        }


    }

    [Serialized]
    [Weight(600)]
    [MaxStackSize(10)]
    [LocDisplayName("Animal Trough")]
    public partial class AnimalTroughItem : WorldObjectItem<AnimalTroughObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Trough for holding Animal Feed.");
    }

    [RequiresSkill(typeof(FarmingSkill),0)]
    public partial class AnimalTroughRecipe: RecipeFamily, IConfigurableRecipe
    {

        static RecipeDefaultModel Defaults => new()
        {
            ModelType                      = typeof(AnimalTroughRecipe).Name,
            Assembly                       = typeof(AnimalTroughRecipe).AssemblyQualifiedName,
            HiddenName                     = "AnimalTrough",
            LocalizableName                = Localizer.DoStr("Animal Trough"),
            IngredientList                 = new()
            {
                new EMIngredient("Wood", true, 8, true),
                new EMIngredient("NaturalFiber", true, 20),
            },
            ProductList                    = new()
            {
                new EMCraftable("AnimalTroughItem"),
            },
            RequiredSkillType              = typeof(FarmingSkill),
            RequiredSkillLevel             = 0,
            BaseExperienceOnCraft          = 1,
            BaseLabor                      = 250,
            LaborIsStatic                  = false,
            BaseCraftTime                  = 1,
            CraftTimeIsStatic              = false,
            CraftingStation                = "WorkbenchItem",
        };

        static AnimalTroughRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AnimalTroughRecipe()
        {
            this.Recipes                   = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories           = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes              = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft         = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
