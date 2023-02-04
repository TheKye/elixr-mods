using System.Collections.Generic;
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

namespace Eco.EM.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WoodGateLargeObject : DoorObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Wood Gate"); } }

        static WoodGateLargeObject()
        {
            WorldObject.AddOccupancy<WoodGateLargeObject>(new List<BlockOccupancy>(){
                    new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class WoodGateLargeRecipe : RecipeFamily
    {            
        public WoodGateLargeRecipe()
        {
            var product = new Recipe(
                "Large Wood Gate",
                Localizer.DoStr("Large Wood Gate"),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 30 ,typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                },

                 new CraftingElement<WoodGateLargeItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WoodGateLargeRecipe), 5f, typeof(CarpentrySkill), typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Large Wood Gate"), typeof(WoodGateLargeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [MaxStackSize(10)]
    [Weight(500)]
    [LocDisplayName("Large Wood Gate")]
    public class WoodGateLargeItem : WorldObjectItem<WoodGateLargeObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A sturdy large wood gate."); } }

        static WoodGateLargeItem() { }
    }
}
