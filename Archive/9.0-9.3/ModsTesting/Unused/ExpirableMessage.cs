using System;

namespace Eco.EM.Framework
{
    public class ExpirableMessage
    {
        public event Action Expire;

        private string _message;
        public string Message 
        { 
            get
            {
                if (!CheckExpired())
                    return _message;

                OnExpire();
                return "";

            }

            private set 
            {
                _message = value;
            }

        }
        public DateTime Expiry { get; private set; }

        public ExpirableMessage(string m, double interval)
        {
            Message = m;
            Expiry = DateTime.Now.AddHours(interval);
        }

        public bool CheckExpired()
        {
            if (DateTime.Now > Expiry)
                return true;

            return false;
        }

        public void OnExpire()
        {
            Expire?.Invoke();
        }
    }
}
