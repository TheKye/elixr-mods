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

namespace Eco.EM.Food
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireRoomContainment, RequireRoomVolume(25), RequireRoomMaterialTier(1.8f, typeof(ZymologyLavishReqTalent), typeof(ZymologyFrugalReqTalent))]
    public partial class FermentingBarrelObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("FermentingBarrel"); } }

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

        public override void Destroy() => base.Destroy();
    }

    [Serialized, LocDisplayName("Fermenting Barrel")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [MaxStackSize(10)]
    [AllowPluginModules(Tags = new[] { "BasicUpgrade", }, ItemTypes = new[] { typeof(CookingUpgradeItem),
 typeof(AdvancedCookingUpgradeItem),})]
    public partial class FermentingBarrelItem : WorldObjectItem<FermentingBarrelObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Fermenting Barrel Is Used To Distill Products.");
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class FermentingBarrelRecipe : RecipeFamily
    {
        public FermentingBarrelRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Fermenting Barrel",
                    Localizer.DoStr("Fermenting Barrel"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Wood", 10, typeof(CarpentrySkill)),
                        new IngredientElement("WoodBoard", 20, typeof(CarpentrySkill)),
                        new IngredientElement("NaturalFiber", 140, typeof(CarpentrySkill)),
                        new IngredientElement(typeof(IronBarItem), 5, typeof(CarpentrySkill))
                    },
                    new CraftingElement<FermentingBarrelItem>()
                    )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FermentingBarrelRecipe), 15, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("FermentingBarrel"), typeof(FermentingBarrelRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}