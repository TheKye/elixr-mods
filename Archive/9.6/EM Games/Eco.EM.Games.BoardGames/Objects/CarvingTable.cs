using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Property;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Games.BoardGames
{
	[Serialized]    
	[RequireComponent(typeof(AttachmentComponent))]
	[RequireComponent(typeof(PropertyAuthComponent))]
	[RequireComponent(typeof(MinimapComponent))]                
	[RequireComponent(typeof(LinkComponent))]                   
	[RequireComponent(typeof(CraftingComponent))]
	[RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
	[RequireComponent(typeof(RoomRequirementsComponent))]
	[RequireRoomContainment]
	[RequireRoomVolume(25)]                              
	public partial class CarvingTableObject : WorldObject
	{
		public override LocString DisplayName => Localizer.Do($"Carving Table"); 
		
		static CarvingTableObject()
		{
			AddOccupancy<CarvingTableObject>(new List<BlockOccupancy>(){
				new BlockOccupancy(new Vector3i(0, 0, 0)),
				new BlockOccupancy(new Vector3i(0, 1, 0)),
				new BlockOccupancy(new Vector3i(-1, 0, 0)),
				new BlockOccupancy(new Vector3i(-1, 1, 0)),
			});	
		}
		
		protected override void Initialize()
		{
			this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Crafting"));                                 
		}


	}

	[Serialized]
	[LocDisplayName("Carving Table")]
	[MaxStackSize(100)]
	public partial class CarvingTableItem : WorldObjectItem<CarvingTableObject>
	{
		public override LocString DisplayDescription => Localizer.Do($"A table for carving both stone and wood.");
		public override DirectionAxisFlags RequiresSurfaceOnSides { get; } = 0 | DirectionAxisFlags.Down;
		static CarvingTableItem() {} 
	}

	[RequiresSkill(typeof(LoggingSkill), 1)]
	public partial class CarvingTableRecipe : RecipeFamily
	{
		public CarvingTableRecipe()
		{
			this.Recipes = new List<Recipe>
			{
				new Recipe(
					"Carving Table",
					Localizer.DoStr("Carving Table"),
					new IngredientElement[]
					{
						new IngredientElement("Wood", 20,typeof(LoggingSkill)),
						new IngredientElement("Rock", 20,typeof(LoggingSkill)),
					},
						new CraftingElement<CarvingTableItem>()
			   )
			};
			this.LaborInCalories = CreateLaborInCaloriesValue(150, typeof(LoggingSkill));
			this.CraftMinutes = CreateCraftTimeValue(typeof(CarvingTableRecipe), 2, typeof(LoggingSkill));
			this.ModsPreInitialize();
			this.Initialize(Localizer.Do($"Carving Table"), typeof(CarvingTableRecipe));
			this.ModsPostInitialize();
			CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
		}

		/// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
		partial void ModsPreInitialize();
		/// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
		partial void ModsPostInitialize();
	}
}