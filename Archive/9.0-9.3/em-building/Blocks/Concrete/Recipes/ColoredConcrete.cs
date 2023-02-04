using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Core.Items;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.Pipes;
using Eco.Mods.TechTree;
using Eco.EM.Artistry;

namespace Eco.EM.Building
{
    #region Grey
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class GreyReinforcedConcreteRecipe :
    RecipeFamily
    {
        public GreyReinforcedConcreteRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "GreyReinforcedConcrete",
                    Localizer.DoStr("Colored Reinforced Concrete"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(CementItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RebarItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(GreyPaintItem), 1)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<GreyReinforcedConcreteItem>(4),
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(MasonrySkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreyReinforcedConcreteRecipe), 4, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Grey Reinforced Concrete"), typeof(GreyReinforcedConcreteRecipe));
            CraftingComponent.AddRecipe(typeof(CementKilnObject), this);
        }
    }

    #endregion
    #region Black
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class BlackReinforcedConcreteRecipe :
Recipe
    {
        public BlackReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "BlackReinforcedConcrete",
                Localizer.DoStr("Black Reinforced Concrete"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CementItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RebarItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(BlackPaintItem), 1)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BlackReinforcedConcreteItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(GreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Yellow
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class YellowReinforcedConcreteRecipe :
Recipe
    {
        public YellowReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "YellowReinforcedConcrete",
                Localizer.DoStr("Yellow Reinforced Concrete"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CementItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RebarItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(YellowPaintItem), 1)
                },
                new CraftingElement[]
                {
                    new CraftingElement<YellowReinforcedConcreteItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(GreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Blue
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class BlueReinforcedConcreteRecipe :
Recipe
    {
        public BlueReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "BlueReinforcedConcrete",
                Localizer.DoStr("Blue Reinforced Concrete"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CementItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RebarItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(BluePaintItem), 1)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BlueReinforcedConcreteItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(GreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Red
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class RedReinforcedConcreteRecipe :
Recipe
    {
        public RedReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "RedReinforcedConcrete",
                Localizer.DoStr("Red Reinforced Concrete"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CementItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RebarItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RedPaintItem), 1)
                },
                new CraftingElement[]
                {
                    new CraftingElement<RedReinforcedConcreteItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(GreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region White
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class WhiteReinforcedConcreteRecipe :
Recipe
    {
        public WhiteReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "WhiteReinforcedConcrete",
                Localizer.DoStr("White Reinforced Concrete"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CementItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RebarItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(WhitePaintItem), 1)
                },
                new CraftingElement[]
                {
                    new CraftingElement<WhiteReinforcedConcreteItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(GreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Purple
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PurpleReinforcedConcreteRecipe :
Recipe
    {
        public PurpleReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "PurpleReinforcedConcrete",
                Localizer.DoStr("Purple Reinforced Concrete"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CementItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RebarItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(PurplePaintItem), 1)
                },
                new CraftingElement[]
                {
                    new CraftingElement<PurpleReinforcedConcreteItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(GreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Green
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class GreenReinforcedConcreteRecipe :
Recipe
    {
        public GreenReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "GreenReinforcedConcrete",
                Localizer.DoStr("Green Reinforced Concrete"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CementItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RebarItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(GreenPaintItem), 1)
                },
                new CraftingElement[]
                {
                    new CraftingElement<GreenReinforcedConcreteItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(GreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Brown
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class BrownReinforcedConcreteRecipe :
Recipe
    {
        public BrownReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "BrownReinforcedConcrete",
                Localizer.DoStr("Brown Reinforced Concrete"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CementItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RebarItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(BrownPaintItem), 1)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BrownReinforcedConcreteItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(GreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Orange
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class OrangeReinforcedConcreteRecipe :
Recipe
    {
        public OrangeReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "OrangeReinforcedConcrete",
                Localizer.DoStr("Orange Reinforced Concrete"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CementItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RebarItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(OrangePaintItem), 1)
                },
                new CraftingElement[]
                {
                    new CraftingElement<OrangeReinforcedConcreteItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(GreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region pink
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PinkReinforcedConcreteRecipe :
    Recipe
    {
        public PinkReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "PinkReinforcedConcrete",
                Localizer.DoStr("Pink Reinforced Concrete"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CementItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(RebarItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement("CrushedRock", 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(PinkPaintItem), 1)
                },
                new CraftingElement[]
                {
                    new CraftingElement<PinkReinforcedConcreteItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(GreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
}
