using Eco.EM.Framework;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Food.Zymology.Objects
{

    [Serialized]
    // Components
    public partial class MortarAndPestleObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Mortar And Pestle");
        public virtual Type RepresentedItemType => typeof(MortarAndPestleItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        static MortarAndPestleObject()
        {
            // Occupancy
        }

        protected override void Initialize() { }
        protected override void PostInitialize() { }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Mortar And Pestle")]
    public partial class MortarAndPestleItem : WorldObjectItem<MortarAndPestleObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Mortar And Pestle, Used for Grounding Down Items to make more useful Items");
        static MortarAndPestleItem() { }
    }

    // Skill requirements
    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class MortarAndPestleRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(MortarAndPestleRecipe).Name,
            Assembly = typeof(MortarAndPestleRecipe).AssemblyQualifiedName,
            HiddenName = "Mortar And Pestle",
            LocalizableName = Localizer.DoStr("Mortar And Pestle"),
            IngredientList = new()
            {

                new EMIngredient(item: "LogItem", isTag: false, amount: 1, isStatic: false),
            },
            ProductList = new()
            {

                new EMCraftable(item: "LogItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "WorkbenchItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent) },
        };

        static MortarAndPestleRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public MortarAndPestleRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
