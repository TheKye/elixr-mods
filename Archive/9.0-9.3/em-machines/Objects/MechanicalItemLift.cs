using Eco.Gameplay.Components;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Industry
{
    [RequiresSkill(typeof(MechanicsSkill), 1)]
    public partial class MechanicalItemLiftRecipe : RecipeFamily
    {
        public MechanicalItemLiftRecipe()
        {
            var product = new Recipe(
                    "Mechanical Item Up Conveyor",
                    Localizer.DoStr("Mechanical Item Up Conveyor"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(PistonItem), 2,typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                        new IngredientElement(typeof(GearboxItem), 1 ,typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                        new IngredientElement(typeof(BrickItem), 4 ,typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                    },

                    new CraftingElement<MechanicalItemLiftItem>(1f)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MechanicalItemLiftRecipe), 2f, typeof(MechanicsSkill), typeof(MechanicsParallelSpeedTalent), typeof(MechanicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Mechanical Item Up Conveyor"), typeof(MechanicalItemLiftRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this);           
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [MaxStackSize(15)]
    [Weight(1000)]
    [LocDisplayName("Mechanical Item Up Conveyor")]
    public partial class MechanicalItemLiftItem : WorldObjectItem<MechanicalItemLiftObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Items are lifted to new heights, if no up available items will try to push forward. Forward direction is indicated."); } }

        static MechanicalItemLiftItem() { }
    }

    [Serialized]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    public partial class MechanicalItemLiftObject : ConveyorBeltObject, IRepresentsItem
    {       
        public override LocString DisplayName { get { return Localizer.DoStr("Mechanical Item Up Conveyor"); } }

        protected override float PassSpeed => 4f;
        protected override string DefaultPassDirection => "Up";

        public Type RepresentedItemType => typeof(MechanicalItemLiftItem);

        protected override void Initialize()
        {
            this.GetComponent<PowerConsumptionComponent>().Initialize(1f);
            this.GetComponent<PowerGridComponent>().Initialize(4, new MechanicalPower()); ;
            base.Initialize();
        }
        
        static MechanicalItemLiftObject()
        {
            AddOccupancy<MechanicalItemLiftObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                });
        }

        // On Act right override to allow Item Lifts to be easily stacked.
        public override InteractResult OnActRight(InteractionContext context)
        {
            if (context.SelectedItem != null && context.SelectedItem.Type == typeof(MechanicalItemLiftItem))
            {
                Vector3i abovePos = Position3i;
                Quaternion playerFace = context.Player.User.FacingDir.ToQuat();
                do
                {
                    abovePos.Y = abovePos.Y + 1;
                } while (WorldObjectsAtPos(abovePos) != null);
                WorldObjectManager.TryPlaceWorldObject(context.Player, (WorldObjectItem)context.SelectedItem, abovePos, playerFace);
                return InteractResult.Success;
            }
            else
            {
                return base.OnActRight(context);
            }
        }
    }
}