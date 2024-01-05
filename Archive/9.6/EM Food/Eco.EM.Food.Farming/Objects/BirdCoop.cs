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
using Eco.EM.Framework.Components;
using Eco.EM.Food;
using System;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Food.Farming
{
    [Serialized]    
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PassiveCraftingComponent))]    // Ensure component is attached to the object
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]            
    public partial class BirdCoopObject : WorldObject    
    {
        public override LocString DisplayName => Localizer.DoStr("Bird Coop");

        protected override void Initialize() { }

		static BirdCoopObject()
		{
            WorldObject.AddOccupancy<BirdCoopObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
                });
        }

        protected override void PostInitialize()
        {
            var storage = GetComponent<PublicStorageComponent>();
            storage.Initialize(2);
            storage.Inventory.AddInvRestriction(new SpecificItemTypesRestriction(new Type[] { typeof(EggItem), typeof(RawChickenItem), typeof(TurkeyCarcassItem) }));
            storage.Inventory.AddInvRestriction(new StackLimitRestriction(20));

            var link = GetComponent<LinkComponent>();
            link.Initialize(8);

            var pcc = GetComponent<PassiveCraftingComponent>();
            pcc.Initialize(300, new List<(Item, float)>() { (Item.Get(typeof(EggItem)), 3), (Item.Get(typeof(RawChickenItem)), 1), (Item.Get(typeof(TurkeyCarcassItem)), 1) });
            pcc.AddCraftCondition(new IngredientCraftCondition(pcc, new List<(Item, float)> { (Item.Get(typeof(BirdFeedItem)), 2) }));
            pcc.AddCraftCondition(new RequiredObjectInAreaCraftCondition(this, 10, 1, typeof(AnimalTroughObject)));
            pcc.AddCraftCondition(new SaturatedObjectInAreaCraftCondition(this, 10, 4, typeof(BirdCoopObject)));
        }


    }

    [Serialized]
    [LocDisplayName("Bird Coop")]
    [MaxStackSize(10)]
    [Ecopedia("Work Stations", "Passive Generators", createAsSubPage: true)]
    public partial class BirdCoopItem : WorldObjectItem<BirdCoopObject>
    {
        public override LocString DisplayDescription  => Localizer.DoStr("Its a Bird Coop! Will produce eggs and bird carcasses!");

        static BirdCoopItem() { }
    }

    [RequiresSkill(typeof(LoggingSkill), 2)]
    public partial class BirdCoopRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BirdCoopRecipe).Name,
            Assembly = typeof(BirdCoopRecipe).AssemblyQualifiedName,
            HiddenName = "Bird Coop",
            LocalizableName = Localizer.DoStr("Bird Coop"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 10),
                new EMIngredient("WoodBoard", true, 20),
                new EMIngredient("NaturalFiber", true, 140),
            },
            ProductList = new()
            {
                new EMCraftable("BirdCoopItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 100,
            LaborIsStatic = false,
            BaseCraftTime = 15,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(LoggingSkill),
            RequiredSkillLevel = 2,
        };

        static BirdCoopRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BirdCoopRecipe()
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