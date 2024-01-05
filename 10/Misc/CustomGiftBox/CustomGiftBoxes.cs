using Eco.Gameplay.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;

namespace ECO.EM.CustomRequests
{
    /* Instructions:
     * You can:
     * Change the Class name to rename the giftbox.
     * Change the items inside the 'Contents' dictionary and/or their amounts. * You will need to find the correct 'Type Name' for the item you want, check the wiki or ask. *
     * Change the number of skill levels the pack adds (pay to win features yay! /s)
     * Change the custom on open message;
     * Change if the custom message should be in a popup (true) in just in chat (false)
     * 
     * NOTE:
     * It's perfectly ok to add additional boxes if you follow the format
     * Add a new class for each box with a 'Contents' dictionary as per the examples, ensure you implement the interface IGiftBox
     * Make sure each class is Serialized (its easiest just to copy one example completely and then edit it)
     * 
     * WARNING:
     * Making gifts that have contents that are too heavy for the recieving inventory will mean the gift can never be opened!
    */

    // Gift Box Recipes Go below

    // Starter Pack
    [Serialized]
    public class StarterPack : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(IronAxeItem)] = 1,
            [typeof(IronPickaxeItem)] = 1,
        };

        public int LevelUps => 2;
        public string CustomMessage => $"A welcome box for joining the server :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallAlpha1 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(MortarItem)] = 250,
            [typeof(IronBarItem)] = 50,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Alpha, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallAlpha2 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(MortarItem)] = 250,
            [typeof(CopperBarItem)] = 30,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Alpha, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallBravo1 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(IronBarItem)] = 50,
            [typeof(ClothItem)] = 50,
            [typeof(WindmillItem)] = 5,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Bravo, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallBravo2 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(CopperBarItem)] = 30,
            [typeof(ClothItem)] = 50,
            [typeof(WindmillItem)] = 5,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Bravo, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallCharlie1 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(IronBarItem)] = 30,
            [typeof(NailItem)] = 200,
            [typeof(WaterwheelItem)] = 5,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Charlie, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallCharlie2 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(CopperBarItem)] = 60,
            [typeof(NailItem)] = 200,
            [typeof(WaterwheelItem)] = 5,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Charlie, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SmallCharlie3 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(LumberItem)] = 50,
            [typeof(NailItem)] = 200,
            [typeof(WaterwheelItem)] = 5,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Small Donation Box Charlie, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class MediumAlpha1 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(IronConcentrateItem)] = 100,
            [typeof(LargeLumberStockpileItem)] = 2,
            [typeof(MechanicalWaterPumpItem)] = 1,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Medium Donation Box Alpha, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class MediumAlpha2 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(CopperConcentrateItem)] = 50,
            [typeof(LargeLumberStockpileItem)] = 2,
            [typeof(MechanicalWaterPumpItem)] = 1,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Medium Donation Box Alpha, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class MediumBravo1 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(SteamTruckItem)] = 1,
            [typeof(ClothItem)] = 500,
            [typeof(FruitTartItem)] = 50,
            [typeof(SimmeredMeatItem)] = 50,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Medium Donation Box Bravo, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class MediumBravo2 : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            [typeof(GoldBarItem)] = 50,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Medium Donation Box Charlie, Say thanks to our donator, Whoever it may be :). Collect additional research papers from UltraFRS/Admin/Owner";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class SpecialFoodPack : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
            //[typeof(MacaroonsItem)] = 100,
            [typeof(FruitMuffinItem)] = 100,
            [typeof(SimmeredMeatItem)] = 100,
            [typeof(ToppedPorridgeItem)] = 100,
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Special Food Box, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }

    [Serialized]
    public class GiveAll_Test : IGiftBox
    {
        public Dictionary<Type, int> Contents => new Dictionary<Type, int>()
        {
        };

        public int LevelUps => 0;
        public string CustomMessage => $"Special Food Box, Say thanks to our donator, Whoever it may be :)";
        public bool UsePopUp => true;
    }
}
