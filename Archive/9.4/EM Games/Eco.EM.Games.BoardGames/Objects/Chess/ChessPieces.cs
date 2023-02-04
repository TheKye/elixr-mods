using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.EM.Framework.Resolvers;
using System.Linq;

namespace Eco.EM.Games.BoardGames
{
    #region Objects
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class StoneKingObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Stone King");
        static StoneKingObject()
        {
            AddOccupancy<StoneKingObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

	[Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class StoneQueenObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Stone Queen");
        static StoneQueenObject()
        {
            AddOccupancy<StoneQueenObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

	[Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class StoneBishopObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Stone Bishop");
        static StoneBishopObject()
    {
        AddOccupancy<StoneBishopObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                });
    }

    public override void Destroy() => base.Destroy();
}

	[Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class StoneKnightObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Stone Knight");
        static StoneKnightObject()
        {
            AddOccupancy<StoneKnightObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class StoneRookObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Stone Rook");
        static StoneRookObject()
        {
            AddOccupancy<StoneRookObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class StonePawnObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Stone Pawn");
        static StonePawnObject()
        {
            AddOccupancy<StonePawnObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class WoodKingObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Wood King");
        static WoodKingObject()
        {
            AddOccupancy<WoodKingObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class WoodQueenObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Wood Queen");
        static WoodQueenObject()
        {
            AddOccupancy<WoodQueenObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class WoodBishopObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Wood Bishop");
        static WoodBishopObject()
        {
            AddOccupancy<WoodBishopObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class WoodKnightObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Wood Knight");
        static WoodKnightObject()
        {
            AddOccupancy<WoodKnightObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class WoodRookObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Wood Rook");
        static WoodRookObject()
        {
            AddOccupancy<WoodRookObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public class WoodPawnObject : WorldObject
    {
        public override LocString DisplayName => Localizer.Do($"Wood Pawn");
        static WoodPawnObject()
        {
            AddOccupancy<WoodPawnObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                });
        }

        public override void Destroy() => base.Destroy();
    }

    [Serialized]
    [LocDisplayName("Stone King")]
    [MaxStackSize(100)]
    public class StoneKingItem : WorldObjectItem<StoneKingObject>
	{
        public override LocString DisplayDescription => Localizer.Do($"Stone Chess Piece");
    }
	[Serialized]
    [LocDisplayName("Stone Queen")]
    [MaxStackSize(100)]
    public class StoneQueenItem : WorldObjectItem<StoneQueenObject>
	{
        public override LocString DisplayDescription => Localizer.Do($"Stone Chess Piece");
    }
	[Serialized]
    [LocDisplayName("Stone Bishop")]
    [MaxStackSize(100)]
    public class StoneBishopItem : WorldObjectItem<StoneBishopObject>
	{
        public override LocString DisplayDescription => Localizer.Do($"Stone Chess Piece");
    }
	[Serialized]
    [LocDisplayName("Stone Knight")]
    [MaxStackSize(100)]
    public class StoneKnightItem : WorldObjectItem<StoneKnightObject>
	{
        public override LocString DisplayDescription => Localizer.Do($"Stone Chess Piece");
    }
	[Serialized]
    [LocDisplayName("Stone Rook")]
    [MaxStackSize(100)]
    public class StoneRookItem : WorldObjectItem<StoneRookObject>
	{
        public override LocString DisplayDescription => Localizer.Do($"Stone Chess Piece");
    }	
	[Serialized]
    [LocDisplayName("Stone Pawn")]
    [MaxStackSize(100)]
    public class StonePawnItem : WorldObjectItem<StonePawnObject>
	{
        public override LocString DisplayDescription => Localizer.Do($"Stone Chess Piece");
    }
	[Serialized]
    [LocDisplayName("Wood King")]
    [MaxStackSize(100)]
    public class WoodKingItem : WorldObjectItem<WoodKingObject> 
	{
        public override LocString DisplayDescription => Localizer.Do($"Wood Chess Piece");
    }
	[Serialized]
    [LocDisplayName("Wood Queen")]
    [MaxStackSize(100)]
    public class WoodQueenItem : WorldObjectItem<WoodQueenObject>
	{
        public override LocString DisplayDescription => Localizer.Do($"Wood Chess Piece");
    }
	[Serialized]
    [LocDisplayName("Wood Bishop")]
    [MaxStackSize(100)]
    public class WoodBishopItem : WorldObjectItem<WoodBishopObject> 
	{
        public override LocString DisplayDescription => Localizer.Do($"Wood Chess Piece");
    }
	[Serialized]
    [LocDisplayName("Wood Knight")]
    [MaxStackSize(100)]
    public class WoodKnightItem : WorldObjectItem<WoodKnightObject> 
	{
        public override LocString DisplayDescription => Localizer.Do($"Wood Chess Piece");
    }
	[Serialized]
    [LocDisplayName("Wood Rook")]
    [MaxStackSize(100)]
    public class WoodRookItem : WorldObjectItem<WoodRookObject> 
	{
        public override LocString DisplayDescription => Localizer.Do($"Wood Chess Piece");
    }
	[Serialized]
    [LocDisplayName("Wood Pawn")]
    [MaxStackSize(100)]
    public class WoodPawnItem : WorldObjectItem<WoodPawnObject> 
	{
        public override LocString DisplayDescription => Localizer.Do($"Wood Chess Piece");
    }
    #endregion
    #region Recipes
    [RequiresSkill(typeof(MasonrySkill), 3)]
	public partial class StoneKingRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StoneKingRecipe).Name,
            Assembly = typeof(StoneKingRecipe).AssemblyQualifiedName,
            HiddenName = "Stone Chess Pieces - King",
            LocalizableName = Localizer.DoStr("Stone Chess Pieces - King"),
            IngredientList = new()
            {
                new EMIngredient("Rock", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("StoneKingItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 100,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
            RequiredSkillType = typeof(MasonrySkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(MasonryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) },
        };

        static StoneKingRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StoneKingRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
	
	[RequiresSkill(typeof(MasonrySkill), 3)]
	public partial class StoneQueenRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StoneQueenRecipe).Name,
            Assembly = typeof(StoneQueenRecipe).AssemblyQualifiedName,
            HiddenName = "Stone Chess Pieces - Queen",
            LocalizableName = Localizer.DoStr("Stone Chess Pieces - Queen"),
            IngredientList = new()
            {
                new EMIngredient("Rock", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("StoneQueenItem"),
            },
            CraftingStation = "CarvingTableItem",
        };

        static StoneQueenRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StoneQueenRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(StoneKingRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
	
	[RequiresSkill(typeof(MasonrySkill), 3)]
	public partial class StoneBishopRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StoneBishopRecipe).Name,
            Assembly = typeof(StoneBishopRecipe).AssemblyQualifiedName,
            HiddenName = "Stone Chess Pieces - Bishop",
            LocalizableName = Localizer.DoStr("Stone Chess Pieces - Bishop"),
            IngredientList = new()
            {
                new EMIngredient("Rock", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("StoneBishopItem"),
            },
            CraftingStation = "CarvingTableItem",
        };

        static StoneBishopRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StoneBishopRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(StoneKingRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
	
	[RequiresSkill(typeof(MasonrySkill), 3)]
	public partial class StoneKnightRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StoneKnightRecipe).Name,
            Assembly = typeof(StoneKnightRecipe).AssemblyQualifiedName,
            HiddenName = "Stone Chess Pieces - Knight",
            LocalizableName = Localizer.DoStr("Stone Chess Pieces - Knight"),
            IngredientList = new()
            {
                new EMIngredient("Rock", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("StoneKnightItem"),
            },
            CraftingStation = "CarvingTableItem",
        };

        static StoneKnightRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StoneKnightRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(StoneKingRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
	
	[RequiresSkill(typeof(MasonrySkill), 3)]
	public partial class StoneRookRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StoneRookRecipe).Name,
            Assembly = typeof(StoneRookRecipe).AssemblyQualifiedName,
            HiddenName = "Stone Chess Pieces - Rook",
            LocalizableName = Localizer.DoStr("Stone Chess Pieces - Rook"),
            IngredientList = new()
            {
                new EMIngredient("Rock", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("StoneRookItem"),
            },
            CraftingStation = "CarvingTableItem",
        };

        static StoneRookRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StoneRookRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(StoneKingRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [RequiresSkill(typeof(MasonrySkill), 3)]
	public partial class StonePawnRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(StonePawnRecipe).Name,
            Assembly = typeof(StonePawnRecipe).AssemblyQualifiedName,
            HiddenName = "Stone Chess Pieces - Pawn",
            LocalizableName = Localizer.DoStr("Stone Chess Pieces - Pawn"),
            IngredientList = new()
            {
                new EMIngredient("Rock", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("StonePawnItem"),
            },
            CraftingStation = "CarvingTableItem",
        };

        static StonePawnRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public StonePawnRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(StoneKingRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class WoodKingRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WoodKingRecipe).Name,
            Assembly = typeof(WoodKingRecipe).AssemblyQualifiedName,
            HiddenName = "Wood Chess Pieces - King",
            LocalizableName = Localizer.DoStr("Wood Chess Pieces - King"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("WoodKingItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 100,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarvingTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 3,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) },
        };

        static WoodKingRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WoodKingRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class WoodQueenRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WoodQueenRecipe).Name,
            Assembly = typeof(WoodQueenRecipe).AssemblyQualifiedName,
            HiddenName = "Wood Chess Pieces - Queen",
            LocalizableName = Localizer.DoStr("Wood Chess Pieces - Queen"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("WoodQueenItem"),
            },
            CraftingStation = "CarvingTableItem",
        };

        static WoodQueenRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WoodQueenRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(WoodKingRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class WoodBishopRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WoodBishopRecipe).Name,
            Assembly = typeof(WoodBishopRecipe).AssemblyQualifiedName,
            HiddenName = "Wood Chess Pieces - Bishop",
            LocalizableName = Localizer.DoStr("Wood Chess Pieces - Bishop"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("WoodBishopItem"),
            },
            CraftingStation = "CarvingTableItem",
        };

        static WoodBishopRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WoodBishopRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(WoodKingRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class WoodKnightRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WoodKnightRecipe).Name,
            Assembly = typeof(WoodKnightRecipe).AssemblyQualifiedName,
            HiddenName = "Wood Chess Pieces - Knight",
            LocalizableName = Localizer.DoStr("Wood Chess Pieces - Knight"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("WoodKnightItem"),
            },
            CraftingStation = "CarvingTableItem",
        };

        static WoodKnightRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WoodKnightRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(WoodKingRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class WoodRookRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WoodRookRecipe).Name,
            Assembly = typeof(WoodRookRecipe).AssemblyQualifiedName,
            HiddenName = "Wood Chess Pieces - Rook",
            LocalizableName = Localizer.DoStr("Wood Chess Pieces - Rook"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("WoodRookItem"),
            },
            CraftingStation = "CarvingTableItem",
        };

        static WoodRookRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WoodRookRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(WoodKingRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class WoodPawnRecipe : Recipe, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(WoodPawnRecipe).Name,
            Assembly = typeof(WoodPawnRecipe).AssemblyQualifiedName,
            HiddenName = "Wood Chess Pieces - Pawn",
            LocalizableName = Localizer.DoStr("Wood Chess Pieces - Pawn"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 20),
            },
            ProductList = new()
            {
                new EMCraftable("WoodPawnItem"),
            },
            CraftingStation = "CarvingTableItem",
        };

        static WoodPawnRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public WoodPawnRecipe()
        {
            CraftingComponent.AddTagProduct(EMRecipeResolver.Obj.ResolveStation(this), typeof(WoodKingRecipe), EMRecipeResolver.Obj.ResolveRecipe(this).First());
        }
    }
    #endregion
}