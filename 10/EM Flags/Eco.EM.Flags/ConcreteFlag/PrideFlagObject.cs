using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Mods.TechTree;
using System;
using Eco.Shared.Math;
using Eco.EM.Framework.Resolvers;
using PropertyChanged;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Occupancy;

namespace Eco.EM.Flags
{
    [Serialized]
    [RequireComponent(typeof(PrideFlagComponent))]
    [DoNotNotify]
    public partial class PrideFlagObject : BaseFlagObject, IRepresentsItem, IPersistentData
    {
        public override LocString DisplayName => Localizer.DoStr("Pride Flag");
        public Type RepresentedItemType => typeof(PrideFlagItem);
        public object PersistentData { get; set; }
    }

    [Serialized]
    [LocDisplayName("Pride Flag")]
    [Ecopedia("Flags", "Flags", createAsSubPage: true)]
    [Weight(10)]
    [DoNotNotify]
    [LocDescription("A flag on a beautifully hand crafted piece of cloth held up by a well crafted iron stand. Display it out front of your house, on your town hall or wherever you like!")]
    public partial class PrideFlagItem : WorldObjectItem<PrideFlagObject>
    {

        static PrideFlagItem()
        {
            WorldObject.AddOccupancy<PrideFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class PrideFlagRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(PrideFlagRecipe).Name,
            Assembly = typeof(PrideFlagRecipe).AssemblyQualifiedName,
            HiddenName = "Pride Flag",
            LocalizableName = Localizer.DoStr("Pride Flag"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 10),
                new EMIngredient("ClothItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("PrideFlagItem"),
            },
            BaseLabor = 30,
            LaborIsStatic = true,
            BaseCraftTime = 0.1f,
            CraftTimeIsStatic = false,
            CraftingStation = "TailoringTableItem",
        };

        static PrideFlagRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public PrideFlagRecipe()
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