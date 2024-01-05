#define EM_Artistry
using Eco.Core.Controller;
using Eco.Core.Items;
using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Systems;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Interactions.Interactors;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Mods.Organisms;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.SharedTypes;
using Eco.Shared.Utils;
using Eco.Shared.View;
using Eco.Simulation.Types;
using Eco.Simulation;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Eco.Shared.Math;

namespace Eco.EM.Artistry
{
    class ArtistryBase : IInitializablePlugin, IModKitPlugin
    {

        public string GetStatus()
        {
            return "Loaded and getting creative..";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM Artistry");
        }

        /// <summary>
        /// Apply the new skills to each person who logs into the server if they do not have it.
        /// This is required to have the UI add the profession correctly also.
        /// </summary>
        public void Initialize(TimedTask timer)
        {/*
            UserManager.OnUserLoggedIn.Add(u =>
            {
                if (!u.Skillset.HasSkill(typeof(ArtistSkill)))
                    u.Skillset.LearnSkill(typeof(ArtistSkill));
            });
        */
            EcopediaGenerator.GenerateEcopediaPageFromFile("ModDocumentation;EM Artistry.xml", "Eco.EM.Artistry.Ecopedia", "Elixr Mods");
            EcopediaGenerator.GenerateEcopediaPageFromFile("ModDocumentation;EM Artistry;Painting.xml", "Eco.EM.Artistry.Ecopedia", "Elixr Mods");
        }

        public string GetCategory() => "Elixr Mods";
    }
}