using Eco.Core.Items;
using Eco.EM.ModkitTools;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.Organisms;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using Eco.EM.Food;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

// The purpose of this object is to assist as an example for modders to use the PassiveCraftComponet added by the EM Modkit Additions.

namespace Eco.EM.Farming
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PassiveCraftingComponent))]    // Ensure component is attached to the object
    [RequireComponent(typeof(PublicStorageComponent))]      // Needs public storage to have something to output items to
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class ResidentialBeeBoxObejct: WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Residential Bee Hive");

        public Type RepresentedItemType => typeof(ResidentialBeeBoxItem);

        protected override void PostInitialize() 
        {
            // Initialize public storage with slots and restrictions
            var storage = GetComponent<PublicStorageComponent>();
            storage.Initialize(2);
            storage.Inventory.AddInvRestriction(new SpecificItemTypesRestriction(new Type[] { typeof(BeeswaxItem), typeof(HoneyItem) }));
            storage.Inventory.AddInvRestriction(new StackLimitRestriction(20));

            // Initialize component with outputs and conditions for generation (see API for list)
            var pcc = GetComponent<PassiveCraftingComponent>();
            pcc.Initialize(15, new List<(Item,float)>() { (Item.Get(typeof(BeeswaxItem)), 1), (Item.Get(typeof(HoneyItem)), 3) });  
            pcc.AddCraftCondition(new PlantAreaCraftCondition(this, 5, 10, new Type[] { typeof(SunflowerBlock) }));
        }

        static ResidentialBeeBoxObejct()
        {
            WorldObject.AddOccupancy<ResidentialBeeBoxObejct>(new List<BlockOccupancy>(){ new BlockOccupancy(new Vector3i(0, 0, 0)) });
        }
    }

    [Serialized]
    [LocDisplayName("Residential Bee Box")]
    [MaxStackSize(5)]
    [Ecopedia("Work Stations", "Passive Generators", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ResidentialBeeBoxItem : WorldObjectItem<ResidentialBeeBoxObejct>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Get the latest buzz in your own backyard.");
    }

    [RequiresSkill(typeof(CarpenterSkill), 2)]
    public partial class ResidentialBeeBoxRecipe : RecipeFamily
    {
        public ResidentialBeeBoxRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ResidentialBeeBox",
                    Localizer.DoStr("Residential Bee Box"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Wood", 10, typeof(CarpenterSkill)),
                        new IngredientElement("WoodBoard", 20, typeof(CarpenterSkill)),
                        new IngredientElement("NaturalFiber", 140, true),
                    },
                    new CraftingElement<ResidentialBeeBoxItem>()
                    )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(CarpenterSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ResidentialBeeBoxRecipe), 15, typeof(CarpenterSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Residential Bee Box"), typeof(ResidentialBeeBoxRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
