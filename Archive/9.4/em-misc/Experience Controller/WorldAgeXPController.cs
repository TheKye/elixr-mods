using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Utils;
using Eco.Simulation;
using Eco.Simulation.Time;
using System;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Admin
{
	public class WorldAgeXPController : IModKitPlugin, IInitializablePlugin, IChatCommandHandler
	{
		public void SetInitialXP(User u)
		{
			float currentWorldTime = (float)WorldTime.Seconds * EcoSim.Obj.EcoDef.TimeMult;
			float initXP = u.UserXP.SkillRate * currentWorldTime / (float)TimeUtil.DaysToSeconds(1);
			u.UserXP.AddExperience(initXP);
		}

		public void Initialize(TimedTask timer)
		{
			// Checks for first Login by User and does stuff.
			UserManager.OnNewUserJoined.Add(u => { if (u.SlgId != "DiscordLinkSlg" || u.SlgId != "1234") SetInitialXP(u); });
		}

		public string GetStatus() => String.Empty;
	}
}