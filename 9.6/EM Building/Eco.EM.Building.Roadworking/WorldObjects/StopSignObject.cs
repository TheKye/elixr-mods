using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.EM.Framework.Resolvers;
using System.Linq;

namespace Eco.EM.Building.Roadworking
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class AStopSignObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Stop Sign");
        public virtual Type RepresentedItemType => typeof(AStopSignItem);

        static AStopSignObject()
        {
            AddOccupancy<AStopSignObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }

        protected override void Initialize() { }


    }

    [Serialized, Weight(600), LocDisplayName("A Stop Sign"), MaxStackSize(100)]
    public partial class AStopSignItem : WorldObjectItem<AStopSignObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Stop Sign.");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
        static AStopSignItem() { }
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class StopSignRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StopSignRecipe).Name,
            Assembly = typeof(StopSignRecipe).AssemblyQualifiedName,
            HiddenName = "Stop Sign",
            LocalizableName = Localizer.DoStr("Stop Sign"),
            IngredientList = new()
            {
                new EMIngredient("WoodBoard", true, 10),
                new EMIngredient("ClothItem", false, 5)
            },
            ProductList = new()
            {
                new EMCraftable("AStopSignItem"),
            },
            CraftingStation = "AnvilItem",
        };

        static StopSignRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StopSignRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(AheadSignRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
}