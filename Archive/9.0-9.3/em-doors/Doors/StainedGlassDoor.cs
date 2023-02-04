using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Mods.TechTree;
using Eco.EM.Artistry;

namespace Eco.EM.Doors
{
    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class StainedGlassDoorRecipe : RecipeFamily
    {
        public StainedGlassDoorRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Stained Glass Door",
                    Localizer.DoStr("Stained Glass Door"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(GlassItem), 6, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(IronBarItem), 4,typeof(SmeltingSkill),typeof(SmeltingLavishResourcesTalent)),
                        new IngredientElement(typeof(GreenDyeItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent))
                    },
                    new CraftingElement<StainedGlassDoorItem>()
                    )
            };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(StainedGlassDoorRecipe), 1, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Stained Glass Door"), typeof(StainedGlassDoorRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Tier(2)]
    [LocDisplayName("Stained Glass Door")]
    [Weight(600)]
    [MaxStackSize(10)]
    public class StainedGlassDoorItem : WorldObjectItem<StainedGlassDoorObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Beautiful Stained Glass Style Door."); } }
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class StainedGlassDoorObject : DoorObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Stained Glass Door"); } }

        protected override void Initialize()
        {
            base.Initialize();
        }

        public override void Destroy() => base.Destroy();

        static StainedGlassDoorObject()
        {
            AddOccupancy<StainedGlassDoorObject>(new List<BlockOccupancy>()
                {
                    new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                });
        }

    }
}