using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace MoreMenus
{
    public class MenuConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

		[Label("Move title logos to the left of screen")]
		[DefaultListValue(false)]
		public bool MenuOnLeft;

		[Label("Use Borders on Logos")]
		[Tooltip("Whether or not borders are shown for logos that have them")]
		[DefaultListValue(true)]
		public bool MenuBorder;
	}
}
