using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.EM.Framework.Components;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Plants;
using Eco.Gameplay.Skills;
using Eco.Mods.Organisms;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

// The purpose of this object is to assist as an example for modders to use the PassiveCraftComponet added by the EM Modkit Additions.

namespace Eco.EM.Food.Farming
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PassiveCraftingComponent))]    // Ensure component is attached to the object
    [RequireComponent(typeof(PublicStorageComponent))]      // Needs public storage to have something to output items to
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class BeeHiveObject: WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Bee Hive");

        public Type RepresentedItemType => typeof(BeeHiveItem);

        protected override void PostInitialize() 
        {
            // Initialize public storage with slots and restrictions
            var storage = GetComponent<PublicStorageComponent>();
            storage.Initialize(2);
            storage.Inventory.AddInvRestriction(new SpecificItemTypesRestriction(new Type[] { typeof(BeeswaxItem), typeof(HoneyItem) }));
            storage.Inventory.AddInvRestriction(new StackLimitRestriction(20));

            // Initialize component with outputs and conditions for generation (see API for list)
            var pcc = GetComponent<PassiveCraftingComponent>();
            pcc.Initialize(300, new List<(Item,float)>() { (Item.Get(typeof(BeeswaxItem)), 1), (Item.Get(typeof(HoneyItem)), 2) });  
            pcc.AddCraftCondition(new PlantAreaCraftCondition(this, 5, 8, new Type[] { typeof(PlantBlock) }));
        }

        static BeeHiveObject()
        {
            WorldObject.AddOccupancy<BeeHiveObject>(new List<BlockOccupancy>(){ new BlockOccupancy(new Vector3i(0, 0, 0)) });
        }
    }

    [Serialized]
    [LocDisplayName("Bee Hive")]
    [MaxStackSize(5)]
    [Ecopedia("Work Stations", "Passive Generators", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BeeHiveItem : WorldObjectItem<BeeHiveObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Get the latest buzz in your own backyard.");
    }

    [RequiresSkill(typeof(CarpenterSkill), 2)]
    public partial class BeeHiveRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType                      = typeof(BeeHiveRecipe).Name,
            Assembly                       = typeof(BeeHiveRecipe).AssemblyQualifiedName,
            HiddenName                     = "BeeHive",
            LocalizableName                = Localizer.DoStr("Bee Hive"),
            IngredientList                 = new()
            {
                new EMIngredient("Wood", true, 18),
                new EMIngredient("WoodBoard", true, 18),
                new EMIngredient("NaturalFiber", true, 140, true),
            },
            ProductList                    = new()
            {
                new EMCraftable("BeeHiveItem"),
            },
            RequiredSkillType              = typeof(CarpenterSkill),
            RequiredSkillLevel             = 0,
            BaseExperienceOnCraft          = 1,
            BaseLabor                      = 100,
            LaborIsStatic                  = false,
            BaseCraftTime                  = 15,
            CraftTimeIsStatic              = false,
            CraftingStation                = "CarpentryTableItem",
        };

        static BeeHiveRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BeeHiveRecipe()
        {
            this.Recipes                   = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories           = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes              = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft         = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
