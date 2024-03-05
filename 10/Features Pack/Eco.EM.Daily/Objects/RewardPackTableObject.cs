using System;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Core.Controller;
using Eco.Shared.Networking;
using Eco.Gameplay.Players;
using Eco.Shared.Math;
using Eco.Core.Utils;
using Eco.Gameplay.Utils;
using System.Collections.Generic;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Interactions;
using System.Text;
using System.Linq;
using Eco.Gameplay.Civics.GameValues;
using System.ComponentModel;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Interactions.Interactors;
using Eco.Shared.SharedTypes;
using NLog.Targets;
using Eco.Mods.TechTree;
using System.Threading.Tasks;
using Eco.Shared.Items;
using Eco.EM.Daily.Component;
using Eco.Shared.IoC;

namespace Eco.EM.Daily
{
    [Serialized, Weight(1000), MaxStackSize(1), LocDisplayName("Reward Pack Table")]
    [ItemGroup("Hidden")]
    [Category("Hidden")]
    [LocDescription("ADMIN ONLY: Use this to assist in creating daily reward packs for the EM daily plugin.")]
    public partial class RewardPackTableItem : WorldObjectItem<RewardPackTableObject>, INotifyPropertyChanged
    {
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(RewardPackCreatorComponent))]
    [RequireComponent(typeof(DailyConfigComponent))]
    public partial class RewardPackTableObject : WorldObject, IRepresentsItem, IHasInteractions
    {
        private static RewardPackTableObject instance;
        public static RewardPackTableObject Instance
        {
            get
            {
                if (instance == null) CreateInstance();
                return instance;
            }
            set => instance = value;
        }
        private static void CreateInstance()
        {
            instance = new RewardPackTableObject();
            ServiceHolder<IWorldObjectManager>.Obj.Add(instance, null, WrappedWorldPosition3.Create(0, -1, 0), default);
        }
        public override LocString DisplayName => Localizer.DoStr("Reward pack table");

        public Type RepresentedItemType => typeof(RewardPackTableItem);

        public RewardPackTableObject() { }
        public override bool PlacesBlocks => false; //Don't try and fill any block positions when spawned. It won't conflict with any other objects you place at the same position
        public override bool Transient => true;
    }
}