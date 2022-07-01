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
        public override string DisplayName => "Refresh";

        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            if (ModContent.GetInstance<MenuConfig>().MenuOnLeft == true)
                logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + ((float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.9f) * 16));

            Asset<Texture2D> texture = Mod.Assets.Request<Texture2D>("Assets/FancyMenuPixeled/Logo");

            Asset<Texture2D> textureNight = Mod.Assets.Request<Texture2D>("Assets/FancyMenuPixeled/LogoNight");

            Asset<Texture2D> textureBorder = Mod.Assets.Request<Texture2D>("Assets/FancyMenuPixeled/LogoBorder");

            Asset<Texture2D> background = Mod.Assets.Request<Texture2D>("Assets/FancyMenuPixeled/LogoBackground");

            float wave1 = (float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.667f) * 0.133f;
            //logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + wave0);
            //logoRotation = MathHelper.ToRadians((float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.5f) * 10);

            //logoScale += wave1 / 2;

            float wave3 = (float)Math.Cos(Main.GlobalTimeWrappedHourly * 2) * 2;
            float offsetFactor = wave3;
            if (offsetFactor < 0)
                offsetFactor = 0;

            Color pseudoBlack = new Color(0.137f, 0.137f, 0.176f).MultiplyRGBA(drawColor);
            Color insideGradient = Color.Lerp(new Color(114, 158, 161), new Color(158, 141, 181), Main.LogoB / 255f).MultiplyRGBA(drawColor);

            spriteBatch.Draw(background.Value, logoDrawCenter, null, insideGradient, logoRotation, texture.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);

            if (ModContent.GetInstance<MenuConfig>().MenuBorder == true)
            {
                for (int i = 0; i < 16; i++)
                {
                    Vector2 offset = new Vector2(offsetFactor + 2f, 0).RotatedBy(MathHelper.PiOver4 * i / 2);
                    spriteBatch.Draw(textureBorder.Value, logoDrawCenter + offset, null, pseudoBlack, logoRotation, textureBorder.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
                }
                for (int i = 0; i < 4; i++)
                {
                    Vector2 offset = new Vector2(offsetFactor, 0).RotatedBy(MathHelper.PiOver2 * i);
                    spriteBatch.Draw(textureBorder.Value, logoDrawCenter + offset, null, drawColor, logoRotation, textureBorder.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
                }
            }

            spriteBatch.Draw(texture.Value, logoDrawCenter, null, drawColor * (Main.LogoA / 255f), logoRotation, texture.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
            spriteBatch.Draw(textureNight.Value, logoDrawCenter, null, drawColor * (Main.LogoB / 255f), logoRotation, texture.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);

            return false;
        }
    }
}
