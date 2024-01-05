using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Artistry
{
    /// <summary>
    /// Artist Profession
    /// </summary>

    [Serialized]
    [LocDisplayName("Artist")]
    [Tag("Profession")]
    public partial class ArtistSkill : Skill
    {
        public override LocString DisplayDescription => Localizer.DoStr("Artistry for people who like to be artistic.");

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int MaxLevel => 1;
    }
}

