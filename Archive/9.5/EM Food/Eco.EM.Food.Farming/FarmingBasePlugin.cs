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
using static Eco.Mods.TechTree.BighornSheep;
using static Eco.Mods.TechTree.Bison;
using static Eco.Mods.TechTree.MountainGoat;
using static Eco.Mods.TechTree.Turkey;

namespace Eco.EM.Food.Farming
{
    public class FarmingBasePlugin : IModKitPlugin, IModInit
    {
        public string GetStatus()
        {
            return "EM Farming - Adding Baby Animals to The Big Animals";
        }

        public static void Initialize()
        {
            var bindings = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic;

            var bisonSpecies = typeof(Bison).GetField("species", bindings).GetValue(typeof(Bison)) as BisonSpecies;
            var list = bisonSpecies.GetType().GetProperty("ResourceList", bindings).GetValue(bisonSpecies) as List<SpeciesResource>;
            list.Add(new SpeciesResource(typeof(BabyBisonItem), new Range(1, 1), 0.01f));

            var mGoatSpecies = typeof(MountainGoat).GetField("species", bindings).GetValue(typeof(MountainGoat)) as MountainGoatSpecies;
            var mlist = mGoatSpecies.GetType().GetProperty("ResourceList", bindings).GetValue(mGoatSpecies) as List<SpeciesResource>;
            mlist.Add(new SpeciesResource(typeof(BabyMountainGoatItem), new Range(1, 1), 0.01f));

            var bHornSpecies = typeof(BighornSheep).GetField("species", bindings).GetValue(typeof(BighornSheep)) as BighornSheepSpecies;
            var bHornList = bHornSpecies.GetType().GetProperty("ResourceList", bindings).GetValue(bHornSpecies) as List<SpeciesResource>;
            bHornList.Add(new SpeciesResource(typeof(BabyBighornSheepItem), new Range(1, 1), 0.01f));

            var turkeySpecies = typeof(Turkey).GetField("species", bindings).GetValue(typeof(Turkey)) as TurkeySpecies;
            var turkeyList = turkeySpecies.GetType().GetProperty("ResourceList", bindings).GetValue(turkeySpecies) as List<SpeciesResource>;
            turkeyList.Add(new SpeciesResource(typeof(EggItem), new Range(1, 3), 0.1f));

            ConsoleColors.PrintConsoleMultiColored("[EM Farming]", System.ConsoleColor.Magenta, " Added Baby Animals: Bison, Mountain Goat, Bighorn Sheep", System.ConsoleColor.White);

        }

        public override string ToString() => "EM Farming";
    }
}