

namespace Eco.EM.Warp
{
    using Eco.EM.Helpers;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using System;
    using System.Linq;
    using Eco.EM;
    public class WarpCommands : IChatCommandHandler
    {
        public const string appName = "<color=purple>[Elixr Mods]:</color> ";
        private static bool loaded = false;

        private const char Delimeter = '|';
        private static WarpConfig config = new WarpConfig();
        private static string Filename = "Warp.EM";

        private static void Load()
        {
            if (!loaded)
            {
                config = FileManager<WarpConfig>.ReadFromFile(Base.SaveLocation, Filename);
                loaded = true;
            }
        }

        public static void WarpReload()
        {
            if (loaded)
            {
                loaded = false;
                config = FileManager<WarpConfig>.ReadFromFile(Base.SaveLocation, Filename);
                loaded = true;
            }
        }
        private static void Save()
        {
            FileManager<WarpConfig>.WriteToFile(config, Base.SaveLocation, Filename);
        }

        [ChatCommand("Warp to specified named warp", "warp")]
        public static void Warp(User user, string Name)
        {
            if (!config.Enable) return;

            Load();

            if (string.IsNullOrWhiteSpace(Name))
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr(appName + "Error: You must specify where you want to warp to."), user));
                return;
            }

            if (config.Warps.Count(w => Compare.IsLike(w.Name, Name)) == 0)
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr(appName + "Error: A warp with this name does not exist"), user));
                return;
            }

            if (config.CalorieCost > 0 && user.Stomach.Calories < config.CalorieCost)
            {
                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Error: You are too hungry to warp (You need {0} calories)"), config.CalorieCost), user));
                return;
            }

            var lastWarp = config.Logs.Where(l => l.UserID == Base.WhoAmI(user)).LastOrDefault();
            if (lastWarp != null)
            {
                var CoolDownStop = DateTime.Parse(lastWarp.Timestamp).AddSeconds(config.Cooldown);

                if (CoolDownStop > DateTime.Now)
                {
                    var timespanleft = CoolDownStop.Subtract(DateTime.Now);
                    var timeleft = timespanleft.ToString(@"mm\:ss");

                    string localizedmessage = Localizer.DoStr(appName + $"Error: Warping is on cooldown.");
                    localizedmessage += $" ({timeleft})";
                    ChatBase.Send(new ChatBase.Message(localizedmessage, user));
                    return;
                }
            }

            var warp = config.Warps.Where(w => Compare.IsLike(w.Name, Name)).FirstOrDefault();

            var locationParts = warp.Location.Split(Delimeter);
            var location = new Vector3(
                float.Parse(locationParts[0]),
                float.Parse(locationParts[1]),
                float.Parse(locationParts[2])
            );

            user.Stomach.BurnCalories(config.CalorieCost);
            user.Player.SetPosition(location);

            config.Logs.Add(new WarpLog()
            {
                Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                UserID = Base.WhoAmI(user),
                WarpedTo = warp.Name
            });

            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "You have been warped to {0}"), warp.Name), user));

            Save();
        }

        [ChatCommand( "Add the specified warp to list at current position", "warp-add",ChatAuthorizationLevel.Admin)]
        public static void WarpAdd(User user, string Name)
        {
            if (!config.Enable) return;

            Load();

            if (string.IsNullOrWhiteSpace(Name))
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr(appName + "Error: You must specify a name for this warp"), user));
                return;
            }

            if (config.Warps.Count(w => Compare.IsLike(w.Name, Name)) > 0)
            {
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr(appName + "Error: A warp with this name already exist"), user));
                return;
            }

            config.Warps.Add(new Warp()
            {
                Name = Name,
                Location = string.Join(Delimeter.ToString(), new string[3] {
                    user.Position.x.ToString(),
                    user.Position.y.ToString(),
                    user.Position.z.ToString()
                })
            });

            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "{0} was added to the list of warps"), Name), user));

            Save();
        }

        [ChatCommand( "Remove the specified warp name from the list", "warp-remove", ChatAuthorizationLevel.Admin)]
        public static void WarpRemove(User user, string Name)
        {
            if (!config.Enable) return;

            Load();

            try
            {
                if (config.Warps.Count(w => Compare.IsLike(w.Name, Name)) == 0)
                {
                    ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Error: {0} does not exist in warps list"), Name), user));
                    return;
                }

                config.Warps.Remove(config.Warps.Where(w => Compare.IsLike(w.Name, Name)).FirstOrDefault());
                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "{0} was removed from the list of warps"), Name), user));

                Save();
            }
            catch (Exception)
            {
                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Error: An error occured while trying to remove warp \"{0}\""), Name), user));
                return;
            }
        }

        [ChatCommand( "Toggle this feature on or off", "warp-toggle",ChatAuthorizationLevel.Admin)]
        public static void WarpToggle(User user)
        {
            config.Enable = !config.Enable;
            ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Warp has been {0}"), Localizer.DoStr((config.Enable ? "Enabled" : "Disabled")))));
            Save();
        }

        [ChatCommand("Adjust the warp cooldown.", "warp-cooldown",ChatAuthorizationLevel.Admin)]
        public static void WarpCooldown(User user, int Seconds)
        {
            if (!config.Enable) return;

            config.Cooldown = Seconds;
            if (Seconds == 0)
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr(appName + $"Cooldown has been disabled on warps")));
            else
                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Cooldown on warps has been set to {0} seconds"), Seconds)));
            Save();
        }

        [ChatCommand("Adjust the warp calorie cost.", "warp-cost", ChatAuthorizationLevel.Admin)]
        public static void WarpCost(User user, int CalorieCost)
        {
            if (!config.Enable) return;

            config.CalorieCost = CalorieCost;
            if (CalorieCost == 0)
                ChatBase.Send(new ChatBase.Message(Localizer.DoStr(appName + $"Warping is now set to free!")));
            else
                ChatBase.Send(new ChatBase.Message(string.Format(Localizer.DoStr(appName + "Warping is now consuming {0} Calories per use."), CalorieCost)));
            Save();
        }

        [ChatCommand("List all available warps.", "warp-list")]
        public static void WarpList(User user)
        {
            if (!config.Enable) return;

            Load();

            var text = string.Empty;
            if (config.Warps.Count == 0)
                text = Localizer.DoStr(appName + "No warps has been set by admins yet.");
            else
                foreach (var warp in config.Warps)
                {
                    var locationParts = warp.Location.Split('|');
                    Vector3 location = new Vector3(
                        float.Parse(locationParts[0]),
                        float.Parse(locationParts[1]),
                        float.Parse(locationParts[2])
                    );

                    text += $"{warp.Name}   {location.x},{location.y},{location.z}\n";
                }

            user.Player.OpenInfoPanel(Localizer.DoStr("Warp Locations"), text);
        }
        [ChatCommand("Reload Warp Config", "warp-reload",  ChatAuthorizationLevel.Admin)]
        public static void WarpReload(User user)
        {
            WarpReload();
            ChatBase.Send(new ChatBase.Message(Localizer.DoStr(appName + "Warp Configs Reloaded"), user));
        }
    }
}
