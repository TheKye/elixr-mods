using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Doors
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class WoodGateMediumObject : DoorObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Medium Wood Gate"); } }

        static WoodGateMediumObject()
        {
            WorldObject.AddOccupancy<WoodGateMediumObject>(new List<BlockOccupancy>(){
                    new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                    new BlockOccupancy(new Vector3i(0, 1, 0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class WoodGateMediumRecipe : RecipeFamily
    {            
        public WoodGateMediumRecipe()
        {
            var product = new Recipe(
                "Medium Wood Gate",
                Localizer.DoStr("Medium Wood Gate"),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 20 ,typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                },

                 new CraftingElement<WoodGateMediumItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WoodGateMediumRecipe), 2f, typeof(CarpentrySkill), typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Medium Wood Gate"), typeof(WoodGateMediumRecipe));
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
    [LocDisplayName("Medium Wood Gate")]
    public class WoodGateMediumItem : WorldObjectItem<WoodGateMediumObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A sturdy Medium wood gate."); } }

        static WoodGateMediumItem() { }
    }
}
