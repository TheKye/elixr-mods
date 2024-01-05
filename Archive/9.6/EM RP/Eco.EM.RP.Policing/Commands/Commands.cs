using Eco.EM.Framework;
using Eco.EM.Framework.Utils;
using Eco.EM.RP.Policing.Helpers;
using Eco.Gameplay.Economy;
using Eco.Gameplay.Players;
using Eco.Gameplay.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.RP.Policing
{
    public class Commands
    {
        public static void SetCell(User user)
        {
            var isOutside = RoomData.Obj.IsOutside(user.Position.XYZi);
            if (isOutside)
                return;
            var isHouse = RoomData.Obj.GetRoom(user.Position.XYZi).RoomDeed.Residency.Residents.Count;

            if (isHouse > 0)
                return;

            var currentRoom = RoomData.Obj.GetRoom(user.Position.XYZi);
        }
        
        public static void FinePlayer(User user, string targetPlayer, string fine)
        {
            User userToGet = PlayerUtils.GetUser(targetPlayer);
            if (userToGet == null)
                return;
            var f = FinesHelper.GetFineType(fine);
            if (f == null)
                return;

            FinesHelper.SetPlayerFine(userToGet, f);
        }

        public static void CitePlayer(User user, string targetPlayer, float fineAmount, string reason)
        {

        }

        public static void ProcessPlayer(User user, string targetPlayer, string offense, string judgement)
        {

        }

        public static void AddFine(User user, string fineName, float fineAmount, string writeup)
        {

        }

        public static void PromoteOfficer(User user, string targetUser, string rank)
        {
            string msg;
            switch (rank)
            {
                case "Cadet":
                    msg = "You Can't Demote using this command please use DemoteOfficer instead";
                    return;
                case "Officer":
                    msg = $"{targetUser} Has been promoted to an Officer! We have sent them a congratulations!";
                    break;
                case "Sgt":
                    msg = $"{targetUser} Has been promoted to a Sargent! We have sent them a congratulations!";
                    break;
                case "Chief":
                    msg = "There can only be one Chief of Police, to change the current chief please use the Retirement command";
                    return;
                default:
                    msg = "Please Use: Cadet, Officer, Sgt or Chief for rank";
                    return;
            }
        }

        public static void DemoteOfficer(User user, string targetUser, string rank, string reason)
        {

        }

        public static void ArrestPlayer(User user, string targetUser)
        {

        }

        public static void JailPlayer(User user, string targetUser)
        {

        }

        public static void SetPoliceStation(User user, bool primary = false)
        {

        }

        public static void GoOnDuty(User user)
        {

        }

        public static void PayFine(User user, int fineNumber)
        {

        }

        public static void GetFines(User user)
        {

        }

        public static void SetCurrency(User user, string currencyName)
        {
            var moneyToUse = CurrencyManager.GetClosestCurrency(currencyName);
        }
    }
}
