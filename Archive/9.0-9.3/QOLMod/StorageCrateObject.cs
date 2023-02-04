using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class StorageCrateObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Storage Crate"); } }

        public virtual Type RepresentedItemType { get { return typeof(StorageCrateItem); } }

        protected override void Initialize()
        {
            base.PostInitialize();

            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(26);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large items
            this.GetComponent<LinkComponent>().Initialize(12);
        }

        public WorldObject WorldObjectsAtPos(Vector3i pos)
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
        public override LocString DisplayDescription { get { return Localizer.DoStr("A General Storage Crate for storing small items.. But has limited link range"); } }
    }

    [RequiresSkill(typeof(LoggingSkill), 2)]
    public partial class StorageCrateRecipe : RecipeFamily
    {
        public StorageCrateRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Storage Crate",
                    Localizer.DoStr("Storage Crate"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Wood", 40, typeof(LoggingSkill))
                    },
                    new CraftingElement<StorageCrateItem>()
                    )
                };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(StorageCrateRecipe), 10, typeof(LoggingSkill));
            this.Initialize(Localizer.DoStr("Storage Crate"), typeof(StorageCrateRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

}