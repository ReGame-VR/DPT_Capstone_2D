using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MeepEngine
{
    public class RmCalibrate
        : Room
    {
        public RmCalibrate(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            bgColor = Color.Black;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        EntGameCursor cursor;

        public override void Update(GameTime gameTime)
        {
            if (Main.KeyCheckPressed(Keys.Back))
                Main.RoomGoto(Main.rmMenu);

            if (Main.KeyCheckPressed(Keys.Q))
                EntScaledKinect.nw = new Vector2(EntKinect.handPos.X, EntKinect.handPos.Y);
            if (Main.KeyCheckPressed(Keys.W))
                EntScaledKinect.ne = new Vector2(EntKinect.handPos.X, EntKinect.handPos.Y);
            if (Main.KeyCheckPressed(Keys.A))
                EntScaledKinect.sw = new Vector2(EntKinect.handPos.X, EntKinect.handPos.Y);
            if (Main.KeyCheckPressed(Keys.S))
                EntScaledKinect.se = new Vector2(EntKinect.handPos.X, EntKinect.handPos.Y);

            if (Main.KeyCheckPressed(Keys.Left))
                EntAsteroid.throwVel = Math.Max(10, EntAsteroid.throwVel - 10);
            if (Main.KeyCheckPressed(Keys.Right))
                EntAsteroid.throwVel = Math.Min(500, EntAsteroid.throwVel + 10);

            base.Update(gameTime);
        }

        public override void RoomStart()
        {
            Main.GameFullScreen();

            Main.InstanceCreate(new EntKinect(game, spriteBatch), Vector2.Zero);
            Main.InstanceCreate(new EntScaledKinect(game, spriteBatch), Vector2.Zero);

            cursor = (EntGameCursor)Main.InstanceCreate(new EntGameCursor(game, spriteBatch), Vector2.Zero);
            Main.InstanceCreate(new EntGameManager(game, spriteBatch), Vector2.Zero);
        }

        public override void Draw(GameTime gameTime)
        {
            Main.DrawText("Calibration", new Vector2(Main.roomWidth / 2 - Assets.menu.MeasureString("Calibration").X / 2, 32), Color.White, Assets.menu);
            Main.DrawText("Velocity:  " + Math.Floor(cursor.curVel.Length()).ToString(), new Vector2(48, 96), Color.White, Assets.menu);
            Main.DrawText("Threshold:  < " + EntAsteroid.throwVel.ToString() + " >", new Vector2(48, 96 + 40), Color.White, Assets.menu);

            Main.DrawSprite(Assets.kinectRGBVideo, new Vector2(Main.roomWidth/2,Main.roomHeight/2), 0f, 1f, 1f, 0.5f);

            Main.DrawSprite(Assets.plusWhite, EntScaledKinect.nw, 0f, 0.5f, 0f, 1f);
            Main.DrawSprite(Assets.plusWhite, EntScaledKinect.ne, 0f, 0.5f, 0f, 1f);
            Main.DrawSprite(Assets.plusWhite, EntScaledKinect.sw, 0f, 0.5f, 0f, 1f);
            Main.DrawSprite(Assets.plusWhite, EntScaledKinect.se, 0f, 0.5f, 0f, 1f);

            Main.DrawText("Q", EntScaledKinect.nw, Color.White, Assets.menu);
            Main.DrawText("W", EntScaledKinect.ne, Color.White, Assets.menu);
            Main.DrawText("A", EntScaledKinect.sw, Color.White, Assets.menu);
            Main.DrawText("S", EntScaledKinect.se, Color.White, Assets.menu);

            Main.DrawSprite(Assets.circleWhite, EntKinect.handPos, 0f, 1f, 0f, 1f);

            base.Draw(gameTime);
        }
    }
}
