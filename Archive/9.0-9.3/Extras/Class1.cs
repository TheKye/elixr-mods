namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 1)]
    public partial class RebarRecipe :
    RecipeFamily
    {
        public RebarRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Rebar",
                    Localizer.DoStr("Rebar"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 2, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<RebarItem>(),
                    }
                ),
            };

            this.ExperienceOnCraft = 2;

            this.LaborInCalories = CreateLaborInCaloriesValue(80, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RebarRecipe), 0.2f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Rebar"), typeof(RebarRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class RebarRecipe
    {
        partial void ModsPreInitialize()
        {
            float CraftMulti = DifficultySettings.Obj.Config.DifficultyModifiers.CraftResourceModifier; // Get the Crafting Resource Modifier       
            var ingredients = this.Recipes[0].Ingredients;
            ingredients.Clear();
            ingredients.AddRange(

            new IngredientElement[]
            {
                new IngredientElement(typeof(SteelBarItem), 1 / CraftMulti, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
            });

            var product = this.Recipes[0].Items;
            product.Clear();
            product.AddRange(
            new CraftingElement[]
            {
                new CraftingElement<RebarItem>(4),
            });
        }

        partial void ModsPostInitialize()
        {
            this.Initialize(Localizer.DoStr("Rebar"), typeof(RebarRecipe));
        }
    }
}
