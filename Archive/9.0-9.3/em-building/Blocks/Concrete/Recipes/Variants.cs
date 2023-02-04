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
    public partial class PaintGreyReinforcedConcreteRecipe :
    RecipeFamily
    {
        public PaintGreyReinforcedConcreteRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "GreyReinforcedConcrete",
                    Localizer.DoStr("Paint Reinforced Concrete"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Concrete", 6, true),
                    new IngredientElement(typeof(GreyPaintItem), 1, true)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<GreyReinforcedConcreteItem>(6),
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(MasonrySkill));
            this.ExperienceOnCraft = 1;
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaintGreyReinforcedConcreteRecipe), 4, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Paint Reinforced Concrete"), typeof(PaintGreyReinforcedConcreteRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CementKilnObject), this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
    #endregion
    #region Black
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintBlackReinforcedConcreteRecipe :
Recipe
    {
        public PaintBlackReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "BlackReinforcedConcrete",
                Localizer.DoStr("Paint Reinforced Concrete - Black"),
                new IngredientElement[]
                {
                    new IngredientElement("Concrete", 6, true),
                    new IngredientElement(typeof(BlackPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BlackReinforcedConcreteItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(PaintGreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Yellow
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintYellowReinforcedConcreteRecipe :
Recipe
    {
        public PaintYellowReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "YellowReinforcedConcrete",
                Localizer.DoStr("Paint Reinforced Concrete - Yellow"),
                new IngredientElement[]
                {
                    new IngredientElement("Concrete", 6, true),
                    new IngredientElement(typeof(YellowPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<YellowReinforcedConcreteItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(PaintGreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Blue
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintBlueReinforcedConcreteRecipe :
Recipe
    {
        public PaintBlueReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "BlueReinforcedConcrete",
                Localizer.DoStr("Paint Reinforced Concrete - Blue"),
                new IngredientElement[]
                {
                    new IngredientElement("Concrete", 6, true),
                    new IngredientElement(typeof(BluePaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BlueReinforcedConcreteItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(PaintGreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Red
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintRedReinforcedConcreteRecipe :
Recipe
    {
        public PaintRedReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "RedReinforcedConcrete",
                Localizer.DoStr("Paint Reinforced Concrete - Red"),
                new IngredientElement[]
                {
                    new IngredientElement("Concrete", 6, true),
                    new IngredientElement(typeof(RedPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<RedReinforcedConcreteItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(PaintGreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region White
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintWhiteReinforcedConcreteRecipe :
Recipe
    {
        public PaintWhiteReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "WhiteReinforcedConcrete",
                Localizer.DoStr("Paint Reinforced Concrete - White"),
                new IngredientElement[]
                {
                    new IngredientElement("Concrete", 6, true),
                    new IngredientElement(typeof(WhitePaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<WhiteReinforcedConcreteItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(PaintGreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Purple
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintPurpleReinforcedConcreteRecipe :
Recipe
    {
        public PaintPurpleReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "PurpleReinforcedConcrete",
                Localizer.DoStr("Paint Reinforced Concrete - Purple"),
                new IngredientElement[]
                {
                    new IngredientElement("Concrete", 6, true),
                    new IngredientElement(typeof(PurplePaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<PurpleReinforcedConcreteItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(PaintGreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Green
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintGreenReinforcedConcreteRecipe :
Recipe
    {
        public PaintGreenReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "GreenReinforcedConcrete",
                Localizer.DoStr("Paint Reinforced Concrete - Green"),
                new IngredientElement[]
                {
                    new IngredientElement("Concrete", 6, true),
                    new IngredientElement(typeof(GreenPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<GreenReinforcedConcreteItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(PaintGreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Brown
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintBrownReinforcedConcreteRecipe :
Recipe
    {
        public PaintBrownReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "BrownReinforcedConcrete",
                Localizer.DoStr("Paint Reinforced Concrete - Brown"),
                new IngredientElement[]
                {
                    new IngredientElement("Concrete", 6, true),
                    new IngredientElement(typeof(BrownPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<BrownReinforcedConcreteItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(PaintGreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region Orange
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintOrangeReinforcedConcreteRecipe :
Recipe
    {
        public PaintOrangeReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "OrangeReinforcedConcrete",
                Localizer.DoStr("Paint Reinforced Concrete - Orange"),
                new IngredientElement[]
                {
                    new IngredientElement("Concrete", 6, true),
                    new IngredientElement(typeof(OrangePaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<OrangeReinforcedConcreteItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(PaintGreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
    #region pink
    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class PaintPinkReinforcedConcreteRecipe :
    Recipe
    {
        public PaintPinkReinforcedConcreteRecipe()
        {
            var product = new Recipe(
                "PinkReinforcedConcrete",
                Localizer.DoStr("Paint Reinforced Concrete - Pink"),
                new IngredientElement[]
                {
                    new IngredientElement("Concrete", 6, true),
                    new IngredientElement(typeof(PinkPaintItem), 1, true)
                },
                new CraftingElement[]
                {
                    new CraftingElement<PinkReinforcedConcreteItem>(6),
                }
            );
            CraftingComponent.AddTagProduct(typeof(CementKilnObject), typeof(PaintGreyReinforcedConcreteRecipe), product);
        }
    }
    #endregion
}
