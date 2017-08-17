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
    public class EntAsteroid
        : Entity
    {
        public EntAsteroid(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            Enabled = true;
            Visible = true;
            
            // Set sprite parameters
            sprite = Assets.sprAsteroid;
            imageAngle = 0f;
            imageScale = 0.75f;
            layer = 0.2f;
        }

        // Difficulty parameters
        float[] velMin = new float[12] { 1.38f, 1.38f, 1.38f, 2.76f, 2.76f, 2.76f, 4.14f, 4.14f, 4.14f, 5.52f, 5.52f, 5.52f };
        float[] velDev = new float[12] { 0f, 0.69f, 1.38f, 0f, 0.69f, 1.38f, 0f, 0.69f, 1.38f, 0f, 0.69f, 1.38f };
        float[] sprScale = new float[12] { 1f, 1f, 1f, 0.75f, 0.75f, 0.75f, 0.5f, 0.5f, 0.5f, 0.4f, 0.4f, 0.4f };
        float[] throwLimit = new float[12] { 0f, 0f, 0f, 0f, 0f, 0f, 2f, 1.8f, 1.6f, 1.4f, 1.2f, 1f };
        float[] catchLimit = new float[12] { 0f, 0f, 0f, 0f, 0f, 0f, 2f, 1.8f, 1.6f, 1.4f, 1.2f, 1f };

        // Asteroid parameters
        float omega;
        float vel;
        float angle;
        float velThrown = 8.35f;

        // If held or thrown
        bool isHeld;
        bool isThrown;

        // Capture timer
        double capTimer = 0f;
        double capTime = 0.1f;
        double capDist = 40;
        bool successCatch;

        // Time limits
        double catchTimer = 0f;
        double throwTimer = 0f;

        // Throw tolerance
        public static float throwVel = 120;
        bool successThrow;

        // Into sun?
        bool successSun;
        bool horizSun;
        bool vertSun;

        // References
        EntGameCursor cursor;
        EntGameManager manager;

        public override void Update(GameTime gameTime)
        {
            // If not held, keep moving

            if (isHeld) // If held
            {
                // Throw timer and limit
                throwTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (throwLimit[EntSetup.difficulty] != 0 && throwTimer >= throwLimit[EntSetup.difficulty])
                {
                    throwTimer = throwLimit[EntSetup.difficulty];

                    // Explodes
                    Assets.sndExplode.Play();
                    Main.InstanceCreate(new EntExplosion(game, spriteBatch), pos);
                    Kill();
                }

                // Change sprite
                if (sprite == Assets.sprAsteroid)
                    sprite = Assets.sprAsteroidUsed;

                // Snap to cursor if held
                pos = cursor.pos;

                // Check if thrown
                if (cursor.curVel.Length() > throwVel)
                {
                    isHeld = false;
                    isThrown = true;
                    angle = (float)Math.Atan2(-cursor.curVel.Y, cursor.curVel.X);
                    successThrow = true;
                }
            }
            else if (!isThrown) // If neither held or thrown
            {
                // Catch timer and limit
                catchTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (catchLimit[EntSetup.difficulty] != 0 && catchTimer >= catchLimit[EntSetup.difficulty])
                {
                    catchTimer = catchLimit[EntSetup.difficulty];

                    // Explodes
                    Assets.sndExplode.Play();
                    Main.InstanceCreate(new EntExplosion(game, spriteBatch), pos);
                    Kill();
                }

                // If not held or thrown, keep floating
                imageAngle += omega;
                pos.X += vel * (float)Math.Cos(angle);
                pos.Y -= vel * (float)Math.Sin(angle);

                // Check if held
                if (Math.Sqrt(Math.Pow(pos.X - cursor.pos.X, 2) + Math.Pow(pos.Y - cursor.pos.Y, 2)) < capDist)
                {
                    if (capTimer < capTime)
                        capTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else
                    {
                        Assets.sndCatch.Play();
                        isHeld = true;
                        successCatch = true;
                    }
                }
                else
                {
                    capTimer = 0f;
                }
            }
            else // If thrown
            {
                imageAngle += 2 * omega;
                pos.X += velThrown * (float)Math.Cos(angle);
                pos.Y -= velThrown * (float)Math.Sin(angle);
            }

            // Sun boundaries
            horizSun = (pos.Y > 0.5 * Main.roomHeight + manager.sunShift * Main.roomHeight - 0.5 * Main.roomHeight * manager.sunScale[EntSetup.difficulty] &&
                        pos.Y < 0.5 * Main.roomHeight + manager.sunShift * Main.roomHeight + 0.5 * Main.roomHeight * manager.sunScale[EntSetup.difficulty]);
            vertSun = (pos.X > 0.5 * Main.roomWidth + manager.sunShift * Main.roomWidth - 0.5 * Main.roomWidth * manager.sunScale[EntSetup.difficulty] &&
                        pos.X < 0.5 * Main.roomWidth + manager.sunShift * Main.roomWidth + 0.5 * Main.roomWidth * manager.sunScale[EntSetup.difficulty]);

            // Delete if out of window, increase score if thrown into sun
            if (pos.X < 0)
            {
                if (isThrown && manager.sunLocation == 3 && horizSun) // West
                    ThrownIntoSun();
                else
                    Assets.sndMiss.Play();
                Kill();
            }
            else if (pos.X > Main.roomWidth)
            {
                if (isThrown && manager.sunLocation == 2 && horizSun) // East
                    ThrownIntoSun();
                else
                    Assets.sndMiss.Play();
                Kill();
            }
            else if (pos.Y < 0)
            {
                if (isThrown && manager.sunLocation == 0 && vertSun) // North
                    ThrownIntoSun();
                else
                    Assets.sndMiss.Play();
                Kill();
            }
            else if (pos.Y > Main.roomHeight)
            {
                if (isThrown && manager.sunLocation == 1 && vertSun) // South
                    ThrownIntoSun();
                else
                    Assets.sndMiss.Play();
                Kill();
            }

            base.Update(gameTime);
        }

        public override void Create()
        {
            // Not held or thrown
            isHeld = false;
            isThrown = false;

            successCatch = false;
            successThrow = false;

            // Not into sun yet
            successSun = false;

            // Random velocities
            omega = (2 * Main.rand.Next(2) - 1) * (0.035f + 0.035f * (float)Main.rand.NextDouble());
            vel = velMin[EntSetup.difficulty] + velDev[EntSetup.difficulty] * (float)Main.rand.NextDouble();
            if (catchLimit[EntSetup.difficulty] != 0)
                vel = Math.Min(vel, ((Main.roomHeight - 5) / 60) / catchLimit[EntSetup.difficulty]);

            // Angle
            if (Main.activeRoom != Main.rmCalibrate && EntSetup.enableSequences)
                angle = EntSequences.mainSequence[EntGameManager.sequenceIndex - 1] * 2 * (float)Math.PI / 8;
            else
                angle = 2 * (float)Math.PI * (float)Main.rand.NextDouble();

            // Image scale
            imageScale = sprScale[EntSetup.difficulty];

            // Starting image angle
            imageAngle = angle;

            // Reasonable random starting position based on angle
            if (angle < 0.25f * (float)Math.PI)
                pos = new Vector2(0, Main.roomHeight / 2 + (Main.roomHeight / 4) * (float)Main.rand.NextDouble());
            else if (angle < 0.5f * (float)Math.PI)
                pos = new Vector2(Main.roomWidth / 2 - (Main.roomWidth / 4) * (float)Main.rand.NextDouble(), Main.roomHeight);
            else if (angle < 0.75f * (float)Math.PI)
                pos = new Vector2(Main.roomWidth / 2 + (Main.roomWidth / 4) * (float)Main.rand.NextDouble(), Main.roomHeight);
            else if (angle < (float)Math.PI)
                pos = new Vector2(Main.roomWidth, Main.roomHeight / 2 + (Main.roomHeight / 4) * (float)Main.rand.NextDouble());
            else if (angle < 1.25f * (float)Math.PI)
                pos = new Vector2(Main.roomWidth, Main.roomHeight / 2 - (Main.roomHeight / 4) * (float)Main.rand.NextDouble());
            else if (angle < 1.5f * (float)Math.PI)
                pos = new Vector2(Main.roomWidth / 2 + (Main.roomWidth / 4) * (float)Main.rand.NextDouble(), 0);
            else if (angle < 1.75f * (float)Math.PI)
                pos = new Vector2(Main.roomWidth / 2 - (Main.roomWidth / 4) * (float)Main.rand.NextDouble(), 0);
            else
                pos = new Vector2(0, Main.roomHeight / 2 - (Main.roomHeight / 2) * (float)Main.rand.NextDouble());

            // Find references
            cursor = (EntGameCursor)Main.InstanceNearest(typeof(EntGameCursor), pos);
            manager = (EntGameManager)Main.InstanceNearest(typeof(EntGameManager), pos);
        }

        public override void Destroy()
        {
            manager.WriteData((float)catchTimer, (float)throwTimer, successCatch, successThrow, successSun);
        }

        bool flameSoundPlayed = false;

        public override void Draw(GameTime gameTime)
        {
            if (EntSetup.sterileGraphics)
            {
                sprite = Assets.nosprite;
                Main.DrawSprite(Assets.sprAsteroidSterile, pos, 0f, imageScale, layer, 1f);
            }

            // Flame effect
            bool exitTop;
            bool exitBottom;
            bool exitEast;
            bool exitWest;

            int exitTolerance = 64;

            if (isThrown)
            {
                exitTop = manager.sunLocation == 0 && pos.Y < exitTolerance &&
                    (pos.X > 0.5 * Main.roomWidth + manager.sunShift * Main.roomWidth - 0.5 * Main.roomWidth * manager.sunScale[EntSetup.difficulty] &&
                    pos.X < 0.5 * Main.roomWidth + manager.sunShift * Main.roomWidth + 0.5 * Main.roomWidth * manager.sunScale[EntSetup.difficulty]);
                exitBottom = manager.sunLocation == 1 && pos.Y > Main.roomHeight - exitTolerance &&
                    (pos.X > 0.5 * Main.roomWidth + manager.sunShift * Main.roomWidth - 0.5 * Main.roomWidth * manager.sunScale[EntSetup.difficulty] &&
                    pos.X < 0.5 * Main.roomWidth + manager.sunShift * Main.roomWidth + 0.5 * Main.roomWidth * manager.sunScale[EntSetup.difficulty]);
                exitEast = manager.sunLocation == 2 && pos.X > Main.roomWidth - exitTolerance &&
                    (pos.Y > 0.5 * Main.roomHeight + manager.sunShift * Main.roomHeight - 0.5 * Main.roomHeight * manager.sunScale[EntSetup.difficulty] &&
                    pos.Y < 0.5 * Main.roomHeight + manager.sunShift * Main.roomHeight + 0.5 * Main.roomHeight * manager.sunScale[EntSetup.difficulty]);
                exitWest = manager.sunLocation == 3 && pos.X < exitTolerance &&
                    (pos.Y > 0.5 * Main.roomHeight + manager.sunShift * Main.roomHeight - 0.5 * Main.roomHeight * manager.sunScale[EntSetup.difficulty] &&
                    pos.Y < 0.5 * Main.roomHeight + manager.sunShift * Main.roomHeight + 0.5 * Main.roomHeight * manager.sunScale[EntSetup.difficulty]);

                if (exitTop || exitBottom || exitEast || exitWest)
                {
                    if (!flameSoundPlayed)
                    {
                        Assets.sndFlame.Play();
                        flameSoundPlayed = true;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (!EntSetup.sterileGraphics)
                            Main.DrawSprite(Assets.sprFlame, new Vector2(pos.X - 16 * i * (float)Math.Cos(angle), pos.Y + 16 * i * (float)Math.Sin(angle)), (float)Main.rand.NextDouble(), 0.5f + 0.5f * (float)Main.rand.NextDouble(), 0.9f, 0.9f - 0.1f * i);
                    }
                }
            }

            // Catch limit feedback
            if (catchLimit[EntSetup.difficulty] != 0 && catchTimer < catchLimit[EntSetup.difficulty])
            {
                if (!EntSetup.sterileGraphics)
                    Main.DrawSprite(Assets.sprAsteroidExpired, pos, imageAngle, imageScale, 0.19f, (float)(catchTimer / catchLimit[EntSetup.difficulty]));
            }

            base.Draw(gameTime);
        }

        void ThrownIntoSun()
        {
            successSun = true;
            manager.successfulAsteroids++;
            EntGameManager.score += 100;
        }
    }
}