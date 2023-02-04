namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    [Serialized]
    [RequiresSkill(typeof(ChefSkill), 0)]    
    public partial class ZymologySkill : Skill
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Zymology"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Make new food items and experiment with other food!"); } }

        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }


        public static ModificationStrategy MultiplicativeStrategy =
            new MultiplicativeStrategy(new float[] { 1,

                1 - 0.5f,

                1 - 0.55f,

                1 - 0.6f,

                1 - 0.65f,

                1 - 0.7f,

                1 - 0.75f,

                1 - 0.8f,

            });
        public override ModificationStrategy MultiStrategy { get { return MultiplicativeStrategy; } }
        public static ModificationStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] { 0,

                0.5f,

                0.55f,

                0.6f,

                0.65f,

                0.7f,

                0.75f,

                0.8f,

            });
        public override ModificationStrategy AddStrategy { get { return AdditiveStrategy; } }
        public static int[] SkillPointCost = {

            1,

            1,

            1,

            1,

            1,

            1,

            1,

        };
        public override int RequiredPoint { get { return this.Level < SkillPointCost.Length ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < SkillPointCost.Length ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 7; } }
        public override int Tier { get { return 3; } }
    }
	
    [Serialized]
    public partial class ZymologySkillBook : SkillBook<ZymologySkill, ZymologySkillScroll>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Zymology Skill Book"); } }
    }

    [Serialized]
    public partial class ZymologySkillScroll : SkillScroll<ZymologySkill, ZymologySkillBook>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Zymology Skill Scroll"); } }
    }

    [RequiresSkill(typeof(CookingSkill), 0)]
    public partial class ZymologySkillBookRecipe : Recipe
    {
        public ZymologySkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ZymologySkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(40),
                new CraftingElement<MortarItem>(50),
                new CraftingElement<ClothItem>(20),
				new CraftingElement<VegetableSoupItem>(10), 
            };
            this.CraftMinutes = new ConstantValue(15);

            this.Initialize(Localizer.DoStr("Zymology Skill Book"), typeof(ZymologySkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
