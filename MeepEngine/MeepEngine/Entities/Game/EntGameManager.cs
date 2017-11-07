using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MeepEngine
{
    public class EntGameManager
        : Entity
    {
        public EntGameManager(Game game, SpriteBatch spriteBatch)
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

        // Difficulty parameters
        public float[] sunScale = new float[12] { 1f, 1f, 1f, 0.75f, 0.75f, 0.75f, 0.5f, 0.5f, 0.5f, 0.25f, 0.25f, 0.25f };
        int[] scoreDecay = new int[12] { 0, 0, 0, 20, 20, 20, 10, 10, 10, 5, 5, 5 };
        float[] delay = new float[12] { 3f, 2.5f, 2f, 1.5f, 1f, 0.75f, 0.5f, 0.5f, 0.5f, 0.25f, 0.25f, 0.25f };

        // Sun location
        public int sunLocation;
        int[] sunGradient = new int[4] { 0, -20, -30, -35 };
        public float sunShift = 0f;

        // Sun alphas
        float[] alpha = new float[4] { 0 , 0 , 0 , 0 };
        float[] alphaTarget = new float[4];
        float alphaGain = 0.05f;

        // Asteroid delay
        float delayTimer = 0f;

        // Score decay
        int decayCount = 0;

        // Score
        public static int score;
        private static int prevScore = 0;

        // Output
        public StreamWriter dataOutput;
        public StreamWriter summaryOutput;

        // Asteroid counter
        public static int totalAsteroids = 100;
        public int currentAsteroid = 0;
        public int successfulAsteroids = 0;

        // Game start countdown
        bool gameStarted = (Main.activeRoom == Main.rmCalibrate);
        double startCountdown = 5f;

        // Sequences
        public static int sequenceIndex = 0;

        public override void Update(GameTime gameTime)
        {
            // Starting countdown
            if (!gameStarted)
            {
                startCountdown -= gameTime.ElapsedGameTime.TotalSeconds;
                if (startCountdown <= 0f)
                {
                    gameStarted = true;
                }
                return;
            }

            #region No Sequences

            if (Main.activeRoom == Main.rmCalibrate || !EntSetup.enableSequences)
            {
                // Keep asteroids coming, choose new sun location
                if (currentAsteroid < totalAsteroids || Main.activeRoom == Main.rmCalibrate)
                {
                    // if there is not a current asteroid
                    if (!Main.InstanceExists(typeof(EntAsteroid)))
                    {
                        if (delayTimer < delay[EntSetup.difficulty])
                        {
                            delayTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        }
                        else
                        {
                            prevScore = score;
                            
                            currentAsteroid++;
                            Main.InstanceCreate(new EntAsteroid(game, spriteBatch), Vector2.Zero);

                            sunLocation = Main.rand.Next(4);
                            sunShift = (1 - sunScale[EntSetup.difficulty]) * ((float)Main.rand.NextDouble() - 0.5f);
                            for (int i = 0; i < 4; i++)
                                alpha[i] = 0;

                            delayTimer = 0f;
                        }
                    }
                }
                else
                {
                    // Finished all asteroids
                    if (!Main.InstanceExists(typeof(EntAsteroid)))
                    {
                        WriteSummary();
                        FinishWritingData();
                        MediaPlayer.Stop();
                        Main.RoomGoto(Main.rmGameOver);
                    }
                }
            } // end if no asteroid 

            #endregion

            #region Sequences

            if (EntSetup.enableSequences && Main.activeRoom != Main.rmCalibrate)
            {
                // Keep asteroids coming, choose new sun location
                if (sequenceIndex < EntSequences.mainSequence.Count)
                {
                    if (!Main.InstanceExists(typeof(EntAsteroid)))
                    {
                        if (delayTimer < delay[EntSetup.difficulty])
                        {
                            delayTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        }
                        else
                        {
                            sequenceIndex++;
                            Main.InstanceCreate(new EntAsteroid(game, spriteBatch), Vector2.Zero);

                            sunLocation = Main.rand.Next(4);
                            sunShift = (1 - sunScale[EntSetup.difficulty]) * ((float)Main.rand.NextDouble() - 0.5f);
                            for (int i = 0; i < 4; i++)
                                alpha[i] = 0;

                            delayTimer = 0f;
                        }
                    }
                }
                else
                {
                    // Finished all asteroids
                    if (!Main.InstanceExists(typeof(EntAsteroid)))
                    {
                        WriteSummary();
                        FinishWritingData();
                        MediaPlayer.Stop();
                        Main.RoomGoto(Main.rmGameOver);
                    }
                }
            }

            #endregion

            // Score decay
            if (scoreDecay[EntSetup.difficulty] != 0)
            {
                if(decayCount != scoreDecay[EntSetup.difficulty])
                {
                    decayCount++;
                }
                else
                {
                    score--;
                    decayCount = 0;
                }
            }

            base.Update(gameTime);
        }

        string path;

        public override void Create()
        {
            score = 0;
            sunLocation = Main.rand.Next(4);

            if (/*!EntSetup.freePlay &&*/ Main.activeRoom != Main.rmCalibrate)
            {
                // Data output
                path = EntSetup.dataDirectory + EntSetup.SpecificSubjectPath();
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += EntSetup.SpecificSubjectFile();
                dataOutput = new StreamWriter(path);

                try { dataOutput.WriteLine("Trial #,Catch Time,Throw Time,Caught,Thrown,Hit Target,Score/Trial"); }
                catch { Main.RoomGoto(Main.rmMenu); }

                // Summary output
                path = EntSetup.dataDirectory + EntSetup.SummaryFilePath();
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += EntSetup.SummaryFile();

                if (!File.Exists(path))
                {
                    summaryOutput = new StreamWriter(path);
                    summaryOutput.WriteLine("Day,Block,Difficulty,Score,Successful Asteroids,Total Asteroids,Success Rate,Range of Motion,Range/Window");
                }
                else
                {
                    summaryOutput = File.AppendText(path);
                    try { summaryOutput.Write(""); }
                    catch { Main.RoomGoto(Main.rmMenu); }
                }

                // Sequences
                if (EntSetup.enableSequences)
                {
                    sequenceIndex = 0;
                }
            }
        }

        public override void Destroy()
        {

        }

        public override void Draw(GameTime gameTime)
        {
            if (Main.activeRoom != Main.rmCalibrate && EntSetup.showScore)
                Main.DrawText("Score: " + score.ToString(), new Vector2(32, 32), Color.White, Assets.font);

            if (!gameStarted)
                Main.DrawText(((int)startCountdown).ToString(), new Vector2(Main.roomWidth / 2 - Assets.font.MeasureString(((int)startCountdown).ToString()).X / 2, Main.roomHeight / 2 - Assets.font.MeasureString(((int)startCountdown).ToString()).Y / 2), Color.White, Assets.font);

            if (EntSetup.sterileGraphics)
                DrawSunSterile();
            else
                DrawSun();

            base.Draw(gameTime);
        }

        void DrawSun()
        {
            alphaTarget[0] = 0.1f + 0.3f * (float)Main.rand.NextDouble();
            alphaTarget[1] = 0.3f + 0.25f * (float)Main.rand.NextDouble();
            alphaTarget[2] = 0.45f + 0.35f * (float)Main.rand.NextDouble();
            alphaTarget[3] = 0.8f;

            for (int i = 0; i < 4; i++)
                alpha[i] -= alphaGain * (alpha[i] - alphaTarget[i]);

            if (sunLocation == 0) // North
                for (int i = 0; i < 4; i++)
                    Main.DrawSprite(Assets.sprSun, new Vector2(Main.roomWidth / 2 + Main.roomWidth * sunShift, sunGradient[i] * sunScale[EntSetup.difficulty] + 8 + (1 - sunScale[EntSetup.difficulty]) * 8), (float)Math.PI, 1f * sunScale[EntSetup.difficulty], 0.3f, alpha[i]);
            else if (sunLocation == 1) // South
                for (int i = 0; i < 4; i++)
                    Main.DrawSprite(Assets.sprSun, new Vector2(Main.roomWidth / 2 + Main.roomWidth * sunShift, Main.roomHeight - sunGradient[i] * sunScale[EntSetup.difficulty] - 8 - (1 - sunScale[EntSetup.difficulty]) * 8), 0f, 1f * sunScale[EntSetup.difficulty], 0.3f, alpha[i]);
            else if (sunLocation == 2) // East
                for (int i = 0; i < 4; i++)
                    Main.DrawSprite(Assets.sprSun, new Vector2(Main.roomWidth - sunGradient[i] * sunScale[EntSetup.difficulty] - 12 - (1 - sunScale[EntSetup.difficulty]) * 12, Main.roomHeight / 2 + Main.roomHeight * sunShift), 1.5f * (float)Math.PI, 0.75f * sunScale[EntSetup.difficulty], 0.3f, alpha[i]);
            else if (sunLocation == 3) // West
                for (int i = 0; i < 4; i++)
                    Main.DrawSprite(Assets.sprSun, new Vector2(sunGradient[i] * sunScale[EntSetup.difficulty] + 12 + (1 - sunScale[EntSetup.difficulty]) * 12, Main.roomHeight / 2 + Main.roomHeight * sunShift), 0.5f * (float)Math.PI, 0.75f * sunScale[EntSetup.difficulty], 0.3f, alpha[i]);
        }

        void DrawSunSterile()
        {
            if (sunLocation == 0) // North
                Main.DrawSprite(Assets.sprSun, new Vector2(Main.roomWidth / 2 + Main.roomWidth * sunShift, 8 + (1 - sunScale[EntSetup.difficulty]) * 8), (float)Math.PI, 1f * sunScale[EntSetup.difficulty], 0.3f, 1f);
            else if (sunLocation == 1) // South
                Main.DrawSprite(Assets.sprSun, new Vector2(Main.roomWidth / 2 + Main.roomWidth * sunShift, Main.roomHeight - 8 - (1 - sunScale[EntSetup.difficulty]) * 8), 0f, 1f * sunScale[EntSetup.difficulty], 0.3f, 1f);
            else if (sunLocation == 2) // East
                Main.DrawSprite(Assets.sprSun, new Vector2(Main.roomWidth - 12 - (1 - sunScale[EntSetup.difficulty]) * 12, Main.roomHeight / 2 + Main.roomHeight * sunShift), 1.5f * (float)Math.PI, 0.75f * sunScale[EntSetup.difficulty], 0.3f, 1f);
            else if (sunLocation == 3) // West
                Main.DrawSprite(Assets.sprSun, new Vector2( 12 + (1 - sunScale[EntSetup.difficulty]) * 12, Main.roomHeight / 2 + Main.roomHeight * sunShift), 0.5f * (float)Math.PI, 0.75f * sunScale[EntSetup.difficulty], 0.3f, 1f);
        }

        public void WriteData(float timeCatch, float timeThrow, bool successCatch, bool successThrow, bool successSun)
        {
            if (/*!EntSetup.freePlay &&*/ Main.activeRoom != Main.rmCalibrate)
                dataOutput.WriteLine(currentAsteroid.ToString() + "," + timeCatch.ToString() 
                    + "," + timeThrow.ToString() + "," + (successCatch ? 1 : 0).ToString() + "," 
                    + (successThrow ? 1 : 0).ToString() + "," + (successSun ? 1 : 0).ToString()
                    + "," + (score - prevScore).ToString());
        }

        public void FinishWritingData()
        {
            if (/*!EntSetup.freePlay &&*/ Main.activeRoom != Main.rmCalibrate)
                dataOutput.Close();
        }

        public void WriteSummary()
        {
            if (/*!EntSetup.freePlay &&*/ Main.activeRoom != Main.rmCalibrate)
            {
                float successRate = (float)successfulAsteroids / (float)currentAsteroid;
                float rangePercent = EntScaledKinect.CalculateRangeArea() / ((float)Main.roomWidth * (float)Main.roomHeight);
                summaryOutput.WriteLine(EntSetup.day.ToString() + "," + EntSetup.block.ToString() + "," + EntSetup.diffString[EntSetup.difficulty] + "," + score.ToString() + "," + successfulAsteroids.ToString() + "," + currentAsteroid.ToString() + "," + successRate.ToString() + "," + EntScaledKinect.CalculateRangeArea().ToString() + "," + rangePercent.ToString());
                summaryOutput.Close();
            }
        }
    }
}