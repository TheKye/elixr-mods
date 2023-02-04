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
    public partial class WoodGateSmallObject : DoorObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Small Wood Gate"); } }

        static WoodGateSmallObject()
        {
            AddOccupancy<WoodGateSmallObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy() => base.Destroy();
    }

    [RequiresSkill(typeof(CarpentrySkill), 2)]
    public partial class WoodGateSmallRecipe : RecipeFamily
    {
        public WoodGateSmallRecipe()
        {
            var product = new Recipe(
                "Small Wood Gate",
                Localizer.DoStr("Small Wood Gate"),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 10 ,typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                },

                 new CraftingElement<WoodGateSmallItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WoodGateSmallRecipe), 1f, typeof(CarpentrySkill), typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Small Wood Gate"), typeof(WoodGateSmallRecipe));
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
    [LocDisplayName("Small Wood Gate")]
    public class WoodGateSmallItem : WorldObjectItem<WoodGateSmallObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A sturdy Small wood gate."); } }

        static WoodGateSmallItem() { }
    }
}
