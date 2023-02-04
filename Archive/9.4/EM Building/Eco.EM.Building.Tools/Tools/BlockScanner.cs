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
using Eco.World.Blocks;
using Eco.EM.Framework.Resolvers;
using System;
using Eco.Core.Items;

namespace Eco.EM.Building.Tools
{
    [Serialized]
    [Category("Tools")]
    [LocDisplayName("Block Scanner")]
    [MaxStackSize(1)]
    [Currency, Tag("Currency")]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public class BlockScannerItem : ToolItem
    {
        private enum ScanSetting { Horizontal, Vertical };
        private ScanSetting scanDir                         = ScanSetting.Vertical;

        public LocString scanReport                         = Localizer.Do($"Depth Scan");

        private static readonly SkillModifiedValue skilledRepairCost = new(1, BasicEngineeringSkill.MultiplicativeStrategy, typeof(BasicEngineeringSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
        
        public override LocString LeftActionDescription     => Localizer.DoStr("Scan");
        public override LocString DisplayDescription        => Localizer.DoStr("Scanning device for identifying blocks underground.");
        public override IDynamicValue SkilledRepairCost     => skilledRepairCost;
        public override float DurabilityRate                => DurabilityMax / 500f;
        public override Item RepairItem                     => Item.Get<IronBarItem>();
        public override int FullRepairAmount                => 8;

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
            Dictionary<string, int> blockCount = new();
            Vector3i target = context.BlockPosition.Value;
            Vector3i blockPos = target;
            StringBuilder title = new();
            StringBuilder text = new();
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
                    blockPos += Vector3i.Down;
                }

                if (scanDir == ScanSetting.Horizontal)
                {

                    switch (facingDir)
                    {
                        case Direction.Forward:
                            {
                                blockPos += Vector3i.Forward;
                                break;
                            }
                        case Direction.Left:
                            {
                                blockPos += Vector3i.Left;
                                break;
                            }
                        case Direction.Back:
                            {
                                blockPos += Vector3i.Back;
                                break;
                            }
                        case Direction.Right:
                            {
                                blockPos += Vector3i.Right;
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
    public partial class BlockScannerRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(BlockScannerRecipe).Name,
            Assembly = typeof(BlockScannerRecipe).AssemblyQualifiedName,
            HiddenName = "Block Scanner",
            LocalizableName = Localizer.DoStr("Block Scanner"),
            IngredientList = new()
            {
                new EMIngredient("IronBarItem", false, 5 ),
                new EMIngredient("WoodBoard", true, 5 ),
                new EMIngredient("CopperBarItem", false, 5 ),
            },
            ProductList = new()
            {
                new EMCraftable("BlockScannerItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 15,
            CraftTimeIsStatic = false,
            CraftingStation = "WainwrightTableItem",
            RequiredSkillType = typeof(BasicEngineeringSkill),
            RequiredSkillLevel = 0,
            IngredientImprovementTalents = typeof(BasicEngineeringLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(BasicEngineeringParallelSpeedTalent), typeof(BasicEngineeringFocusedSpeedTalent) },
        };

        static BlockScannerRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public BlockScannerRecipe()
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
