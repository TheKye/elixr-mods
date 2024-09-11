using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace Eco.EM.Machines.Conveyors
{
    public class ItemFilterManager : IModKitPlugin, IInitializablePlugin
    {
        public string GetStatus()
        {
            return "Filtering";
        }

        public void Initialize(TimedTask timer)
        {
            var filters = Item.AllItems.OfType<FilterModuleItem>();
            foreach (var filter in filters)
            {
                filter.Init();
            }
        }
    }

    public class FilterModuleAttribute : ItemAttribute { }

    [Serialized]
    public abstract class FilterModuleItem : Item
    {
        public abstract List<Item> FilterList { get; }
        public abstract void Init();
    }
}
