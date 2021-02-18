﻿using Microsoft.Xna.Framework;
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
        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            Asset<Texture2D> texture = ModContent.GetTexture("MoreMenus/Assets/ConsistentLogo");
            Asset<Texture2D> textureOutline = ModContent.GetTexture("MoreMenus/Assets/ConsistentLogo_Outline");
            Asset<Texture2D> gradient = ModContent.GetTexture("MoreMenus/Assets/tLogoGradient");
            float wave0 = (float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.9f) * 24;
            float wave1 = (float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.667f) * 0.133f;
            logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + wave0);
            logoRotation = MathHelper.ToRadians((float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.5f) * 10);

            logoScale += wave1 / 2;

            float wave3 = (float)Math.Cos(Main.GlobalTimeWrappedHourly * 2) * 2;
            float offsetFactor = wave3;
            if (offsetFactor < 0)
                offsetFactor = 0;

            Color PseudoBlack = new Color(0.137f, 0.137f, 0.176f);

            spriteBatch.Draw(gradient.Value, logoDrawCenter, null, Color.White, logoRotation, texture.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);

            for (int i = 0; i < 16; i++)
            {
                Vector2 offset = new Vector2(offsetFactor + 2f, 0).RotatedBy(MathHelper.PiOver4 * i / 2);
                spriteBatch.Draw(textureOutline.Value, logoDrawCenter + offset, null, PseudoBlack, logoRotation, textureOutline.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < 4; i++)
            {
                Vector2 offset = new Vector2(offsetFactor, 0).RotatedBy(MathHelper.PiOver2 * i);
                spriteBatch.Draw(textureOutline.Value, logoDrawCenter + offset, null, Color.White, logoRotation, textureOutline.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
            }

            spriteBatch.Draw(texture.Value, logoDrawCenter, null, Color.White, logoRotation, texture.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);

            return false;
        }
    }
}
