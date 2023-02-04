using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.Arches
{
    class ArchesBase : IModKitPlugin
    {
        public const string version = "2.0.0";
        public const string packName = "Arches Version: ";
        public const string application = "[Elixr Mods]: ";

        public string GetStatus()
        {
            return "Loaded and ready for support..";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM - Arches");
        }
    }
}
