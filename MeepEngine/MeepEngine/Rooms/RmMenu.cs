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
    public class RmMenu
        : Room
    {
        public RmMenu(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            bgColor = Color.Black;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void RoomStart()
        {
            Main.GameWindowed();

            Main.InstanceCreate(new EntMainMenu(game, spriteBatch), Vector2.Zero);
            Main.InstanceCreate(new EntSequences(game, spriteBatch), Vector2.Zero);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
