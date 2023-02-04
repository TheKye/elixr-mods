﻿using Eco.Core.Utils;
using Eco.Shared.Localization;

namespace Eco.EM.Framework.Resolvers
{
    public class EMConfigureConfig
    {
        [LocDisplayName("Default Max Stack Size")]
        [LocDescription("Set the default max stack size of those that don't have the max stack size attribute (Default is 100)")]
        public int DefaultMaxStackSize { get; set; } = 100;

        [LocDisplayName("Force All Items to have the same Stack Size")]
        [LocDescription("Force all items to share the same stack size, this should work for almost any mod and all vanilla items as well")]
        public bool ForceSameStackSizes { get; set; } = false;

        [LocDisplayName("Forced Stack Size Amount")]
        [LocDescription("Set the stack size amount")]
        public int ForcedSameStackAmount { get; set; } = 100;

        [LocDisplayName("Use Config Overrides")]
        [LocDescription("Enable the Use of Config overrides for Recipes, only enable this if you wish to configure the recipes yourself")]
        public bool useConfigOverrides { get; set; } = false;

        [LocDescription("Recipes loaded by modules. ANY change to this list will require a server restart to take effect.")]
        [LocDisplayName("Recipes")]
        public SerializedSynchronizedCollection<RecipeModel> EMRecipes { get; set; } = new();

        [LocDescription("EM Link radius loaded by modules. ANY change to this list will require a server restart to take effect.")]
        [LocDisplayName("Link Distances")]
        public SerializedSynchronizedCollection<LinkModel> EMLinkDistances { get; set; } = new();

        [LocDescription("Stack sizes by modules. ANY change to this list will require a server restart to take effect.")]
        [LocDisplayName("Stack Sizes")]
        public SerializedSynchronizedCollection<StackSizeModel> EMStackSizes { get; set; } = new();

        [LocDescription("Storage slots by modules. ANY change to this list will require a server restart to take effect.")]
        [LocDisplayName("Storage Slots")]
        public SerializedSynchronizedCollection<StorageSlotModel> EMStorageSlots { get; set; } = new();

        [LocDescription("Item weight by modules. ANY change to this list will require a server restart to take effect.")]
        [LocDisplayName("Item Weight")]
        public SerializedSynchronizedCollection<ItemWeightModel> EMItemWeight { get; set; } = new();

        [LocDescription("Food Item Values by modules. ANY change to this list will require a server restart to take effect.")]
        [LocDisplayName("Food Items")]
        public SerializedSynchronizedCollection<FoodItemModel> EMFoodItem { get; set; } = new();

        [LocDescription("Home Furnishing Values by modules. ANY change to this list will require a server restart to take effect.")]
        [LocDisplayName("Home Furnishing Values")]
        public SerializedSynchronizedCollection<HousingModel> EMHousingValue { get; set; } = new();

        [LocDescription("Vehicle Configuration Values by modules. ANY change to this list will require a server restart to take effect.")]
        [LocDisplayName("Vehicle Configuration Values")]
        public SerializedSynchronizedCollection<VehicleModel> EMVehicles { get; set; } = new();
    }
}
