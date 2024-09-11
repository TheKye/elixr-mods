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
using Eco.Shared.Items;
using Eco.Gameplay.Auth;
using Eco.Shared.IoC;
using Eco.EM.Framework.Resolvers;
using System;
using Eco.Gameplay.GameActions;
using Eco.Shared.Utils;
using Eco.World;
using System.Linq;

namespace Eco.EM.Building.Tools
{
    [Serialized]
    [LocDisplayName("Material Chisel")]
    [Tier(4), Weight(500), Category("Tool")]
    [Tag("Tool", 1), MaxStackSize(1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]
    public partial class MaterialChiselItem : HammerItem
    {
        // Descriptions
        public override LocString LeftActionDescription => Localizer.DoStr("Swap");
        public override LocString DisplayDescription => Localizer.DoStr("This chisel will remove a constucted block into its inventory and replace it with a carried block");

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
        public override Item RepairItem => RandomUtil.CoinToss() ? Get<IronBarItem>() : Get<BoardItem>();
        public override int FullRepairAmount => 1;

        [Serialized] private readonly LimitedInventory chiselStack = new(1);

        public MaterialChiselItem()
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

        private InteractResult PlaceBlockFill(InteractionContext context, Vector3i blockPosition)
        {
            int rotation = 0;
            BlockLayout layout = null;
            if (context.Parameters != null)
            {
                BSONValue val;
                if (context.Parameters.TryGetValue("formRotation", out val))
                    rotation = val.Int32Value;

                if (context.Parameters.TryGetValue("blocks", out val))
                    layout = BsonManipulator.FromBson<BlockLayout>(val);
            }

            var creatingItem = context.CarriedItem as BlockItem;

            if (creatingItem == null)
                return InteractResult.NoOp;

            // TODO SJS: Verify all the blocks are created from the same type

            var form = context.Player?.User.Inventory.Carried.SelectedForm?.FormType.Name;
            var blockType = BlockFormManager.GetBlockTypeToCreate(context.Player, context.SelectedItem, context.CarriedItem, form, rotation);

            // Let's give up! (Let the carried type handle it)
            if (form == null || blockType == null || layout == null)
                return InteractResult.NoOp;

            // Create game action pack, fill it and try to perform.
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

    [RequiresSkill(typeof(CarpenterSkill), 0)]
    [RepairRequiresSkill(typeof(CarpentrySkill), 1)]
    public partial class MaterialChiselRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(MaterialChiselRecipe).Name,
            Assembly = typeof(MaterialChiselRecipe).AssemblyQualifiedName,
            HiddenName = "Material Chisel",
            LocalizableName = Localizer.DoStr("Material Chisel"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 6),
                new EMIngredient("WoodBoard", true, 2),
            },                  
            ProductList = new()
            {
                new EMCraftable("MaterialChiselItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 15,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(CarpentrySkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(CarpentryLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) },
        };

        static MaterialChiselRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public MaterialChiselRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}