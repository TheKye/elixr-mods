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
    public partial class PaintGreyBrickRecipe :
    RecipeFamily
    {
        public PaintGreyBrickRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "GreyBrick",
                    Localizer.DoStr("Paint Bricks"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(BrickItem), 6, true),
                    new IngredientElement(typeof(GreyPaintItem), 1, true)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<GreyBrickItem>(6),
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(MasonrySkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaintGreyBrickRecipe), 4, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Bricks"), typeof(PaintGreyBrickRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
    #endregion
    #region Black
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintBlackBrickRecipe :
Recipe
    {
        public PaintBlackBrickRecipe()
        {
            var product = new Recipe(
                "BlackBrick",
                Localizer.DoStr("Paint Bricks - Black"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BrickItem), 6, true),
                    new IngredientElement(typeof(BlackPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BlackBrickItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(PaintGreyBrickRecipe), product);
        }
    }
    #endregion
    #region Yellow
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintYellowBrickRecipe :
Recipe
    {
        public PaintYellowBrickRecipe()
        {
            var product = new Recipe(
                "YellowBrick",
                Localizer.DoStr("Paint Bricks - Yellow"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BrickItem), 6, true),
                    new IngredientElement(typeof(YellowPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<YellowBrickItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(PaintGreyBrickRecipe), product);
        }
    }
    #endregion
    #region Blue
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintBlueBrickRecipe :
Recipe
    {
        public PaintBlueBrickRecipe()
        {
            var product = new Recipe(
                "BlueBrick",
                Localizer.DoStr("Paint Bricks - Blue"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BrickItem), 6, true),
                    new IngredientElement(typeof(BluePaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BlueBrickItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(PaintGreyBrickRecipe), product);
        }
    }
    #endregion
    #region Red
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintRedBrickRecipe :
Recipe
    {
        public PaintRedBrickRecipe()
        {
            var product = new Recipe(
                "RedBrick",
                Localizer.DoStr("Paint Bricks - Red"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BrickItem), 6, true),
                    new IngredientElement(typeof(RedPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<RedBrickItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(PaintGreyBrickRecipe), product);
        }
    }
    #endregion
    #region White
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintWhiteBrickRecipe :
Recipe
    {
        public PaintWhiteBrickRecipe()
        {
            var product = new Recipe(
                "WhiteBrick",
                Localizer.DoStr("Paint Bricks - White"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BrickItem), 6, true),
                    new IngredientElement(typeof(WhitePaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<WhiteBrickItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(PaintGreyBrickRecipe), product);
        }
    }
    #endregion
    #region Purple
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintPurpleBrickRecipe :
Recipe
    {
        public PaintPurpleBrickRecipe()
        {
            var product = new Recipe(
                "PurpleBrick",
                Localizer.DoStr("Paint Bricks - Purple"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BrickItem), 6, true),
                    new IngredientElement(typeof(PurplePaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<PurpleBrickItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(PaintGreyBrickRecipe), product);
        }
    }
    #endregion
    #region Green
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintGreenBrickRecipe :
Recipe
    {
        public PaintGreenBrickRecipe()
        {
            var product = new Recipe(
                "GreenBrick",
                Localizer.DoStr("Paint Bricks - Green"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BrickItem), 6, true),
                    new IngredientElement(typeof(GreenPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<GreenBrickItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(PaintGreyBrickRecipe), product);
        }
    }
    #endregion
    #region Brown
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintBrownBrickRecipe :
Recipe
    {
        public PaintBrownBrickRecipe()
        {
            var product = new Recipe(
                "BrownBrick",
                Localizer.DoStr("Paint Bricks - Brown"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BrickItem), 6, true),
                    new IngredientElement(typeof(BrownPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BrownBrickItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(PaintGreyBrickRecipe), product);
        }
    }
    #endregion
    #region Orange
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintOrangeBrickRecipe :
Recipe
    {
        public PaintOrangeBrickRecipe()
        {
            var product = new Recipe(
                "OrangeBrick",
                Localizer.DoStr("Paint Bricks - Orange"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BrickItem), 6, true),
                    new IngredientElement(typeof(OrangePaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<OrangeBrickItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(PaintGreyBrickRecipe), product);
        }
    }
    #endregion
    #region pink
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintPinkBrickRecipe :
    Recipe
    {
        public PaintPinkBrickRecipe()
        {
            var product = new Recipe(
                "PinkBrick",
                Localizer.DoStr("Paint Bricks - Pink"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BrickItem), 6, true),
                    new IngredientElement(typeof(PinkPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<PinkBrickItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(KilnObject), typeof(PaintGreyBrickRecipe), product);
        }
    }
    #endregion
}
