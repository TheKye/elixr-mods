namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Components.VehicleModules;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Math;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Networking;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Interactions;
    using Eco.Core.Controller;
    using Eco.Shared.Items;
    using Eco.Core.Tests;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Gameplay.Property;
    using System.Threading;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class BedFrameItem :
        Item
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Bed Frame"); } }

        public override LocString DisplayDescription { get { return Localizer.DoStr("A Bed Frame For The Kings Bed"); } }
    }
        [RequiresSkill(typeof(LumberSkill), 4)]
        public partial class BedFrameRecipe : Recipe
        {
            public BedFrameRecipe()
            {
                this.Products = new CraftingElement[]
                {
                new CraftingElement<BedFrameItem>(),
                };
                this.Ingredients = new CraftingElement[]
                {
                new CraftingElement<LumberItem>(typeof(LumberSkill), 50, LumberSkill.MultiplicativeStrategy, typeof(LumberLavishResourcesTalent)),
                new CraftingElement<RivetItem>(typeof(LumberSkill), 50, LumberSkill.MultiplicativeStrategy, typeof(LumberLavishResourcesTalent)),
                };
                this.ExperienceOnCraft = 2;
                this.CraftMinutes = CreateCraftTimeValue(typeof(BedFrameRecipe), Item.Get<BedFrameItem>().UILink(), 10, typeof(LumberSkill), typeof(LumberFocusedSpeedTalent), typeof(LumberParallelSpeedTalent));
                this.Initialize(Localizer.DoStr("Bed Frame"), typeof(BedFrameRecipe));
                CraftingComponent.AddRecipe(typeof(SawmillObject), this);
            }
        }
}