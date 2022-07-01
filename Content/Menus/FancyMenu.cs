using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.ModLoader;

namespace MoreMenus.Content
{
    public class FancyMenu : ModMenu
    {
        public override string DisplayName => "Sharp";

        private float _gearRotation = 0;

        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            if (ModContent.GetInstance<MenuConfig>().MenuOnLeft == true)
                logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + ((float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.9f) * 16));

            Asset<Texture2D> gear = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoGear");
            Asset<Texture2D> gearBorder = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoGearBorder");

            Asset<Texture2D> text = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoText");
            Asset<Texture2D> textBorder = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoTextBorder");

            Asset<Texture2D> tree = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoTree");
            Asset<Texture2D> treeNight = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoTreeNight");
            Asset<Texture2D> treeBorder = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoTreeBorder");

            Asset<Texture2D> background = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoBackground");
            float wave1 = (float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.667f) * 0.133f;
            float wave2 = (float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.667f) * 0.133f;
            //logoRotation = MathHelper.ToRadians((float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.5f) * 10);

            //float gearScale = 1 + wave1 / 2;
            //float treeScale = 1 + wave2;

            float wave3 = (float)Math.Cos(Main.GlobalTimeWrappedHourly * 2) * 2;
            float offsetValue = wave3;
            if (offsetValue < 0)
                offsetValue = 0;

            _gearRotation += 0.01f;
            if (_gearRotation > MathHelper.TwoPi)
                _gearRotation = 0;

            Color pseudoBlack = new Color(35, 35, 46).MultiplyRGBA(drawColor);
            Color insideGradient = Color.Lerp(new Color(114, 158, 161), new Color(158, 141, 181), Main.LogoB / 255f).MultiplyRGBA(drawColor);

            spriteBatch.Draw(background.Value, logoDrawCenter, null, insideGradient, logoRotation, background.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);

            if (ModContent.GetInstance<MenuConfig>().MenuBorder == true)
            {
                for (int i = 0; i < 8; i++)
                {
                    Vector2 offset = new Vector2(offsetValue + 2f, 0).RotatedBy(MathHelper.PiOver2 * i / 2);
                    spriteBatch.Draw(gearBorder.Value, logoDrawCenter + offset, null, pseudoBlack, _gearRotation, gearBorder.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
                    spriteBatch.Draw(treeBorder.Value, logoDrawCenter + offset, null, pseudoBlack, logoRotation, treeBorder.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
                    spriteBatch.Draw(textBorder.Value, logoDrawCenter + offset, null, pseudoBlack, logoRotation, textBorder.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
                }

                for (int i = 0; i < 8; i++)
                {
                    Vector2 offset = new Vector2(offsetValue / 2f, 0).RotatedBy(MathHelper.PiOver2 * i / 2);
                    spriteBatch.Draw(gearBorder.Value, logoDrawCenter + offset, null, drawColor, _gearRotation, gearBorder.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
                    spriteBatch.Draw(treeBorder.Value, logoDrawCenter + offset, null, drawColor, logoRotation, treeBorder.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
                    spriteBatch.Draw(textBorder.Value, logoDrawCenter + offset, null, drawColor, logoRotation, textBorder.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
                }
            }

            spriteBatch.Draw(gear.Value, logoDrawCenter, null, drawColor, _gearRotation, gear.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
            spriteBatch.Draw(tree.Value, logoDrawCenter, null, drawColor * (Main.LogoA / 255f), logoRotation, tree.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
            spriteBatch.Draw(treeNight.Value, logoDrawCenter, null, drawColor * (Main.LogoB / 255f), logoRotation, tree.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
            spriteBatch.Draw(text.Value, logoDrawCenter, null, drawColor, logoRotation, text.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);

            return false;
        }
    }
}
