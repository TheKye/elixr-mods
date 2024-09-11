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
using System.Linq;
using Eco.Core.Items;
using Eco.Gameplay.Modules;
using Eco.EM.Framework.Extentsions;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Items.Recipes;

namespace Eco.EM.Housing.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]

    public partial class LimestoneRollingStoneDoorObject : EmDoor
    {
        public override LocString DisplayName => Localizer.DoStr("Limestone Rolling Stone Door");
        public Type RepresentedItemType => typeof(LimestoneRollingStoneDoorItem);
        public override bool HasTier => true;
        public override int Tier => 1;
        static LimestoneRollingStoneDoorObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = 0; x >= -7; x--)
                for (int y = 0; y <= 3; y++)
                    BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)));

            AddOccupancy<LimestoneRollingStoneDoorObject>(BlockOccupancyList);
        }
        protected override void Initialize()
        {
        }

    }

    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class LimestoneRollingStoneDoorRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(LimestoneRollingStoneDoorRecipe).Name,
            Assembly = typeof(LimestoneRollingStoneDoorRecipe).AssemblyQualifiedName,
            HiddenName = "Limestone Rolling Stone Door",
            LocalizableName = Localizer.DoStr("Limestone Rolling Stone Door"),
            IngredientList = new()
            {
                new EMIngredient("MortarItem", false, 50),
                new EMIngredient("Rock", true, 100),
            },
            ProductList = new()
            {
                new EMCraftable("LimestoneRollingStoneDoorItem"),
            },
            CraftingStation = "MasonryTableItem",
        };

        static LimestoneRollingStoneDoorRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public LimestoneRollingStoneDoorRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(RollingStoneDoorRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(2000)]
    [Tier(1)]
    [LocDisplayName("Limestone Rolling Stone Door")]
    [Ecopedia("Mod Documentation", "Modded Doors", createAsSubPage: true)]
    [LocDescription("A rolling stone door for your Dwarven mine made from limestone")]
    public class LimestoneRollingStoneDoorItem : WorldObjectItem<LimestoneRollingStoneDoorObject>
    {
        
        static LimestoneRollingStoneDoorItem() { }
    }
}