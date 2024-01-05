#define EM_Artistry
using Eco.Core.Controller;
using Eco.Core.Items;
using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Systems;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.EM.Framework.Utils;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Interactions.Interactors;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Mods.Organisms;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.SharedTypes;
using Eco.Shared.Utils;
using Eco.Shared.View;
using Eco.Simulation.Types;
using Eco.Simulation;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Eco.EM.Artistry
{
    class ArtistryBase : IInitializablePlugin, IModKitPlugin
    {

        public string GetStatus()
        {
            return "Loaded and getting creative..";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM Artistry");
        }

        /// <summary>
        /// Apply the new skills to each person who logs into the server if they do not have it.
        /// This is required to have the UI add the profession correctly also.
        /// </summary>
        public void Initialize(TimedTask timer)
        {/*
            UserManager.OnUserLoggedIn.Add(u =>
            {
                if (!u.Skillset.HasSkill(typeof(ArtistSkill)))
                    u.Skillset.LearnSkill(typeof(ArtistSkill));
            });
        */
            EcopediaGenerator.GenerateEcopediaPageFromFile("ModDocumentation;EM Artistry.xml", "Eco.EM.Artistry.Ecopedia", "Elixr Mods");
            EcopediaGenerator.GenerateEcopediaPageFromFile("ModDocumentation;EM Artistry;Painting.xml", "Eco.EM.Artistry.Ecopedia", "Elixr Mods");
        }

        public string GetCategory() => "Elixr Mods";
    }
}

[Category("Hidden")]
[Tag("Logging")]
public abstract class AxeItem : MeleeWeaponItem, IInteractor, IHasInteractions, IController, IViewController, IHasUniversalID
{
    private static IDynamicValue caloriesBurn = new ConstantValue(0f);

    private static IDynamicValue damage = new ConstantValue(100f);

    private static IDynamicValue tier = new ConstantValue(0f);

    private static IDynamicValue skilledRepairCost = new ConstantValue(1f);

    public override Item RepairItem => Item.Get<StoneItem>();

    public override int FullRepairAmount => 1;

    public override IDynamicValue CaloriesBurn => caloriesBurn;

    public override IDynamicValue Damage => damage;

    public override IDynamicValue Tier => tier;

    public override IDynamicValue SkilledRepairCost => skilledRepairCost;

    public override Type ExperienceSkill => typeof(LoggingSkill);

    public override ItemCategory ItemCategory => ItemCategory.Axe;

    public override bool IsValidForInteraction(Item item)
    {
        return item is LogItem;
    }

    [Interaction(InteractionTrigger.LeftClick, null, InteractionModifier.None, null, 0f, 0f, ClientPredictedBlockAction.None, 0, false, TriBool.None, null, AccessType.FullAccess, (InteractionFlags)0, new string[] { "Choppable" }, DisallowedEnvVars = new string[] { "felled" }, AnimationDriven = true, InteractionDistance = 1.5f)]
    [Interaction(InteractionTrigger.LeftClick, "Slice", InteractionModifier.None, new string[] { "slice" }, 0f, 0f, ClientPredictedBlockAction.None, 0, false, TriBool.None, "#FFFF00", AccessType.FullAccess, (InteractionFlags)0, new string[] { }, AnimationDriven = true, InteractionDistance = 1.5f)]
    public bool Chop(Player player, InteractionTriggerInfo triggerInfo, InteractionTarget target)
    { 
        var Damage = new MultiDynamicValue(MultiDynamicOps.Sum, new ConstantValue(0.5f), CreateDamageValue(player.User.Skillset.GetSkill(typeof(LoggingSkill)).Level, typeof(LoggingSkill), typeof(LoggersLuckTalent)));
        if (triggerInfo == InteractionTrigger.LeftClick)
        {
            if (target.IsBlock && this.TryCreateMultiblockContext(out var context, target, player, true, null, null, null, null, "Choppable"))
            {
                using (GameActionPack pack = new GameActionPack())
                {
                    if (target.IsBlock)
                    {
                        TreeDebris treeDebris = target.Block().Get<TreeDebris>();
                        if (treeDebris != null)
                        {
                            foreach (KeyValuePair<Type, Eco.Shared.Math.Range> debrisResource in ((TreeSpecies)EcoSim.GetSpecies(treeDebris.Species)).DebrisResources)
                            {
                                pack.AddToInventory(player.User.Inventory, Item.Get(debrisResource.Key), debrisResource.Value.RandInt, player.User);
                            }
                        }
                    }

                    context.ActionDescription = GameActionDescription.DoStr("clean up tree debris", "cleaning up tree debris");
                    context.ExperiencePerAction *= 0.1f;
                    pack.DeleteBlock(context);
                    return !pack.TryPerform(player.User).Failed;
                }
            }

            TreeEntity treeEntity = target.NetObj as TreeEntity;
            if (treeEntity != null)
            {
                float damageReceived;
                GameActionPack pack2 = treeEntity.TryApplyDamage(new GameActionPack(), player, Damage, target, this, out damageReceived);
                pack2.UseTool(this.CreateMultiblockContext(player, applyXPSkill: true, treeEntity.Position.XYZi()));
                return pack2.TryPerform(player.User).Success;
            }
        }

        return false;
    }
}
