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
    public class EntSmoke
        : Entity
    {
        public EntSmoke(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            Enabled = true;
            Visible = true;
            
            // Set sprite parameters
            sprite = Assets.nosprite;
            imageAngle = 0f;
            imageScale = 1f;
            layer = 0.2f;
        }

        public override void Update(GameTime gameTime)
        {
            alpha -= 0.05f;

            if (alpha <= 0)
                Kill();

            base.Update(gameTime);
        }

        float angle;
        float scale;

        float alpha = 1;

        public override void Create()
        {
            angle = (float)(2 * Math.PI * Main.rand.NextDouble());
            scale = 0.25f + 0.75f*(float)Main.rand.NextDouble();
        }

        public override void Destroy()
        {

        }

        public override void Draw(GameTime gameTime)
        {
            if( !EntSetup.sterileGraphics )
                Main.DrawSprite(Assets.sprSmoke, pos, angle, scale, layer, alpha);

            base.Draw(gameTime);
        }
    }
}