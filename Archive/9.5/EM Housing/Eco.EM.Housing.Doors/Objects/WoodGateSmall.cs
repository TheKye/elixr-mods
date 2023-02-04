using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Housing.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WoodGateSmallObject : DoorObject
    {
        public override LocString DisplayName => Localizer.DoStr("Small Wood Gate");

        static WoodGateSmallObject()
        {
            AddOccupancy<WoodGateSmallObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0,0,-1)),
                new BlockOccupancy(new Vector3i(0,0,1))
            });
        }

        protected override void Initialize()
        {
        }

        public override void Destroy() => base.Destroy();
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class WoodGateSmallRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WoodGateSmallRecipe).Name,
            Assembly = typeof(WoodGateSmallRecipe).AssemblyQualifiedName,
            HiddenName = "Small Wood Gate",
            LocalizableName = Localizer.DoStr("Small Wood Gate"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 10),
            },
            ProductList = new()
            {
                new EMCraftable("WoodGateSmallItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) },
        };

        static WoodGateSmallRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WoodGateSmallRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(500)]
    [LocDisplayName("Small Wood Gate")]
    [Ecopedia("Modded Objects", "Modded Doors", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public class WoodGateSmallItem : WorldObjectItem<WoodGateSmallObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A sturdy Small wood gate.");

        static WoodGateSmallItem() { }
    }
}