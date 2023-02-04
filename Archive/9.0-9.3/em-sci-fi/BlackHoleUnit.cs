using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Shared.Items;
using Eco.Core.Controller;
using Eco.Gameplay.Interactions;
using Eco.Shared.Math;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Core.Utils;
using System.Linq;
using Eco.Gameplay.Players;
using Eco.Mods.TechTree;

namespace Eco.EM.Scifi
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(PublicStorageComponent))]  
	[RequireComponent(typeof(CustomTextComponent))]	
    public partial class BlackHoleUnitObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Black Hole Unit"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(BlackHoleUnitItem); } } 

        protected override void Initialize()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(1);
            storage.Storage.AddInvRestriction(new CustomStackLimitRestriction(999999999));
			this.GetComponent<CustomTextComponent>().Initialize(100);
        }
		
		protected override void PostInitialize()
        {
            base.PostInitialize();
            this.GetComponent<LinkComponent>().Initialize(8);
        }

        public override void Destroy()
        {
            base.Destroy();
        }
		
		public override void Tick()
        {
            base.Tick();
			
            var storage = this.GetComponent<PublicStorageComponent>();
            var textC = this.GetComponent<CustomTextComponent>();
            foreach (var stack in storage.Inventory.Stacks)
            {
                if (stack.Item != null)
                {
                    int Q = stack.Quantity;
                    string N = stack.Item.Name;
					string fullText = Localizer.Format($".\n<size=350%><ecoicon item=\"" + N + "\"></ecoicon></size><size=3>\n\n</size>" + Q);
					textC.TextData.Text = ProfanityFilter.Clean(fullText.PercentizeSizeTags().CapLength(100));
					textC.TextData.Changed(nameof(textC.TextData.Text));
					textC.Parent.SetDirty();
					SetName(stack.Item.DisplayName + " Unit");
                }
				else
				{
					string fullText = "";
					textC.TextData.Text = ProfanityFilter.Clean(fullText.PercentizeSizeTags().CapLength(100));
					textC.TextData.Changed(nameof(textC.TextData.Text));
					textC.Parent.SetDirty();
					SetName("Empty Unit");
				}
			}
        }

        public WorldObject WorldObjectsAtPos(Vector3i pos)
        {
            WorldObject objAtPos = null;
            WorldObjectManager.ForEach(worldObject =>
            {
                foreach (Vector3i vector in worldObject.WorldOccupancy)
                {
                    if (vector == pos)
                    {
                        objAtPos = worldObject;
                        break;
                    }
                }
            });
            return objAtPos;
        }

        public override InteractResult OnActRight(InteractionContext context)
        {
            var inventory = this.GetComponent<PublicStorageComponent>();
            if (context.SelectedItem != null && context.SelectedItem.Type == typeof(BlackHoleUnitItem))
            {
                Vector3i abovePos = Position3i;
                Quaternion playerFace = context.Player.User.FacingDir.ToQuat();
                do
                {
                    abovePos.Y += 1;
                } 
                while (WorldObjectsAtPos(abovePos) != null);
                WorldObjectManager.TryPlaceWorldObject(context.Player, (WorldObjectItem)context.SelectedItem, abovePos, playerFace);
                return InteractResult.Success;
            }

            ValResult<int> carriedResult = null;
            ValResult<int> toolbarResult = null;

            var user = context.Player.User;
            var toolbarStack = user.Inventory.Toolbar.SelectedStack;
            var carriedStack = user.Inventory.Carried.Stacks.FirstOrDefault(stack => stack.Quantity > 0);
            var finalStack = carriedStack ?? toolbarStack;
            var finalItem = finalStack?.Item;

            // First we try to move carried slot
            if (carriedStack?.Item != null)
            {
                carriedResult = user.Inventory.Carried.MoveAsManyItemsAsPossible(inventory.Inventory, user);
                // Return result only on success
                if (carriedResult.IsSuccessWithChanges()) return this.InsertResultWrap(carriedResult, finalItem, user, inventory.Inventory);
                var res = this.WrapFailureMessage(carriedResult);
                if (!res.IsNoOp) return res;
            }

            // Then we try to move toolbar selected
            if (toolbarStack?.Item != null && !(toolbarStack.Item is ToolItem))
            {
                toolbarResult = context.Modifier == InteractionModifier.Ctrl
                    ? user.Inventory.ToolbarBackpack.MoveAsManyItemsAsPossible(inventory.Inventory, stack => stack.Item.Type == toolbarStack.Item.Type, user)
                    : user.Inventory.ToolbarBackpack.MoveAsManyItemsAsPossible(inventory.Inventory, stack => stack == toolbarStack, user);

                if (toolbarResult.IsSuccessWithChanges()) return this.InsertResultWrap(toolbarResult, finalItem, user, inventory.Inventory);
                var res = this.WrapFailureMessage(toolbarResult);
                if (!res.IsNoOp) return res;
            }

            // Case if carried and inv slots were empty
            if (carriedResult == null && toolbarResult == null) return InteractResult.NoOp;

            // Merge failure result to provide more info to player
            return InteractResult.NoOpWithReason(carriedResult?.Merge(toolbarResult).Message ?? toolbarResult.Message);

        }

        private InteractResult WrapFailureMessage(ValResult<int> res)
        {
            if (res.Success && res.Val <= 0) res.Message = Localizer.DoStr("Target storage is full!");
            return (InteractResult)res;
        }

        private InteractResult InsertResultWrap(ValResult<int> invResult, Item item, User user, Inventory inventory)
        {
            user.OnItemInserted.Invoke(item?.DisplayName.NotTranslated, inventory);
            return InteractResult.Success;
        }

    }

    [Serialized]
    [LocDisplayName("Black Hole Unit")]
    [Ecopedia("Crafted Objects", "Storage", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class BlackHoleUnitItem :
        WorldObjectItem<BlackHoleUnitObject> 
    {
        public override LocString DisplayDescription  { get { return Localizer.DoStr("Used to store near endless quantities of a single item.\nInspired by: Industrial Foregoing mod for Minecraft."); } }

        static BlackHoleUnitItem()
        {
            
        }

    }

    [RequiresSkill(typeof(ElectronicsSkill), 6)]
    public partial class BlackHoleUnitRecipe :
        RecipeFamily
    {
        public BlackHoleUnitRecipe()
        {
            var product = new Recipe(
                "BlackHoleUnit",
                Localizer.DoStr("Black Hole Unit"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(SteelPlateItem), 10, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(GlassItem), 4, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    new IngredientElement(typeof(AdvancedCircuitItem), 4, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                },
					new CraftingElement<BlackHoleUnitItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 15;
            this.LaborInCalories = CreateLaborInCaloriesValue(2000, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlackHoleUnitRecipe), 20, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent), typeof(ElectronicsParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Black Hole Unit"), typeof(BlackHoleUnitRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}






