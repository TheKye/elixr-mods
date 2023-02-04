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
    public partial class ShippingContainerObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Shipping Container"); } }

        static ShippingContainerObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = -1; x <= 0; x++)
                for (int z = 0; z <= 1; z++)
                    for (int y = -5; y <= 0; y++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, z, y), typeof(WorldObjectBlock)));

            AddOccupancy<ShippingContainerObject>(BlockOccupancyList);
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

            if (context.SelectedItem != null && context.SelectedItem.Type == typeof(ShippingContainerItem))
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
            storage.Initialize(56);
            this.GetComponent<LinkComponent>().Initialize(12);
        }

        public override void Destroy() => base.Destroy();
    }
       
    [Serialized]
    [Tier(2)]
    [LocDisplayName("Shipping Container")]
    [Weight(20000)]
    [MaxStackSize(10)]
    public partial class ShippingContainerItem : WorldObjectItem<ShippingContainerObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Shipping Container For Storage."); } }
    }

    [RequiresSkill(typeof(MechanicsSkill), 3)]
    public partial class ShippingContainerRecipe : RecipeFamily
    {
        public ShippingContainerRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Shipping Container",
                    Localizer.DoStr("Shipping Container"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronPlateItem), 30, typeof(MechanicsSkill)),
                    new IngredientElement(typeof(ScrewsItem), 40, typeof(MechanicsSkill)),
                    new IngredientElement(typeof(IronBarItem), 15, typeof(MechanicsSkill))
                    },
                    new CraftingElement<ShippingContainerItem>()
                    )
            };
            this.ExperienceOnCraft = 10;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ShippingContainerRecipe), 10, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Shipping Container"), typeof(ShippingContainerRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}