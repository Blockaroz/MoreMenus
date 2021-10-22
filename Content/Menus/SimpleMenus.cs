using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.ModLoader;

namespace MoreMenus.Content
{
    public class TextMenu : ModMenu
    {
        public override string DisplayName => "Text Logo";

        public override Asset<Texture2D> Logo => Mod.Assets.Request<Texture2D>("Assets/General/TextMenuLogo");

        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            if (ModContent.GetInstance<MenuConfig>().MenuOnLeft == true)
                logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + ((float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.9f) * 16));

            logoRotation = MathHelper.ToRadians((float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.5f) * 10);
            drawColor = Color.White;
            Color PseudoBlack = new Color(0.137f, 0.137f, 0.176f);

            for (int i = 0; i < 8; i++)
            {
                Vector2 offset = Vector2.UnitY.RotatedBy(MathHelper.PiOver4 * i) * 2f;
                spriteBatch.Draw(Logo.Value, logoDrawCenter + offset, null, PseudoBlack * 0.227f, logoRotation, Logo.Size() / 2, logoScale, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(Logo.Value, logoDrawCenter, null, drawColor, logoRotation, Logo.Size() / 2, logoScale, SpriteEffects.None, 0);
            return false;
        }
    }

    public class ContagionMenu : ModMenu
    {
        public override string DisplayName => "Special Menu";

        public override Asset<Texture2D> Logo => Mod.Assets.Request<Texture2D>("Assets/General/ContagionLogo");
    }
}
