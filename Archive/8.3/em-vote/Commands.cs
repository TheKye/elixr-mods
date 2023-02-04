using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.TSO
{
    using Eco.Gameplay.Systems.Chat;
}

namespace Eco.TSO
{
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;

    public class VoteCommands : IChatCommandHandler
    {
        #region Properties
        private static VoteConfig Config => VoteMechanics.Instance.VoteConfig.Config;
        #endregion

        #region Commands
        [ChatCommand( "vote", "Vote for this server on TopServers.Online" )]
        public static void DoVote( User user )
        {
            ChatManager.ServerMessageToPlayer( Localizer.DoStr( VoteMechanics.Instance.CastVote( user ) ), user );
        }
        #endregion
    }
}

