using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using System;
using Eco.Core.Items;
using Eco.Gameplay.Modules;
using Eco.EM.Framework.Extentsions;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Items.Recipes;

namespace Eco.EM.Housing.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]

    public partial class ElevatorDoorObject : EmDoor
    {
        public override LocString DisplayName => Localizer.DoStr("Elevator Door");
        public Type RepresentedItemType => typeof(ElevatorDoorItem);
        public override bool HasTier => true;
        public override int Tier => 4;
        protected override void Initialize()
        {
        }

        static ElevatorDoorObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int y = 0; y <= 2; y++)
                for (int x = -2; x <= 1; x++)
                    BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, 0), typeof(BuildingWorldObjectBlock)));

            AddOccupancy<ElevatorDoorObject>(BlockOccupancyList);
        }


    }

    [Serialized]
    [Tier(4)]
    [Weight(600)]
    [MaxStackSize(10)]
    [LocDisplayName("Elevator Door")]
    [Ecopedia("Mod Documentation", "Modded Doors", createAsSubPage: true)]
    [LocDescription("A Set Of Elevator Doors. Can be locked for certain players.")]
    public class ElevatorDoorItem : WorldObjectItem<ElevatorDoorObject>
    {
        
        static ElevatorDoorItem() { }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 2)]
    public partial class ElevatorDoorRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ElevatorDoorRecipe).Name,
            Assembly = typeof(ElevatorDoorRecipe).AssemblyQualifiedName,
            HiddenName = "Elevator Doors",
            LocalizableName = Localizer.DoStr("Elevator Doors"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 40),
                new EMIngredient("ScrewsItem", false, 30),
                new EMIngredient("BasicCircuitItem", false, 10),
                new EMIngredient("ServoItem", false, 2),
                new EMIngredient("CopperWiringItem", false, 40)
            },
            ProductList = new()
            {
                new EMCraftable("ElevatorDoorItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "AssemblyLineItem",
            RequiredSkillType = typeof(ElectronicsSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(ElectronicsLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(ElectronicsFocusedSpeedTalent), typeof(ElectronicsParallelSpeedTalent) },
        };

        static ElevatorDoorRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ElevatorDoorRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}