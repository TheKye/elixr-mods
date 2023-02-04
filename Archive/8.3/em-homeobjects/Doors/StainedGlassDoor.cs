namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Wires;
    using Eco.Shared.Networking;
    using Eco.Gameplay.Audio;

    [RequiresSkill(typeof(SmeltingSkill), 0)]
    public class StainedGlassDoorRecipe : Recipe
    {
        public StainedGlassDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
            new CraftingElement<StainedGlassDoorItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
            new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 6, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
            new CraftingElement<GlassItem>(typeof(SmeltingSkill), 4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)),
            new CraftingElement<GreenDyeItem>(2)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(StainedGlassDoorRecipe), Item.Get<StainedGlassDoorItem>().UILink(), 10, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Stained Glass Door"), typeof(StainedGlassDoorRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
    [Serialized]
    [ItemTier(2)]
    [Weight(600)]
    public class StainedGlassDoorItem : WorldObjectItem<StainedGlassDoorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Stained Glass Door"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Beautiful Stained Glass Style Door."); } }
    }
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class StainedGlassDoorObject : WorldObject, IWireContainer
    {
        [Serialized] public bool OpensOut { get; private set; }
        [Serialized] public bool Open { get; private set; }
        public override LocString DisplayName { get { return Localizer.DoStr("Stained Glass Door"); } }
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
        protected StainedGlassDoorObject() { }
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
      // protected override void OnCreate()
      // {
      //     base.OnCreate();
      //     // determine open direction
      //     var placerPos = this.Creator.User.Position;
      //     var toDoor = placerPos - this.Position;
      //     var facing = this.Rotation.RotateVector(Vector3.Forward);
      //     this.OpensOut = Vector3.Dot(toDoor, facing) < 0;
      // }
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