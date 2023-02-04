using Eco.Core.Plugins.Interfaces;
using Eco.Core.Serialization;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.CustomisedRequests
{
    public class EMSpawnCycler : IModKitPlugin, IInitializablePlugin
    {
        private const string _configFile = "/SpawnConfig.json";
        private const string saveLocation = "/Configs/Mods/EM/SpawnCycler";

        public static string AssemblyLocation => Directory.GetCurrentDirectory();
        public static string SaveLocation => AssemblyLocation + saveLocation;

        public static SpawnConfig Config { get; set; }

        public EMSpawnCycler()
        {
            if (!Directory.Exists(SaveLocation)) Directory.CreateDirectory(SaveLocation);

            if (!File.Exists(SaveLocation + _configFile))   { Config = new SpawnConfig(); SaveConfig(); }
            else                                            { Config = LoadConfig(); }
        }
        
        public string GetStatus() => Localizer.DoStr($"World spawns being rotated");
        public void Initialize(TimedTask timer) 
        {
            if (!UserManager.Config.UseExactSpawnLocation) { UserManager.Config.UseExactSpawnLocation = true; UserManager.Obj.SaveConfigAsync(); }

            if (Config.Points.Count() == 0)
            { Config.Points.Add(new SpawnPoint() { PointName = "Original Spawn", Location = UserManager.Config.SpawnLocation }); SaveConfig(); }

            UserManager.OnNewUserJoined.Add(u => Config.CycleWorldSpawn());
        }

        public static SpawnConfig LoadConfig()
        {
            var stringContent = string.Empty;
            using (var file = new StreamReader(SaveLocation + _configFile))
            {
                stringContent = file.ReadToEnd();
                file.Close();
                file.Dispose();
            }

            if (string.IsNullOrWhiteSpace(stringContent))   { return new SpawnConfig(); }
            else                                            { return SerializationUtils.DeserializeJson<SpawnConfig>(stringContent); }
        }

        public static void SaveConfig() 
        {
            try
            {
                var stringContent = SerializationUtils.SerializeJson(Config, true);
                using var file = new StreamWriter(SaveLocation + _configFile);
                file.Write(stringContent);
            }
            catch (Exception e)
            {
                Log.WriteErrorLine(Localizer.DoStr("Unable to save the configuration file for spawn cycler. Please consult EM Development Team."));
                Log.WriteErrorLine(Localizer.DoStr($"Error: {e.Message}"));
            }
        }
    }

    public class SpawnConfig
    {
        public bool cycle = true;
        public int NextPointPosition { get; set; } = 0;
        public List<SpawnPoint> Points { get; set; } = new List<SpawnPoint>();

        public void CycleWorldSpawn() { if (cycle) UpdateSpawnConfig(NextSpawnLocation().Location); }

        public void UpdateSpawnConfig(Vector3i location)
        {
            UserManager.Config.SpawnLocation = location;
            UserManager.Obj.SaveConfigAsync();
        }

        public SpawnPoint CurrentSpawnLocation() => Points[NextPointPosition];

        public SpawnPoint NextSpawnLocation()
        {
            if (++NextPointPosition >= Points.Count()) NextPointPosition = 0; // Ensure no index out of bounds
            Save();
            return Points[NextPointPosition];
        }

        public int SetSpawnLocation(string pointName)
        {
            var point = Points.FindIndex(p => p.PointName == pointName);
            if (point != -1) 
            { 
                NextPointPosition = point; 
                Save();
                UpdateSpawnConfig(Points[NextPointPosition].Location);
            }          
            return point;
        }

        public void Toggle() { cycle = !cycle; Save(); }

        public void Save() => EMSpawnCycler.SaveConfig();
    }

    public class SpwanCyclerCommands : IChatCommandHandler
    {
        public static SpawnConfig obj = EMSpawnCycler.Config;

        [ChatCommand("Elixr Mods Spawn Cycler Plugin", ChatAuthorizationLevel.Admin)]
        public static void WorldSpawn() { }

        [ChatSubCommand("WorldSpawn", "List all the current world spawn points.", "ws-list", ChatAuthorizationLevel.Admin)]
        public static void List(User user)
        {
            var point = obj.CurrentSpawnLocation();
            StringBuilder sb = new StringBuilder();
            foreach (var p in obj.Points) sb.AppendLine(string.Format("{0}{1}: {2}{3}", p == point? "<color=green>" : "", p.PointName, p.Location, p == point? "</color>" : ""));
            user.Player.OpenCustomPanel(Localizer.DoStr("World Spawns"), sb.ToString(), "SpawnInfo");
        }

        [ChatSubCommand("WorldSpawn", "Adds a new point to the cycle list.", "ws-add", ChatAuthorizationLevel.Admin)]
        public static void Add(User user, string pointName)
        {
            var santizedPointName = pointName.TrimStart(' ').TrimEnd(' ');

            if (obj.Points.Any(point => point.PointName == santizedPointName)) { user.Player.MsgLocStr(string.Format("Point with name {0} already exists", santizedPointName)); return; }
            if (obj.Points.Any(point => point.Location == user.Position)) { user.Player.MsgLocStr(string.Format("Point with location {0} already exists", user.Position)); return; }

            var newPoint = new SpawnPoint() { PointName = santizedPointName, Location = (Vector3i)user.Position };
            obj.Points.Add(newPoint);
            obj.Save();
            user.Player.MsgLocStr(string.Format("Point {0} with location {1} has been added to the end of the list", newPoint.PointName, newPoint.Location));
        }

        [ChatSubCommand("WorldSpawn", "Removes a specific point from the cycle list.", "ws-rem", ChatAuthorizationLevel.Admin)]
        public static void Remove(User user, string pointName)
        {
            var santizedPointName = pointName.TrimStart(' ').TrimEnd(' ');
            var point = obj.Points.FirstOrDefault(x => x.PointName == santizedPointName);

            if (point == null)              { user.Player.MsgLocStr(string.Format("Point with name {0} does not exist exists, check name and try again", santizedPointName));           return; }
            if (obj.CurrentSpawnLocation() == point) Skip(user);
            if (!obj.Points.Remove(point))  { user.Player.MsgLocStr(string.Format("Point with name {0} could not be removed, Please consult EM Development Team.", santizedPointName)); return; }         
            user.Player.MsgLocStr(string.Format("Point with name {0} removed from cycle list", santizedPointName));               
        }

        [ChatSubCommand("WorldSpawn", "Checks the name and location of the next spawn point", "ws-check", ChatAuthorizationLevel.Admin)]
        public static void Check(User user)
        {
            var point = obj.CurrentSpawnLocation();
            user.Player.MsgLocStr(string.Format("The next spawn location is {0} located at {1}",
                    point.PointName,
                    point.Location
                    ),
                Shared.Services.MessageCategory.Chat);
        }

        [ChatSubCommand("WorldSpawn", "Skips to the next spawn point in the cycle list.", "ws-skip", ChatAuthorizationLevel.Admin)]
        public static void Skip(User user)
        {
            obj.UpdateSpawnConfig(obj.NextSpawnLocation().Location);
            Check(user);
        }

        [ChatSubCommand("WorldSpawn", "Sets the next spawn point to a specific named point", "ws-set", ChatAuthorizationLevel.Admin)]
        public static void Set(User user, string pointName)
        {
            var point = obj.SetSpawnLocation(pointName);
            if (point == -1) user.Player.MsgLocStr(string.Format("Unable to find point {0} in cycle list.", pointName), Shared.Services.MessageCategory.Chat);
            else Check(user);
        }

        [ChatSubCommand("WorldSpawn", "Toggles if world spawn cycling should occur", "ws-toggle", ChatAuthorizationLevel.Admin)]
        public static void Toggle(User user)
        {
            obj.Toggle();
            user.Player.MsgLocStr(string.Format("World spawns are {0}cycling.", obj.cycle? "" : "not "), Shared.Services.MessageCategory.Chat);
        }
    }

    public class SpawnPoint
    {
        public string PointName { get; set; }
        public Vector3i Location { get; set; }
    }
}