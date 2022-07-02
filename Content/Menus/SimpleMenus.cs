using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreMenus.Content
{
    //public class TextMenu : ModMenu
    //{
    //    public override string DisplayName => "Simple Text";

    //    public override Asset<Texture2D> Logo => Mod.Assets.Request<Texture2D>("Assets/General/TextMenuLogo");

    //    public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
    //    {
    //        if (ModContent.GetInstance<MenuConfig>().MenuOnLeft == true)
    //            logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + ((float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.9f) * 16));

    //        logoRotation = MathHelper.ToRadians((float)Math.Cos(Main.GlobalTimeWrappedHourly / 1.5f) * 10);
    //        drawColor = Color.White;
    //        Color PseudoBlack = new Color(0.137f, 0.137f, 0.176f);

    //        for (int i = 0; i < 8; i++)
    //        {
    //            Vector2 offset = Vector2.UnitY.RotatedBy(MathHelper.PiOver4 * i) * 2f;
    //            spriteBatch.Draw(Logo.Value, logoDrawCenter + offset, null, PseudoBlack * 0.227f, logoRotation, Logo.Size() / 2, logoScale, SpriteEffects.None, 0);
    //        }
    //        spriteBatch.Draw(Logo.Value, logoDrawCenter, null, drawColor, logoRotation, Logo.Size() / 2, logoScale, SpriteEffects.None, 0);
    //        return false;
    //    }
    //}

    public class JungleLogo : ModMenu
    {
        public override string DisplayName => "Jungle";

        public override Asset<Texture2D> Logo => Mod.Assets.Request<Texture2D>("Assets/General/JungleLogo");

        public override int Music => MusicID.Jungle;

        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            if (ModContent.GetInstance<MenuConfig>().MenuOnLeft == true)
                logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + ((float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.9f) * 16));

            spriteBatch.Draw(Logo.Value, logoDrawCenter, null, drawColor * (Main.LogoA / 255f), logoRotation, Logo.Size() * 0.5f, logoScale, 0, 0);

            Asset<Texture2D> nightLogo = Mod.Assets.Request<Texture2D>("Assets/General/JungleLogoNight");
            spriteBatch.Draw(nightLogo.Value, logoDrawCenter, null, drawColor * (Main.LogoB / 255f), logoRotation, nightLogo.Size() * 0.5f, logoScale, 0, 0);

            return false;
        }
    }

    public class HallowLogo : ModMenu
    {
        public override string DisplayName => "Hallow";

        public override int Music => MusicID.TheHallow;

        public override Asset<Texture2D> Logo => Mod.Assets.Request<Texture2D>("Assets/General/HallowLogo");

        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            if (ModContent.GetInstance<MenuConfig>().MenuOnLeft == true)
                logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + ((float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.9f) * 16));

            spriteBatch.Draw(Logo.Value, logoDrawCenter, null, drawColor * (Main.LogoA / 255f), logoRotation, Logo.Size() * 0.5f, logoScale, 0, 0);
            
            Asset<Texture2D> nightLogo = Mod.Assets.Request<Texture2D>("Assets/General/HallowLogoNight");
            spriteBatch.Draw(nightLogo.Value, logoDrawCenter, null, drawColor * (Main.LogoB / 255f), logoRotation, nightLogo.Size() * 0.5f, logoScale, 0, 0);

            return false;
        }
    }

    public class MushroomLogo : ModMenu
    {
        public override string DisplayName => "Mushroom";

        public override Asset<Texture2D> Logo => Mod.Assets.Request<Texture2D>("Assets/General/MushroomLogo");

        public override int Music => MusicID.Mushrooms;

        public override void Update(bool isOnTitleScreen)
        {
            Main.SmoothedMushroomLightInfluence = MathHelper.Lerp(Main.SmoothedMushroomLightInfluence, 1f, 0.2f);
        }

        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            if (ModContent.GetInstance<MenuConfig>().MenuOnLeft == true)
                logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + ((float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.9f) * 16));

            return true;
        }

        public override void PostDrawLogo(SpriteBatch spriteBatch, Vector2 logoDrawCenter, float logoRotation, float logoScale, Color drawColor)
        {
            Asset<Texture2D> glow = Mod.Assets.Request<Texture2D>("Assets/General/MushroomLogoGlow");
            Color darkBlue = Color.Blue * (logoScale * 0.1f + 0.5f);
            darkBlue.A = 0;

            spriteBatch.Draw(glow.Value, logoDrawCenter, null, darkBlue, logoRotation, glow.Size() * 0.5f, logoScale, 0, 0);
        }
    }

    public class PurityBrightLogo : ModMenu
    {
        public override string DisplayName => "Bright Forest";

        public override Asset<Texture2D> Logo => Mod.Assets.Request<Texture2D>("Assets/General/PurityBrightLogo");

        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            if (ModContent.GetInstance<MenuConfig>().MenuOnLeft == true)
                logoDrawCenter = new Vector2(Main.screenWidth / 5f, Main.screenHeight / 2.2f + ((float)Math.Sin(Main.GlobalTimeWrappedHourly / 1.9f) * 16));

            spriteBatch.Draw(Logo.Value, logoDrawCenter, null, drawColor * (Main.LogoA / 255f), logoRotation, Logo.Size() * 0.5f, logoScale, 0, 0);

            Asset<Texture2D> nightLogo = Mod.Assets.Request<Texture2D>("Assets/General/PurityBrightLogoNight");
            spriteBatch.Draw(nightLogo.Value, logoDrawCenter, null, drawColor * (Main.LogoB / 255f), logoRotation, nightLogo.Size() * 0.5f, logoScale, 0, 0);

            return false;
        }
    }
}
