using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.Mods.TechTree;
using Eco.Shared.Math;

namespace Eco.EM.Doors
{
    [RequiresSkill(typeof(LoggingSkill), 0)]
    public partial class ElegantDoorRecipe : RecipeFamily
    {
        public ElegantDoorRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Elegant Door",
                    Localizer.DoStr("Elegant Door"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Wood", 8, typeof(LoggingSkill))
                    },
                    new CraftingElement<ElegantDoorItem>()
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ElegantDoorRecipe), 1, typeof(LoggingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Elegant Door"), typeof(ElegantDoorRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Tier(1)]
    [LocDisplayName("Elegant Door")]
    [Weight(600)]
    [MaxStackSize(10)]
    public class ElegantDoorItem : WorldObjectItem<ElegantDoorObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("An Elegant Style Door."); } }

    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class ElegantDoorObject : DoorObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Elegant Door"); } }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();

        static ElegantDoorObject()
        {
            AddOccupancy<ElegantDoorObject>(new List<BlockOccupancy>()
                {
                    new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                });
        }
    }
}