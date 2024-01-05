using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Shared.Localization;
using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using Eco.Shared.Math;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Mods.TechTree;
using System;
using Eco.Shared.Networking;
using Eco.Core.Controller;
using Eco.Gameplay.Players;

namespace Eco.EM.Flags
{
    [Serialized]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(FlagComponent))]
    public partial class EcoManiacsFlagObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Eco Maniacs Flag"); } }
        public Type RepresentedItemType => typeof(EcoManiacsFlagItem);

    }

    [Serialized]
    [LocDisplayName("Eco Maniacs Flag")]
    [Ecopedia("Flags", "Flags", createAsSubPage: true)]
    [Weight(10)]
    public partial class EcoManiacsFlagItem : WorldObjectItem<EcoManiacsFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("The Eco Maniacs flag on a beautifully hand crafted piece of cloth held up by a well crafted stand. Display it out front of your house, on your town hall or wherever you like!"); } }

        static EcoManiacsFlagItem()
        {
            WorldObject.AddOccupancy<EcoManiacsFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class EcoManiacsFlagRecipe : RecipeFamily
    {
        public EcoManiacsFlagRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Eco Maniacs Flag",
                    Localizer.DoStr("Eco Maniacs Flag"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<EcoManiacsFlagItem>(2),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("Eco Maniacs Flag"), typeof(EcoManiacsFlagRecipe));

            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }

    // Included so the base objects do not need to be distributed separately
    [Serialized]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public abstract class BaseFlagObject : WorldObject
    {
        [Serialized] public bool Outside { get; private set; }

        public BaseFlagObject()
        {
            Outside = SetOutside();
            this.RoomChanged.Add(CheckRoom);
            CheckRoom();
        }

        private bool SetOutside() { return this.Room == Gameplay.Rooms.Room.Global; }

        public void CheckRoom() => this.SetAnimatedState("Enabled", Outside);
    }

    [Eco]
    public enum FlagMaterial
    {
        IronGold = 0,
        Redwood = 1,
    }

    [Serialized]
    public abstract class FlagComponent : WorldObjectComponent
    {
        [Eco, ClientInterfaceProperty] public FlagMaterial MaterialOption { get; set; } = FlagMaterial.IronGold;

        [RPC, Autogen]
        public void SetFlagPole(Player player)
        {
            this.Parent.TriggerAnimatedEvent(MaterialOption.GetName());
        }
    }
}