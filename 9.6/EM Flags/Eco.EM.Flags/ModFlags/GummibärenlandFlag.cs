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

    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(FlagComponent))]
    public partial class GummibärenlandFlagObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Gummibärenland Flag"); } }
        public Type RepresentedItemType => typeof(GummibärenlandFlagItem);
    }

    [Serialized]
    [LocDisplayName("Gummibärenland Flag")]
    [Ecopedia("Flags", "Flags", createAsSubPage: true)]
    [Weight(10)]
    public partial class GummibärenlandFlagItem : WorldObjectItem<GummibärenlandFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("The Gummibärenland flag on a beautifully hand crafted piece of cloth held up by a well crafted stand. Display it out front of your house, on your town hall or wherever you like!"); } }

        static GummibärenlandFlagItem()
        {
            WorldObject.AddOccupancy<GummibärenlandFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    //This is the Recipe you can remove the whole recipe if you don't want it crafted
    //if you want to remove the recipe remove from here to
    public partial class GummibärenlandFlagRecipe : RecipeFamily
    {
        public GummibärenlandFlagRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Gummibärenland Flag",
                    Localizer.DoStr("Gummibärenland Flag"),
                    new IngredientElement[]
                    {
                        //These are the crafting costs, you can edit the cost to what ever you would like or change the items completely
                    new IngredientElement(typeof(IronBarItem), 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<GummibärenlandFlagItem>(2),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("Gummibärenland Flag"), typeof(GummibärenlandFlagRecipe));

            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }

    // Included so the base objects do not need to be distributed separately
    [Serialized]

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