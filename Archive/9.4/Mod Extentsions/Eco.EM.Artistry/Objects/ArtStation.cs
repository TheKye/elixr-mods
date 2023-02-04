using Eco.EM.Framework.Resolvers;
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

   [RequiresSkill(typeof(CarpentrySkill), 1)]
    public partial class ArtStationRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ArtStationRecipe).Name,
            Assembly = typeof(ArtStationRecipe).AssemblyQualifiedName,
            HiddenName = "Art Station",
            LocalizableName = Localizer.DoStr("Art Station"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 20, true),
                new EMIngredient("PaintBrushItem", false, 6, true),
            },
            ProductList = new()
            {
                new EMCraftable("ArtStationItem"),
            },
            BaseExperienceOnCraft = 2,
            BaseLabor = 500,
            LaborIsStatic = false,
            BaseCraftTime = 20,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) },
        };

        static ArtStationRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ArtStationRecipe()
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
