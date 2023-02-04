using Eco.Core.Utils;
using Eco.Shared.Localization;

namespace Eco.EM.Framework.Resolvers
{
    public class EMConfigureConfig
    {
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
