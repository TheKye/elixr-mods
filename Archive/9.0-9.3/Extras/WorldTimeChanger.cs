using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using Eco.Simulation.Time;
using System;
using System.Reflection;

namespace Eco.EM.Admin.WorldTimeChanger
{
    public class WorldTimeCommands : IChatCommandHandler
    {
        [ChatCommand("Sets The Worlds Date To Selected Day, You can also specify true or false to grant accumulated xp if you choose to advance the time", ChatAuthorizationLevel.Admin)]
        public static void SetDayTime(User user, int day = 0, bool grantXp = false)
        {
            WorldTime.Reset();
            Log.WriteWarningLineLocStr("World Time Reset");
            double newtime = TimeUtil.DaysToSeconds(day);
            if (grantXp)
                WorldTime.ForceAdvanceTime(newtime);
            else
            {
                double fakeStartTime = TimeUtil.Seconds - newtime;
                WorldTime.Obj.GetType().GetField("realTimeAtLoad", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).SetValue(WorldTime.Obj, fakeStartTime);
            }
            WorldTime.TimeChanged();
            Log.WriteWarningLineLocStr($"World Time Set To Day: {day}");
            user.OKBoxLoc($"World Time was Reset: It is now Day {day}");

        }
    }
}