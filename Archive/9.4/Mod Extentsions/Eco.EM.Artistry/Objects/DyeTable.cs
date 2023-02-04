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
            new BlockOccupancy(new Vector3i(-1, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            new BlockOccupancy(new Vector3i(-1, 1, 0)),
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
    public partial class DyeTableRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(DyeTableRecipe).Name,
            Assembly = typeof(DyeTableRecipe).AssemblyQualifiedName,
            HiddenName = "Dye Table",
            LocalizableName = Localizer.DoStr("Dye Table"),
            IngredientList = new()
            {
                new EMIngredient("Rock", true, 20),
                new EMIngredient("Wood", true, 20),
                new EMIngredient("BucketItem", false, 6),
            },
            ProductList = new()
            {
                new EMCraftable("DyeTableItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 250,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "MasonryTableItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static DyeTableRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public DyeTableRecipe()
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
