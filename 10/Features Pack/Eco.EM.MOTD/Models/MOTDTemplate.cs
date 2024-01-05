using System.Collections.Generic;

namespace Eco.EM.MOTD
{
    public static class MOTDTEMPLATE
    {

        public static readonly string _template = @"# Do NOT edit any line that begins with a # as these are lines that will be ignored.
#
# Style tags as per Text Mesh Pro Markup http://digitalnativestudios.com/textmeshpro/docs/rich-text/ 
# Some style tags will not work as they require the correct assets in Unity.
#
# Tested tags
# <b></b> - Bold, <i></i> Italics, 
# <color=""colorName""></color> Color (colorName can also be Hex)
# <noparse></noparse> if you need to use <> for some reason in your MOTD
#
# Elixr Mods Personalisation Tags
#
# Using any of the following in your MOTD if you want it replaced with Server Data.
# {{USER}} - The Logging in users name
# {{SERVER}} - The Name of the Server from the Eco Configs.
# {{UPTIME}} - How many days the world has been running for
# {{DISCORD}} - Set in Network Config - The servers Discord Link.
# {{WEBPAGE}} - Set in Network Config - The servers Webpage Link. Not Currently Used
# {{MESSAGELIST}} - A Bullet point list of admin set messages. (this is to allow you to place this list appropriately in the MOTD.)
#
#
# CUSTOM MOTD TITLE (One Line Only)
<color=""orange""><b>MOTD</b></color>
#
# MOTD BODY
<size=""20em"">Welcome <color=""blue""><b>{{USER}}</b></color> to <color=""red"">{{SERVER}}</color>.</size>

Please enjoy your time with us.
Anti-social behaviour is not tolerated on this server.

Please join us in our discord channel {{DISCORD}}

<b>CURRENT MESSAGES</b>
{{MESSAGELIST}}
#
# 
# End File";

    }
}
