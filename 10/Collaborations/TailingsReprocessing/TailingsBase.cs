using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.Tailings
{
    class TailingsBase : IInitializablePlugin
    {
        public const string version = "2.1.0";
        public const string packName = "Tailings Reprocessing Version:";
        public const string application = "[Elixr Mods]:";

        public string GetStatus()
        {
            return "Loaded and helping the enviroment..";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM - Tailings Reprocessing");
        }

        public void Initialize(TimedTask timer)
        {
            Log.WriteErrorLineLocStr(Localizer.DoStr($"{application} {packName} {version}"));
        }

        public string GetCategory()
        {
            throw new NotImplementedException();
        }
    }
}
