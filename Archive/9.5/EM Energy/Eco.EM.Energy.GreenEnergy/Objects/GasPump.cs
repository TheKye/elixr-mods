using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Property;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Energy.GreenEnergy
{
    // ToDo: 
    // Add Gas Pump To Use the Natural Gas World Layer for natural Gas Mining.
    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class GasPumpObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Gas Pump");

        static GasPumpObject()
        {
            AddOccupancy<GasPumpObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                new BlockOccupancy(new Vector3i(-1, 0, 0)),
                new BlockOccupancy(new Vector3i(-1, 1, 0)),
            });
        }

        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));
        }

        public override void Destroy() => base.Destroy();
    }

    public partial class GasPumpItem : WorldObjectItem<GasPumpObject>
    {
        public override LocString DisplayDescription => Localizer.Do($"A Big Pump for Fracking Natural Gas");

        static GasPumpItem() { }
    }

    // ToDo:
    // Add Recipe
    public partial class GasPumpRecipe : RecipeFamily
    {
        public GasPumpRecipe()
        {

        }
    }
}
