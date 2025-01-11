// Made By Donand J Trump, Xi Jinping aka. Kenith Pelletier, Ryan Bosse

using System;
using System.Linq;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Shared.Items;
using Eco.Shared.Logging;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Property;
using Eco.Core.Utils;
using Eco.Gameplay.Components.Store;
using Eco.Gameplay.Components.Storage;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Players;
using Eco.Gameplay.Interactions.Interactors;
using Eco.Shared.SharedTypes;

namespace Eco.Mods.TechTree
{
	[Serialized]
	[Weight(1000)]
	[RequireComponent(typeof(StoreComponent))]
	[RequireComponent(typeof(PropertyAuthComponent))]
	[RequireComponent(typeof(MinimapComponent))]
	[RequireComponent(typeof(PowerConsumptionComponent))]
	[RequireComponent(typeof(PowerGridComponent))]
	[RequireComponent(typeof(LinkComponent))]
	
	public partial class GasPumpObject : WorldObject, IRepresentsItem, IHasInteractions
	{
		public override LocString DisplayName => Localizer.DoStr("Gas Pump");
		public virtual Type RepresentedItemType => typeof(GasPumpItem);

		[Interaction(InteractionTrigger.RightClick, "Shop", InteractionModifier.Shift)]
		public void Shop(Player context, InteractionTriggerInfo triggerInfo, InteractionTarget target)
		{
			//Get the Closest Vehicle the player owns within 3 blocks of the players position
			var vehicleDeed = WorldObjectManager.GetOwnedBy(context.User).Where(x => x.HasComponent<StandaloneAuthComponent>() && x.Position.CloseTo(context.User.Position, new System.Numerics.Vector3(3, 3,3))).FirstOrDefault();

			if (vehicleDeed == null)
			{
				Log.WriteErrorLineLocStr("No Vehicle Nearby");
				context.ErrorLocStr("No Vehicle Nearby");
				return;
			}
			else
			{
				Log.WriteErrorLineLocStr(vehicleDeed.DisplayName);
				context.ErrorLocStr(vehicleDeed.DisplayName);

			}

			//Get Linked Inventories and check for Gasoline
			var gasInven = this.GetComponent<LinkComponent>().GetSortedLinkedInventories(context.User).AllInventories.Where(x => x.Stacks.Any()).FirstOrDefault();

			//If null print out of order
			if(gasInven == null)
			{
				Log.WriteErrorLineLocStr("Out of Order");
				context.ErrorLocStr("Out of Order");
				return;
			}

			if (!gasInven.Stacks.Any()) 
			{
				Log.WriteErrorLineLocStr("Out of Order");
				context.ErrorLocStr("Out of Order");
				return;
			}
			//Else Sell the gasoline and put it in the vehicle
			else
			{
				foreach(var istack in gasInven.Stacks)
				{
					if (!gasInven.Stacks.Any()) break;
					if (istack.Item.GetType() == typeof(GasolineItem))
					{
						var fuelSlot = vehicleDeed.GetComponent<FuelSupplyComponent>().Inventory;
						var storage = vehicleDeed.GetComponent<PublicStorageComponent>().Inventory;
						Result secondFail = Core.Utils.Result.FailedNoMessage;
						//Try and put it in a fuel slot as to refuel the vehicle
						var failed = gasInven.TryMoveItems<GasolineItem>(1, fuelSlot);
						if (failed.Success)
						{
							Log.WriteErrorLineLocStr("1 Gallon Purchased!");
							context.ErrorLocStr("1 Gallon Purchased!");
							break;
						}
						//If failed try and put in its inventory
						if (failed.Failed)
						{
							secondFail = gasInven.TryMoveItems<GasolineItem>(1, storage);

							if (secondFail.Failed)
							{
								context.ErrorLocStr("Not Enough Room to buy More Gasoline");

								break;
							}
							Log.WriteErrorLineLocStr("1 Gallon Purchased!");
							context.ErrorLocStr("1 Gallon Purchased!");
							break;

						}

					}
				}
			}

			return;
		}

		protected override void Initialize()
		{
			this.ModsPreInitialize();
			this.GetComponent<MinimapComponent>().SetCategory(Localizer.DoStr("Economy"));
			this.GetComponent<PowerGridComponent>().Initialize(10.0f, default(ElectricPower));
			this.GetComponent<LinkComponent>().Initialize(15);
		}
		 partial void ModsPreInitialize();
		
	}

	[Serialized]
	[LocDisplayName("Gas Pump")]
	[Ecopedia("Work Stations", "Economic", createAsSubPage: true)]
	[LocDescription("Allows the selling of fuel. Range of 15m to storages. Consumes 50w of Electrical Power")]
	public partial class GasPumpItem : WorldObjectItem<GasPumpObject>, IPersistentData
	{
		[Serialized] public object? PersistentData { get; set; }
		
		static GasPumpItem()
		{
			WorldObject.AddOccupancy<GasPumpObject>([
			new(new Vector3i(0, 0, 0)),
            new(new Vector3i(0, 1, 0)),
			]);
		}
	 
	}


	[RequiresSkill(typeof(IndustrySkill), 1)]
	public partial class GasPumpRecipe : RecipeFamily
	{
		public GasPumpRecipe()
		{
			var product = new Recipe(
				"Gas Pump",  
				Localizer.DoStr("Gas Pump"),
				[
					new(typeof(SteelBarItem), 5, typeof(IndustrySkill)),
					new(typeof(PlasticItem), 20, typeof(IndustrySkill)),
					new(typeof(ScrewsItem), 5, typeof(IndustrySkill)),
					new(typeof(BasicCircuitItem), 2, typeof(IndustrySkill)),
					new(typeof(GlassItem), 2, typeof(IndustrySkill)),
					new(typeof(SyntheticRubberItem), 2, typeof(IndustrySkill)),
				],
					new CraftingElement<GasPumpItem>()
				);
				
			this.Recipes = [product];
			this.ExperienceOnCraft = 1;
			this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(IndustrySkill));
			this.CraftMinutes = CreateCraftTimeValue(typeof(GasPumpRecipe), 5,
			typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));
			this.Initialize(Localizer.DoStr("Gas Pump"), typeof(GasPumpRecipe));
			CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
		}

	}
}