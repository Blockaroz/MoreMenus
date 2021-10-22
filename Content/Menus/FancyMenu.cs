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
        public override string DisplayName => "Sharp Logo";

        private float _gearRotation = 0;
        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            if (ModContent.GetInstance<MenuConfig>().MenuOnLeft == true)
                logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + ((float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.9f) * 16));

            Asset<Texture2D> gear = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoGear");
            Asset<Texture2D> gearBorder = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoGear_Border");

            Asset<Texture2D> text = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoText");
            Asset<Texture2D> textBorder = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoText_Border");

            Asset<Texture2D> tree = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoTree");
            Asset<Texture2D> treeNight = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoTree_Night");
            Asset<Texture2D> treeBorder = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoTree_Border");

            Asset<Texture2D> background = Mod.Assets.Request<Texture2D>("Assets/FancyMenu/LogoBackground");
            float wave1 = (float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.667f) * 0.133f;
            float wave2 = (float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.667f) * 0.133f;
            logoRotation = MathHelper.ToRadians((float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.5f) * 10);

            float gearScale = 1 + wave1 / 2;
            float treeScale = 1 + wave2;

            float wave3 = (float)Math.Cos(Main.GlobalTimeWrappedHourly * 2) * 2;
            float offsetValue = wave3;
            if (offsetValue < 0)
                offsetValue = 0;

            _gearRotation += 0.01f;
            if (_gearRotation > MathHelper.TwoPi)
                _gearRotation = 0;

            Color PseudoBlack = new Color(0.137f, 0.137f, 0.176f);

            spriteBatch.Draw(background.Value, logoDrawCenter, null, Color.White, logoRotation, background.Size() * 0.5f, gearScale, SpriteEffects.None, 0f);

            if (ModContent.GetInstance<MenuConfig>().MenuBorder == true)
            {
                for (int i = 0; i < 8; i++)
                {
                    Vector2 offset = new Vector2(offsetValue + 2f, 0).RotatedBy(MathHelper.PiOver2 * i / 2);
                    spriteBatch.Draw(gearBorder.Value, logoDrawCenter + offset, null, PseudoBlack, _gearRotation, gearBorder.Size() * 0.5f, gearScale, SpriteEffects.None, 0f);
                    spriteBatch.Draw(treeBorder.Value, logoDrawCenter + offset, null, PseudoBlack, logoRotation, treeBorder.Size() * 0.5f, treeScale, SpriteEffects.None, 0f);
                    spriteBatch.Draw(textBorder.Value, logoDrawCenter + offset, null, PseudoBlack, logoRotation, textBorder.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
                }

                for (int i = 0; i < 8; i++)
                {
                    Vector2 offset = new Vector2(offsetValue / 2f, 0).RotatedBy(MathHelper.PiOver2 * i / 2);
                    spriteBatch.Draw(gearBorder.Value, logoDrawCenter + offset, null, Color.White, _gearRotation, gearBorder.Size() * 0.5f, gearScale, SpriteEffects.None, 0f);
                    spriteBatch.Draw(treeBorder.Value, logoDrawCenter + offset, null, Color.White, logoRotation, treeBorder.Size() * 0.5f, treeScale, SpriteEffects.None, 0f);
                    spriteBatch.Draw(textBorder.Value, logoDrawCenter + offset, null, Color.White, logoRotation, textBorder.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
                }
            }

            spriteBatch.Draw(gear.Value, logoDrawCenter, null, Color.White, _gearRotation, gear.Size() * 0.5f, gearScale, SpriteEffects.None, 0f);
            spriteBatch.Draw(tree.Value, logoDrawCenter, null, Color.White, logoRotation, tree.Size() * 0.5f, treeScale, SpriteEffects.None, 0f);
            spriteBatch.Draw(text.Value, logoDrawCenter, null, Color.White, logoRotation, text.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);

            return false;
        }
    }
}
