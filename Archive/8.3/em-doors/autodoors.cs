
    using Eco.Gameplay.Objects;
    using Eco.Shared.Serialization;

namespace Eco.Gameplay.Components
{

    [RequireComponent(typeof(StatusComponent), null)]
    [Serialized]
    public class AutoDoorsComponent : WorldObjectComponent
    {
    }
}