using System.ComponentModel;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Shared.Math;
using Eco.Gameplay.DynamicValues;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;
using Eco.Gameplay.Components;
using Eco.Gameplay.Skills;
using Eco.Core.Utils;
using Eco.Gameplay.Rooms;
using Eco.Simulation;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Objects;
using Eco.World.Blocks;
using Eco.Core.Items;
using System.Collections.Generic;
using Eco.Shared.Items;
using Eco.Gameplay.Auth;
using System.Linq;
using Eco.Core.IoC;
using Eco.Gameplay.Components.Auth;
using System;
using Eco.Shared.Networking;
using Eco.Gameplay.Players;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Systems.TextLinks;

namespace Eco.EM.Tools
{
    [Serialized]
    [LocDisplayName("Material Chisel")]
    [Tier(4)]
    [Weight(500)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [MaxStackSize(1)]
    public partial class MaterialChiselItem : HammerItem
    {
        // Descriptions
        public override LocString LeftActionDescription { get { return Localizer.DoStr("Swap"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("This chisel will remove a constucted block into its inventory and replace it with a carried block"); } }

        // Statics        
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(MaterialChiselItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(8, typeof(SelfImprovementSkill), typeof(MaterialChiselItem), new MaterialChiselItem().UILink()));
        private static IDynamicValue tier = new ConstantValue(4);
        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(4, CarpenterSkill.MultiplicativeStrategy, typeof(CarpenterSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
        private static IDynamicValue exp = new ConstantValue(0.2f);

        // Tool overrides
        public override IDynamicValue CaloriesBurn => caloriesBurn;
        public override IDynamicValue Tier => tier;
        public override IDynamicValue ExperienceRate { get { return exp; } }
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }
        public override float DurabilityRate { get { return DurabilityMax / 500f; } }
        public override Item RepairItem { get { return Item.Get<IronBarItem>(); } }
        public override int FullRepairAmount { get { return 4; } }

        [Serialized] private LimitedInventory chiselStack = new LimitedInventory(1);

        public MaterialChiselItem()
        {
            chiselStack.AddInvRestriction(new CarriedRestriction());
            chiselStack.AddInvRestriction(new StackLimitRestriction(20));
        }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            var authResult = ServiceHolder<IAuthManager>.Obj.IsAuthorized((Vector3i)context.Player.Position, context.Player.User, (AccessType.ConsumerAccess | AccessType.FullAccess | AccessType.OwnerAccess), null);
            var blockAuthResult = ServiceHolder<IAuthManager>.Obj.IsAuthorized(context.TargetPosition, context.Player.User, (AccessType.ConsumerAccess | AccessType.FullAccess | AccessType.OwnerAccess), null);
            if (!authResult.Success && !blockAuthResult.Success || !authResult.Success || !blockAuthResult.Success)
            {
                context.Player.ErrorLocStr($"You are Not Authorized to do that.");
                return InteractResult.Fail;

            }
            if (!context.HasBlock)
                return InteractResult.NoOp;

            var blockToSwap = context.Block;
            var blockPosition = context.BlockPosition.Value;

            if (!blockToSwap.Is<Constructed>())
            {
                context.Player.MsgLocStr(Localizer.Do($"Only construction materials can be chisled out"));
                return InteractResult.NoOp;
            }

            BlockItem blockItem = BlockItem.CreatingItem(blockToSwap.GetType());

            if (blockItem != null)
            {
                // if we are carrying the same block or we have an empty carry slot just give it to us in that slot.
                if (context.CarriedItem == null)
                {
                    context.Player.Msg(Localizer.Do($"You have no blocks to swap into this place"));
                    return InteractResult.Fail;
                }

                //try to add the block to the wandstack
                Result result = chiselStack.TryAddItem(blockItem);
                //unable to add returns a message to the player and discontinues Interaction
                if (!result.Success)
                {
                    context.Player.Msg(Localizer.Do($"Unable to add this block to the material chisel"));
                    return InteractResult.NoOp;
                }

                context.Player.Msg(Localizer.Do($"Added 1 {blockItem.DisplayName} to the material chisel"));
                //delete the block from the world and any plant above it
                World.World.DeleteBlock(blockPosition);
                var plant = EcoSim.PlantSim.GetPlant(context.BlockPosition.Value + Vector3i.Up);
                if (plant != null)
                    EcoSim.PlantSim.DestroyPlant(plant, DeathType.Harvesting);

                //if we are carrying something then let us place it.
                if (context.CarriedItem != null)
                {
                    BSONValue rotation = null;
                    context.Parameters?.TryGetValue("formRotation", out rotation);
                    var form = context.Player?.User.Inventory.Carried.SelectedForm?.FormType.Name;
                    var blockType = BlockFormManager.GetBlockTypeToCreate(context.Player, context.SelectedItem, context.CarriedItem, form, rotation?.Int32Value ?? 0);

                    if (blockType == null)
                    {
                        blockType = ((BlockItem)context.CarriedItem).BlockTypes[0];

                        if (blockType == null)
                        {
                            context.Player.Msg(Localizer.Do($"Unable to place this type of block"));
                            return InteractResult.NoOp;
                        }
                    }

                    World.World.SetBlock(blockType, blockPosition);
                    context.Player.User.Inventory.RemoveItem(context.CarriedItem.Type);
                }
                this.BurnCaloriesNow(context.Player);
                this.UseDurability(DurabilityRate, context.Player);
                //recheck rooms
                RoomData.QueueRoomTest(blockPosition);

                return InteractResult.Success;
            }

            context.Player.Msg(Localizer.Do($"No chisable block found"));

            return InteractResult.NoOp;
        }

        public override InteractResult OnActRight(InteractionContext context)
        {
            if (context.Modifier == InteractionModifier.Shift)
            {
                foreach (ItemStack s in chiselStack.Stacks)
                {
                    if (!s.Empty())
                    {
                        var stackSize = s.Quantity;
                        string stackType;
                        string pronoun = "is";

                        if (stackSize > 1)
                        {
                            stackType = s.Item.DisplayNamePlural;
                            pronoun = "are";
                        }
                        else
                            stackType = s.Item.DisplayName;

                        context.Player.Msg(Localizer.Do($"There {pronoun} {stackSize} {stackType} in your material chisel."));
                    }
                    else
                        context.Player.Msg(Localizer.Do($"The material chisel is empty"));
                }

                return InteractResult.Success;
            }

            if (context.HasTarget)
            {
                if (context.Target is WorldObject wo && wo.HasComponent<PublicStorageComponent>())
                {
                    var stockpile = wo.GetComponent<PublicStorageComponent>();
                    var moved = chiselStack.MoveAsManyItemsAsPossible(stockpile.Inventory, context.Player.User);
                    context.Player.Msg(Localizer.Do($"{moved.Val} items moved"));
                    return InteractResult.Success;
                }
            }

            return base.OnActRight(context);
        }
    }

    [RequiresSkill(typeof(CarpenterSkill), 0)]
    [RepairRequiresSkill(typeof(CarpenterSkill), 1)]
    public partial class MaterialChiselRecipe : RecipeFamily
    {
        public MaterialChiselRecipe()
        {
            var product = new Recipe(
                    "Material Chisel",
                    Localizer.DoStr("Material Chisel"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 6,typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                        new IngredientElement("WoodBoard", 2 ,typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                    },

                    new CraftingElement<MaterialChiselItem>(1f)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(150f, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MaterialChiselRecipe), 15f, typeof(CarpentrySkill), typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent));

            this.Initialize(Localizer.DoStr("Material Chisel"), typeof(MaterialChiselRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}