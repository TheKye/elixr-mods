using System;
using System.ComponentModel;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using Eco.Mods.TechTree;
using Eco.Shared.Math;

namespace Eco.EM.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class ElegantDoubleDoorObject : EmDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Elegant Double Door"); } }
        public virtual Type RepresentedItemType { get { return typeof(ElegantDoubleDoorItem); } }

        static ElegantDoubleDoorObject()
        {
            AddOccupancy<ElegantDoubleDoorObject>(new List<BlockOccupancy>()
                {
                    new BlockOccupancy(new Vector3i(1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(1, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                });
        }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();

    }

    [Serialized]
    [Tier(1)]
    [Weight(600)]
    [MaxStackSize(10)]
    [DisplayName("Elegant Double Door")]
    public class ElegantDoubleDoorItem : WorldObjectItem<ElegantDoubleDoorObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Double Wooden Door."); } }

        static ElegantDoubleDoorItem() { }
    }

    [RequiresSkill(typeof(LoggingSkill), 0)]
    public partial class ElegantDoubleDoorRecipe : RecipeFamily
    {
        public ElegantDoubleDoorRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Elegant Double Door",
                    Localizer.DoStr("Elegant Double Door"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(ElegantDoorItem), 2, true),
                    },
                    new CraftingElement<ElegantDoubleDoorItem>()
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ElegantDoubleDoorRecipe), 2, typeof(LoggingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Elegant Double Door"), typeof(ElegantDoubleDoorRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}