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
    public partial class GreyBrickRecipe :
    RecipeFamily
    {
        public GreyBrickRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "GreyBrick",
                    Localizer.DoStr("Colored Bricks"),
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
                    new CraftingElement<GreyBrickItem>(4),
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(MasonrySkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GreyBrickRecipe), 4, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Grey Bricks"), typeof(GreyBrickRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    #endregion
    #region Black
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class BlackBrickRecipe :
Recipe
    {
        public BlackBrickRecipe()
        {
            var product = new Recipe(
                "BlackBrick",
                Localizer.DoStr("Black Bricks"),
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
                    new CraftingElement<BlackBrickItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(GreyBrickRecipe), product);
        }
    }
    #endregion
    #region Yellow
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class YellowBrickRecipe :
Recipe
    {
        public YellowBrickRecipe()
        {
            var product = new Recipe(
                "YellowBrick",
                Localizer.DoStr("Yellow Bricks"),
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
                    new CraftingElement<YellowBrickItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(GreyBrickRecipe), product);
        }
    }
    #endregion
    #region Blue
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class BlueBrickRecipe :
Recipe
    {
        public BlueBrickRecipe()
        {
            var product = new Recipe(
                "BlueBrick",
                Localizer.DoStr("Blue Bricks"),
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
                    new CraftingElement<BlueBrickItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(GreyBrickRecipe), product);
        }
    }
    #endregion
    #region Red
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class RedBrickRecipe :
Recipe
    {
        public RedBrickRecipe()
        {
            var product = new Recipe(
                "RedBrick",
                Localizer.DoStr("Red Bricks"),
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
                    new CraftingElement<RedBrickItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(GreyBrickRecipe), product);
        }
    }
    #endregion
    #region White
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class WhiteBrickRecipe :
Recipe
    {
        public WhiteBrickRecipe()
        {
            var product = new Recipe(
                "WhiteBrick",
                Localizer.DoStr("White Bricks"),
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
                    new CraftingElement<WhiteBrickItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(GreyBrickRecipe), product);
        }
    }
    #endregion
    #region Purple
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PurpleBrickRecipe :
Recipe
    {
        public PurpleBrickRecipe()
        {
            var product = new Recipe(
                "PurpleBrick",
                Localizer.DoStr("Purple Bricks"),
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
                    new CraftingElement<PurpleBrickItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(GreyBrickRecipe), product);
        }
    }
    #endregion
    #region Green
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class GreenBrickRecipe :
Recipe
    {
        public GreenBrickRecipe()
        {
            var product = new Recipe(
                "GreenBrick",
                Localizer.DoStr("Green Bricks"),
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
                    new CraftingElement<GreenBrickItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(GreyBrickRecipe), product);
        }
    }
    #endregion
    #region Brown
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class BrownBrickRecipe :
Recipe
    {
        public BrownBrickRecipe()
        {
            var product = new Recipe(
                "BrownBrick",
                Localizer.DoStr("Brown Bricks"),
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
                    new CraftingElement<BrownBrickItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(GreyBrickRecipe), product);
        }
    }
    #endregion
    #region Orange
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class OrangeBrickRecipe :
Recipe
    {
        public OrangeBrickRecipe()
        {
            var product = new Recipe(
                "OrangeBrick",
                Localizer.DoStr("Orange Bricks"),
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
                    new CraftingElement<OrangeBrickItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(GreyBrickRecipe), product);
        }
    }
    #endregion
    #region pink
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PinkBrickRecipe :
    Recipe
    {
        public PinkBrickRecipe()
        {
            var product = new Recipe(
                "PinkBrick",
                Localizer.DoStr("Pink Bricks"),
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
                    new CraftingElement<PinkBrickItem>(4),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(GreyBrickRecipe), product);
        }
    }
    #endregion
}
