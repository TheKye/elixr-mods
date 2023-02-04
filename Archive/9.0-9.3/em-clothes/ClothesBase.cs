using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.Clothing
{
    class ClothesBase : IInitializablePlugin, IModKitPlugin
    {
        public const string version = "2.0.0";
        public const string packName = "Clothes Version:";
        public const string application = "[Elixr Mods]:";

        public string GetStatus()
        {
            return "Loaded and getting dressed..";
        }

        public void Initialize(TimedTask timer)
        {
            Log.WriteErrorLineLocStr(Localizer.DoStr($"{application} {packName} {version}"));
        }
    }
}
