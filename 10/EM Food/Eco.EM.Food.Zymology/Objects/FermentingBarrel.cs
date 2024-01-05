using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Property;
using Eco.Gameplay.Skills;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Core.Items;
using Eco.Gameplay.Modules;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using System;

namespace Eco.EM.Food.Zymology
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]

    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireRoomContainment, RequireRoomVolume(25), RequireRoomMaterialTier(1.8f, typeof(ZymologyLavishReqTalent), typeof(ZymologyFrugalReqTalent))]
    public partial class FermentingBarrelObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("Fermenting Barrel");

        static FermentingBarrelObject()
        {
            WorldObject.AddOccupancy<FermentingBarrelObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 1, 0)),
                new BlockOccupancy(new Vector3i(0, 0, -1)),
                new BlockOccupancy(new Vector3i(0, 1, -1)),
                new BlockOccupancy(new Vector3i(-1, 0, -1)),
                new BlockOccupancy(new Vector3i(-1, 1, -1)),
                });
        }


    }

    [Serialized, LocDisplayName("Fermenting Barrel")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true)]
    [MaxStackSize(10)]
    [AllowPluginModules(Tags = new[] { "BasicUpgrade", }, ItemTypes = new[] { typeof(CookingUpgradeItem),
 typeof(AdvancedCookingUpgradeItem),})]
    public partial class FermentingBarrelItem : WorldObjectItem<FermentingBarrelObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Fermenting Barrel Is Used To Distill Products.");
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class FermentingBarrelRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(FermentingBarrelRecipe).Name,
            Assembly = typeof(FermentingBarrelRecipe).AssemblyQualifiedName,
            HiddenName = "Fermenting Barrel",
            LocalizableName = Localizer.DoStr("Fermenting Barrel"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true,10),
                new EMIngredient("WoodBoard", true, 20),
                new EMIngredient("NaturalFiber", true, 140),
                new EMIngredient("IronBarItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("FermentingBarrelItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 15,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static FermentingBarrelRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public FermentingBarrelRecipe()
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