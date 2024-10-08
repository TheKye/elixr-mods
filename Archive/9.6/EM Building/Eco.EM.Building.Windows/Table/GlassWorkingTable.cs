﻿using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Property;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace Eco.EM.Building.Windows
{
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    [RequireComponent(typeof(PluginModulesComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]
    public partial class GlassworkingTableObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Glassworking Table");
        public Type RepresentedItemType => typeof(GlassworksItem);
        public override TableTextureMode TableTexture => TableTextureMode.Brick;

        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Crafting"));
        }

        static GlassworkingTableObject()
        {
            AddOccupancy<GlassworkingTableObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            new BlockOccupancy(new Vector3i(-1, 0, 0)),
            new BlockOccupancy(new Vector3i(-1, 1, 0)),
            });
        }


    }

    [Serialized, LocDisplayName("Glassworking Table")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true)]
    [AllowPluginModules(Tags = new[] { "BasicUpgrade" }, ItemTypes = new[] { typeof(GlassworkingAdvancedUpgradeItem) })] //noloc
    public partial class GlassworksItem : WorldObjectItem<GlassworkingTableObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A table used to create glass and windows.");
        public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
    }

    [RequiresSkill(typeof(GlassworkingSkill), 1)]

    public partial class GlassworkingTableRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GlassworkingTableRecipe).Name,
            Assembly = typeof(GlassworkingTableRecipe).AssemblyQualifiedName,
            HiddenName = "Glassworking Table",
            LocalizableName = Localizer.DoStr("Glassworking Table"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 20),
                new EMIngredient("Rock", true, 20),
                new EMIngredient("IronBarItem", false, 25),
            },
            ProductList = new()
            {
                new EMCraftable("GlassworksItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 500,
            LaborIsStatic = false,
            BaseCraftTime = 20,
            CraftTimeIsStatic = false,
            CraftingStation = "MasonryTableItem",
            RequiredSkillType = typeof(GlassworkingSkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(GlassworkingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(GlassworkingParallelSpeedTalent), typeof(GlassworkingFocusedSpeedTalent) },
        };

        static GlassworkingTableRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GlassworkingTableRecipe()
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