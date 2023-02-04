using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using Eco.Core.Items;
using System;
using Eco.Mods.TechTree;
using Eco.Shared.Math;
using Eco.EM.Framework.Resolvers;

namespace Eco.EM.Flags
{
    [Serialized]
    [RequireComponent(typeof(AffiliationFlagComponent))]
    public partial class AffiliationFlagObject : BaseFlagObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Affiliation Flag");
        public Type RepresentedItemType => typeof(AffiliationFlagItem);
    }

    [Serialized]
    [LocDisplayName("Affiliation Flag")]
    [Ecopedia("Flags", "Flags", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Weight(10)]
    public partial class AffiliationFlagItem : WorldObjectItem<AffiliationFlagObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A flag on a beautifuly hand crafted piece of cloth held up by a well crafted iron stand. Display it out front of your house, on your town hall or wherever you like!");
        static AffiliationFlagItem()
        {
            WorldObject.AddOccupancy<AffiliationFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class AffiliationFlagRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(AffiliationFlagRecipe).Name,
            Assembly = typeof(AffiliationFlagRecipe).AssemblyQualifiedName,
            HiddenName = "Affiliation Flag",
            LocalizableName = Localizer.DoStr("Affiliation Flag"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 10),
                new EMIngredient("ClothItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("AffiliationFlagItem"),
            },
            BaseLabor = 30,
            LaborIsStatic = true,
            BaseCraftTime = 0.1f,
            CraftTimeIsStatic = false,
            CraftingStation = "TailoringTableItem",
        };

        static AffiliationFlagRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public AffiliationFlagRecipe()
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