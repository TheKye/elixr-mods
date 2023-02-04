using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.Chat;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Utils;
using Eco.Nid.ChatTags.Entities;
using Eco.Nid.ChatTags.Helpers;
using Eco.Nid.Helpers;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eco.Mods.TechTree;

namespace Eco.Nid.ChatTags
{
    public static class Methods
    {
        public static void GenerateNewTag()
        {
            string tagName;
            int priority;

            lock (ChatTagsDirector.configSaveLocker)
            {
                foreach (var s in Skill.AllSkills)
                {
                    if (s.Type == typeof(SurvivalistSkill))
                        continue;

                    if (!ChatTagsExtendedInit.API.Config.UseIcons)
                        tagName = s.DisplayName;
                    else
                        tagName = $"<ecoicon name='{s.DisplayName}'></ecoicon>";

                    if (s.Tier == 2)
                        priority = 3;
                    else if (s.Tier == 3)
                        priority = 2;
                    else if (s.Tier == 4)
                        priority = 1;
                    else
                        priority = 4;

                    ChatTag tag = new ChatTag()
                    {
                        Visible = true,
                        Color = "",
                        TagName = tagName,
                        Priority = priority,
                        Members = new List<Member>()
                    };
                    ChatTagsDirector.Config.PlayerTags.Add(tag);
                    ChatTagsDirector.SaveConfig();
                }
            }
        }
    }
}
