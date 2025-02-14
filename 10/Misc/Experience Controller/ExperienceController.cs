﻿using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Time;
using Eco.Shared.Utils;
using Eco.Simulation;
using Eco.Simulation.Time;
using System;
using System.Text;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.ModKit
{
    public class SpecialStarController : IModKitPlugin, IInitializablePlugin
    {
        public void Initialize(TimedTask timer)
        {
            //fix invoke method
            foreach (var user in UserManager.Users)
            {
                user.Skillset.OnSkillLevelChanged.Add(sk =>
                {
                    // Check if the player already has gathering, logging, or mining skill
                    if (!user.Skillset.HasSkill(typeof(GatheringSkill)) && !user.Skillset.HasSkill(typeof(LoggingSkill)) && !user.Skillset.HasSkill(typeof(MiningSkill)))

                        if (sk.GetType() == typeof(GatheringSkill) || sk.GetType() == typeof(LoggingSkill) || sk.GetType() == typeof(MiningSkill))
                        {
                            // Grant an additional star
                            user.UserXP.StarsAvailable ++;
                            
                            // Notify the player
                            user.Player.MsgLocStr($"Congratulations! You have earned an additional star for choosing {sk.Name} as your first skill.");

                        }
                });
            }

        }

        public string GetStatus() => String.Empty;

        public string GetCategory() => "";
    }
}

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.Admin
{
    [ChatCommandHandler]
    public class ExperienceController : IModKitPlugin, IInitializablePlugin
    {
        // CHANGE THIS IF REQUIRED :: The stars you want new players to start with
        public int startingStars = 1;
        public bool AdjustAsWorldAges = true;
        public bool AdjustAfterInitialBonusApplied = true;

        // CHANGE THIS IF REQUIRED :: 
        // These are the xp milestones BEFORE difficulty (Collaboration). High collaboration will double these, Low collaboration will halve.
        // To set to 0 stars for new players change the the xp required for level 1 and ensure starting stars is 0.
        // The XP progression for new stars              { 1,  2,  3,   4,   5,	  6 ,  7,   }
        public static readonly int[] newSpecialtyCosts = [20, 50, 100, 200, 400, 800, 1600];


        // Don't change anything below.
        private float Multiplier => DifficultySettings.Obj.Config.GameSettings.AdvancedGameSettings.SkillCostMultiplier;

        [ChatCommand("XP level related commands")]
        public static void XPCosts() { }

        [ChatSubCommand("XpCosts", "Display the cost in xp of your next level up", "nextXP", ChatAuthorizationLevel.User)]
        public static void GetNextCost(User user)
        {
            StringBuilder sb = new();

            sb.AppendLine($"The current difficulty multiplier is {DifficultySettings.Obj.Config.GameSettings.AdvancedGameSettings.SkillCostMultiplier} ");
            sb.AppendLine($"Current costs modified for difficulty: ");

            for (int i = 1; i < SkillManager.Settings.LevelUps.Length; i++)
            {
                sb.AppendLine($"Level {i} = {SkillManager.Settings.LevelUps[i] * DifficultySettings.Obj.Config.GameSettings.AdvancedGameSettings.SkillCostMultiplier}.");
            }

            sb.AppendLine();
            sb.AppendLine($"Your current player XP is at {Math.Round(user.UserXP.XP, 2)}");
            sb.AppendLine($"You're next level will be at {user.UserXP.NextStarCost}");

            user.Player.InfoBoxLocStr($"{sb}");
        }

        public void SetInitialXP(User u)
        {
            float currentWorldTime = (float)WorldTime.Seconds * EcoSim.Obj.EcoDef.TimeMult;
            float initXP = u.UserXP.SkillRate * currentWorldTime / (float)TimeUtil.DaysToSeconds(1);
            u.UserXP.AddExperience(initXP);
        }

        public void Initialize(TimedTask timer)
        {
            SkillManager.Settings.LevelUps = newSpecialtyCosts;

            // Checks for first Login by User and does stuff.
            UserManager.NewUserJoinedEvent.Add(u =>
            {
                if (u.StrangeId != "DiscordLinkSlg")
                {
                    // Set the initial XP of new users joining based on BASE XP if toggled and the benefit is not accumulative.
                    if (AdjustAsWorldAges && !AdjustAfterInitialBonusApplied) SetInitialXP(u);

                    // Set the stars of the new player based on the defined star benefit.
                    while (u.UserXP.TotalStarsEarned < startingStars - 1) { u.UserXP.AddExperience(u.UserXP.NextStarCost); }

                    // Adds the XP of new users joining based on BASE XP if toggled and the benefit is accumulative.
                    if (AdjustAsWorldAges && AdjustAfterInitialBonusApplied) SetInitialXP(u);
                }
            });
        }

        public string GetStatus() => String.Empty;

        public string GetCategory() => "";
    }
}