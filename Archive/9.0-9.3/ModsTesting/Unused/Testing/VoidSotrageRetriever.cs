using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.CustomisedRequests
{
    public class VoidCommands : IChatCommandHandler
    {

        [ChatCommand("Elixr Mods Void Storage Retrieval", ChatAuthorizationLevel.User)]
        public static void Void() { }

        [ChatSubCommand("Void", "Get All Items From Void Storage", "getvoid", ChatAuthorizationLevel.User)]
        public static void GetVoid(User user)
        {
            var voids = GameData.Obj.VoidStorageManager.VoidStorages.ToList(); // Gets all the Void Storages

            int count = 1;
            PhysicalVoidStorageObject box = null; 
            foreach (var v in voids)
            {
                if (!v.CanUserAccess(user)) continue; // Only retrieve users void storages
                if (v.Name == "Alpha Backer Rewards" || v.Name == "Wolf Whisperer Rewards") continue; // don't touch backer storages

                while (!v.Inventory.IsEmpty)
                {
                    if (box == null) box = WorldObjectManager.ForceAdd(typeof(PhysicalVoidStorageObject), user, user.Position.Round + (new Vector3i(1, 0, 0) * count), Quaternion.Identity, false) as PhysicalVoidStorageObject;
                    if (box == null) { count++; continue; }

                    var inv = box.GetComponent<PublicStorageComponent>().Inventory;
                    v.Inventory.MoveAsManyItemsAsPossible(inv, user);
                    box.Lock();
                    box = null;
                    count++;
                }
            }
        }
    }

    [Serialized]
    [LocDisplayName("Physical Void")]
    [LocCategory("Hidden")]
    public partial class PhysicalVoidStorageItem : WorldObjectItem<PhysicalVoidStorageObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A General Storage Crate for storing small items.. But has limited link range"); } }
    }

    [Serialized]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [LocCategory("Hidden")]
    public class PhysicalVoidStorageObject : WorldObject, IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Physical Void Sotrage Crate"); } }

        public Type RepresentedItemType => typeof(PhysicalVoidStorageItem);

        protected override void Initialize()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(400);
            storage.Storage.AddInvRestriction(new StackLimitRestriction(99999));
            this.GetComponent<LinkComponent>().Initialize(20);
            storage.Inventory.OnChanged.Add(EmptyCheck);
        }

        private void EmptyCheck(User user) { if (GetComponent<PublicStorageComponent>().Inventory.IsEmpty) Destroy(); }

        [OnDeserialized] void OnDeserialized() { Lock(); }

        public void Lock() { GetComponent<PublicStorageComponent>().Inventory.AddInvRestriction(new NoAddRestictions()); }
    }
}
