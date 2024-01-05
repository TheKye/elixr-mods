using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
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
    [MaxStackSize(10)]
    [LocDisplayName("Hunting Hat")]
    public partial class HuntingHatItem : ClothingItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Quietly the natural born hunter stalks their prey...");
        public override string Slot => ClothingSlot.Head;
        public override bool Starter => false;
        private static Dictionary<UserStatType, float> flatStats = new()
        {
                { UserStatType.DetectionRange, 1f }
        };

        public override Dictionary<UserStatType, float> GetFlatStats() { return flatStats; }  
    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class HuntingHatRecipe : RecipeFamily
    {
        private string rName = "Hunting Hat";
        private Type skillBase = typeof(TailoringSkill);
        private Type ingTalent = typeof(TailoringLavishResourcesTalent);
        private Type[] speedTalents = { typeof(TailoringParallelSpeedTalent), typeof(TailoringFocusedSpeedTalent) };

        public HuntingHatRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CelluloseFiberItem), 20, skillBase, ingTalent),
                    new IngredientElement(typeof(FurPeltItem), 1, false),
                },
                 new CraftingElement<HuntingHatItem>(1f)
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
