using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.WorldGenerator;


namespace Eco.EM.Artistry
{
    [Serialized]
    [LocDisplayName("Painting")]
    [RequiresSkill(typeof(ArtistSkill), 0), Tag("Art Specialty"), Tier(2)]
    [Ecopedia("Professions", "Art", createAsSubPage: true)]
    [Tag("Specialty")]
    [LocDescription("Become a master of the arts")]
    public partial class PaintingSkill : Skill
    {

        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }

        public static MultiplicativeStrategy MultiplicativeStrategy =
            new(new float[] {
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
    [LocDisplayName("Painting Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true)]
    public partial class PaintingSkillBook : SkillBook<PaintingSkill, PaintingSkillScroll>
    {
    }

    [Serialized]
    [LocDisplayName("Painting Skill Scroll")]
    public partial class PaintingSkillScroll : SkillScroll<PaintingSkill, PaintingSkillBook>
    {
    }

    [RequiresSkill(typeof(TailoringSkill), 0)]
    public partial class PaintingSkillBookRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PaintingSkillBookRecipe).Name,
            Assembly = typeof(PaintingSkillBookRecipe).AssemblyQualifiedName,
            HiddenName = "Painting Skill Book",
            LocalizableName = Localizer.DoStr("Painting Skill Book"),
            IngredientList = new()
            {
                new EMIngredient("PaperItem", false, 40),
                new EMIngredient("ClothItem", false, 10),
                new EMIngredient("WoodBoard", true, 20),
                new EMIngredient("Basic Research", true, 5)
            },
            ProductList = new()
            {
                new EMCraftable("PaintingSkillBook", 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 2000,
            LaborIsStatic = false,
            BaseCraftTime = 30,
            CraftTimeIsStatic = false,
            CraftingStation = "ResearchTableItem",
            RequiredSkillType = typeof(TailoringSkill),
            RequiredSkillLevel = 0,
        };

        static PaintingSkillBookRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PaintingSkillBookRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Localizer.DoStr(Defaults.LocalizableName), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized]
    [LocDisplayName("Lavish Workspace: Painting")]
    [LocDescription("Increases the tier requirement of tables by 0.2, but reduces the resources needed by 5 percent.")]
    public partial class PaintingLavishWorkspaceTalentGroup : TalentGroup
    {

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
        public override bool Base => false;
        public override Type TalentGroupType => typeof(PaintingLavishWorkspaceTalentGroup);
        public PaintingLavishResourcesTalent()
        {
            this.Value = 0.95f;
        }
    }

    [Serialized]
    public partial class PaintingLavishReqTalent : LavishWorkspaceTalent
    {
        public override bool Base => false;
        public override Type TalentGroupType => typeof(PaintingLavishWorkspaceTalentGroup);
        public PaintingLavishReqTalent()
        {
            this.Value = 0.2f;
        }
    }

    [Serialized]
    [LocDisplayName("Parallel Processing: Painting")]
    [LocDescription("Increases the crafting speed of related tables when they share a room with the same tables by 20 percent.")]
    public partial class PaintingParallelProcessingTalentGroup : TalentGroup
    {

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
        public override bool Base => false;
        public override Type TalentGroupType => typeof(PaintingParallelProcessingTalentGroup);
        public PaintingParallelSpeedTalent()
        {
            this.Value = 0.8f;
        }
    }

    [Serialized]
    [LocDisplayName("Frugal Workspace: Painting")]
    [LocDescription("Lowers the tier requirement of related tables by 0.2")]
    public partial class PaintingFrugalWorkspaceTalentGroup : TalentGroup
    {

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
        public override bool Base => false;
        public override Type TalentGroupType => typeof(PaintingFrugalWorkspaceTalentGroup);
        public PaintingFrugalReqTalent()
        {
            this.Value = -0.2f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Painting")]
    [LocDescription("Doubles the speed of related tables when alone.")]
    public partial class PaintingFocusedWorkflowTalentGroup : TalentGroup
    {

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
        public override bool Base => false;
        public override Type TalentGroupType => typeof(PaintingFocusedWorkflowTalentGroup);
        public PaintingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }
}
