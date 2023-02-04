namespace Eco.EM.Pm
{
    using Eco.Core.Plugins.Interfaces;
    using Eco.Core.Utils;
    using Eco.EM.Framework;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    public class PMManager : IModKitPlugin
    {
        private const string _logFile = "PmLogs.txt";
        private const string _subPath = "/EM/PrivateMessages";
        internal const string ID = "EM_Private_Messages";
        private string newline = $"Server Rebooted, adding break: Server Restarted at: {DateTime.Now}";

        public PMManager()
        {
            Base.CreateDirectoryIfNotExist(Base.SaveLocation + _subPath);
            if (!File.Exists(Path.Combine(Base.SaveLocation + _subPath, _logFile)))
                File.Create(_logFile);

            StreamWriter stream = File.AppendText(Path.Combine(Base.SaveLocation + _subPath, _logFile));
            stream.WriteLineAsync(newline);
            stream.Close();

        }

        public static void Log(string port)
        {
            StreamWriter stream = File.AppendText(Path.Combine(Base.SaveLocation + _subPath, _logFile));
            stream.WriteLineAsync(port);
            stream.Close();
        }

        public string GetStatus()
        {
            return "EM Private Messages - Running..";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM - Private Messages");
        }

        //GetFullLog
        public static string GetFullLog()
        {
            StreamReader stream = File.OpenText(Path.Combine(Base.SaveLocation + _subPath, _logFile));
            StringBuilder builder = new StringBuilder();

            try
            {
                using (stream)
                {
                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        builder.Append("\n" + line);
                    }
                }
            }
            catch (Exception e)
            {
                builder.Append("The file could not be read:");
                builder.Append(e.Message);
            }

            stream.Close();
            return builder.ToString();
        }


        
        //GetLogOfPlayer(Player)
        public static string GetPlayerPMLog(string username)
        {
            StreamReader stream = File.OpenText(Path.Combine(Base.SaveLocation + _subPath, _logFile));
            StringBuilder builder = new StringBuilder();

            try
            {
                using (stream)
                {
                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        if (line.Contains(username)) 
                        {
                            int indexOfUser = line.IndexOf(username);
                            int indexOfSent = line.IndexOf("Sent");
                            //stops collection of name if name is in message
                            int indexOfMessage = line.IndexOf("is:");
                            if (indexOfUser < indexOfMessage)
                            {
                                //Get Sender
                                int startOfName = line.IndexOf("M:") + 3;
                                int endOfName = line.IndexOf("Sent") - 1;
                                string sender = line[startOfName..endOfName];

                                //Get Receiver
                                startOfName = line.IndexOf("to:") + 4;
                                endOfName = line.IndexOf("The Message") - 2;
                                string receiver = line[startOfName..endOfName];

                                //Get Message
                                indexOfMessage = line.IndexOf("is:") + 3;
                                string message = line.Remove(0, indexOfMessage);

                                //Format String
                                if (sender == username)
                                {
                                    builder.Append("\n<color=lightblue>to " + receiver + ":</color> " + message);
                                }
                                else
                                {
                                    builder.Append("\n<color=orange>from " + sender + ":</color> " + message);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                builder.Append("The file could not be read:");
                builder.Append(e.Message);
            }

            stream.Close();
            return builder.ToString();
        }

        //PMManager.Log($"{DateTime.Now}: {user.Name} Sent a Private Message to: {targetUser.Name}. The Message is: {message}");
        //GetLogPlayerToPlayer(Player1, Player2)
        public static string GetMessagesWithPlayer(User user, string targetusername)
        {
            StreamReader stream = File.OpenText(Path.Combine(Base.SaveLocation + _subPath, _logFile));
            StringBuilder builder = new StringBuilder();
            string username = $"{user.Name}";

            try
            {
                using (stream)
                {
                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        if (line.Contains(username) && line.Contains(targetusername))
                        {
                            int indexOfUser = line.IndexOf(username);
                            int indexOfSent = line.IndexOf("Sent");
                            if (indexOfUser < indexOfSent)
                            {
                                int indexOfMessage = line.IndexOf("is:") + 3;
                                string newLine = line.Remove(0,indexOfMessage);
                                builder.Append("\n<color=lightblue>" + username + ":</color> " + newLine);
                            }
                            else
                            {
                                int indexOfMessage = line.IndexOf("is:") + 3;
                                string newLine = line.Remove(0, indexOfMessage);
                                builder.Append("\n<color=orange>" + targetusername + ":</color> " + newLine);
                            }
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                builder.Append("The file could not be read:");
                builder.Append(e.Message);
            }

            stream.Close();
            return builder.ToString();
        }

        //PMManager.Log($"{DateTime.Now}: {user.Name} Sent a Private Message to: {targetUser.Name}. The Message is: {message}");
        //Gets Last Player to message user
        public static string GetLastPlayer(User user)
        {
            StreamReader stream = File.OpenText(Path.Combine(Base.SaveLocation + _subPath, _logFile));
            StringBuilder builder = new StringBuilder();
            string username = $"{user.Name}";

            try
            {
                using (stream)
                {
                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        if (line.Contains(username))
                        {
                            int indexOfUser = line.IndexOf(username);
                            int indexOfSent = line.IndexOf("Sent");
                            //stops collection of name if name is in message
                            int indexOfMessage = line.IndexOf("is:");
                            if (indexOfUser > indexOfSent && indexOfUser < indexOfMessage)
                            {
                                builder.Clear();
                                int startOfName = line.IndexOf("M:") + 3;
                                int endOfName = line.IndexOf("Sent") - 1;
                                string newLine = line[startOfName..endOfName];
                                builder.Append(newLine);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                builder.Append("The file could not be read:");
                builder.Append(e.Message);
            }

            stream.Close();
            return builder.ToString();
        }

    }
}
