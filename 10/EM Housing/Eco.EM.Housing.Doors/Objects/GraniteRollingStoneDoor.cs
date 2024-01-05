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

    public partial class GraniteRollingStoneDoorObject : EmDoor, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Granite Rolling Stone Door");
        public Type RepresentedItemType => typeof(GraniteRollingStoneDoorItem);
        public override bool HasTier => true;
        public override int Tier => 1;
        static GraniteRollingStoneDoorObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = 0; x >= -7; x--)
                for (int y = 0; y <= 3; y++)
                    BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)));

            AddOccupancy<GraniteRollingStoneDoorObject>(BlockOccupancyList);
        }

        protected override void Initialize()
        {
        }


    }

    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class GraniteRollingStoneDoorRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(GraniteRollingStoneDoorRecipe).Name,
            Assembly = typeof(GraniteRollingStoneDoorRecipe).AssemblyQualifiedName,
            HiddenName = "Granite Rolling Stone Door",
            LocalizableName = Localizer.DoStr("Granite Rolling Stone Door"),
            IngredientList = new()
            {
                new EMIngredient("MortarItem", false, 50),
                new EMIngredient("Rock", true, 100),
            },
            ProductList = new()
            {
                new EMCraftable("GraniteRollingStoneDoorItem"),
            },
            CraftingStation = "MasonryTableItem",
        };

        static GraniteRollingStoneDoorRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public GraniteRollingStoneDoorRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(RollingStoneDoorRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(2000)]
    [Tier(1)]
    [LocDisplayName("Granite Rolling Stone Door")]
    [Ecopedia("Mod Documentation", "Modded Doors", createAsSubPage: true)]
    [LocDescription("A rolling stone door for your Dwarven mine made from granite")]
    public class GraniteRollingStoneDoorItem : WorldObjectItem<GraniteRollingStoneDoorObject>
    {        
        static GraniteRollingStoneDoorItem() { }
    }
}