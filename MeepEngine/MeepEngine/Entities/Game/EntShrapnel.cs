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
    public class EntShrapnel
        : Entity
    {
        public EntShrapnel(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            Enabled = true;
            Visible = true;
            
            // Set sprite parameters
            sprite = Assets.nosprite;
            imageAngle = 0f;
            imageScale = 1f;
            layer = 0.18f;
        }

        public override void Update(GameTime gameTime)
        {
            alpha -= 0.025f;

            pos.X += (float)Math.Cos(angle) * 8.35f;
            pos.Y -= (float)Math.Sin(angle) * 8.35f;

            imageAngle += 0.1f;

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
            scale = 0.5f + 0.5f * (float)Main.rand.NextDouble();

            imageAngle = angle;
        }

        public override void Destroy()
        {

        }

        public override void Draw(GameTime gameTime)
        {
            if (!EntSetup.sterileGraphics)
                Main.DrawSprite(Assets.sprAsteroidBit, pos, imageAngle, scale, layer, alpha);

            base.Draw(gameTime);
        }
    }
}