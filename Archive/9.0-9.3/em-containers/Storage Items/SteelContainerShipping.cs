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

namespace Eco.EM.Storage
{
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class SteelShippingContainerObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Steel Shipping Container"); } }

        static SteelShippingContainerObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = -2; x <= 0; x++)
                for (int z = 0; z <= 2; z++)
                    for (int y = -8; y <= 0; y++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, z, y), typeof(WorldObjectBlock)));

            WorldObject.AddOccupancy<SteelShippingContainerObject>(BlockOccupancyList);
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

            if (context.SelectedItem != null && context.SelectedItem.Type == typeof(SteelShippingContainerItem))
            {
                Vector3i abovePos = Position3i;
                Quaternion playerFace = context.Player.User.FacingDir.Rotate180().ToQuat();
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

        protected override void PostInitialize()
        {
            base.PostInitialize();

            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(128);
            this.GetComponent<LinkComponent>().Initialize(12);
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [Tier(3)]
    [Weight(30000)]
    [MaxStackSize(10)]
    [LocDisplayName("Steel Shipping Container")]
    public partial class SteelShippingContainerItem : WorldObjectItem<SteelShippingContainerObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Steel Shipping Container For Storage."); } }
    }

    [RequiresSkill(typeof(IndustrySkill), 4)]
    public partial class SteelShippingContainerRecipe : RecipeFamily
    {
        public SteelShippingContainerRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Steel Shipping Container",
                    Localizer.DoStr("Steel Shipping Container"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelPlateItem), 20, typeof(IndustrySkill)),
                    new IngredientElement(typeof(ScrewsItem), 50, typeof(IndustrySkill)),
                    new IngredientElement(typeof(SteelBarItem), 30, typeof(IndustrySkill))
                    },
                    new CraftingElement<SteelShippingContainerItem>()
                    )
            };
            this.ExperienceOnCraft = 10;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(IndustrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelShippingContainerRecipe), 10, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Steel Shipping Container"), typeof(SteelShippingContainerRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(RollingMillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}