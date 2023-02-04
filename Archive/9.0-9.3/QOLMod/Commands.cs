using Eco.Core.Controller;
using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.EM.Framework.Groups;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.UI;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Group = Eco.EM.Framework.Groups.Group;

namespace Eco.EM.QOL
{
    public class Commands : IChatCommandHandler
    {
        public static readonly List<Item> allSkillsAsItem = Skill.AllItems.Where(i => i.Group == "Skills").ToList();

        [ChatCommand("Elixr Mods And NID Mods QOL Plugin", ChatAuthorizationLevel.Admin)]
        public static void QOL() { }

        [ChatSubCommand("QOL", "Configures a setting in the QOL config. Settings: max-talents, max-skills", "qol-config", ChatAuthorizationLevel.Admin)]
        public static void ConfigureQOL(User user, string setting, int value)
        {
            setting = Base.Sanitize(setting);

            if (!QOLManager.Config.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Base.appName + $"{setting} is not a valid configuration option. Please use: Max, Cost, Expiry or Cooldown", user);
                return;
            }

            switch (setting)
            {
                case "max-talents":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>QOL Max Talent Reset</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                case "max-skills":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>QOL Max Skills Reset</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Base.appName + $"QOLation {setting} has been set to {value}.", user);
                    break;
            }

            QOLManager.SaveConfig();
        }

        [ChatSubCommand("QOL", "Configures a setting a groups QOL config. Settings: max-talents, max-skills.", "qol-grpconfig", ChatAuthorizationLevel.Admin)]
        public static void GroupConfigureQOL(User user, string groupName, string setting, int value)
        {
            setting = Base.Sanitize(setting);

            Group group = GroupsManager.API.GetGroup(groupName);

            if (group == null)
            {
                ChatBaseExtended.CBError(Base.appName + $"{groupName} could not be found.", user);
                return;
            }

            var groupConfig = group.Permissions.Find(p => p.Identifier == QOLManager.ID) as QOLConfig;

            if (groupConfig == null)
            {
                groupConfig = QOLManager.Config.DeepCopy();
                group.AddPermission(groupConfig);
            }

            if (setting == "max-talents" && value < QOLManager.Config.MaxTalents && value != 0)
            {
                ChatBaseExtended.CBError(Base.appName + $"Groups cannot have a smaller maximum value than the serverwide maximum {QOLManager.Config.MaxTalents}. Reduce the serverwide maximum first.", user);
                return;
            }

            if (setting == "max-skills" && value < QOLManager.Config.MaxSkills && value != 0)
            {
                ChatBaseExtended.CBError(Base.appName + $"Groups cannot have a smaller maximum value than the serverwide maximum {QOLManager.Config.MaxSkills}. Reduce the serverwide maximum first.", user);
                return;
            }

            if (!groupConfig.UpdateConfig(setting, value))
            {
                ChatBaseExtended.CBError(Base.appName + $"{setting} is not a valid configuration option.", user);
                return;
            }

            switch (setting)
            {
                case "max-talents":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>QOL Max Talent Reset</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                case "max-skills":
                    ChatBaseExtended.CBInfoBox(Base.appName + $"<color=yellow>QOL Max Skills Reset</color> has been changed to <color=green>{value}</color>.", user);
                    break;
                default:
                    ChatBaseExtended.CBInfoBox(Base.appName + $"QOL {setting} for {group.GroupName} has been set to {value}.", user);
                    break;
            }

            GroupsManager.API.SaveData();
        }

        [ChatSubCommand("QOL", "Unlearns specific talent.", "talent-reset", ChatAuthorizationLevel.Admin)]
        public static void TalentUnlearn(User user, string talentName)
        {
            talentName = SanitizeSkillTalent(talentName);
            DateTime check = DateTime.Now;
            QOLManager.Data.ResetSkills(check);

            var userData = QOLManager.Data.GetQOLUserData(user.Name);
            if (userData.MaxTalentsUsed >= QOLManager.Data.GetMaxTalents(user))
            {
                ChatBaseExtended.CBError(Base.appName + $"You have exhausted all your talent resets today.", user);
                return;
            }

            if (user.Talentset.Talents.Count > 0)
            {
                Type targetTalent = GetUserTalent(user, talentName);
                if (targetTalent != null)
                {
                    if (user.Talentset.HasTalent(targetTalent))
                    {
                        user.Talentset.ClearTalent(targetTalent);
                        userData.UseTalents();
                        QOLManager.SaveData();
                        ChatBaseExtended.CBOkBox($"You Have Reset Your Talent {talentName}, you Have {QOLManager.Config.MaxTalents - userData.MaxTalentsUsed}", user);
                        Log.WriteLine(Localizer.DoStr($"{user.Name} Reset Their Talent: {talentName}"));
                        return;
                    }
                    else
                    {
                        ChatBaseExtended.CBError(Base.appName + $"You Don't Have Talent", user);
                        return;
                    }
                }
                else
                {
                    ChatBaseExtended.CBError(Base.appName + $"Can't Find that talent.", user);
                    return;
                }
            }
            else
            {
                ChatBaseExtended.CBError(Base.appName + $"You have no Talents to reset", user);
                return;
            }

        }

        [ChatSubCommand("QOL", "Resets profession (skill) to unlearnt state.", "skill-reset", ChatAuthorizationLevel.Admin)]
        public static void SkillReset(User user, string skillName)
        {
            DateTime check = DateTime.Now;
            QOLManager.Data.ResetSkills(check);

            var userData = QOLManager.Data.GetQOLUserData(user.Name);
            if (userData.MaxSkillsUsed >= QOLManager.Data.GetMaxSkills(user))
            {
                ChatBaseExtended.CBError(Base.appName + $"You have exhausted all your talent resets today.", user); // Add the time remaining here??
                return;
            }

            string skillPrepped = SanitizeSkillTalent(skillName);
            Skillset skillset = user.Skillset;
            Talentset talentset = user.Talentset;
            bool exists = ExistsSkill(skillPrepped);

            if (exists)
            {
                if (!IsMultipleNotLiteralSkill(skillPrepped))
                {
                    Type targetSkillType = GetMatchSkillAsType(skillPrepped);
                    Skill targetSkill = GetSkillInSkillSet(targetSkillType, skillset);

                    if (targetSkill != null)
                    {
                        if (IsRootSkill(targetSkill))
                        {
                            ChatBaseExtended.CBError(Base.appName + $"You Cannot Abandon this kind of skill.", user); // Add the time remaining here??
                            return;
                        }

                        var skillTalentsAsGroup = targetSkill.Talents.ToList();
                        List<Type> skillTalentsType = new List<Type>();
                        foreach (TalentGroup t in skillTalentsAsGroup)
                        {
                            foreach (Type z in t.Talents)
                            {
                                skillTalentsType.Add(z);
                            }
                        }
                        foreach (Type x in skillTalentsType)
                        {
                            talentset.Talents.Remove(x);
                        }
                        targetSkill.ForceSetLevel(0);
                        skillset.RefreshSkills();
                        Skill.OnSkillsChanged.Invoke();

                        userData.UseSkills();
                        QOLManager.SaveData();
                        ChatBaseExtended.CBOkBox($"You Have Abandoned the skill: {skillName}, you have {QOLManager.Config.MaxSkills - userData.MaxSkillsUsed} uses left", user);
                        ChatBaseExtended.CBInfo(Base.appName + $"You Have Abandoned the skill: {skillName}, you have {QOLManager.Config.MaxSkills - 1} uses left", user); // Add the time remaining here??
                        Log.WriteLine(Localizer.DoStr($"{user.Name} Has Reset their skill: {skillName}"));                        
                        return;
                    }
                    else
                    {
                        ChatBaseExtended.CBError(Base.appName + $"Something is wrong with the selected skill", user); // Add the time remaining here??
                        return;
                    }
                }
                else
                {
                    ChatBaseExtended.CBError(Base.appName + $"That is a main skill, you can't unlearn that.", user); // Add the time remaining here??
                    return;
                }
            }
            else
            {
                ChatBaseExtended.CBError(Base.appName + $"That skill Doesn't Exist.", user); // Add the time remaining here??
                return;
            }
        }

        public static string SanitizeSkillTalent(string name)
        {
            return Regex.Replace(name, @"\s", "");
        }

        public static bool ExistsSkill(string skillName)
        {
            Item skillDefItem = allSkillsAsItem.Find(s => s.Type.Name.Contains(skillName, StringComparison.OrdinalIgnoreCase));
            if (skillDefItem != null)
            {
                Type skillDefType = skillDefItem.Type;
                if (skillDefType != null)
                {
                    return true;
                }
                else return false;
            }
            else
            {
                return false;
            }
        }

        //Should be used after check for multiple skill was done!
        public static Type GetMatchSkillAsType(string skillName)
        {
            bool exists = ExistsSkill(skillName);

            if (exists)
            {
                Type skillDefType = FindSkillAsType(skillName);

                if (skillDefType != null)
                {
                    if (IsLiteralSkill(skillName))
                    {
                        skillDefType = GetLiteralSkillType(skillName);
                        return skillDefType;

                    }
                    else
                    {
                        return skillDefType;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static Type FindSkillAsType(string skillName)
        {
            if (ExistsSkill(skillName))
            {
                Item skillDefItem = allSkillsAsItem.Find(s => s.Type.Name.Contains(skillName, StringComparison.OrdinalIgnoreCase));
                Type skillDefType = skillDefItem.Type;
                return skillDefType;
            }
            else return null;
        }

        public static Type GetLiteralSkillType(string skill)
        {
            string adaptedString = string.Concat(skill, "skill");
            if (IsLiteralSkill(skill))
            {
                Item literalSkill = allSkillsAsItem.FirstOrDefault(l => l.Type.Name.ToString().Equals(adaptedString, StringComparison.OrdinalIgnoreCase));
                return literalSkill.Type;
            }
            else return null;
        }

        public static List<Skill> GetRootSkills(Skillset skillset)
        {
            List<Skill> rootSkills = skillset.Skills.Where(s => s.IsRoot).ToList();

            if (rootSkills.Count > 0)
            {
                return rootSkills;
            }
            else return null;
        }

        public static bool IsRootSkill(Skill targetSkill)
        {
            if (targetSkill.IsRoot)
            {
                return true;
            }
            else return false;
        }

        public static bool IsMultipleSkill(string skill)
        {
            List<Item> skillDefListItem = allSkillsAsItem.FindAll(s => s.Type.Name.Contains(skill, StringComparison.OrdinalIgnoreCase));
            bool isMultiple = skillDefListItem.Count() > 1;

            if (isMultiple)
            {
                return true;
            }
            else return false;
        }

        public static bool IsLiteralSkill(string skill)
        {
            string adaptedString = string.Concat(skill, "skill");
            bool isLiteral = allSkillsAsItem.Any(i => i.Type.Name.ToString().Equals(adaptedString, StringComparison.OrdinalIgnoreCase));
            if (isLiteral)
            {
                return true;
            }
            else return false;

        }

        public static bool IsMultipleNotLiteralSkill(string skill)
        {
            bool isMultiple = IsMultipleSkill(skill);
            bool isLiteral = IsLiteralSkill(skill);

            if (isMultiple && !isLiteral)
            {
                return true;
            }
            else return false;
        }

        public static bool IsSkillInSkillset(Type skill, Skillset skillset)
        {
            bool isThere = skillset.Skills.Any(a => a.Type == skill);

            if (isThere)
            {
                return true;
            }
            else return false;
        }

        public static Skill GetSkillInSkillSet(Type skill, Skillset skillset)
        {
            Skill isThere = skillset.Skills.FirstOrDefault(a => a.Type == skill);

            if (isThere != null)
            {
                return isThere;
            }
            else return null;
        }

        public static void ChangeSpecPoints(int amount, User targetUser)
        {
            targetUser.SpecialtyPoints = GetSpecPoints(targetUser) + amount;
            targetUser.Changed("SpecialtyPoints");
            targetUser.Changed("XP");
        }

        public static int GetSpecPoints(User user)
        {
            int points = user.SpecialtyPoints;
            return points;
        }

        public static int GetCurrentSkillLevel(Skill targetSkill)
        {
            int currLvl = targetSkill.Level;
            return currLvl;
        }

        public static Skill GetSkillFromType(Type skillAsType)
        {
            SkillTree skillTree = SkillTree.SkillTreeFromSkill(skillAsType);
            Skill skill = skillTree.StaticSkill;
            return skill;
        }

        public static Type GetUserTalent(User targetUser, string talentName)
        {
            List<Type> talents = targetUser.Talentset.Talents.ToList();
            Type target = talents.FirstOrDefault(t => t.Name.Contains(talentName, StringComparison.OrdinalIgnoreCase));

            if (target != null)
            {
                return target;
            }
            else return null;
        }

        public static Talent GetTalent(string talent)
        {
            return Talent.TypeToTalent.FirstOrDefault(x => x.Key.Equals(talent)).Value;
        }
    }
}
