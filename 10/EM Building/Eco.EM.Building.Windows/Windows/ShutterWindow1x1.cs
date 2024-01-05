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

namespace Eco.EM.Building.Windows.Windows
{
    [Serialized]
    // Components
    public partial class ShutterWindow1x1Object : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Shutter Window 1X1");
        public virtual Type RepresentedItemType => typeof(ShutterWindow1x1Item);
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        static ShutterWindow1x1Object()
        {
            // Occupancy
        }

        protected override void Initialize() { }
        protected override void PostInitialize() { }


    }

    [Serialized, Weight(50), MaxStackSize(100)]
    [LocDisplayName("Shutter Window 1X1")]
    public partial class ShutterWindow1x1Item : WorldObjectItem<ShutterWindow1x1Object>
    {
        public override LocString DisplayDescription => Localizer.DoStr("An elegant window shutter for a 1x1 window");
        static ShutterWindow1x1Item() { }
    }

    [RequiresSkill(typeof(CarpentrySkill), 0)]
    public partial class ShutterWindow1x1Recipe : RecipeFamily, IConfigurableRecipe
    {     
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ShutterWindow1x1Recipe).Name,
            Assembly = typeof(ShutterWindow1x1Recipe).AssemblyQualifiedName,
            HiddenName = "ShutterWindow1X1",
            LocalizableName = Localizer.DoStr("Shutter Window 1X1"),
            IngredientList = new()
            {
                new EMIngredient(item:"Wood", isTag:true, amount:10, isStatic:false),
            },
            ProductList = new()
            {
                new EMCraftable(item: "ShutterWindow1x1Item", amount:1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "REPLACEME",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent), },
        };

        static ShutterWindow1x1Recipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ShutterWindow1x1Recipe()
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
