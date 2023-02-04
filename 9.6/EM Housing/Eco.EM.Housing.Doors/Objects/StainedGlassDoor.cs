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
using Eco.EM.Framework.Resolvers;
using System;
using Eco.Core.Items;
using Eco.Gameplay.Modules;

namespace Eco.EM.Housing.Doors
{
    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public partial class StainedGlassDoorRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StainedGlassDoorRecipe).Name,
            Assembly = typeof(StainedGlassDoorRecipe).AssemblyQualifiedName,
            HiddenName = "Stained Glass Door",
            LocalizableName = Localizer.DoStr("Stained Glass Door"),
            IngredientList = new()
            {
                new EMIngredient("GlassItem", false, 6),
                new EMIngredient("IronBarItem", false, 4),
            },
            ProductList = new()
            {
                new EMCraftable("StainedGlassDoorItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "AnvilItem",
            RequiredSkillType = typeof(SmeltingSkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(SmeltingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent) },
        };

        static StainedGlassDoorRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StainedGlassDoorRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized]
    [LocDisplayName("Stained Glass Door")]
    [Tier(2)]
    [Weight(600)]
    [MaxStackSize(10)]
    [Ecopedia("Mod Documentation", "Modded Doors", createAsSubPage: true)]
    public class StainedGlassDoorItem : WorldObjectItem<StainedGlassDoorObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Beautiful Stained Glass Style Door.");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class StainedGlassDoorObject : DoorObject
    {
        public override LocString DisplayName => Localizer.DoStr("Stained Glass Door");
        public virtual Type RepresentedItemType => typeof(ElegantDoorItem);
        public override bool HasTier => true;
        public override int Tier => 2;
        protected override void Initialize()
        {
        }



        static StainedGlassDoorObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0,0,0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(0,1,0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(0,0,1)),
                new BlockOccupancy(new Vector3i(0,0,-1)),
                new BlockOccupancy(new Vector3i(0,1,1)),
                new BlockOccupancy(new Vector3i(0,1,-1)),
            };
            AddOccupancy<StainedGlassDoorObject>(BlockOccupancyList);

        }
    }
}