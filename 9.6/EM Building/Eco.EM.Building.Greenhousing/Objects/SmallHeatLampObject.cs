using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Building.Greenhousing
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HeatLampComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    public partial class SmallHeatLampObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Small Heat Lamp");

        public virtual Type RepresentedItemType => typeof(SmallHeatLampItem);

        static SmallHeatLampObject() { 
            AddOccupancy<SmallHeatLampObject>(new List<BlockOccupancy>() 
            { 
            new BlockOccupancy(new Vector3i(0, 0, 0)) 
            }); 
        }

        protected override void Initialize()
        {
            this.GetComponent<PowerGridComponent>().Initialize(10, new MechanicalPower());
            this.GetComponent<PowerConsumptionComponent>().Initialize(150);
            this.GetComponent<HeatLampComponent>().Initialize(6);
        }

        public override void Tick()
        {
            base.Tick();
                SetAnimatedState("Light", this.Operating);
        }
    }

    [Serialized, LocDisplayName("Small Heat Lamp")]
    [LocDescription("Small Heat Lamp, required for a greenhouse to work. Provides Heat for plants to grow")]
    public class SmallHeatLampItem : WorldObjectItem<SmallHeatLampObject>
    {
        
    }

    //todo Add Recipe
    [RequiresSkill(typeof(BasicEngineeringSkill), 1)]
    public partial class SmallHeatLampRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SmallHeatLampRecipe).Name,
            Assembly = typeof(SmallHeatLampRecipe).AssemblyQualifiedName,
            HiddenName = "Small Heat Lamp",
            LocalizableName = Localizer.DoStr("Small Heat Lamp"),
            IngredientList = new()
            {
                new EMIngredient("GlassItem", false, 1),
                new EMIngredient("IronBarItem", false, 1),
            },
            ProductList = new()
            {
                new EMCraftable("SmallHeatLampItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "WainwrightTableItem",
            RequiredSkillType = typeof(BasicEngineeringSkill),
            RequiredSkillLevel = 5,
            IngredientImprovementTalents = typeof(BasicEngineeringLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(BasicEngineeringParallelSpeedTalent), typeof(BasicEngineeringFocusedSpeedTalent) },
        };

        static SmallHeatLampRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SmallHeatLampRecipe()
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
