using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.CustomisedRequests
{
    public class EMSpawnCycler : IModKitPlugin, IInitializablePlugin
    {
        //Only Change this to your world generator settings, ie if 72, 72 just put 72, or 200, 200 just put 200
        public int worldDimensions = 72;

        // Don't touch anything below
        List<User> newUsers = new();
        public void Initialize(TimedTask timer) 
        {
            if (!UserManager.Config.UseExactSpawnLocation) { UserManager.Config.UseExactSpawnLocation = true; UserManager.Obj.SaveConfigAsync(); }

            UserManager.NewUserJoinedEvent.Add(u =>
            {
                newUsers.Add(u);
            });

            UserManager.OnUserLoggedIn.Add(u => {
                if (newUsers.Contains(u))
                {
                    var rnd = new Random();
                    Vector3 spawnpost = new(rnd.Range(0, worldDimensions * 10 - 1), rnd.Range(60, 75), rnd.Range(0, worldDimensions * 10 - 1));
                    Log.WriteErrorLineLocStr($"{spawnpost}");
                    u.Player.SetPosition(spawnpost);
                    newUsers.Remove(u);
                }
            });
        }


        public string GetStatus() => Localizer.DoStr($"World spawns being rotated");
        public string GetCategory() => "";
    }
}