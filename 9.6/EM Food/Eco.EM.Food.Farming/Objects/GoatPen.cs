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

namespace Eco.EM.Food.Farming
{

    [Serialized]
    // Components
    public partial class GoatPenObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Goat Pen");
        public override LocString DisplayDescription => Localizer.DoStr("Goat Pen");
        public virtual Type RepresentedItemType => typeof(GoatPenItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        static GoatPenObject()
        {
            // Occupancy
        }

        protected override void Initialize() { }
        protected override void PostInitialize() { }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Goat Pen")]
    public partial class GoatPenItem : WorldObjectItem<GoatPenObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Pen for Keeping Your Goats In!");
        static GoatPenItem() { }
    }

    [RequiresSkill(typeof(FarmingSkill), 2)]
    public partial class GoatPenRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GoatPenRecipe).Name,
            Assembly = typeof(GoatPenRecipe).AssemblyQualifiedName,
            HiddenName = "Goat Pen",
            LocalizableName = Localizer.DoStr("Goat Pen"),
            IngredientList = new()
            {
                new EMIngredient(item: "BabyMountainGoatItem", isTag: false, amount: 3, isStatic: false),
                new EMIngredient(item: "Wood", isTag: true, amount: 50, isStatic: false)
            },
            ProductList = new()
            {
                new EMCraftable(item: "GoatPenItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 15,
            CraftTimeIsStatic = false,
            CraftingStation = "FarmersTableItem",
            RequiredSkillType = typeof(FarmingSkill),
            RequiredSkillLevel = 2,
        };

        static GoatPenRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GoatPenRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
