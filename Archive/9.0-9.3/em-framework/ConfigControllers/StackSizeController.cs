using Eco.Core.Utils;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Eco.EM.Framework
{
    public class StackSizeElement
    {
        public string ItemName { get; set; }
        public int StackSize { get; set; }

        public StackSizeElement(string n, int s)
        {
            ItemName = n;
            StackSize = s;
        }

        public override string ToString() => ItemName;
    }

    public interface IStackSizeConfig
    {
        public SerializedSynchronizedCollection<StackSizeElement> StackSizes { get; set; }
    }

    public class StackSizeController
    {
        private static readonly StackSizeController obj = new StackSizeController();

        static StackSizeController() { }

        private StackSizeController() { }

        public static StackSizeController Obj => obj;

        public void InitializeStackConfig(IStackSizeConfig config, bool VanillaOveride = false)
        {
            IEnumerable<Item> locals;

            if (VanillaOveride)
                locals = Item.AllItems.Where(x =>
                x.GetType().Module == Item.Get("WorkbenchItem").GetType().Module
                && !(x.Category == "Hidden")
                && !x.TagNames().ToList().Contains("NotInBrowser")
                && !(x is Skill)
                && ItemAttribute.Has<MaxStackSizeAttribute>(x.Type));
            else
                locals = Item.AllItems.Where(x =>
                x.GetType().Module == config.GetType().Module
                && !(x.Category == "Hidden")
                && !x.TagNames().ToList().Contains("NotInBrowser")
                && !(x is Skill)
                && ItemAttribute.Has<MaxStackSizeAttribute>(x.Type));

            locals = locals.OrderBy(x => x.DisplayName);

            BuildStackSizeList(config, locals);
            OverrideStackSizes(config, locals);
        }

        // Goes through and loads new items for stack sizes into the dictionary.
        private void BuildStackSizeList(IStackSizeConfig config, IEnumerable<Item> locals)
        {
            // Go through and keep items that are still referenced in the namespace
            SerializedSynchronizedCollection<StackSizeElement> cleanList = new SerializedSynchronizedCollection<StackSizeElement>();
            for (int i = 0; i < config.StackSizes.Count; i++)
            {
                if (locals.Any(x => x.DisplayName == config.StackSizes[i].ItemName))
                {
                    if (!cleanList.Any(x => x.ItemName == config.StackSizes[i].ItemName))
                    {
                        cleanList.Add(new StackSizeElement(config.StackSizes[i].ItemName, config.StackSizes[i].StackSize));
                    }
                }
            }
            config.StackSizes = cleanList;

            // Now add anything that is new
            foreach (var i in locals)
            {
                if (!config.StackSizes.Any(x => x.ItemName == i.DisplayName))
                {
                    config.StackSizes.Add(new StackSizeElement(i.DisplayName, i.MaxStackSize));
                }
            }
        }

        // Overrides the preset stacksizes to those set in the config on load before adding newly created items
        private void OverrideStackSizes(IStackSizeConfig config, IEnumerable<Item> locals)
        {
            foreach (var i in locals)
            {
                // Check for the items in the stack size list
                var element = config.StackSizes.SingleOrDefault(x => x.ItemName == i.DisplayName);
                if (element == null) continue;

                // Get the stacksize attribute and override it.
                var mss = ItemAttribute.Get<MaxStackSizeAttribute>(i.Type);

                // currently we only change items that have a MaxStackSizeAttribute
                if (mss != null)
                    mss.GetType().GetProperty("MaxStackSize", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(mss, element.StackSize);
            }
        }
    }
}