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

namespace Eco.EM.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class ElevatorDoorObject : EmDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Elevator Door"); } }

        protected override void Initialize() { }
        static ElevatorDoorObject()
        {

            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int z = 0; z <= 2; z++)
                for (int y = -2; y <= 1; y++)
                    BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(0, z, y), typeof(BuildingWorldObjectBlock)));

            WorldObject.AddOccupancy<ElevatorDoorObject>(BlockOccupancyList);
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [Tier(3)]
    [Weight(600)]
    [MaxStackSize(10)]
    [LocDisplayName("Elevator Door")]
    public class ElevatorDoorItem : WorldObjectItem<ElevatorDoorObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Set Of Elevator Doors. Can be locked for certain players."); } }

        static ElevatorDoorItem() { }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 2)]
    public partial class ElevatorDoorRecipe : RecipeFamily
    {
        public ElevatorDoorRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Elevator Door",
                    Localizer.DoStr("Elevator Door"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 40, typeof(ElectronicsSkill)),
                        new IngredientElement(typeof(ScrewsItem), 30, typeof(ElectronicsSkill)),
                        new IngredientElement(typeof(BasicCircuitItem), 10, typeof(ElectronicsSkill)),
                        new IngredientElement(typeof(ServoItem), 2, typeof(ElectronicsSkill)),
                        new IngredientElement(typeof(CopperWiringItem), 40, typeof(ElectronicsSkill))
                    },
                    new CraftingElement<ElevatorDoorItem>()
                    )
            };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ElevatorDoorRecipe), 5, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent), typeof(ElectronicsParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Elevator Door"), typeof(ElevatorDoorRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}