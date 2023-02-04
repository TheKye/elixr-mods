namespace Eco.EM.Base
{
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.Plugins.Networking;
    using Eco.Shared.Authentication;
    using Eco.Shared.Networking;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    public class RegisterServer : IModKitPlugin
    {
        const string endpoint = "https://claystk.info/api/list/register";
        bool Complete = false;
        string status = "Sending...";

        Timer _timer;

        public RegisterServer () {
            Init(null);
        }

        public string GetStatus()
        {
            return status;
        }

        public void Init(object state)
        {
            Initialize(null);
        }

        public void Initialize(TimedTask timer)
        {
            if (!Complete)
            {
                try
                {
                    var serverInfo = NetworkManager.Config;
                    var data = new Dictionary<string, string>
                    {
                        { "Description", serverInfo.Description },
                        { "GamePort", serverInfo.GameServerPort.ToString() },
                        { "WebPort", serverInfo.WebServerPort.ToString() },
                        { "EcoVersion", EcoVersion.Version.ToString() },
                        { "EMVersion", Base.version }
                    };
                    
                    if (Base.PostRequest(endpoint, data))
                    {
                        _timer = null;

                        status = "Done";
                        Complete = true;
                    }
                    else
                    {
                        _timer = new Timer(Init, null, 120000, 120000);
                        status = "Failed, Retrying...";
                    }
                }
                catch (Exception)
                {
                    _timer = new Timer(Init, null, 120000, 120000);

                    status = "Error while registering server.";
                    Initialize(null);
                }
            }
            else
            {
                _timer = null;
            }
        }
    }
}
