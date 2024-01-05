using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Items.Recipes;

namespace Eco.Mods.TechTree
{
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    public partial class HandWaterPumpObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Hand Water Pump");
        public Type RepresentedItemType => typeof(HandWaterPumpItem);

        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Crafting"));
        }

        static HandWaterPumpObject()
        {
            AddOccupancy<HandWaterPumpObject>(
                new List<BlockOccupancy>()
                {
                    new BlockOccupancy(new Vector3i(0, 0, 0)),
                });
        }

    }

    [Serialized]
    [LocDisplayName("Hand Water Pump")]
    [MaxStackSize(10)]
    [LocDescription("A Hand Pump used for gathering water.")]
    public partial class HandWaterPumpItem : WorldObjectItem<HandWaterPumpObject>
    {
        
        static HandWaterPumpItem() { }
    }

    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class HandWaterPumpRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(HandWaterPumpRecipe).Name,
            Assembly = typeof(HandWaterPumpRecipe).AssemblyQualifiedName,
            HiddenName = "Hand Water Pump",
            LocalizableName = Localizer.DoStr("Hand Water Pump"),
            IngredientList = new()
            {
                new EMIngredient("HewnLog", true, 20, true),
                new EMIngredient("Rock", true, 30, true),
            },
            ProductList = new()
            {
                new EMCraftable("HandWaterPumpItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "MasonryTableItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 1,
        };

        static HandWaterPumpRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public HandWaterPumpRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Localizer.DoStr(Defaults.LocalizableName), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}