using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using Eco.Shared.Localization;
using Eco.World.Blocks;
using Eco.EM.Framework.Resolvers;
using System;
using Eco.Core.Items;

namespace Eco.EM.Housing.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class RollingStoneDoorObject : EmDoor
    {
        public override LocString DisplayName => Localizer.DoStr("Rolling Stone Door");
        public Type RepresentedItemType => typeof(RollingStoneDoorItem);
        public override bool HasTier => true;
        public override int Tier => 1;

        static RollingStoneDoorObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = 0; x >= -7; x--)
                for (int y = 0; y <= 3; y++)
                    BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""));

            AddOccupancy<RollingStoneDoorObject>(BlockOccupancyList);
        }

        public override void Destroy() => base.Destroy();
    }

    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class RollingStoneDoorRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(RollingStoneDoorRecipe).Name,
            Assembly = typeof(RollingStoneDoorRecipe).AssemblyQualifiedName,
            HiddenName = "Rolling Stone Door",
            LocalizableName = Localizer.DoStr("Rolling Stone Door"),
            IngredientList = new()
            {
                new EMIngredient("MortarItem", false, 50),
                new EMIngredient("Rock", true, 100),
            },
            ProductList = new()
            {
                new EMCraftable("RollingStoneDoorItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 300,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "MasonryTableItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 1,
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static RollingStoneDoorRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public RollingStoneDoorRecipe()
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
    [Weight(2000)]
    [Tier(1)]
    [LocDisplayName("Rolling Stone Door")]
    [Ecopedia("Modded Objects", "Modded Doors", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public class RollingStoneDoorItem : WorldObjectItem<RollingStoneDoorObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("A rolling stone door for your Dwarven mine");

        static RollingStoneDoorItem() { }
    }
}