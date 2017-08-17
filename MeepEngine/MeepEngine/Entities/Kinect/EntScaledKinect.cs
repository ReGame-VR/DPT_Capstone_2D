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
    public class EntScaledKinect
        : Entity
    {
        public EntScaledKinect(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            Enabled = true;
            Visible = true;
            
            // Set sprite parameters
            sprite = Assets.nosprite;
            imageAngle = 0f;
            imageScale = 1f;
            layer = 0f;
        }

        // Quadrilateral range
        public static Vector2 nw = new Vector2(285, 225);
        public static Vector2 ne = new Vector2(480, 170);
        public static Vector2 sw = new Vector2(295, 295);
        public static Vector2 se = new Vector2(525, 300);

        // Scaled position
        public static Vector2 handPos = new Vector2(0, 0);

        public override void Update(GameTime gameTime)
        {
            handPos = ScalePoint(EntKinect.handPos);
            base.Update(gameTime);
        }

        public override void Create()
        {

        }

        public override void Destroy()
        {

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        Vector2 ScalePoint(Vector2 absPoint)
        {
            Vector2 scaledPoint = new Vector2();
            float top;
            float bottom;
            float left;
            float right;

            // Interpolate
            top = nw.Y + ((absPoint.X - nw.X) / (ne.X - nw.X)) * (ne.Y - nw.Y);
            bottom = sw.Y + ((absPoint.X - sw.X) / (se.X - sw.X)) * (se.Y - sw.Y);
            left = nw.X + ((absPoint.Y - nw.Y) / (sw.Y - nw.Y)) * (sw.X - nw.X);
            right = ne.X + ((absPoint.Y - ne.Y) / (se.Y - ne.Y)) * (se.X - ne.X);

            // Scale
            scaledPoint.X = ((absPoint.X - left) / (right - left)) * Main.roomWidth;
            scaledPoint.Y = ((absPoint.Y - top) / (bottom - top)) * Main.roomHeight;

            // Clamp
            scaledPoint.X = Math.Min(Math.Max(scaledPoint.X, 0), Main.roomWidth);
            scaledPoint.Y = Math.Min(Math.Max(scaledPoint.Y, 0), Main.roomHeight);

            return scaledPoint;
        }

        public static float CalculateRangeArea()
        {
            Vector2 a = ne - nw;
            Vector2 b = sw - nw;
            Vector2 c = sw - se;
            Vector2 d = ne - se;

            float area1;
            float area2;

            area1 = Math.Abs(a.X * b.Y - a.Y * b.X) / 2;
            area2 = Math.Abs(c.X * d.Y - c.Y * d.X) / 2;

            return area1 + area2;
        }
    }
}