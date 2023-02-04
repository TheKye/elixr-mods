using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Components;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.Shared.Services;
using Eco.World;

namespace Eco.EM.Industry
{
    [Serialized]
    [Category("Tools")]
    [LocDisplayName("Block Scanner")]
    [MaxStackSize(1)]
    public class BlockScannerItem : ToolItem
    {
        private enum ScanSetting { Horizontal, Vertical };
        private ScanSetting scanDir = ScanSetting.Vertical;
        public LocString scanReport = Localizer.Do($"Depth Scan");

        public override LocString LeftActionDescription { get { return Localizer.DoStr("Scan"); } }

        public override LocString DisplayDescription { get { return Localizer.DoStr("Scanning device for identifying blocks underground."); } }

        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(1, BasicEngineeringSkill.MultiplicativeStrategy, typeof(BasicEngineeringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

        public override float DurabilityRate { get { return DurabilityMax / 500f; } }

        public override Item RepairItem { get { return Item.Get<IronBarItem>(); } }
        public override int FullRepairAmount { get { return 8; } }

        public override InteractResult OnActRight(InteractionContext context)
        {
            if (scanDir == ScanSetting.Horizontal)
            {
                scanDir = ScanSetting.Vertical;
                scanReport = Localizer.Do($"Depth Scan");
                context.Player.MsgLocStr(scanReport, MessageCategory.Info);
                return InteractResult.Success;
            }
            else if (scanDir == ScanSetting.Vertical)
            {
                scanDir = ScanSetting.Horizontal;
                scanReport = Localizer.Do($"Horizontal Scan");
                context.Player.MsgLocStr(scanReport, MessageCategory.Info);
                return InteractResult.Success;
            }
            else
            {
                return InteractResult.NoOp;
            }
        }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (!context.HasBlock)
                return InteractResult.NoOp;

            Direction facingDir = context.Player.User.FacingDir;
            Dictionary<string, int> blockCount = new Dictionary<string, int>();
            Vector3i target = context.BlockPosition.Value;
            Vector3i blockPos = target;
            StringBuilder title = new StringBuilder();
            StringBuilder text = new StringBuilder();
            this.BurnCaloriesNow(context.Player);
            this.UseDurability(DurabilityRate, context.Player);
            for (int scans = 30; scans > 0; scans--)
            {

                Block scanBlock = World.World.GetBlock(blockPos);
                string blockName = scanBlock.GetType().Name;

                if (blockCount.ContainsKey(blockName))
                {
                    blockCount[blockName]++;
                }
                else
                {
                    blockCount.Add(blockName, 1);
                }

                if (scanDir == ScanSetting.Vertical)
                {
                    blockPos = blockPos + Vector3i.Down;
                }

                if (scanDir == ScanSetting.Horizontal)
                {

                    switch (facingDir)
                    {
                        case Direction.Forward:
                            {
                                blockPos = blockPos + Vector3i.Forward;
                                break;
                            }
                        case Direction.Left:
                            {
                                blockPos = blockPos + Vector3i.Left;
                                break;
                            }
                        case Direction.Back:
                            {
                                blockPos = blockPos + Vector3i.Back;
                                break;
                            }
                        case Direction.Right:
                            {
                                blockPos = blockPos + Vector3i.Right;
                                break;
                            }
                    }
                }
            }
            
            title.Append("Blocks Scanned: " + scanReport + "!");
            foreach (KeyValuePair<string, int> b in blockCount)
            {
                text.Append(b.Key + ": " + b.Value + "\n");
            }
            context.Player.OpenInfoPanel(title.ToString(), text.ToString(), "ScanReport");

            BurnCaloriesNow(context.Player);
            return InteractResult.Success;
        }
    }

    [RequiresSkill(typeof(BasicEngineeringSkill), 0)]
    [RepairRequiresSkill(typeof(BasicEngineeringSkill), 1)]
    public partial class BlockScannerRecipe : RecipeFamily
    {
        public BlockScannerRecipe()
        {
            var product = new Recipe(
                    "Block Scanner",
                    Localizer.DoStr("Block Scanner"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(IronBarItem), 5 ,typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                        new IngredientElement("WoodBoard", 5 ,typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),
                        new IngredientElement(typeof(CopperBarItem), 5 ,typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent))
                    },

                    new CraftingElement<BlockScannerItem>(1f)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(150f, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BlockScannerRecipe), 15f, typeof(BasicEngineeringSkill), typeof(BasicEngineeringParallelSpeedTalent), typeof(BasicEngineeringFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Block Scanner"), typeof(BlockScannerRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
