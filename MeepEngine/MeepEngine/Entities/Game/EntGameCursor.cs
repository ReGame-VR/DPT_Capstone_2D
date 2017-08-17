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
    public class EntGameCursor
        : Entity
    {
        public EntGameCursor(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            Enabled = true;
            Visible = true;
            
            // Set sprite parameters
            sprite = Assets.sprRocket;
            imageAngle = 0f;
            imageScale = 0.75f;
            layer = 0.1f;
        }

        // Circular position buffer
        int posBufferLength = 10;
        List<Vector2> positionBuffer = new List<Vector2>();

        // Cursor velocity
        public Vector2 curVel = Vector2.Zero;

        // Cursor direction
        double sinAngle = 0f;
        double cosAngle = 0f;
        double angDiff = 0f;
        double angDir = 0f;
        double angGain = 0.05f;

        public override void Update(GameTime gameTime)
        {
            // Add new point to circular buffer
            if (!EntSetup.useMouse)
                positionBuffer.Add(EntScaledKinect.handPos);
            else
                positionBuffer.Add(new Vector2(Main.mouseState.X, Main.mouseState.Y));
            positionBuffer.RemoveAt(0);

            // Set position to mean of buffer
            pos = VectorListMean(positionBuffer);

            // Calculate velocity from buffer
            curVel = BufferVelocity();

            // Rotate sprite towards direction
            if (float.IsNaN(imageAngle))
                imageAngle = 0f;

            if (curVel.Length() > 25)
            {
                sinAngle = -Math.Sin(imageAngle);
                cosAngle = -Math.Cos(imageAngle);

                angDiff = Math.Acos((cosAngle * curVel.X + sinAngle * curVel.Y) / (curVel.Length()));
                angDir = Math.Sign(curVel.X * sinAngle - cosAngle * curVel.Y);

                imageAngle += (float)(angDir * angGain * angDiff);
                imageAngle %= 2 * (float)Math.PI;
            }

            // Smoke effect
            if (curVel.Length() > 25)
            {
                Main.InstanceCreate(new EntSmoke(game, spriteBatch), pos);
            }

            base.Update(gameTime);
        }

        public override void Create()
        {
            // Fill buffer with current position
            for (int i = 0; i < posBufferLength; i++)
            {
                positionBuffer.Add(EntScaledKinect.handPos);
            }

            // Set position to mean of buffer
            pos = VectorListMean(positionBuffer);
        }

        public override void Destroy()
        {

        }

        public override void Draw(GameTime gameTime)
        {
            if (EntSetup.sterileGraphics)
            {
                sprite = Assets.nosprite;
                Main.DrawSprite(Assets.sprRocketSterile, pos, 0f, imageScale, layer, 1f);
            }

            base.Draw(gameTime);
        }

        Vector2 VectorListMean(List<Vector2> list)
        {
            Vector2 meanVector;
            float x_total = 0;
            float y_total = 0;

            for (int i = 0; i < list.Count; i++)
            {
                x_total += list[i].X;
                y_total += list[i].Y;
            }

            meanVector = new Vector2(x_total / list.Count, y_total / list.Count);
            return meanVector;
        }

        Vector2 BufferVelocity()
        {
            Vector2 velocity;

            float x1 = 0;
            float x2 = 0;
            float y1 = 0;
            float y2 = 0;

            int k = 3;
            for (int i = 0; i < k; i++)
            {
                x1 += positionBuffer[i].X;
                y1 += positionBuffer[i].Y;
                x2 += positionBuffer[positionBuffer.Count - 1 - i].X;
                y2 += positionBuffer[positionBuffer.Count - 1 - i].Y;
            }

            x1 /= k;
            x2 /= k;
            y1 /= k;
            y2 /= k;

            velocity = new Vector2(x2 - x1, y2 - y1);

            return velocity;
        }
    }
}