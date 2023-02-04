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

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.CustomFlags
{
    [Serialized]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SusProjectFlagComponent))]
    public partial class SusProjectFlagObject : CustomBaseFlagObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Sustainability Project Flag");
        public Type RepresentedItemType => typeof(SusProjectFlagItem);
    }

    [Serialized]
    [LocDisplayName("Sustainability Project Flag")]
    [Ecopedia("Flags", "Flags", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Weight(10)]
    public partial class SusProjectFlagItem : WorldObjectItem<SusProjectFlagObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The Sustainability Project Flag on a beautifuly hand crafted piece of cloth held up by a well crafted stand. Display it out front of your house, on your town hall or wherever you like!");

        static SusProjectFlagItem()
        {
            WorldObject.AddOccupancy<SusProjectFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    //This is the Recipe you can remove the whole recipe if you don't want it crafted
    //if you want to remove the recipe remove from here

    public partial class SusProjectFlagRecipe : RecipeFamily
    {
        public SusProjectFlagRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Sustainability Project Flag",
                    Localizer.DoStr("Sustainability Project Flag"),
                    new IngredientElement[]
                    {
                        //These are the crafting costs, you can edit the cost to what ever you would like or change the items completely
                    new IngredientElement(typeof(IronBarItem), 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<SusProjectFlagItem>(2),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("Sustainability Project Flag"), typeof(SusProjectFlagRecipe));

            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }

    // Included so the base objects do not need to be distributed seperately
    [Serialized]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public abstract class CustomBaseFlagObject : WorldObject
    {
        public CustomBaseFlagObject() { }
        //Remove All from below if you don't want animations based on room
        public override void RoomUpdated()
        {
            CheckRoom();
            base.RoomUpdated();
        }

        private bool IsOutside() => this.Room == Gameplay.Rooms.Room.Global;

        public void CheckRoom() => this.SetAnimatedState("Enabled", IsOutside());

        protected override void PostInitialize()
        {
            base.PostInitialize();
            CheckRoom();
        }
        //end remove
    }

    [Eco]
    public enum CustomFlagMaterial
    {
        IronGold = 0,
        Redwood = 1,
    }

    [Serialized, AutogenClass]
    public abstract class CustomFlagComponent : WorldObjectComponent
    {
        CustomFlagMaterial materialOption;

        [Eco, ClientInterfaceProperty, GuestHidden]
        public CustomFlagMaterial MaterialOption
        {
            get => this.materialOption;
            set
            {
                if (value == this.materialOption) return;
                this.materialOption = value;
                this.Changed(nameof(this.MaterialOption));
            }
        }

        [RPC, Autogen, GuestHidden]
        public void SetFlagPole(Player player)
        {
            this.Parent.SetAnimatedState("PoleChange", MaterialOption.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Parent.SetAnimatedState("PoleChange", MaterialOption.GetName());
        }
    }

    [Eco]
    public enum SusProjectFlag
    {
        SusProject,
    }

    [Serialized, LocDisplayName("Flag Settings")]
    public partial class SusProjectFlagComponent : CustomFlagComponent
    {
        SusProjectFlag flagOption;
        [Eco, ClientInterfaceProperty, GuestHidden]
        public SusProjectFlag FlagOption
        {
            get => this.flagOption;
            set
            {
                if (value == this.flagOption) return;
                this.flagOption = value;
                this.Changed(nameof(this.FlagOption));
            }
        }

        [RPC, Autogen, GuestHidden]
        public void SetFlag(Player player)
        {
            this.Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Parent.SetAnimatedState("FlagChange", FlagOption.GetName());
        }
    }
}