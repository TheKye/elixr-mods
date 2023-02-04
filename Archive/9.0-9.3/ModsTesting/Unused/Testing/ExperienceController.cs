using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Chat;
using System;
using System.Reflection;
using System.Text;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Admin
{
	public class ExperienceController : IModKitPlugin, IInitializablePlugin, IChatCommandHandler
	{
		// CHANGE THIS IF REQUIRED :: The stars you want new players to start with
		public int startingStars = 1;

		// CHANGE THIS IF REQUIRED :: 
		// DO NOT change the the first 0 (level 0).
		// These are the xp milestones BEFORE difficulty (Collaboration). High collaboration will double these, Low collaboration will halve.
		// To set to 0 stars for new players change the the xp required for level 1 and ensure starting stars is 0.
		// The XP progression for new stars              { 0, 1, 2,  3,  4,   5,   6 ,  7,   8    }
		public static readonly int[] newSpecialtyCosts = { 0, 0, 20, 50, 100, 200, 400, 800, 1600 };


		// Don't change anything below.
		private float Multiplier => DifficultySettings.Obj.Config.DifficultyModifiers.SpecialtyCostMultiplier;

		private int BonusXP => GetBonusXP(startingStars);

		[ChatCommand("XP level related commands")]
		public static void XPCosts() { }

		[ChatSubCommand("XpCosts", "Display the cost in xp of your next level up", "nextXP", ChatAuthorizationLevel.User)]
		public static void GetNextCost(User user)
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"The current difficulty multiplier is {DifficultySettings.Obj.Config.DifficultyModifiers.SpecialtyCostMultiplier} ");
			sb.AppendLine($"Current costs modified for difficulty: ");

			for (int i = 1; i < Skillset.SpecialtyCosts.Length; i++)
			{
				sb.AppendLine($"Level {i} = {Skillset.SpecialtyCosts[i] * DifficultySettings.Obj.Config.DifficultyModifiers.SpecialtyCostMultiplier}.");
			}

			sb.AppendLine();
			sb.AppendLine($"Your current player XP is at {Math.Round(user.XP,2)}");
			sb.AppendLine($"You're next level will be at {user.Skillset.SpecialtyCost}");

			user.Player.InfoBoxLocStr($"{sb}");
		}

		// Loop through the SkillSet array progressively adding the xp we need to buiuld to the stars required.
		private int GetBonusXP(int startingStars)
		{
			var xpReq = 0;

			if (startingStars < 1)
				return 0;

			for (int i = 1; i <= startingStars; i++)
			{
				xpReq += Skillset.SpecialtyCosts[Math.Clamp(i, 1, Skillset.SpecialtyCosts.Length - 1)];
			}

			return xpReq;
		}

		public void Initialize(TimedTask timer)
		{
			typeof(Skillset).GetField("SpecialtyCosts", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public).SetValue(null, newSpecialtyCosts);

			// Checks for first Login by User and does stuff.
			UserManager.OnNewUserJoined.Add(u =>
			{
				u.UseXP(-(BonusXP * Multiplier));
			});
		}

		public string GetStatus() => String.Empty;
	}
}