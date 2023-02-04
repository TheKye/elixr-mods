using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Storage
{ 
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(StockpileComponent))]
    [RequireComponent(typeof(WorldStockpileComponent))]
    public partial class LogPileObject : WorldObject, IRepresentsItem
    {
        public static readonly Vector3i DefaultDim = new Vector3i(2, 2, 4);

        public override LocString DisplayName => Localizer.DoStr("LogPile");

        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        public virtual Type RepresentedItemType => typeof(LogPileItem); 

        static LogPileObject() { }

        protected override void OnCreate()
        {
            base.OnCreate();
            StockpileComponent.ClearPlacementArea(this.Creator, this.Position3i, DefaultDim, this.Rotation);
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(DefaultDim.x * DefaultDim.z);
            storage.Storage.AddInvRestriction(new TagRestriction(Tag.Wood.Name));
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("LogPile")]
    [Ecopedia("Crafted Objects", "Storage", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class LogPileItem : WorldObjectItem<LogPileObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Designates a 2x2x4 area as storage for logs.");

        static LogPileItem() { }

        public override bool TryPlaceObject(Player player, Vector3i position, Quaternion rotation)
        {
            return this.TryPlaceObjectOnSolidGround(player, position, rotation);
        }
    }

    public partial class LogPileRecipe : RecipeFamily
    {
        public LogPileRecipe()
        {
            var product = new Recipe(
                "LogPile",
                Localizer.DoStr("LogPile"),
                new IngredientElement[]
                {
               new IngredientElement("Wood", 8, true),
               new IngredientElement("NaturalFiber", 20)
                },
               new CraftingElement<LogPileItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(25);
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("LogPile"), typeof(LogPileRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
