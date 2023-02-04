using Eco.EM.Framework;
using Eco.EM.Framework.ChatBase;
using Eco.EM.Framework.Text;
using Eco.Gameplay.Players;
using Eco.Gameplay.Systems.Chat;
using Eco.Shared.Localization;
using System;

namespace Eco.EM.Commands
{
    public class TablesTesting : IChatCommandHandler
    {
        [ChatCommand("Test The Tables")]
        public static void TablesTest(User user)
        {
            Base.Debug("First Line Test");
            var myTable = new Table(3);
            Base.Debug($"{myTable.Columns.Length}");
            myTable.Columns[0].Title = "ID";
            myTable.Columns[1].Title = "Name";
            myTable.Columns[2].Title = "Score";

            Base.Debug($"{myTable.Columns[0]} {myTable.Columns[1]} {myTable.Columns[2]}");
            foreach (var player in Base.Users)
            {
                Base.Debug($"{player.Name}");
                string[] stringValues =
                {
                    player.Id.ToString(),
                    player.Name,
                    player.Reputation.ToString()
                };
                Base.Debug($"{stringValues}");
                myTable.Rows.Add(new Row() { Values = stringValues });
            }
            string table = Tables.ToString(myTable);
            ChatBase.Send(new ChatBase.Message("Tables Testing", table, user));
        }
    }
}
