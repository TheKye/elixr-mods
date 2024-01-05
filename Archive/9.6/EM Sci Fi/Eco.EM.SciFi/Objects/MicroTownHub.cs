using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Math;
using Eco.World.Blocks;

namespace Eco.EM.SciFi
{
    using Eco.EM.Framework.Utils;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Players;
    using Eco.World;
    using System.Text;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class MicroTownHubObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("MicroTown Hub"); } } 
        public override TableTextureMode TableTexture => TableTextureMode.Wood; 
        public virtual Type RepresentedItemType { get { return typeof(MicroTownHubItem); } }
        [Serialized, ThreadSafe] private Dictionary<int, Vector3i> checkedPositions = new();
        [Serialized, ThreadSafe]
        private Dictionary<string, int> blockCount = new()
        {
            {"MT Small House", 0},
            {"MT Wheat Farm", 0},
            {"MT Small Silo", 0},
            {"MT Large Silo", 0}
        };

        [Serialized] private int tickCounter;
        [Serialized] private int counter15min;
        [Serialized] private bool breakHub = false;
        [Serialized] private int populationCapacity;
        [Serialized] private int populationTotal;
        [Serialized] private double jobsFilledPercent;
        [Serialized] private int unemployed;
        [Serialized] private int farmedStorageCapacity;
        [Serialized] private int wheatStored;
        [Serialized] private double wheatGrowth;
        [Serialized] private int wheatSpoiled;


        protected override void Initialize()
        {
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(12);
            storage.Storage.AddInvRestriction(new CustomStackLimitRestriction(200));

        }

        public override void Tick()
        {
            base.Tick();
            
            if (!breakHub)
            {
                tickCounter++;
                if (tickCounter > 5)
                {
                    this.PrimaryCheck();
                    this.PrimaryAction();
                    tickCounter = 1;
                }
            }  

        }

        private void DisplayHubUI(Player player)
        {
            StringBuilder text = new();
            text.Append("\n<color=green>Town Stats</color>");
            text.Append($"\n<color=yellow>Total Population:</color> {populationTotal}");
            text.Append($"\n<color=yellow>Housing Capacity:</color> {populationCapacity}");
            text.Append($"\n<color=yellow>Jobs Filled:</color> {jobsFilledPercent}");
            text.Append($"\n<color=yellow>Unemployed:</color> {unemployed}");
            text.Append($"\n<color=yellow>Silo Capacity:</color> {farmedStorageCapacity}");
            text.Append($"\n<color=yellow>Wheat Stored:</color> {wheatStored}");
            text.Append($"\n<color=yellow>Wheat Growth:</color> {wheatGrowth}");

            text.Append("\n\n<color=green>Town Blocks</color>");
            foreach (KeyValuePair<string, int> MTBlock in blockCount)
            {
                text.Append($"\n{MTBlock.Key}: {MTBlock.Value}");
            }

            player.OpenInfoPanel("Micro Town Hub", text.ToString(), "MicroTownHub");
        }

        private void PrimaryAction()
        {

            //Population Calculations
            populationCapacity = CalculatePopulationCapacity();
            if (populationTotal < 4) { populationTotal = 4; } //minimum population to prevent complete loss and provide starting population

            //Farmed Capacity Calculation
            farmedStorageCapacity = CalculateFarmedCapacity();

            //15 Minute
            counter15min++;
            if (counter15min > 12 * 15)
            {
                counter15min = 0;
                //Crops Spoiled
                if (wheatStored > farmedStorageCapacity)
                {
                    wheatSpoiled = (int)Math.Floor((wheatStored - farmedStorageCapacity) * .5f);
                    wheatStored -= wheatSpoiled;
                }

                //Feed the Population, result gives Food Percent
                int foodNeeded = populationTotal * 2;
                double foodPercent = 1;
                if (wheatStored >= foodNeeded)
                {
                    wheatStored -= foodNeeded;
                }    
                else
                {
                    foodPercent = wheatStored / populationTotal;
                    wheatStored = 0;
                }

                //Population Growth/Death every 15 min based on Food Percent and doesnt exceed cap.
                populationTotal += CalculatePopulationGrowth(foodPercent);
                //Homeless 40% wander away or something
                populationTotal -= CalculateHomelessLoss();

            }

            //Employment Calculation
            int workersNeeded = CalculateWorkersNeeded();
            int workersAvailable = CalculateWorkersAvailable();
            if (workersAvailable > workersNeeded)
            {
                jobsFilledPercent = 1;
                unemployed = workersAvailable - workersNeeded;
            }
            else
            {
                jobsFilledPercent = populationTotal / workersNeeded;
                unemployed = 0;
            }

            //Add rollover
            //Wheat Farming Calculation, send all wheat to virtual storage.
            wheatGrowth += blockCount["MT Wheat Farm"] * 0.08f * jobsFilledPercent;
            if (wheatGrowth > 1)
            {
                wheatGrowth = 0;
                wheatStored += 1;
            }
               

            //Wheat Distribution = send enough wheat to hub to fill stack
            //maybe have shift r click pull items from virtual storage

        }

        private int CalculateHomelessLoss()
        {
            int overCapacity = CalculateHomeless();
            if (overCapacity < 10) { overCapacity = 0; } // up to 10 homeless, no loss
            return (int)Math.Ceiling(overCapacity * .4);
        }

        private int CalculatePopulationGrowth(double foodPercent)
        {
            double maxPercent = (.2 * foodPercent * foodPercent) + (.1 * foodPercent) - .1; //max -10% to 20% with 0 at 50% food.
            double minPercent = (.25 * foodPercent * foodPercent) + (.05 * foodPercent) - .2; //min -20% to 10% with 0 at 80% food.
            int maxCap = (int)Math.Ceiling(maxPercent * populationTotal);
            int minCap = (int)Math.Floor(minPercent * populationTotal);
            return GetRandomNumber(minCap, maxCap);
        }

        private int GetRandomNumber(int min, int max)
        {
            Random random = new(Guid.NewGuid().GetHashCode());
            return random.Next(min, max);
        }

        private int CalculateWorkersNeeded()
        {
            int workersNeeded = 0;
            workersNeeded += blockCount["MT Small Silo"] * 1;
            workersNeeded += blockCount["MT Large Silo"] * 2;
            workersNeeded += blockCount["MT Wheat Farm"] * 2;
            return workersNeeded;
        }

        private int CalculateWorkersAvailable()
        {
            return populationTotal - CalculateHomeless();
        }

        private int CalculateHomeless()
        {
            return Math.Max(populationTotal - populationCapacity, 0);
        }

        private int CalculateFarmedCapacity()
        {
            int baseCapacity = 40;
            baseCapacity += blockCount["MT Small Silo"] * 40;
            baseCapacity += blockCount["MT Large Silo"] * 100;
            return baseCapacity;
        }

        private int CalculatePopulationCapacity()
        {
            int baseCapacity = 4;
            baseCapacity += blockCount["MT Small House"] * 4;
            return baseCapacity;
        }

        private void ClearBlockCount()
        {
            blockCount["MT Small House"] = 0;
            blockCount["MT Wheat Farm"] = 0;
            blockCount["MT Small Silo"] = 0;
            blockCount["MT Large Silo"] = 0;
        }

        private void PrimaryCheck()
        {
            this.ClearBlockCount();
            Vector3i HubPosition = (Vector3i)this.Position;
            checkedPositions.Add(1, HubPosition);
            this.CheckAllDirections(HubPosition);
            checkedPositions.Clear();
        }

        private void CheckAllDirections(Vector3i position)
        {
            Vector3i[] directions = {Vector3i.Back, Vector3i.Forward, Vector3i.Left, Vector3i.Right};
            foreach (Vector3i direction in directions)
            {
                Vector3i newPosition = position + direction;
                if (!this.CheckIfChecked(newPosition)) //Doesnt check same position more than once
                {
                    string result = this.CheckBlock(newPosition);
                    if (this.IsMicroBlock(result)) //Only cares about MT Blocks
                    {
                        blockCount[result] += 1;

                        //the hopefully successful and not infinite loop
                        this.CheckAllDirections(newPosition);
                    }
                }
            }
        }

        private bool IsMicroBlock(string blockName)
        {
            if (blockName == "MicroTown Hub")
            {
                breakHub = true; //more than one hub stops the tick count, must be fixed and replaced to correct
                return false;
            }

            Dictionary<string, int>.KeyCollection keyColl = blockCount.Keys;
            foreach (string s in keyColl)
            {
                if (blockName == s)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckIfChecked(Vector3i position)
        {
            foreach (KeyValuePair<int, Vector3i> cPositions in checkedPositions)
            {
                if (cPositions.Value == position)
                {
                    return true;
                }
            }
            return false;
        }

        private string CheckBlock(Vector3i position)
        {
            Block scanBlock = World.GetBlock(position);

            int newKey = checkedPositions.Count + 1;
            checkedPositions.Add(newKey, position);

            if (scanBlock.GetType() == typeof(WorldObjectBlock))
            {
                WorldObjectHandle objHandle = ((WorldObjectBlock)scanBlock).WorldObjectHandle;
                WorldObject obj = objHandle.Object;
                return obj.DisplayName;
            }
            return "No Block";
        }

        public override InteractResult OnActRight(InteractionContext context)
        {
            if (breakHub)
            {
                StringBuilder text = new();
                text.Append("\n<color=red>Hub is Broken, due to placing multiple hubs.</color>.");
                context.Player.OpenInfoPanel("Micro Town Hub", text.ToString(), "MicroTownHub");
            }
            else
            {
                DisplayHubUI(context.Player);
            }

            return InteractResult.Success;
        }

    }

    [Serialized]
    [LocDisplayName("MicroTown Hub")]
    [Ecopedia("Crafted Objects", "Storage", createAsSubPage: true)]                                                                           
    public partial class MicroTownHubItem :
        WorldObjectItem<MicroTownHubObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("Main Hub for Micro Town.");

        static MicroTownHubItem()
        {
            
        }

        

    }

    public partial class MicroTownHubRecipe :
        RecipeFamily
    {
        public MicroTownHubRecipe()
        {
            var product = new Recipe(
                "MicroTownHub",
                Localizer.DoStr("MicroTown Hub"),
                new IngredientElement[]
                {
               new IngredientElement("Wood", 10),   
                },
               new CraftingElement<MicroTownHubItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(25); 
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.Initialize(Localizer.DoStr("MicroTown Hub"), typeof(MicroTownHubRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}
