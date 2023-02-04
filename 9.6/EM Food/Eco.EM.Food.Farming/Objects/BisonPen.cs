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
    public partial class BisonPenObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Bison Pen");
        public override LocString DisplayDescription => Localizer.DoStr("The Bison Pen is used to gain Bison Fur. Bison pens also need a Nearby Animal Trough with Herbivore Feed to be able to produce anything.");
        public virtual Type RepresentedItemType => typeof(BisonPenItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        static BisonPenObject()
        {
            // Occupancy
        }

        protected override void Initialize() { }
        protected override void PostInitialize() { }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Bison Pen")]
    public partial class BisonPenItem : WorldObjectItem<BisonPenObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Pen for Keeping Your Bison in!");
        static BisonPenItem() { }
    }

    [RequiresSkill(typeof(FarmingSkill), 4)]
    public partial class BisonPenRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BisonPenRecipe).Name,
            Assembly = typeof(BisonPenRecipe).AssemblyQualifiedName,
            HiddenName = "Bison Pen",
            LocalizableName = Localizer.DoStr("Bison Pen"),
            IngredientList = new()
            {
                new EMIngredient(item: "BabyBisonItem", isTag: false, amount: 3, isStatic: false),
                new EMIngredient(item: "Wood", isTag: true, amount: 50, isStatic: false)
            },
            ProductList = new()
            {
                new EMCraftable(item: "BisonPenItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 15,
            CraftTimeIsStatic = false,
            CraftingStation = "FarmersTableItem",
            RequiredSkillType = typeof(FarmingSkill),
            RequiredSkillLevel = 4,
        };

        static BisonPenRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BisonPenRecipe()
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
