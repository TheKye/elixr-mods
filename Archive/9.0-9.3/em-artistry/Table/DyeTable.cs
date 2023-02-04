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
    public partial class DyeTableObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Dye Table");
        public Type RepresentedItemType => typeof(DyeTableItem);

        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));
        }

        static DyeTableObject()
        {
            WorldObject.AddOccupancy<DyeTableObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            });
        }

        public override void Destroy() { base.Destroy(); }
    }

    [Serialized]
    [LocDisplayName("Dye Table")]
    [MaxStackSize(100)]
    public partial class DyeTableItem : WorldObjectItem<DyeTableObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("For creative butterflies."); 
    }

    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class DyeTableRecipe : RecipeFamily
    {
        private string rName = "Dye Table";
        private Type skillBase = typeof(PaintingSkill);
        private Type ingTalent = typeof(PaintingLavishResourcesTalent);
        private Type[] speedTalents = { typeof(PaintingParallelSpeedTalent), typeof(PaintingFocusedSpeedTalent) };

        public DyeTableRecipe()
        {
            var product = new Recipe(
               rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Rock", 20, skillBase, ingTalent),
                    new IngredientElement(typeof(BucketItem), 6, skillBase, ingTalent),
                },
                 new CraftingElement<DyeTableItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(500f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 20f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
