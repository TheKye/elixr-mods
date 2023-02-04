using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using Eco.Mods.TechTree;
using Eco.Shared.Math;

namespace Eco.EM.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class GreatHallDoorObject : DoorObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Great Hall Door"); } }

        protected override void Initialize() { }

        static GreatHallDoorObject() 
        {
            #region Block Occupancy
            var BlockOccupancyList = new List<BlockOccupancy>();

            /*for (int z = 0; z <= 5; z++)
                for (int y = -5; y <= 0; y++)
                    BlockOccupancyList.Add( new BlockOccupancy( new Vector3i( 0, z, y ), typeof(BuildingWorldObjectBlock) ) );
            
            WorldObject.AddOccupancy<GreatHallDoubleDoorObject>( BlockOccupancyList );*/
            //BlockOccupancyList.Clear();

            BlockOccupancyList.Clear();

            for (int z = 0; z <= 0; z++)
                for (int x = 0; x >= -2; x--)
                    for (int y = 0; y <= 5; y++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(BuildingWorldObjectBlock)));
            #endregion

            AddOccupancy<GreatHallDoorObject>(BlockOccupancyList);
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [Tier(2)]
    [Weight(600)]
    [LocDisplayName("Great Hall Door")]
    [MaxStackSize(10)]
    public class GreatHallDoorItem : WorldObjectItem<GreatHallDoorObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Giant Door For Decorative Halls. Can be locked for certain players."); } }

        static GreatHallDoorItem() { }
    }

    [RequiresSkill(typeof(CarpentrySkill), 4)]
    public partial class GreatHallDoorRecipe : RecipeFamily
    {
        public GreatHallDoorRecipe()
        {
            var product = new Recipe(
            "GreatHallDoor",
            Localizer.DoStr("Great Hall Door"),
            new IngredientElement[]
            {
               new IngredientElement(typeof(IronBarItem), 30, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
               new IngredientElement("Lumber", 100, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
            },
                 new CraftingElement<GreatHallDoorItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(CarpentrySkill));
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreatHallDoorRecipe), 5, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Great Hall Door"), typeof(GreatHallDoorRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}