using System;
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

namespace Eco.EM.Artistry
{
    /// <summary>
    /// Artist Profession
    /// </summary>

    [Serialized]
    [LocDisplayName("Artist")]
    [Tag("Profession")]
    public partial class ArtistSkill : Skill
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Artistry for people who like to be artistic."); } }

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    /// <summary>
    /// Painting Specialization
    /// </summary>
    [Serialized]
    [LocDisplayName("Painting")]
    [RequiresSkill(typeof(ArtistSkill), 0), Tag("Art Specialty"), Tier(2)]
    [Ecopedia("Professions", "Art", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Specialty")]
    public partial class PaintingSkill : Skill
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Become a master of the arts"); } }

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
        public override int RequiredPoint { get { return this.Level < SkillPointCost.Length ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < SkillPointCost.Length ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 7; } }
        public override int Tier { get { return 4; } }

    }

    [Serialized]
    [LocDisplayName("Painting Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class PaintingSkillBook : SkillBook<PaintingSkill, PaintingSkillScroll>
    {
    }

    [Serialized]
    [LocDisplayName("Painting Skill Scroll")]
    public partial class PaintingSkillScroll : SkillScroll<PaintingSkill, PaintingSkillBook>
    {
    }

    [RequiresSkill(typeof(TailoringSkill), 0)]
    public partial class PaintingSkillBookRecipe : RecipeFamily
    {
        public PaintingSkillBookRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Painting Skill Book",
                    Localizer.DoStr("Painting Skill Book"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(PaperItem), 40),
                        new IngredientElement(typeof(ClothItem), 10),
                        new IngredientElement("WoodBoard", 20),
                        new IngredientElement("Basic Research", 5)
                    },
                new CraftingElement<PaintingSkillBook>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(2000);
            this.CraftMinutes = new ConstantValue(30);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Painting Skill Book"), typeof(PaintingSkillBookRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Lavish Workspace: Painting")]
    public partial class PaintingLavishWorkspaceTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Increases the tier requirement of tables by 0.2, but reduces the resources needed by 5 percent.");

        public PaintingLavishWorkspaceTalentGroup()
        {
            Talents = new Type[]
            {

            typeof(PaintingLavishResourcesTalent),

            typeof(PaintingLavishReqTalent),

            };
            this.OwningSkill = typeof(PaintingSkill);
            this.Level = 6;
        }
    }


    [Serialized]
    public partial class PaintingLavishResourcesTalent : LavishWorkspaceTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(PaintingLavishWorkspaceTalentGroup); } }
        public PaintingLavishResourcesTalent()
        {
            this.Value = 0.95f;
        }
    }

    [Serialized]
    public partial class PaintingLavishReqTalent : LavishWorkspaceTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(PaintingLavishWorkspaceTalentGroup); } }
        public PaintingLavishReqTalent()
        {
            this.Value = 0.2f;
        }
    }

    [Serialized]
    [LocDisplayName("Parallel Processing: Painting")]
    public partial class PaintingParallelProcessingTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Increases the crafting speed of related tables when they share a room with the same tables by 20 percent.");

        public PaintingParallelProcessingTalentGroup()
        {
            Talents = new Type[]
            {

            typeof(PaintingParallelSpeedTalent),


            };
            this.OwningSkill = typeof(PaintingSkill);
            this.Level = 3;
        }
    }


    [Serialized]
    public partial class PaintingParallelSpeedTalent : ParallelProcessingTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(PaintingParallelProcessingTalentGroup); } }
        public PaintingParallelSpeedTalent()
        {
            this.Value = 0.8f;
        }
    }

    [Serialized]
    [LocDisplayName("Frugal Workspace: Painting")]
    public partial class PaintingFrugalWorkspaceTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Lowers the tier requirement of related tables by 0.2");

        public PaintingFrugalWorkspaceTalentGroup()
        {
            Talents = new Type[]
            {

            typeof(PaintingFrugalReqTalent),


            };
            this.OwningSkill = typeof(PaintingSkill);
            this.Level = 6;
        }
    }


    [Serialized]
    public partial class PaintingFrugalReqTalent : FrugalWorkspaceTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(PaintingFrugalWorkspaceTalentGroup); } }
        public PaintingFrugalReqTalent()
        {
            this.Value = -0.2f;
        }
    }

    [LocDisplayName("Focused Workflow: Painting")]
    public partial class PaintingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public PaintingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {

            typeof(PaintingFocusedSpeedTalent),


            };
            this.OwningSkill = typeof(PaintingSkill);
            this.Level = 3;
        }
    }


    [Serialized]
    public partial class PaintingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(PaintingFocusedWorkflowTalentGroup); } }
        public PaintingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }
}

