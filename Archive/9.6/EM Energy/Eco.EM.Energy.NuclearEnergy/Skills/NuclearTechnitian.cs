using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Energy.NuclearEnergy
{
    [Serialized]
    [LocDisplayName("Nuclear Technition")]
    [Ecopedia("Professions", "NuclearTechnition", createAsSubPage: true)]
    [RequiresSkill(typeof(EngineerSkill), 0), Tag("Engineer Specialty"), Tier(1)]
    [Tag("Specialty")]
    public partial class NuclearTechnitionSkill : Skill
    {
        public override LocString DisplayDescription => Localizer.DoStr("You probably want someone who knows their stuff when working with nuclear reactors...");

        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }

        public static MultiplicativeStrategy MultiplicativeStrategy =
            new(new float[] { 1,

                1 - 0.5f,
                1 - 0.55f,
                1 - 0.6f,
                1 - 0.65f,
                1 - 0.7f,
                1 - 0.75f,
                1 - 0.8f,
            });
        public override MultiplicativeStrategy MultiStrategy => MultiplicativeStrategy;
        public static AdditiveStrategy AdditiveStrategy =
            new(new float[] {
                0,
                0.5f,
                0.55f,
                0.6f,
                0.65f,
                0.7f,
                0.75f,
                0.8f,
            });

        public override AdditiveStrategy AddStrategy => AdditiveStrategy;
        public override int MaxLevel => 7;
        public override int Tier => 4;
    }

    [Serialized]
    [LocDisplayName("Nuclear Technition Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true)]
    public partial class NuclearTechnitionSkillBook : SkillBook<NuclearTechnitionSkill, NuclearTechnitionSkillScroll>
    {
    }

    [Serialized]
    [LocDisplayName("Nuclear Technition Skill Scroll")]
    public partial class NuclearTechnitionSkillScroll : SkillScroll<NuclearTechnitionSkill, NuclearTechnitionSkillBook>
    {
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 1)]
    public partial class NuclearTechnitionSkillBookRecipe : RecipeFamily
    {
        public NuclearTechnitionSkillBookRecipe()
        {
            this.Recipes = new List<Recipe>
             {
                new Recipe(
                    "Mechanics",
                    Localizer.DoStr("Mechanics"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(EngineeringResearchPaperAdvancedItem), 30),
                        new IngredientElement(typeof(MetallurgyResearchPaperAdvancedItem), 30),
                        new IngredientElement("Basic Research", 200),
                        new IngredientElement("Advanced Research", 50),
                    },
                new CraftingElement<NuclearTechnitionSkillBook>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(10000);
            this.CraftMinutes = CreateCraftTimeValue(30);

            this.Initialize(Localizer.DoStr("Nuclear Technition Skill Book"), typeof(NuclearTechnitionSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}