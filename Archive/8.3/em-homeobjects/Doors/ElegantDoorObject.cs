namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.World.Blocks;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Wires;
    using Eco.Shared.Networking;
    using Eco.Gameplay.Rooms;
    using Eco.Gameplay.Audio;

    [RequiresSkill(typeof(HewingSkill), 0)]

    public class ElegantDoorRecipe : Recipe
    {
        public ElegantDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
            new CraftingElement<ElegantDoorItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
            new CraftingElement<LogItem>(typeof(HewingSkill), 8, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent)),
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(ElegantDoorRecipe), Item.Get<ElegantDoorItem>().UILink(), 10, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Elegant Door"), typeof(ElegantDoorRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }


    [Serialized]
    [ItemTier(1)]
    [Weight(600)]
    public class ElegantDoorItem : WorldObjectItem<ElegantDoorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Elegant Door"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("An Elegant Style Door."); } }

    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class ElegantDoorObject : WorldObject, IWireContainer
    {
        [Serialized] public bool OpensOut { get; private set; }
        [Serialized] public bool Open { get; private set; }
        public override LocString DisplayName { get { return Localizer.DoStr("Elegant Door"); } }
        protected override void Initialize()
        {
        }
        public override void Destroy()
        {
            base.Destroy();
        }

        public bool IsAirtight { get { return !this.Open; } }
        
        WireInput input;
        IEnumerable<WireConnection> IWireContainer.Wires { get { return this.input.SingleItemAsEnumerable(); } }

        protected ElegantDoorObject() { }

        public void SetOpen(bool open)
        {
            if (this.Open == open) return;
            this.ToggleOpen();
        }


        public override InteractResult OnActRight(InteractionContext context)

        {
                ToggleOpen();
            return InteractResult.Success;
        }
        
        //protected override void OnCreate()
        ///{
        //   base.OnCreate();
        //   // determine open direction
        //   var placerPos = this.Creator.User.Position;
        //   var toDoor = placerPos - this.Position;
        //   var facing = this.Rotation.RotateVector(Vector3.Forward);
        //   this.OpensOut = Vector3.Dot(toDoor, facing) < 0;
        //}

        protected override void PostInitialize()
        {
            this.input = WireInput.CreateSignalInput(this, "Open Door", v => this.SetOpen(v == 0f ? false : true));
            base.Initialize();
        }

        public override void SendInitialState(BSONObject bsonObj, INetObjectViewer viewer)

        {
            base.SendInitialState(bsonObj, viewer);
            bsonObj["open"] = this.Open;
            bsonObj["opensOut"] = this.OpensOut;
        }

        private void ToggleOpen()
        {
            if (this.Open)
                AudioManager.PlayAudio("Doors/DoorCloseSfx", this.Position);
            if (!this.Open)
                AudioManager.PlayAudio("Doors/DoorOpenSfx", this.Position);

            this.Open = !this.Open;
            this.RPC("Toggle");

            this.SetDirty();
        }
    }
}