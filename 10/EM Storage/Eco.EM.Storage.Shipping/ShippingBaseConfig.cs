using Eco.Core.Controller;
using Eco.Core.Plugins;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.Shared.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eco.EM.Storage
{
    public class ShippingBaseConfig 
    {
        [LocDisplayName("20ft Shipping Container Link Distance")]
        [LocDescription("Sets the link distance for the 20ft Shipping Container, Please be sure to restart the server after adjusting the link distance.")]
        public int LinkDistance { get; set; } = 12;

        [LocDisplayName("20ft Shipping Container Storage Slots")]
        [LocDescription("Sets the amount of storage slots in the 20ft Shipping Container. Please be sure to restart the server after adjusting this value. WARNING: Reducing the slots may result in lost items!")]
        public int Storage { get; set; } = 56;

        [LocDisplayName("40ft Shipping Container Link Distance")]
        [LocDescription("Sets the link distance for the 20ft Shipping Container, Please be sure to restart the server after adjusting the link distance.")]
        public int TLinkDistance { get; set; } = 12;

        [LocDisplayName("20ft Shipping Container Storage Slots")]
        [LocDescription("Sets the amount of storage slots in the 40ft Shipping Container. Please be sure to restart the server after adjusting this value. WARNING: Reducing the slots may result in lost items!")]
        public int TStorage { get; set; } = 128;

        [LocDisplayName("Storage Crate Link Distance")]
        [LocDescription("Sets the link distance for the Storage Crate, Please be sure to restart the server after adjusting the link distance.")]
        public int CrateLinkDistance { get; set; } = 5;

        [LocDisplayName("Storage Crate Storage Slots")]
        [LocDescription("Sets the amount of storage slots in the Storage Crate. Please be sure to restart the server after adjusting this value. WARNING: Reducing the slots may result in lost items!")]
        public int CrateStorage { get; set; } = 20;
    }
}
