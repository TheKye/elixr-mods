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

    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(WhiteTigerFlagComponent))]
    public partial class WhiteTigerFlagObject : CustomBaseFlagObject, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("White Tiger Flag");
        public Type RepresentedItemType => typeof(WhiteTigerFlagItem);
    }

    [Serialized]
    [LocDisplayName("White Tiger Flag")]
    [Ecopedia("Flags", "Flags", createAsSubPage: true)]
    [Weight(10)]
    public partial class WhiteTigerFlagItem : WorldObjectItem<WhiteTigerFlagObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The White Tiger Flag on a beautifully hand crafted piece of cloth held up by a well crafted stand. Display it out front of your house, on your town hall or wherever you like!");

        static WhiteTigerFlagItem()
        {
            WorldObject.AddOccupancy<WhiteTigerFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    //This is the Recipe you can remove the whole recipe if you don't want it crafted
    //if you want to remove the recipe remove from here to
    //Recipe removed By Request
    /*
    public partial class WhiteTigerFlagRecipe : RecipeFamily
    {
        public WhiteTigerFlagRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "White Tiger Flag",
                    Localizer.DoStr("White Tiger Flag"),
                    new IngredientElement[]
                    {
                        //These are the crafting costs, you can edit the cost to what ever you would like or change the items completely
                    new IngredientElement(typeof(IronBarItem), 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<WhiteTigerFlagItem>(2),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("White Tiger Flag"), typeof(WhiteTigerFlagRecipe));

            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
    */

    // Included so the base objects do not need to be distributed separately
    [Serialized]

    [RequireComponent(typeof(PropertyAuthComponent))]
    public abstract class CustomBaseFlagObject : WorldObject
    {
        [Serialized] public bool Outside { get; private set; }

        public CustomBaseFlagObject()
        {
            this.SetAnimatedState("IsRoom", true);
        }
    }

    [Eco]
    public enum customFlagMaterial
    {
        IronGold,
        Redwood
    }

    [Serialized]
    public partial class CustomFlagComponent : WorldObjectComponent
    {
        public CustomFlagComponent() { }

        customFlagMaterial materialOption;

        [Eco, ClientInterfaceProperty, GuestHidden]
        public customFlagMaterial MaterialOption
        {
            get => this.materialOption;
            set
            {
                if (value == this.materialOption) return;
                this.materialOption = value;
                this.Changed(nameof(this.MaterialOption));
            }
        }

        [RPC, Autogen]
        public void SetFlagPole(Player player)
        {
            this.Parent.TriggerAnimatedEvent(MaterialOption.GetName());
            this.Changed(nameof(materialOption));
        }
    }

    [Eco]
    public enum WhiteTigerFlag
    {
        WhiteTiger,
        LGBTQIA,
        UnitedNations,
        Ukraine,
        FlagOfEurope
    }

    [Serialized, AutogenClass, LocDisplayName("Flag Selection")]
    public partial class WhiteTigerFlagComponent : CustomFlagComponent
    {
        public WhiteTigerFlagComponent() { }

        WhiteTigerFlag wtmaterialOption;

        [Eco, ClientInterfaceProperty, GuestHidden]
        public WhiteTigerFlag WtMaterialOption
        {
            get => this.wtmaterialOption;
            set
            {
                if (value == this.wtmaterialOption) return;
                this.wtmaterialOption = value;
                this.Changed(nameof(this.WtMaterialOption));
            }
        }

        [RPC, Autogen, GuestHidden]
        public void SetFlag(Player player)
        {
            this.Parent.SetAnimatedState("FlagChange", WtMaterialOption.GetName());
            this.Changed(nameof(WtMaterialOption));
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Parent.SetAnimatedState("FlagChange", WtMaterialOption.GetName());
        }
    }
}