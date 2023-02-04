using Eco.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Admin
{
    public class AdminConfig
    {
        [LocDescription("Displays extra info about a player on their tooltip")]
        public bool EnableExtraAdminInfo { get; set; } = false;

        [LocDescription("Use this to enable the reporting system.")]
        public bool EnableReports { get; set; } = false;

        [LocDescription("Use this to enable the help system, it uses the same Webhook as Reports do")]
        public bool EnableHelpRequests { get; set; } = false;

        [LocDescription("This is the role that will be Pinged on a report (Default is Admin)")]
        public ulong AdminRoleID { get; set; } = 0;

        [LocDescription("Here you can enable or disable admins being pinged for Report Notifications")]
        public bool NotifyAdmin { get; set; } = false;

        [LocDescription("This is the Webhook URL Required for sending the notifications, This is a Discord Webhook only.")]
        public string Webhook { get; set; } = "";

        [LocDescription("Set this to have a Specific name added to the report system if you have multiple servers in one community, this will allow you to determine where the report came from so you can have a single report channel. If Left Blank will just Post from: Your Server.")]
        public string MultiServerReportName { get; set; } = "";

        [LocDescription("Enable the use of the Multi Channel Setup for sending Specific Reports to specific Channels")]
        public bool MultiChannelSystem { get; set; } = false;

        [LocDescription("If MultiChannelSystem is true, this is required for the reports to go to")]
        public string ReportChannelWebhook { get; set; } = "";

        [LocDescription("If MultiChannelSystem is true, this is required for the help requests to go to")]
        public string HelpChannelWebhook { get; set; } = "";

        [LocDescription("If MultiChannelSystem is true, this is required for the warnings to go to")]
        public string WarningLogsWebhook { get; set; } = "";

        [LocDescription("How long in seconds a player must wait before being able to use the report command again")]
        public double ReportCoolDown { get; set; } = 60;

        [LocDescription("How long in seconds a player must wait before being able to use the help me command again")]
        public double HelpCoolDown { get; set; } = 60;

        [LocDescription("You can use this to send a custom response message when a player uses the help me command")]
        public string CustomHelpResponseMessage { get; set; } = "";
    }
}
