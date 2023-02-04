using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Core.Items;
using Eco.Mods.TechTree;
using Eco.EM.ModkitTools;
using Eco.EM.Food;
using System;

namespace Eco.EM.Farming
{
    [Serialized]    
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PassiveCraftingComponent))]    // Ensure component is attached to the object
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class ChickenCoopObject : WorldObject    
    {
        public override LocString DisplayName => Localizer.DoStr("ChickenCoop");

        protected override void Initialize() { }

		static ChickenCoopObject()
		{
            WorldObject.AddOccupancy<ChickenCoopObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
                });
        }

        protected override void PostInitialize()
        {
            var storage = GetComponent<PublicStorageComponent>();
            storage.Initialize(2);
            storage.Inventory.AddInvRestriction(new SpecificItemTypesRestriction(new Type[] { typeof(EggItem), typeof(RawChickenItem) }));
            storage.Inventory.AddInvRestriction(new StackLimitRestriction(20));

            var link = GetComponent<LinkComponent>();
            link.Initialize(8);

            var pcc = GetComponent<PassiveCraftingComponent>();
            pcc.Initialize(15, new List<(Item, float)>() { (Item.Get(typeof(EggItem)), 6), (Item.Get(typeof(RawChickenItem)), 3) });
            pcc.AddCraftCondition(new IngredientCraftCondition(pcc, new List<(Item, float)> { (Item.Get(typeof(ChickenFeedItem)), 2) }));
            pcc.AddCraftCondition(new RequiredObjectInAreaCraftCondition(this, 10, 1, typeof(AnimalTroughObject)));
            pcc.AddCraftCondition(new SaturatedObjectInAreaCraftCondition(this, 10, 4, typeof(ChickenCoopObject)));
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("Chicken Coop")]
    [MaxStackSize(10)]
    [Ecopedia("Work Stations", "Passive Generators", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ChickenCoopItem : WorldObjectItem<ChickenCoopObject>
    {
        public override LocString DisplayDescription  => Localizer.DoStr("Its a Chicken Coop! Will produce eggs and chicken carcasses!.");

        static ChickenCoopItem() { }
    }

    [RequiresSkill(typeof(LoggingSkill), 2)]
    public partial class ChickenCoopRecipe : RecipeFamily
    {
        public ChickenCoopRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Chicken Coop",
                    Localizer.DoStr("Chicken Coop"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Wood", 10, typeof(LoggingSkill)),
                        new IngredientElement("WoodBoard", 20, typeof(LoggingSkill)),
                        new IngredientElement("NaturalFiber", 140, true),
                    },
                    new CraftingElement<ChickenCoopItem>()
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ChickenCoopRecipe), 15, typeof(LoggingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("ChickenCoop"), typeof(ChickenCoopRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}