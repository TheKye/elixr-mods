using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Housing.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WoodGateLargeObject : DoorObject
    {
        public override LocString DisplayName => Localizer.DoStr("Large Wood Gate");

        static WoodGateLargeObject()
        {
            WorldObject.AddOccupancy<WoodGateLargeObject>(new List<BlockOccupancy>(){
                    new BlockOccupancy(new Vector3i(0, 0, 0),  typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(0, 1, 0),  typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(0, 0, -1)),
                    new BlockOccupancy(new Vector3i(0, 1, -1)),
                    new BlockOccupancy(new Vector3i(-1, 0, -1)),
                    new BlockOccupancy(new Vector3i(-1, 1, -1)),
                    new BlockOccupancy(new Vector3i(0, 0, 1)),
                    new BlockOccupancy(new Vector3i(0, 1, 1)),
                    new BlockOccupancy(new Vector3i(-1, 0, 1)),
                    new BlockOccupancy(new Vector3i(-1, 1, 1)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class WoodGateLargeRecipe : RecipeFamily, IConfigurableRecipe
    {            
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WoodGateLargeRecipe).Name,
            Assembly = typeof(WoodGateLargeRecipe).AssemblyQualifiedName,
            HiddenName = "Large Wood Gate",
            LocalizableName = Localizer.DoStr("Large Wood Gate"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 30),
            },
            ProductList = new()
            {
                new EMCraftable("WoodGateLargeItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 50,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) },
        };

        static WoodGateLargeRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WoodGateLargeRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(500)]
    [LocDisplayName("Large Wood Gate")]
    [Ecopedia("Modded Objects", "Modded Doors", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public class WoodGateLargeItem : WorldObjectItem<WoodGateLargeObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A sturdy large wood gate.");

        static WoodGateLargeItem() { }
    }
}
