using Eco.Core.Items;
using Eco.EM.Framework;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System;

namespace Eco.EM.Building.Tools
{
    [Serialized]
    [LocDisplayName("Filled Jerry Can")]
    [MaxStackSize(1)]
    [Weight(5000)]
    [IgnoreStackSize]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]
    public partial class FilledJerryCanItem : RepairableItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Jerry-can with fuel in it for on the move Refueling of your gasoline powered Tools.");

        public override IDynamicValue SkilledRepairCost => new ConstantValue(1);
        public override string OnUsed(Player player, ItemStack itemStack)
        {
            if (player.User.Inventory.Toolbar.SelectedItem is not RepairableItem selectedItem) return "";
            switch (selectedItem)
            {
                //case JackHammerItem:
                    //break;
                case ChainsawItem:
                    break;
                //case AugerItem:
                    //break;
                default:
                    return string.Format(Text.Error($"This item can only be used to refuel The Auger, Chainsaw or Jackhammer"));
            }

            if (selectedItem.Durability == 100) return $"You don't need to refuel your {selectedItem.DisplayName}, it is full.";

            var oldDurability = selectedItem.Durability;
            var toAdd = 100 - oldDurability;

            if (toAdd > Durability)
                toAdd = Durability;

            if (Durability - toAdd <= 0)
                Durability = 0;

            else
                this.Durability -= toAdd;

            selectedItem.Durability += toAdd;

            player.MsgLocStr($"You have Refueled your {selectedItem.DisplayName}");

            if (Durability == 0)
            {
                player.User.Inventory.ToolbarBackpack.RemoveItem(typeof(FilledJerryCanItem));
                player.User.Inventory.ToolbarBackpack.AddItem(typeof(EmptyJerryCanItem));
            }

            return base.OnUsed(player, itemStack);
        }
    }

    [RequiresSkill(typeof(OilDrillingSkill), 2)]
    public partial class FilledJerryCanRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(FilledJerryCanRecipe).Name,
            Assembly = typeof(FilledJerryCanRecipe).AssemblyQualifiedName,
            HiddenName = "FillJerryCan",
            LocalizableName = Localizer.DoStr("Fill Jerry Can"),
            IngredientList = new()
            {
                new EMIngredient("EmptyJerryCanItem", false, 16, true),
                new EMIngredient("GasolineItem", false, 1, true)
            },
            ProductList = new()
            {
                new EMCraftable("FilledJerryCanItem", 16),
            },
            BaseExperienceOnCraft = 0.1f,
            BaseLabor = 500,
            LaborIsStatic = false,
            BaseCraftTime = 5,
            CraftTimeIsStatic = false,
            CraftingStation = "PumpJackItem",
            RequiredSkillType = typeof(OilDrillingSkill),
            RequiredSkillLevel = 2,
            IngredientImprovementTalents = typeof(OilDrillingLavishResourcesTalent),
            SpeedImprovementTalents = new Type[] { typeof(OilDrillingFocusedSpeedTalent), typeof(OilDrillingParallelSpeedTalent) },
        };

        static FilledJerryCanRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public FilledJerryCanRecipe()
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
