using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;

namespace Eco.EM.Food
{ 
    [Serialized]
    [RequiresSkill(typeof(ChefSkill), 0), Tag("Chef Specialty"), Tier(3)]    
    [LocDisplayName("Zymology")]
    [Ecopedia("Professions", "Chef", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Specialty")]
    public partial class ZymologySkill : Skill
    {
        public override LocString DisplayDescription => Localizer.DoStr("Make new food items and experiment with other food!");

        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }


        public static MultiplicativeStrategy MultiplicativeStrategy =
            new MultiplicativeStrategy(new float[] { 1,

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
            new AdditiveStrategy(new float[] { 0,

                0.5f,

                0.55f,

                0.6f,

                0.65f,

                0.7f,

                0.75f,

                0.8f,

            });
        public override AdditiveStrategy AddStrategy => AdditiveStrategy; 
        public static int[] SkillPointCost = {

            1,

            1,

            1,

            1,

            1,

            1,

            1,

        };
        public override int RequiredPoint => this.Level < SkillPointCost.Length ? SkillPointCost[this.Level] : 0;
        public override int PrevRequiredPoint => this.Level - 1 >= 0 && this.Level - 1 < SkillPointCost.Length ? SkillPointCost[this.Level - 1] : 0;
        public override int MaxLevel => 7;
        public override int Tier => 3;
    }
	
    [Serialized]
    [LocDisplayName("Zymology Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ZymologySkillBook : SkillBook<ZymologySkill, ZymologySkillScroll>
    {
    }

    [Serialized]
    [LocDisplayName("Zymology Skill Scroll")]
    public partial class ZymologySkillScroll : SkillScroll<ZymologySkill, ZymologySkillBook>
    {
    }

    [RequiresSkill(typeof(CookingSkill), 0)]
    public partial class ZymologySkillBookRecipe : RecipeFamily
    {
        public ZymologySkillBookRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Zymology Skill Book",
                    Localizer.DoStr("Zymology Skill Book"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Lumber", 40),
                        new IngredientElement(typeof(MortarItem), 50),
                        new IngredientElement(typeof(ClothItem), 20),
                        new IngredientElement(typeof(VegetableSoupItem), 10),
                        new IngredientElement(typeof(CulinaryResearchPaperBasicItem), 5)
                    },
                    new CraftingElement<ZymologySkillBook>()
                    )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(2000);
            this.CraftMinutes = new ConstantValue(15);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Zymology Skill Book"), typeof(ZymologySkillBookRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Lavish Workspace: Zymology")]
    public partial class ZymologyLavishWorkspaceTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription => Localizer.DoStr("Increases the tier requirement of tables by 0.2, but reduces the resources needed by 5 percent.");

        public ZymologyLavishWorkspaceTalentGroup()
        {
            Talents = new Type[]
            {

            typeof(ZymologyLavishResourcesTalent),

            typeof(ZymologyLavishReqTalent),

            };
            this.OwningSkill = typeof(ZymologySkill);
            this.Level = 6;
        }
    }


    [Serialized]
    public partial class ZymologyLavishResourcesTalent : LavishWorkspaceTalent
    {
        public override bool Base => false;
        public override Type TalentGroupType => typeof(ZymologyLavishWorkspaceTalentGroup);
        public ZymologyLavishResourcesTalent()
        {
            this.Value = 0.95f;
        }
    }

    [Serialized]
    public partial class ZymologyLavishReqTalent : LavishWorkspaceTalent
    {
        public override bool Base => false;
        public override Type TalentGroupType => typeof(ZymologyLavishWorkspaceTalentGroup);
        public ZymologyLavishReqTalent()
        {
            this.Value = 0.2f;
        }
    }

    [Serialized]
    [LocDisplayName("Parallel Processing: Zymology")]
    public partial class ZymologyParallelProcessingTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription => Localizer.DoStr("Increases the crafting speed of related tables when they share a room with the same tables by 20 percent.");

        public ZymologyParallelProcessingTalentGroup()
        {
            Talents = new Type[]
            {

            typeof(ZymologyParallelSpeedTalent),


            };
            this.OwningSkill = typeof(ZymologySkill);
            this.Level = 3;
        }
    }


    [Serialized]
    public partial class ZymologyParallelSpeedTalent : ParallelProcessingTalent
    {
        public override bool Base => false;
        public override Type TalentGroupType => typeof(ZymologyParallelProcessingTalentGroup);
        public ZymologyParallelSpeedTalent()
        {
            this.Value = 0.8f;
        }
    }

    [Serialized]
    [LocDisplayName("Frugal Workspace: Zymology")]
    public partial class ZymologyFrugalWorkspaceTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription => Localizer.DoStr("Lowers the tier requirement of related tables by 0.2");

        public ZymologyFrugalWorkspaceTalentGroup()
        {
            Talents = new Type[]
            {

            typeof(ZymologyFrugalReqTalent),


            };
            this.OwningSkill = typeof(ZymologySkill);
            this.Level = 6;
        }
    }


    [Serialized]
    public partial class ZymologyFrugalReqTalent : FrugalWorkspaceTalent
    {
        public override bool Base => false;
        public override Type TalentGroupType => typeof(ZymologyFrugalWorkspaceTalentGroup);
        public ZymologyFrugalReqTalent()
        {
            this.Value = -0.2f;
        }
    }

    [LocDisplayName("Focused Workflow: Zymology")]
    public partial class ZymologyFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public ZymologyFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {

            typeof(ZymologyFocusedSpeedTalent),


            };
            this.OwningSkill = typeof(ZymologySkill);
            this.Level = 3;
        }
    }


    [Serialized]
    public partial class ZymologyFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base => false;
        public override Type TalentGroupType => typeof(ZymologyFocusedWorkflowTalentGroup);
        public ZymologyFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }
}
