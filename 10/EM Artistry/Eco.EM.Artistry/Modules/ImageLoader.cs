using Eco.Gameplay.Objects;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Artistry.UnityImageLoader
{

    [Serialized]
    public class ImageLoaderComponent : WorldObjectComponent 
    {
        string url { get; set; }

        public ImageLoaderComponent()
        {
        }
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}