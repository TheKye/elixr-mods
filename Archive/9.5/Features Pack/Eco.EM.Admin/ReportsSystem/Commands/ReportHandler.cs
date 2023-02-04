using Eco.EM.Framework.ChatBase;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Messaging.Chat.Commands;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;

namespace Eco.EM.Admin.ReportsSystem
{
    public class ReportHandler : IChatCommandHandler
    {
        [ChatCommand("The EM Reporting/Help Request and Warning System")]
        public static void ReportSystem(User user) { }
    }
}