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
using Eco.EM.Framework.Resolvers;
using Eco.Core.Items;
using Eco.EM.Framework.Extentsions;
using Eco.Gameplay.Modules;

namespace Eco.EM.Housing.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class ElegantDoubleDoorObject : EmDoor
    {
        public override LocString DisplayName => Localizer.DoStr("Elegant Double Door");
        public virtual Type RepresentedItemType => typeof(ElegantDoubleDoorItem);
        public override bool HasTier => true;
        public override int Tier => 1;
        static ElegantDoubleDoorObject()
        {

            var BlockOccupancyList = new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0,0,0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f) ),
                new BlockOccupancy(new Vector3i(-1,0,0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(1,0,0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f) ),
                new BlockOccupancy(new Vector3i(0,1,0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f) ),
                new BlockOccupancy(new Vector3i(-1,1,0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                new BlockOccupancy(new Vector3i(1,1,0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f) ),
                new BlockOccupancy(new Vector3i(0,0,1)),
                new BlockOccupancy(new Vector3i(-1,0,1)),
                new BlockOccupancy(new Vector3i(1,0,1)),
                new BlockOccupancy(new Vector3i(0,0,-1)),
                new BlockOccupancy(new Vector3i(-1,0,-1)),
                new BlockOccupancy(new Vector3i(1,0,-1))

            };
            AddOccupancy<ElegantDoubleDoorObject>(BlockOccupancyList);
        }

        protected override void Initialize()
        {
        }



    }

    [Serialized]
    [Weight(600)]
    [Tier(1)]
    [MaxStackSize(10)]
    [DisplayName("Elegant Double Door")]
    [Ecopedia("Mod Documentation", "Modded Doors", createAsSubPage: true)]
    public class ElegantDoubleDoorItem : WorldObjectItem<ElegantDoubleDoorObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Double Wooden Door Designed So Beautifully.");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
        static ElegantDoubleDoorItem() { }
    }

    [RequiresSkill(typeof(LoggingSkill), 0)]
    public partial class ElegantDoubleDoorRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ElegantDoubleDoorRecipe).Name,
            Assembly = typeof(ElegantDoubleDoorRecipe).AssemblyQualifiedName,
            HiddenName = "Elegant Double Door",
            LocalizableName = Localizer.DoStr("Elegant Double Door"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 12),
            },
            ProductList = new()
            {
                new EMCraftable("ElegantDoubleDoorItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(LoggingSkill),
            RequiredSkillLevel = 0,
        };

        static ElegantDoubleDoorRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ElegantDoubleDoorRecipe()
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