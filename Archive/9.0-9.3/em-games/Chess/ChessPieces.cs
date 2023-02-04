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

namespace Eco.EM.Games
{
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

	[RequiresSkill(typeof(MasonrySkill), 3)]
	public partial class StoneKingRecipe : RecipeFamily
	{
        private string rName = "Stone King";
        private Type skillBase = typeof(MasonrySkill);
        private Type ingTalent = typeof(MasonryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) };

        public StoneKingRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Rock", 20, skillBase, ingTalent),
                },
                new CraftingElement<StoneKingItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
		}

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[RequiresSkill(typeof(MasonrySkill), 3)]
	public partial class StoneQueenRecipe : RecipeFamily
	{
        private string rName = "Stone Queen";
        private Type skillBase = typeof(MasonrySkill);
        private Type ingTalent = typeof(MasonryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) };

        public StoneQueenRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Rock", 20, skillBase, ingTalent),
                },
                new CraftingElement<StoneQueenItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[RequiresSkill(typeof(MasonrySkill), 3)]
	public partial class StoneBishopRecipe : RecipeFamily
	{
        private string rName = "Stone Bishop";
        private Type skillBase = typeof(MasonrySkill);
        private Type ingTalent = typeof(MasonryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) };

        public StoneBishopRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Rock", 20, skillBase, ingTalent),
                },
                new CraftingElement<StoneBishopItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[RequiresSkill(typeof(MasonrySkill), 3)]
	public partial class StoneKnightRecipe : RecipeFamily
	{
        private string rName = "Stone Knight";
        private Type skillBase = typeof(MasonrySkill);
        private Type ingTalent = typeof(MasonryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) };

        public StoneKnightRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Rock", 20, skillBase, ingTalent),
                },
                new CraftingElement<StoneKnightItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[RequiresSkill(typeof(MasonrySkill), 3)]
	public partial class StoneRookRecipe : RecipeFamily
	{
        private string rName = "Stone Rook";
        private Type skillBase = typeof(MasonrySkill);
        private Type ingTalent = typeof(MasonryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) };

        public StoneRookRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Rock", 20, skillBase, ingTalent),
                },
                new CraftingElement<StoneRookItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[RequiresSkill(typeof(MasonrySkill), 2)]
	public partial class StonePawnRecipe : RecipeFamily
	{
        private string rName = "Stone Pawn";
        private Type skillBase = typeof(MasonrySkill);
        private Type ingTalent = typeof(MasonryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(MasonryParallelSpeedTalent), typeof(MasonryFocusedSpeedTalent) };

        public StonePawnRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Rock", 20, skillBase, ingTalent),
                },
                new CraftingElement<StonePawnItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
	
	[RequiresSkill(typeof(CarpentrySkill), 3)]
	public partial class WoodKingRecipe : RecipeFamily
	{
        private string rName = "Wood King";
        private Type skillBase = typeof(CarpentrySkill);
        private Type ingTalent = typeof(CarpentryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) };

        public WoodKingRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 20, skillBase, ingTalent),
                },
                new CraftingElement<WoodKingItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class WoodQueenRecipe : RecipeFamily
    {
        private string rName = "Wood Queen";
        private Type skillBase = typeof(CarpentrySkill);
        private Type ingTalent = typeof(CarpentryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) };

        public WoodQueenRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 20, skillBase, ingTalent),
                },
                new CraftingElement<WoodQueenItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class WoodBishopRecipe : RecipeFamily
    {
        private string rName = "Wood Bishop";
        private Type skillBase = typeof(CarpentrySkill);
        private Type ingTalent = typeof(CarpentryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) };

        public WoodBishopRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 20, skillBase, ingTalent),
                },
                new CraftingElement<WoodBishopItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class WoodKnightRecipe : RecipeFamily
    {
        private string rName = "Wood Knight";
        private Type skillBase = typeof(CarpentrySkill);
        private Type ingTalent = typeof(CarpentryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) };

        public WoodKnightRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 20, skillBase, ingTalent),
                },
                new CraftingElement<WoodKnightItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class WoodRookRecipe : RecipeFamily
    {
        private string rName = "Wood Rook";
        private Type skillBase = typeof(CarpentrySkill);
        private Type ingTalent = typeof(CarpentryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) };

        public WoodRookRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 20, skillBase, ingTalent),
                },
                new CraftingElement<WoodRookItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CarpentrySkill), 3)]
    public partial class WoodPawnRecipe : RecipeFamily
    {
        private string rName = "Wood Pawn";
        private Type skillBase = typeof(CarpentrySkill);
        private Type ingTalent = typeof(CarpentryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) };

        public WoodPawnRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 20, skillBase, ingTalent),
                },
                new CraftingElement<WoodPawnItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarvingTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}