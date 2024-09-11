using Eco.Core.Items;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;
using System;
using System.Collections.Generic;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Components;
using Eco.Shared.Math;
using Eco.EM.Energy.Electronics.Components;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Energy.Electronics
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerStorageComponent))]
    public class RechargeableBatteryObject: WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Battery Pack");
        public override TableTextureMode TableTexture => TableTextureMode.Metal;
        public Type RepresentedItemType => typeof(RechargeableBatteryItem);

        static RechargeableBatteryObject()
        {
            AddOccupancy<RechargeableBatteryObject>(new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0,0,0), typeof(WorldObjectBlock))
            });
        }

        protected override void Initialize()
        {
            this.GetComponent<PowerStorageComponent>().Initialize(500000f, 250f);
        }

    }

    [Serialized, Weight(10000)]
    [LocDisplayName("Battery Pack")]
    [Ecopedia("Crafted Objects", "Power Cells", createAsSubPage: true)]
    public partial class RechargeableBatteryItem : WorldObjectItem<RechargeableBatteryObject>, IPersistentData
    {
        public override LocString DisplayDescription => Localizer.DoStr("A standing, energy storage cell");

        [Serialized] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 4)]
    public partial class RechargeableBatteryRecipe : RecipeFamily
    {
        public RechargeableBatteryRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Rechargeable Battery",
                    Localizer.DoStr("Rechargeable Battery"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(PlasticItem), 20, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(IronBarItem), 8, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(BasicCircuitItem), 16, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(CopperWiringItem), 30, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    },
                    new CraftingElement<RechargeableBatteryItem>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(ElectronicsSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(RechargeableBatteryRecipe), 5, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Rechargeable Battery"), typeof(RechargeableBatteryRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
