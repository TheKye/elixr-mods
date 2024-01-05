using System;
using Eco.EM.Framework.Resolvers;
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

namespace Eco.EM.Storage.Warehousing
{
    [Serialized]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]

    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class StorageCrateObject : WorldObject, IRepresentsItem, ILinkRadiusObject, IStorageSlotObject
    {
        public override LocString DisplayName => Localizer.DoStr("Storage Crate");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public virtual Type RepresentedItemType => typeof(StorageCrateItem);

        private static readonly LinkModel LinkDefaults = new(typeof(StorageCrateObject)) { LinkRadius = 12, };
        private static readonly StorageSlotModel SlotDefaults = new(typeof(StorageCrateObject), 38, 1);

        static StorageCrateObject()
        {
            EMLinkRadiusResolver.AddDefaults(LinkDefaults);
            EMStorageSlotResolver.AddDefaults(SlotDefaults);
        }

        protected override void Initialize()
        {
            base.PostInitialize();

            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(EMStorageSlotResolver.Obj.ResolveSlots(this));
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large items
            GetComponent<LinkComponent>().Initialize(EMLinkRadiusResolver.Obj.ResolveLinkRadius(this));
        }

        public static WorldObject WorldObjectsAtPos(Vector3i pos)
        {
            WorldObject objAtPos = null;
            WorldObjectManager.ForEach(worldObject =>
            {
                foreach (Vector3i vector in worldObject.WorldOccupancy)
                {
                    if (vector == pos)
                    {
                        objAtPos = worldObject;
                        break;
                    }
                }
            });
            return objAtPos;
        }

        public override InteractResult OnActRight(InteractionContext context)
        {

            if (context.SelectedItem != null && context.SelectedItem.Type == typeof(StorageCrateItem))
            {
                Vector3i abovePos = Position3i;
                Quaternion playerFace = context.Player.User.FacingDir.ToQuat();
                do
                {
                    abovePos.Y += 1;
                }
                while (WorldObjectsAtPos(abovePos) != null);
                WorldObjectManager.TryPlaceWorldObject(context.Player, (WorldObjectItem)context.SelectedItem, abovePos, playerFace);
                return InteractResult.Success;
            }

            return base.OnActRight(context);
        }


    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(600)]
    [LocDisplayName("Storage Crate")]
    public partial class StorageCrateItem : WorldObjectItem<StorageCrateObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A General Storage Crate for storing small items.. But has limited link range");
    }

    [RequiresSkill(typeof(LoggingSkill), 2)]
    public partial class StorageCrateRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StorageCrateRecipe).Name,
            Assembly = typeof(StorageCrateRecipe).AssemblyQualifiedName,
            HiddenName = "Storage Crate",
            LocalizableName = Localizer.DoStr("Storage Crate"),
            RequiredSkillType = typeof(LoggingSkill),
            RequiredSkillLevel = 2,
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 100),
            },
            ProductList = new()
            {
                new EMCraftable("StorageCrateItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "WorkbenchItem",
        };
        static StorageCrateRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StorageCrateRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ModsPreInitialize();
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}