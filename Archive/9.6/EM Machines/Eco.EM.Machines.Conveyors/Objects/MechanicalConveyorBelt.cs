using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Machines.Conveyors
{
    // Recipe
    [RequiresSkill(typeof(MechanicsSkill), 1)]
    public partial class MechanicalConveyorBeltRecipe : RecipeFamily
    {
        public MechanicalConveyorBeltRecipe()
        {
            var product = new Recipe(
                    "Mechanical Conveyor Belt",
                    Localizer.DoStr("Mechanical Conveyor Belt"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(PistonItem), 2,typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                        new IngredientElement(typeof(GearboxItem), 1 ,typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                        new IngredientElement(typeof(BrickItem), 4 ,typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                    },

                    new CraftingElement<MechanicalConveyorBeltItem>(1f)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MechanicalConveyorBeltRecipe), 2f, typeof(MechanicsSkill), typeof(MechanicsParallelSpeedTalent), typeof(MechanicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Mechanical Conveyor Belt"), typeof(MechanicalConveyorBeltRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    // Item
    [Serialized]
    [LocDisplayName("Conveyor Belt")]
    [MaxStackSize(10)] // how many of the item can be held in a single stack
    [Weight(1000)] // how much wight the item takes up in the inventory
    public partial class MechanicalConveyorBeltItem : WorldObjectItem<MechanicalConveyorBeltObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Simply pushes items forward along the belt. Forward direction is indicated.");

        static MechanicalConveyorBeltItem() { }
    }

    // Object
    [Serialized]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    public partial class MechanicalConveyorBeltObject : ConveyorBeltObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Conveyor Belt");

        public Type RepresentedItemType => typeof(MechanicalConveyorBeltItem);

        protected override float PassSpeed => 4f;
        protected override string DefaultPassDirection => "Forward";

        protected override void Initialize()
        {
            this.GetComponent<PowerConsumptionComponent>().Initialize(1f);
            this.GetComponent<PowerGridComponent>().Initialize(4, new MechanicalPower());
            base.Initialize();
        }
        
        static MechanicalConveyorBeltObject()
        {
            AddOccupancy<MechanicalConveyorBeltObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                });
        }
    }
}
