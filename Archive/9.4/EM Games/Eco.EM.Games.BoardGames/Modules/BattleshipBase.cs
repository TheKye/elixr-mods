using Eco.Gameplay.Objects;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco.EM.Games.BoardGames
{
    [Serialized]
    public abstract class BattleshipBase : WorldObject
    {
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void OnCreate()
        {
            base.OnCreate();
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();
        }
    }
}
