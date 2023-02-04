using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Property;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Artistry
{
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]
    public partial class ArtStationObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Art Station");
        public Type RepresentedItemType => typeof(ArtStationItem);

        protected override void Initialize() 
        {
            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));
        }

        static ArtStationObject()
        {
            WorldObject.AddOccupancy<ArtStationObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            new BlockOccupancy(new Vector3i(-1, 0, 0)),
            new BlockOccupancy(new Vector3i(-1, 1, 0)),
            });
        }

        public override void Destroy() { base.Destroy(); }
    }

    [Serialized]
    [LocDisplayName("Art Station")]
    [MaxStackSize(100)]
    public partial class ArtStationItem : WorldObjectItem<ArtStationObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("For creative snowflakes."); 
    }

   [RequiresSkill(typeof(CarpenterSkill), 1)]
    public partial class ArtStationRecipe : RecipeFamily
    {
        private string rName = "Art Station";
        private Type skillBase = typeof(PaintingSkill);
        private Type ingTalent = typeof(PaintingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) };

        public ArtStationRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 20, skillBase, ingTalent),
                    new IngredientElement(typeof(PaintBrushItem), 6, skillBase, ingTalent),
                },
                 new CraftingElement<ArtStationItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(500f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 20f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
