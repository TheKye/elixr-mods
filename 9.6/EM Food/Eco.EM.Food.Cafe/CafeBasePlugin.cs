using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.Animals;
using Eco.Mods.TechTree;
using Eco.Shared.Math;
using Eco.Simulation.Types;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Eco.Mods.TechTree.Turkey;
using static Eco.Mods.TechTree.MountainGoat;
using Eco.Mods.Organisms;
using static Eco.Mods.Organisms.Beans;

namespace Eco.EM.Food.Cafe
{
    public class CafeBasePlugin : IModKitPlugin, IModInit
    {
        public string GetStatus()
        {
            return "EM Cafe - New Items to animals";
        }

        public static void Initialize()
        {
            var bindings = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic;
            var turkeySpecies = typeof(Turkey).GetField("species", bindings).GetValue(typeof(Turkey)) as TurkeySpecies;
            var list = turkeySpecies.GetType().GetProperty("ResourceList", bindings).GetValue(turkeySpecies) as List<SpeciesResource>;
            list.Add(new SpeciesResource(typeof(TurkeyEggItem), new Range(1, 1), 1f));

            var goatSpecies = typeof(MountainGoat).GetField("species", bindings).GetValue(typeof(MountainGoat)) as MountainGoatSpecies;
            var glist = goatSpecies.GetType().GetProperty("ResourceList", bindings).GetValue(goatSpecies) as List<SpeciesResource>;
            glist.Add(new SpeciesResource(typeof(GoatMilkItem), new Range(1, 1), 1f));

            var beanSpecies = typeof(Beans).GetField("species", bindings).GetValue(typeof(Beans)) as BeansSpecies;
            var blist = beanSpecies.GetType().GetProperty("ResourceList", bindings).GetValue(beanSpecies) as List<SpeciesResource>;
            blist.Add(new SpeciesResource(typeof(CoffeeBeanItem), new Range(1, 1), 0.4f));

            ConsoleColors.PrintConsoleMultiColored("[EM Cafe]", System.ConsoleColor.Magenta, " Adding New Items to animals and plants.", System.ConsoleColor.White);

        }

        public override string ToString() => "EM Cafe";

        public string GetCategory() => "Food";
    }
}