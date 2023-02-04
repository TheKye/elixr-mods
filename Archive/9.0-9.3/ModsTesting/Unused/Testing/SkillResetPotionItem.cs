using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.Collections.Generic;

namespace FRS_Consumables
{
    [Serialized]
    public abstract class SkillResetPotionItem: Item
    {
        public abstract Skill SkillType { get; }

        public override void OnUsed(Player player, ItemStack itemStack)
        {
                itemStack.TryModifyStack(player.User, -1, () => player.User.Skillset.HasSkill(SkillType.GetType()), () => SkillType.AbandonSpecialty(player.User));
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(200)]
    [LocDisplayName("Masonary Reset Potion")]
    public class MasonarySkillResetPotionItem : SkillResetPotionItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("A potion to abandon the masonary specialty skill");
        // Set the skill type for this potion.
        public override Skill SkillType => (Skill)Get(typeof(MasonrySkill));
    }

    [RequiresSkill(typeof(MasonrySkill),1)]
    public partial class MasonarySkillResetPotionRecipe: RecipeFamily
    {
        public MasonarySkillResetPotionRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "MasonrySkillResetPotion",
                    Localizer.DoStr("Masonry Skill Reset Potion"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Rock", 10, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                        new IngredientElement(typeof(MortarItem), 10, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent))
                    },
                    new CraftingElement<MasonarySkillResetPotionItem>(1)
                    )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MasonarySkillResetPotionRecipe), 8, typeof(MasonrySkill), typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Masonry Skill Reset Potion"), typeof(MasonarySkillResetPotionRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
}
