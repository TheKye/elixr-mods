using Eco.Core.Items;
using Eco.Core.Utils;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Auth;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Rooms;
using Eco.Mods.TechTree;
using Eco.Shared.IoC;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Simulation;
using Eco.World;
using Eco.World.Blocks;
using System.ComponentModel;
using System.Linq;

namespace Eco.EM.Building.Tools
{
    [Serialized]
    [LocDisplayName("Chisel And Bag")]
    [Currency, Tag("Currency")]
    [Tier(4), Weight(500), Category("Tool")]
    [Tag("Tool"), MaxStackSize(1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]
    public partial class ChiselAndBagItem : HammerItem
    {
        // Descriptions
        public override LocString LeftActionDescription => Localizer.DoStr("Swap");
        public override LocString DisplayDescription => Localizer.DoStr("A Combination of the Chisel and the Chisel Bag to give you more storage space when using the chisel");

        // Statics        
        private static readonly IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(MaterialChiselItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(8, typeof(SelfImprovementSkill), typeof(MaterialChiselItem)));
        private static readonly IDynamicValue tier = new ConstantValue(4);
        private static readonly SkillModifiedValue skilledRepairCost = new(4, CarpenterSkill.MultiplicativeStrategy, typeof(CarpenterSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
        private static readonly IDynamicValue exp = new ConstantValue(0.2f);

        // Tool overrides
        public override IDynamicValue CaloriesBurn => caloriesBurn;
        public override IDynamicValue Tier => tier;
        public override IDynamicValue ExperienceRate => exp;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate => DurabilityMax / 500f;
        public override Item RepairItem => Item.Get<IronBarItem>();
        public override int FullRepairAmount => 4;

        [Serialized] private readonly LimitedInventory chiselStack = new(4);

        public ChiselAndBagItem()
        {
            chiselStack.AddInvRestriction(new CarriedRestriction());
            chiselStack.AddInvRestriction(new StackLimitRestriction(20));
        }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (this.Durability == 0)
                return InteractResult.Failure(Localizer.DoStr("The Chisel is broken and needs repairs, it can not be used until it has been repaired"));

            var authResult = ServiceHolder<IAuthManager>.Obj.IsAuthorized(context, (AccessType.ConsumerAccess | AccessType.FullAccess | AccessType.OwnerAccess), null);
            var blockAuthResult = ServiceHolder<IAuthManager>.Obj.IsAuthorized(context, (AccessType.ConsumerAccess | AccessType.FullAccess | AccessType.OwnerAccess), null);
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
                    int rotation = 0;

                    if (context.Parameters.TryGetValue("formRotation", out BSONValue val))
                        rotation = val.Int32Value;

                    var form = context.Player?.User.Inventory.Carried.SelectedForm?.FormType.Name;
                    var blockType = BlockFormManager.GetBlockTypeToCreate(context.Player, context.SelectedItem, context.CarriedItem, form, rotation);

                    if (blockType == null)
                    {
                        blockType = ((BlockItem)context.CarriedItem).BlockTypes[0];

                        if (blockType == null)
                        {
                            context.Player.Msg(Localizer.Do($"Unable to place this type of block"));
                            return InteractResult.NoOp;
                        }
                    }
                    this.BurnCaloriesNow(context.Player);
                    this.UseDurability(DurabilityRate, context.Player);
                    //recheck rooms
                    RoomData.QueueRoomTest(blockPosition);

                    return PlaceBlockFill(context, context.TargetPosition);
                }


                return InteractResult.Success;
            }

            context.Player.Msg(Localizer.Do($"No chisable block found"));

            return InteractResult.NoOp;
        }

        public override InteractResult OnActRight(InteractionContext context)
        {
            if (context.Modifier == InteractionModifier.Shift)
            {
                string message = "";

                if (chiselStack.Stacks.Any())
                    message += "There is: ";

                int iteration = 0;

                foreach (ItemStack s in chiselStack.Stacks)
                {
                    if (!s.Empty())
                    {
                        iteration++;
                        var stackSize = s.Quantity;
                        string stackType;

                        if (stackSize > 1)
                            stackType = s.Item.DisplayNamePlural;
                        else
                            stackType = s.Item.DisplayName;

                        message += $"{stackSize} {stackType}, ";
                    }
                    else if(iteration == 0)
                        message = "The material chisel is empty.";
                }

                if (iteration >= 1)
                    message += "in your material chisel.";

                context.Player.Msg(Localizer.DoStr($"{message}"));

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

        private InteractResult PlaceBlockFill(InteractionContext context, Vector3i blockPosition)
        {
            int rotation = 0;
            BlockLayout layout = null;
            if (context.Parameters != null)
            {
                if (context.Parameters.TryGetValue("formRotation", out BSONValue val))
                    rotation = val.Int32Value;

                if (context.Parameters.TryGetValue("blocks", out val))
                    layout = BsonManipulator.FromBson<BlockLayout>(val);
            }


            if (context.CarriedItem is not BlockItem creatingItem)
                return InteractResult.NoOp;

            // TODO SJS: Verify all the blocks are created from the same type

            var form = context.Player?.User.Inventory.Carried.SelectedForm?.FormType.Name;
            var blockType = BlockFormManager.GetBlockTypeToCreate(context.Player, context.SelectedItem, context.CarriedItem, form, rotation);

            // Let's give up! (Let the carried type handle it)
            if (form == null || blockType == null || layout == null)
                return InteractResult.NoOp;

            using (var pack = new GameActionPack())
            {
                // Fill the pack.
                pack.PlaceBlock(
                    context: this.CreateMultiblockContext(context.Player, true, layout.Blocks.Select(x => x.Key + blockPosition)),
                    blockType: blockType,
                    createBlockAction: true,
                    removeFromInv: context.Player?.User.Inventory,
                    itemToRemove: creatingItem.GetType());

                // Try to perform created actions.
                return (InteractResult)pack.TryPerform(false);
            }
        }
    }

    // Skill requirements
    public partial class ChiselAndBagRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ChiselAndBagRecipe).Name,
            Assembly = typeof(ChiselAndBagRecipe).AssemblyQualifiedName,
            HiddenName = "Chisel And Bag",
            LocalizableName = Localizer.DoStr("Chisel And Bag"),
            IngredientList = new()
            {
                new EMIngredient(item: "MaterialChiselItem", isTag: false, amount: 1, isStatic: true),
                new EMIngredient(item: "ChiselBagItem", isTag: false, amount: 1, isStatic: true),
            },
            ProductList = new()
            {
                new EMCraftable(item: "ChiselAndBagItem", amount: 1),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 0.5f,
            CraftTimeIsStatic = false,
            CraftingStation = "ToolBenchItem",
        };

        static ChiselAndBagRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public ChiselAndBagRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(EMRecipeResolver.Obj.ResolveRecipeName(this), GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}