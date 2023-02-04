namespace Eco.CTK
{
    using Eco.Core.Plugins;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public sealed class MOTDMechanics : IModKitPlugin, IInitializablePlugin, IConfigurablePlugin
    {
        static readonly MOTDMechanics _instance = new MOTDMechanics( );
        public static MOTDMechanics Instance
        {
            get {
                return _instance;
            }
        }

        private PluginConfig<MOTDs> Settings;
        IPluginConfig IConfigurablePlugin.PluginConfig => Settings;
        public MOTDs Config => Settings.Config;
        public object GetEditObject() => Settings.Config;
        public void OnEditObjectChanged( object o, string param ) => Save( );

        public MOTDMechanics()
        {
            Load( );

            if (Settings.Config.Interval > 0)
            {
                Timer = new Timer( DoSend, null, 0, Settings.Config.Interval );
            }
        }

        internal void Disable()
        {
            Timer.Dispose( );
            Config.Enabled = false;
        }

        internal void Enable()
        {
            Timer = new Timer( DoSend, null, 0, Settings.Config.Interval ); ;
            Config.Enabled = false;
        }

        internal void SetInterval( int seconds )
        {
            Config.Interval = seconds * 1000;
            Enable( );
        }

        public void Initialize( TimedTask timer )
        {

        }

        public void Load()
        {
            try
            {
                Settings = new PluginConfig<MOTDs>( filename );

                if (Config.Enabled)
                    Enable( );
            }
            catch (Exception e)
            {
                Console.WriteLine( "An error occurred while loading motds." );
                Console.WriteLine( e.Message );
            }
        }

        public void Save()
        {
            try
            {
                Settings.Save( );
            }
            catch (Exception e)
            {
                Console.WriteLine( "An error occurred while loading vote rewards data." );
                Console.WriteLine( e.Message );
            }
        }

        public void DoSend( object state )
        {
            ChatBase.Send( new ChatBase.Message(
                Send( )
            ) );
        }

        private string Send()
        {
            if (Config.Messages.Count == 0) {
                Disable( );
                return Text.Error( "No MOTD Messages to send" );
            }

            var Message = Config.Messages[MessageSteps];
            MessageSteps++;

            return Text.Positive( Message );
        }

        public string GetStatus()
        {
            Load( );

            if (Config.Enabled)
                return $"Running - {MessageStep} / {Config.Messages.Count}";
            return "Stopped";
        }

        internal int MessageSteps
        {
            get {
                return MessageStep;
            }
            set {
                if (value >= Config.Messages.Count)
                    MessageStep = 0;
                else
                    MessageStep = value;
            }
        }

        // DO NOT MODIFY THESE VALUES!
        private static Timer Timer;
        private static int MessageStep = 0;
        private static bool loaded = false;
        private static string filename = "MOTD";
    }
}