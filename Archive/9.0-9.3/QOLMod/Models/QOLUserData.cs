using Newtonsoft.Json;
using System;

namespace Eco.EM.QOL
{
    [Serializable]
    public class QOLUserData
    {
        public int MaxSkillsUsed { get; private set; }

        public int MaxTalentsUsed { get; private set; }

        public QOLUserData(int skill = 0, int tal = 0)
        {
            MaxSkillsUsed = skill;
            MaxTalentsUsed = tal;
        }

        public void UseSkills()
        {
            MaxSkillsUsed++;
        }

        public void UseTalents()
        {
            MaxTalentsUsed++;
        }
        public void ResetUsers()
        {
            MaxSkillsUsed = 0;
            MaxTalentsUsed = 0;
        }
    }
}
