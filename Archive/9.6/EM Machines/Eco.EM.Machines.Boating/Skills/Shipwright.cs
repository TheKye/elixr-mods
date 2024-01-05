

using Eco.Gameplay.Skills;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;

namespace Eco.EM.Machines.Boating
{
    [Serialized]
    [LocDisplayName("Shipwright")]
    [Ecopedia("Professions", "Engineer", createAsSubPage: true)]
    [RequiresSkill(typeof(EngineerSkill), 0), Tag("Engineer Specialty"), Tier(2)]
    [Tag("Specialty")]
    [Tag("Teachable")]
    public partial class ShipwrightSkill : Skill
    {
        public override LocString DisplayDescription => Localizer.DoStr("Channel your inner explorer and explore the seven seas!");

        public static MultiplicativeStrategy MultiplicativeStrategy =
            new MultiplicativeStrategy(new float[] {
                1,
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
            new AdditiveStrategy(new float[] {
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
        public override int Tier => 2;
    }

    [Serialized]
    [LocDisplayName("Shipwright Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true)]
    public partial class ShipwrightSkillBook : SkillBook<ShipwrightSkill, ShipwrightSkillScroll> { }

    [Serialized]
    [LocDisplayName("Shipwright Skill Scroll")]
    public partial class ShipwrightSkillScroll : SkillScroll<ShipwrightSkill, ShipwrightSkillBook> { }


    [RequiresSkill(typeof(BasicEngineeringSkill), 1)]
    public partial class ShipwrightSkillBookRecipe : RecipeFamily
    {
        public ShipwrightSkillBookRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Shipwright",  //noloc
                Localizer.DoStr("Shipwright Skill Book"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(DendrologyResearchPaperAdvancedItem), 5, typeof(EngineerSkill)),
                    new IngredientElement(typeof(MetallurgyResearchPaperAdvancedItem), 3, typeof(EngineerSkill)),
                    new IngredientElement(typeof(GatheringResearchPaperBasicItem), 3, typeof(EngineerSkill)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<ShipwrightSkillScroll>()
                });
            Recipes = new List<Recipe> { recipe };
            LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(EngineerSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(ShipwrightSkillBookRecipe), 5, typeof(EngineerSkill));
            Initialize(Localizer.DoStr("Shipwright Skill Book"), typeof(ShipwrightSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
