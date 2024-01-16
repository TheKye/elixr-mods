using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
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