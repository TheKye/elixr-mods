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
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Items.Recipes;

namespace Eco.EM.Flags
{
    [Serialized]
    [RequireComponent(typeof(NationalFlagComponent))]
    [DoNotNotify]
    public partial class NationalFlagObject : BaseFlagObject, IRepresentsItem, IPersistentData
    {
        public override LocString DisplayName => Localizer.DoStr("National Flag");
        public Type RepresentedItemType => typeof(NationalFlagItem);
        public object PersistentData { get; set; }
    }

    [Serialized]
    [LocDisplayName("National Flag")]
    [Ecopedia("Flags", "Flags", createAsSubPage: true)]
    [Weight(10)]
    [LocDescription("A flag on a beautifully hand crafted piece of cloth held up by a well crafted iron stand. Display it out front of your house, on your town hall or wherever you like!")]
    [DoNotNotify]
    public partial class NationalFlagItem : WorldObjectItem<NationalFlagObject>
    {
        static NationalFlagItem()
        {
            WorldObject.AddOccupancy<NationalFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class NationalFlagRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(NationalFlagRecipe).Name,
            Assembly = typeof(NationalFlagRecipe).AssemblyQualifiedName,
            HiddenName = "National Flag",
            LocalizableName = Localizer.DoStr("National Flag"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 10),
                new EMIngredient("ClothItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("NationalFlagItem"),
            },
            BaseLabor = 30,
            LaborIsStatic = true,
            BaseCraftTime = 0.1f,
            CraftTimeIsStatic = false,
            CraftingStation = "TailoringTableItem",
        };

        static NationalFlagRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public NationalFlagRecipe()
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