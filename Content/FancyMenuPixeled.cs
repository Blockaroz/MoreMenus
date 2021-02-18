using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.ModLoader;

namespace MoreMenus.Content
{
    public class FancyMenuPixeled : ModMenu
    {
        public override string DisplayName => "Consistently Styled Logo";

        private float gearRotation = 0;
        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            Asset<Texture2D> tex = ModContent.GetTexture("Blockaroz14Mod/Menus/tLogoText");
            Asset<Texture2D> texOutline = ModContent.GetTexture("Blockaroz14Mod/Menus/tLogoText_Outline");

            float wave0 = (float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.9f) * 24;
            float wave1 = (float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.667f) * 0.133f;
            logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + wave0);
            logoRotation = MathHelper.ToRadians((float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.5f) * 10);

            float scaleFactor = 1 + wave1 / 2;

            float wave3 = (float)Math.Cos(Main.GlobalTimeWrappedHourly * 2) * 2;
            float offsetFactor = wave3;
            if (offsetFactor < 0)
                offsetFactor = 0;

            gearRotation += 0.01f;
            if (gearRotation > MathHelper.TwoPi)
                gearRotation = 0;

            Color PseudoBlack = new Color(0.137f, 0.137f, 0.176f);

            spriteBatch.Draw(gradient.Value, logoDrawCenter, null, Color.White, logoRotation, tex.Size() * 0.5f, gearScale, SpriteEffects.None, 0f);

            for (int i = 0; i < 8; i++)
            {
                Vector2 offset = new Vector2(offsetFactor + 2f, 0).RotatedBy(MathHelper.PiOver2 * i / 2);
                spriteBatch.Draw(gearOutline.Value, logoDrawCenter + offset, null, PseudoBlack, gearRotation, tex.Size() * 0.5f, gearScale, SpriteEffects.None, 0f);
            }

            for (int i = 0; i < 8; i++)
            {
                Vector2 offset = new Vector2(offsetFactor / 2, 0).RotatedBy(MathHelper.PiOver2 * i / 2);
                spriteBatch.Draw(gearOutline.Value, logoDrawCenter + offset, null, Color.White, gearRotation, tex.Size() * 0.5f, gearScale, SpriteEffects.None, 0f);
            }

            spriteBatch.Draw(gear.Value, logoDrawCenter, null, Color.White, gearRotation, text.Size() * 0.5f, gearScale, SpriteEffects.None, 0f);

            return false;
        }
    }
}
