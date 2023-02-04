namespace Eco.CTK
{
    using System;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Gameplay.Players;

    public class ExtendedUser : IModKitPlugin
    {
        string status = "Initializing...";

        static readonly ExtendedUser _instance = new ExtendedUser();
        public static ExtendedUser Instance
        {
            get {
                return _instance;
            }
        }

        public string GetStatus()
        {
            return status;
        }

        public ExtendedUser() {
            UserManager.OnNewUserJoined.Add(AutoCapHouseSkillRate);
            status = "Initialized";
        }

        private void AutoCapHouseSkillRate( User user ) {
            user.CachedHouseValue.OnChanged.AddUnique( HouseValueUpdated );
        }

        private void HouseValueUpdated( )
        {
            foreach (var u in Base.Users)
            {
                var cacheHV = u.CachedHouseValue;
                if (cacheHV != null)
                {
                    var HousingValue = cacheHV?.HousingSkillRate??0;
                    var FoodValue = (u.SkillRate - HousingValue);
                    if (HousingValue > FoodValue)
                        u.CachedHouseValue.HousingSkillRate = FoodValue;
                    else
                        u.CachedHouseValue.HousingSkillRate = HousingValue;
                }
            }
        }
    }
}