namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    // Speciality
    [Serialized]
    [RequiresSkill(typeof(SurvivalistSkill), 0)]
    public partial class RecycleSkill : Skill
    {
        public override LocString DisplayName        { get { return Localizer.DoStr("Recycle"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr(""); } }

        public static ModificationStrategy MultiplicativeStrategy =
            new MultiplicativeStrategy(new float[] { 1,

                1 - 0.5f,

                1 - 0.55f,

                1 - 0.6f,

                1 - 0.65f,

                1 - 0.7f,

                1 - 0.75f,

                1 - 0.8f,

            });
        public override ModificationStrategy MultiStrategy { get { return MultiplicativeStrategy; } }
        public static ModificationStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] { 0,

                0.5f,

                0.55f,

                0.6f,

                0.65f,

                0.7f,

                0.75f,

                0.8f,

            });
        public override ModificationStrategy AddStrategy { get { return AdditiveStrategy; } }
        public static int[] SkillPointCost = {

            1,

            1,

            1,

            1,

            1,

            1,

            1,

        };
        public override int RequiredPoint { get { return this.Level < SkillPointCost.Length ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < SkillPointCost.Length ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 7; } }
       
    }

    //[Serialized]
    //public partial class RecycleSkillBook : SkillBook<RecycleSkill, RecycleSkillScroll>
    //{
    //    public override string FriendlyName { get { return "Smelting Skill Book"; } }
    //}

    //[Serialized]
    //public partial class RecycleSkillScroll : SkillScroll<RecycleSkill, RecycleSkillBook>
    //{
    //    public override string FriendlyName { get { return "Smelting Skill Scroll"; } }
    //}

    //[RequiresSkill(typeof(SurvivalistSkill), 0)]
    //public partial class RecycleSkillBookRecipe : Recipe
    //{
    //    public RecycleSkillBookRecipe()
    //    {
    //        this.Products = new CraftingElement[]
    //        {
    //            new CraftingElement<RecycleSkillBook>(),
    //        };
    //        this.Ingredients = new CraftingElement[]
    //        {
    //            new CraftingElement<LogItem>(5),
    //            new CraftingElement<BoardItem>(10),
    //            new CraftingElement<PlantFibersItem>(30)
    //        };
    //        this.CraftMinutes = new ConstantValue(90);

    //        this.Initialize("Recycling Skill Book", typeof(RecycleSkillBookRecipe));
    //        CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
    //    }
    //}
}
