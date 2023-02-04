using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Framework.BrowserLinks
{
    [Serialized]
    public class BrowserLink : TextLinkButton
    {      
        protected string Address { get; set; }
        protected string Text { get; set; }

        public BrowserLink(string text, string address) : base()
        {
            Address = address;
            Text = text;
            HoveredHeader = Localizer.DoStr($"{Text}");
            OnClick.Add((x) => BrowserLinkManager.Obj.OpenBrowser(x, Address));
        }
    }
}
