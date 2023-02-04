using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using Eco.Mods.TechTree;
using Eco.Shared.Math;

namespace Eco.EM.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class SlidingDoorObject : EmDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Sliding Door"); } }

        public override void Destroy() => base.Destroy();

        static SlidingDoorObject()
        {
            AddOccupancy<SlidingDoorObject>(new List<BlockOccupancy>()
            {
                    new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
    }

    [Serialized]
    [Tier(2)]
    [Weight(600)]
    [LocDisplayName("Sliding Door")]
    [MaxStackSize(10)]
    public class SlidingDoorItem : WorldObjectItem<SlidingDoorObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Sliding Glass Door. Can be locked for certain players."); } }

        static SlidingDoorItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 4)]
    public partial class SlidingDoorRecipe : RecipeFamily
    {
        public SlidingDoorRecipe()
        {
            var product = new Recipe(
            "SlidingDoor",
            Localizer.DoStr("Sliding Door"),
            new IngredientElement[]
            {
                new IngredientElement(typeof(IronBarItem), 5, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)),
                new IngredientElement(typeof(GlassItem), 10, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)),
            },
            new CraftingElement<SlidingDoorItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(GlassworkingSkill));
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(SlidingDoorRecipe), 1, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Sliding Door"), typeof(SlidingDoorRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}