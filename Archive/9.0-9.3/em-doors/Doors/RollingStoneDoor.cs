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
using Eco.World;

namespace Eco.EM.Doors
{
    [Serialized]
    public partial class RollingStoneDoorBlock : Block
    { }

    [Serialized]
	[RequireComponent(typeof(PropertyAuthComponent))]
	public partial class RollingStoneDoorObject : EmDoor
    {
		public override LocString DisplayName { get { return Localizer.DoStr("Rolling Stone Door"); } }

		static RollingStoneDoorObject()
		{
            WorldObject.AddOccupancy<RollingStoneDoorObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(-7, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-6, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-5, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-4, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-3, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-2, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-7, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-6, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-5, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-4, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-3, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-2, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-7, 2, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-6, 2, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-5, 2, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-4, 2, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-3, 2, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-2, 2, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 2, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 2, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-7, 3, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-6, 3, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-5, 3, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-4, 3, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-3, 3, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-2, 3, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(-1, 3, 0), typeof(BuildingWorldObjectBlock)),
                new BlockOccupancy(new Vector3i(0, 3, 0), typeof(BuildingWorldObjectBlock)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

	[RequiresSkill(typeof(MasonrySkill), 1)]
	public partial class RollingStoneDoorRecipe : RecipeFamily
	{
		public RollingStoneDoorRecipe()
		{
            var product = new Recipe(
                "Rolling Stone Door",
                Localizer.DoStr("Rolling Stone Door"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(MortarItem), 50,typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("Rock", 100 ,typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                },

                 new CraftingElement<RollingStoneDoorItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(300f, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RollingStoneDoorRecipe), 5, typeof(MechanicsSkill), typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Rolling Stone Door"), typeof(RollingStoneDoorRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);          
		}

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

	[Serialized]
	[MaxStackSize(10)]
    [Weight(2000)]
    [LocDisplayName("Rolling Stone Door")]
	public class RollingStoneDoorItem : WorldObjectItem<RollingStoneDoorObject>
	{
		public override LocString DisplayDescription { get { return Localizer.DoStr("A rolling stone door for your Dwarven mine"); } }

        static RollingStoneDoorItem() { }
	}
}