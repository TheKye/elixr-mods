using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
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
    [RequireComponent(typeof(StoreComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class FarmersStandObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Farmers Stand"); } }

        public virtual Type RepresentedItemType { get { return typeof(FarmersStandItem); } }

        protected override void PostInitialize()
        {
            this.GetComponent<PropertyAuthComponent>().SetPublic();
        }

        static FarmersStandObject()
        {
            WorldObject.AddOccupancy<FarmersStandObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(-2, 0, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 0, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 0, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 1, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 1, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 1, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 2, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 2, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 2, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-2, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 0, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 0, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 0, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 1, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 1, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 1, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 2, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 2, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 2, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(-1, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 0, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 0, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 0, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 0, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 1, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 1, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 1, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 2, -3), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 2, -2), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 2, -1), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
            });
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(5000)]
    [LocDisplayName("Farmers Stand")]
    public partial class FarmersStandItem : WorldObjectItem<FarmersStandObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Allows the selling and trading of items outdoors."); } }

        static FarmersStandItem()
        {
        }
    }

    [RequiresSkill(typeof(CarpentrySkill), 1)]
    public partial class FarmersStandRecipe : RecipeFamily
    {
        public FarmersStandRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Farmers Stand",
                    Localizer.DoStr("Farmers Stand"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Wood", 30, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                        new IngredientElement("NaturalFiber", 100, typeof(CarpentrySkill),typeof(CarpentryLavishResourcesTalent))
                    },
                    new CraftingElement<FarmersStandItem>()
                    )
                };
            this.ExperienceOnCraft = 10;
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FarmersStandRecipe), 25, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Farmers Stand"), typeof(FarmersStandRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

}
