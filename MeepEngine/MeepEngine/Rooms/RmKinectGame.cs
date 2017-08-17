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
    public class RmKinectGame
        : Room
    {
        public RmKinectGame(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            bgColor = Color.Black;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        bool paused = false;

        public override void Update(GameTime gameTime)
        {
            if (Main.KeyCheckPressed(Keys.Space))
            {
                paused = !paused;
                active = !paused;
            }

            if (Main.KeyCheckPressed(Keys.Back))
            {
                manager.WriteSummary();
                manager.FinishWritingData();
                MediaPlayer.Stop();
                Main.RoomGoto(Main.rmMenu);
            }

            base.Update(gameTime);
        }

        EntGameManager manager;

        public override void RoomStart()
        {
            Main.GameFullScreen();

            try
            {
                MediaPlayer.Play(Assets.sndMusic);
                MediaPlayer.IsRepeating = true;
            }
            catch
            {
            
            }

            Main.InstanceCreate(new EntKinect(game, spriteBatch), Vector2.Zero);
            Main.InstanceCreate(new EntScaledKinect(game, spriteBatch), Vector2.Zero);

            Main.InstanceCreate(new EntBackground(game, spriteBatch), Vector2.Zero);
            Main.InstanceCreate(new EntGameCursor(game, spriteBatch), Vector2.Zero);
            manager = (EntGameManager)Main.InstanceCreate(new EntGameManager(game, spriteBatch), Vector2.Zero);
        }

        public override void Draw(GameTime gameTime)
        {
            if (paused)
            {
                Main.DrawText("Paused", new Vector2(Main.roomWidth / 2 - Assets.font.MeasureString("Paused").X / 2, Main.roomHeight / 2), Color.White, Assets.font);
            }
            //Main.DrawSprite(Assets.kinectRGBVideo, new Vector2(Main.roomWidth / 2, Main.roomHeight / 2), 0f, 0.5f, 0.9f, 0.25f);
            base.Draw(gameTime);
        }
    }
}
