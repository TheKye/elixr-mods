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
    public partial class BigHornPenObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Big Horn Sheep Pen");
        public override LocString DisplayDescription => Localizer.DoStr("The Big Horn Sheep Pen is used to gain Wool. Big Horn Sheep pens also need a Nearby Animal Trough with Herbivore Feed to be able to produce anything.");
        public virtual Type RepresentedItemType => typeof(BigHornPenItem);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        static BigHornPenObject()
        {
            // Occupancy
        }

        protected override void Initialize() { }
        protected override void PostInitialize() { }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Big Horn Pen")]
    public partial class BigHornPenItem : WorldObjectItem<BigHornPenObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Pen for Keeping Your Big Horn Sheep in!");
        static BigHornPenItem() { }
    }

    [RequiresSkill(typeof(FarmingSkill), 4)]
    public partial class BigHornPenRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BigHornPenRecipe).Name,
            Assembly = typeof(BigHornPenRecipe).AssemblyQualifiedName,
            HiddenName = "Big Horn Pen",
            LocalizableName = Localizer.DoStr("Big Horn Pen"),
            IngredientList = new()
            {
                new EMIngredient(item: "BabyBighornSheepItem", isTag: false, amount: 3, isStatic: false),
                new EMIngredient(item: "Wood", isTag: true, amount: 50, isStatic: false)
            },
            ProductList = new()
            {
                new EMCraftable(item: "BigHornPenItem", amount: 1),
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

        static BigHornPenRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BigHornPenRecipe()
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
