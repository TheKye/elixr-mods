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
using Eco.Gameplay.Modules;
using Eco.EM.Framework.Extentsions;

namespace Eco.EM.Housing.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class SlidingDoorObject : EmDoor
    {
        public override LocString DisplayName => Localizer.DoStr("Sliding Door");
        public Type RepresentedItemType => typeof(ElegantDoorItem);
        public override bool HasTier => true;
        public override int Tier => 2;
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
        }
    }

    [Serialized]
    [Tier(2)]
    [Weight(600)]
    [LocDisplayName("Sliding Door")]
    [MaxStackSize(10)]
    [Ecopedia("Modded Objects", "Modded Doors", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public class SlidingDoorItem : WorldObjectItem<SlidingDoorObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Sliding Glass Door. Can be locked for certain players.");

        static SlidingDoorItem() { }
    }

    [RequiresSkill(typeof(GlassworkingSkill), 4)]
    public partial class SlidingDoorRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SlidingDoorRecipe).Name,
            Assembly = typeof(SlidingDoorRecipe).AssemblyQualifiedName,
            HiddenName = "Sliding Door",
            LocalizableName = Localizer.DoStr("Sliding Door"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 5),
                new EMIngredient("GlassItem", false, 10),
            },
            ProductList = new()
            {
                new EMCraftable("SlidingDoorItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "KilnItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 4,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent) },
        };

        static SlidingDoorRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SlidingDoorRecipe()
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