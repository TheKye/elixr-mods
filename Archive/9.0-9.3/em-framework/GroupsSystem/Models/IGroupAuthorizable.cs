using Eco.Shared.Serialization;
using System;

namespace Eco.EM.Framework.Groups
{
    public interface IGroupAuthorizable
    {
        string Identifier { get; }
        bool Permit(SimpleGroupUser user);
    }
}
