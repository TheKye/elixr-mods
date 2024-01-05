using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Clothing
{
    [Serialized]
    [Weight(100)]
    [LocDisplayName("Lumberjack Shirt")]
    public partial class LumberjackShirtItem : ClothingItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Timberrrrrrrrrrr.");
        public override string Slot => ClothingSlot.Shirt;
        public override bool Starter => false;
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class LumberjackShirtRecipe : RecipeFamily
    {
        private string rName = "Lumberjack Shirt";
        private Type skillBase = typeof(TailoringSkill);
        private Type ingTalent = typeof(TailoringLavishResourcesTalent);
        private Type[] speedTalents = { typeof(TailoringParallelSpeedTalent), typeof(TailoringFocusedSpeedTalent) };

        public LumberjackShirtRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CelluloseFiberItem), 20, skillBase, ingTalent),
                    new IngredientElement(typeof(FurPeltItem), 10, skillBase, ingTalent),
                },
                 new CraftingElement<LumberjackShirtItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(300f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 10f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
