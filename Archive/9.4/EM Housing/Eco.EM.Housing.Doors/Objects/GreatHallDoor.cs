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
using Eco.EM.Framework.Resolvers;
using System;
using Eco.Core.Items;

namespace Eco.EM.Housing.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class GreatHallDoorObject : DoorObject
    {
        public override LocString DisplayName => Localizer.DoStr("Great Hall Door");
        public override Type RepresentedItemType => typeof(GreatHallDoorItem);
        public override bool HasTier => true;
        public override int Tier => 1;
        protected override void Initialize() { }

        static GreatHallDoorObject()
        {
            #region Occupancy
            var BlockOccupancyList = new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-2, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-2, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(0, 2, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-1, 2, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-2, 2, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(0, 3, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-1, 3, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-2, 3, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(0, 4, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-1, 4, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-2, 4, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(0, 5, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-1, 5, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(-2, 5, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),

                new BlockOccupancy(new Vector3i(0,  0, 1)),
                new BlockOccupancy(new Vector3i(-1, 0, 1)),
                new BlockOccupancy(new Vector3i(-2, 0, 1)),
                new BlockOccupancy(new Vector3i(0,  1, 1)),
                new BlockOccupancy(new Vector3i(-1, 1, 1)),
                new BlockOccupancy(new Vector3i(-2, 1, 1)),
                new BlockOccupancy(new Vector3i(0,  2, 1)),
                new BlockOccupancy(new Vector3i(-1, 2, 1)),
                new BlockOccupancy(new Vector3i(-2, 2, 1)),
                new BlockOccupancy(new Vector3i(0,  3, 1)),
                new BlockOccupancy(new Vector3i(-1, 3, 1)),
                new BlockOccupancy(new Vector3i(-2, 3, 1)),
                new BlockOccupancy(new Vector3i(0,  4, 1)),
                new BlockOccupancy(new Vector3i(-1, 4, 1)),
                new BlockOccupancy(new Vector3i(-2, 4, 1)),
                new BlockOccupancy(new Vector3i(0,  5, 1)),
                new BlockOccupancy(new Vector3i(-1, 5, 1)),
                new BlockOccupancy(new Vector3i(-2, 5, 1)),

                new BlockOccupancy(new Vector3i(0,  0, -1)),
                new BlockOccupancy(new Vector3i(-1, 0, -1)),
                new BlockOccupancy(new Vector3i(-2, 0, -1)),
                new BlockOccupancy(new Vector3i(0,  1, -1)),
                new BlockOccupancy(new Vector3i(-1, 1, -1)),
                new BlockOccupancy(new Vector3i(-2, 1, -1)),
                new BlockOccupancy(new Vector3i(0,  2, -1)),
                new BlockOccupancy(new Vector3i(-1, 2, -1)),
                new BlockOccupancy(new Vector3i(-2, 2, -1)),
                new BlockOccupancy(new Vector3i(0,  3, -1)),
                new BlockOccupancy(new Vector3i(-1, 3, -1)),
                new BlockOccupancy(new Vector3i(-2, 3, -1)),
                new BlockOccupancy(new Vector3i(0,  4, -1)),
                new BlockOccupancy(new Vector3i(-1, 4, -1)),
                new BlockOccupancy(new Vector3i(-2, 4, -1)),
                new BlockOccupancy(new Vector3i(0,  5, -1)),
                new BlockOccupancy(new Vector3i(-1, 5, -1)),
                new BlockOccupancy(new Vector3i(-2, 5, -1)),

                new BlockOccupancy(new Vector3i(0,  0, 2)),
                new BlockOccupancy(new Vector3i(-1, 0, 2)),
                new BlockOccupancy(new Vector3i(-2, 0, 2)),
                new BlockOccupancy(new Vector3i(0,  1, 2)),
                new BlockOccupancy(new Vector3i(-1, 1, 2)),
                new BlockOccupancy(new Vector3i(-2, 1, 2)),
                new BlockOccupancy(new Vector3i(0,  2, 2)),
                new BlockOccupancy(new Vector3i(-1, 2, 2)),
                new BlockOccupancy(new Vector3i(-2, 2, 2)),
                new BlockOccupancy(new Vector3i(0,  3, 2)),
                new BlockOccupancy(new Vector3i(-1, 3, 2)),
                new BlockOccupancy(new Vector3i(-2, 3, 2)),
                new BlockOccupancy(new Vector3i(0,  4, 2)),
                new BlockOccupancy(new Vector3i(-1, 4, 2)),
                new BlockOccupancy(new Vector3i(-2, 4, 2)),
                new BlockOccupancy(new Vector3i(0,  5, 2)),
                new BlockOccupancy(new Vector3i(-1, 5, 2)),
                new BlockOccupancy(new Vector3i(-2, 5, 2)),

                new BlockOccupancy(new Vector3i(0,  0, -2)),
                new BlockOccupancy(new Vector3i(-1, 0, -2)),
                new BlockOccupancy(new Vector3i(-2, 0, -2)),
                new BlockOccupancy(new Vector3i(0,  1, -2)),
                new BlockOccupancy(new Vector3i(-1, 1, -2)),
                new BlockOccupancy(new Vector3i(-2, 1, -2)),
                new BlockOccupancy(new Vector3i(0,  2, -2)),
                new BlockOccupancy(new Vector3i(-1, 2, -2)),
                new BlockOccupancy(new Vector3i(-2, 2, -2)),
                new BlockOccupancy(new Vector3i(0,  3, -2)),
                new BlockOccupancy(new Vector3i(-1, 3, -2)),
                new BlockOccupancy(new Vector3i(-2, 3, -2)),
                new BlockOccupancy(new Vector3i(0,  4, -2)),
                new BlockOccupancy(new Vector3i(-1, 4, -2)),
                new BlockOccupancy(new Vector3i(-2, 4, -2)),
                new BlockOccupancy(new Vector3i(0,  5, -2)),
                new BlockOccupancy(new Vector3i(-1, 5, -2)),
                new BlockOccupancy(new Vector3i(-2, 5, -2)),

                new BlockOccupancy(new Vector3i(0,  0, 3)),
                new BlockOccupancy(new Vector3i(-1, 0, 3)),
                new BlockOccupancy(new Vector3i(-2, 0, 3)),
                new BlockOccupancy(new Vector3i(0,  1, 3)),
                new BlockOccupancy(new Vector3i(-1, 1, 3)),
                new BlockOccupancy(new Vector3i(-2, 1, 3)),
                new BlockOccupancy(new Vector3i(0,  2, 3)),
                new BlockOccupancy(new Vector3i(-1, 2, 3)),
                new BlockOccupancy(new Vector3i(-2, 2, 3)),
                new BlockOccupancy(new Vector3i(0,  3, 3)),
                new BlockOccupancy(new Vector3i(-1, 3, 3)),
                new BlockOccupancy(new Vector3i(-2, 3, 3)),
                new BlockOccupancy(new Vector3i(0,  4, 3)),
                new BlockOccupancy(new Vector3i(-1, 4, 3)),
                new BlockOccupancy(new Vector3i(-2, 4, 3)),
                new BlockOccupancy(new Vector3i(0,  5, 3)),
                new BlockOccupancy(new Vector3i(-1, 5, 3)),
                new BlockOccupancy(new Vector3i(-2, 5, 3)),

                new BlockOccupancy(new Vector3i(0,  0, -3)),
                new BlockOccupancy(new Vector3i(-1, 0, -3)),
                new BlockOccupancy(new Vector3i(-2, 0, -3)),
                new BlockOccupancy(new Vector3i(0,  1, -3)),
                new BlockOccupancy(new Vector3i(-1, 1, -3)),
                new BlockOccupancy(new Vector3i(-2, 1, -3)),
                new BlockOccupancy(new Vector3i(0,  2, -3)),
                new BlockOccupancy(new Vector3i(-1, 2, -3)),
                new BlockOccupancy(new Vector3i(-2, 2, -3)),
                new BlockOccupancy(new Vector3i(0,  3, -3)),
                new BlockOccupancy(new Vector3i(-1, 3, -3)),
                new BlockOccupancy(new Vector3i(-2, 3, -3)),
                new BlockOccupancy(new Vector3i(0,  4, -3)),
                new BlockOccupancy(new Vector3i(-1, 4, -3)),
                new BlockOccupancy(new Vector3i(-2, 4, -3)),
                new BlockOccupancy(new Vector3i(0,  5, -3)),
                new BlockOccupancy(new Vector3i(-1, 5, -3)),
                new BlockOccupancy(new Vector3i(-2, 5, -3)),

                new BlockOccupancy(new Vector3i(0,  0, 4)),
                new BlockOccupancy(new Vector3i(-1, 0, 4)),
                new BlockOccupancy(new Vector3i(-2, 0, 4)),
                new BlockOccupancy(new Vector3i(0,  1, 4)),
                new BlockOccupancy(new Vector3i(-1, 1, 4)),
                new BlockOccupancy(new Vector3i(-2, 1, 4)),
                new BlockOccupancy(new Vector3i(0,  2, 4)),
                new BlockOccupancy(new Vector3i(-1, 2, 4)),
                new BlockOccupancy(new Vector3i(-2, 2, 4)),
                new BlockOccupancy(new Vector3i(0,  3, 4)),
                new BlockOccupancy(new Vector3i(-1, 3, 4)),
                new BlockOccupancy(new Vector3i(-2, 3, 4)),
                new BlockOccupancy(new Vector3i(0,  4, 4)),
                new BlockOccupancy(new Vector3i(-1, 4, 4)),
                new BlockOccupancy(new Vector3i(-2, 4, 4)),
                new BlockOccupancy(new Vector3i(0,  5, 4)),
                new BlockOccupancy(new Vector3i(-1, 5, 4)),
                new BlockOccupancy(new Vector3i(-2, 5, 4)),

                new BlockOccupancy(new Vector3i(0,  0, -4)),
                new BlockOccupancy(new Vector3i(-1, 0, -4)),
                new BlockOccupancy(new Vector3i(-2, 0, -4)),
                new BlockOccupancy(new Vector3i(0,  1, -4)),
                new BlockOccupancy(new Vector3i(-1, 1, -4)),
                new BlockOccupancy(new Vector3i(-2, 1, -4)),
                new BlockOccupancy(new Vector3i(0,  2, -4)),
                new BlockOccupancy(new Vector3i(-1, 2, -4)),
                new BlockOccupancy(new Vector3i(-2, 2, -4)),
                new BlockOccupancy(new Vector3i(0,  3, -4)),
                new BlockOccupancy(new Vector3i(-1, 3, -4)),
                new BlockOccupancy(new Vector3i(-2, 3, -4)),
                new BlockOccupancy(new Vector3i(0,  4, -4)),
                new BlockOccupancy(new Vector3i(-1, 4, -4)),
                new BlockOccupancy(new Vector3i(-2, 4, -4)),
                new BlockOccupancy(new Vector3i(0,  5, -4)),
                new BlockOccupancy(new Vector3i(-1, 5, -4)),
                new BlockOccupancy(new Vector3i(-2, 5, -4)),
            };
            #endregion

            AddOccupancy<GreatHallDoorObject>(BlockOccupancyList);
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [Tier(2)]
    [Weight(600)]
    [LocDisplayName("Great Hall Door")]
    [MaxStackSize(10)]
    [Ecopedia("Modded Objects", "Modded Doors", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public class GreatHallDoorItem : WorldObjectItem<GreatHallDoorObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Giant Door For Decorative Halls. Can be locked for certain players.");

        static GreatHallDoorItem() { }
    }

    [RequiresSkill(typeof(CarpentrySkill), 4)]
    public partial class GreatHallDoorRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GreatHallDoorRecipe).Name,
            Assembly = typeof(GreatHallDoorRecipe).AssemblyQualifiedName,
            HiddenName = "Great Hall Door",
            LocalizableName = Localizer.DoStr("Great Hall Door"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 30),
                new EMIngredient("Lumber", true, 100),
            },
            ProductList = new()
            {
                new EMCraftable("GreatHallDoorItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static GreatHallDoorRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GreatHallDoorRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}