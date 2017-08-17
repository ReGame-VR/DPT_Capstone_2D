using System;
using System.Collections.Generic;
using System.Linq;
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
    public class EntSequences
        : Entity
    {
        public EntSequences(Game game, SpriteBatch spriteBatch)
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

        public static List<int> mainSequence;
        public static List<int> fixedBlock;
        public static string fixedBlockString = "14346";
        public static int randomSeed = 137456;

        public static StreamWriter sequenceOutput;

        public static Random RNG;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Create()
        {

        }

        public override void Destroy()
        {

        }

        public static void SetRNG(int seed)
        {
            RNG = new Random(seed);
        }

        public static List<int> CreateTrainingSequence(int seed)
        {
            SetRNG(seed);
            fixedBlock = BlockStringToList(fixedBlockString);

            List<int> fullSequence = new List<int>();
            
            for (int i = 0; i < 10; i++)
            {
                fullSequence = AppendRandomBlock(fullSequence, fixedBlock);
                fullSequence.AddRange(fixedBlock);
                fullSequence.AddRange(fixedBlock);
                fullSequence.AddRange(fixedBlock);
            }

            return fullSequence;
        }

        public static List<int> CreateTestingSequence(int seed)
        {
            SetRNG(seed);
            fixedBlock = BlockStringToList(fixedBlockString);

            List<int> fullSequence = new List<int>();

            for (int i = 0; i < 2; i++)
            {
                fullSequence = AppendRandomBlock(fullSequence, fixedBlock);
                fullSequence.AddRange(fixedBlock);
            }

            return fullSequence;
        }

        public static List<int> AppendRandomBlock(List<int> sequence, List<int> fixedBlock)
        {
            int randNum;
            bool valid;

            for (int i = 0; i < 5; i++)
            {
                valid = false;
                while (!valid)
                {
                    randNum = RNG.Next(8);

                    // Check for repetition
                    if (sequence.Count > 0 && randNum == sequence[sequence.Count - 1])
                        continue;

                    // Check for trill
                    if (sequence.Count >= 3 && sequence[sequence.Count - 1] == sequence[sequence.Count - 3] && randNum == sequence[sequence.Count - 2])
                        continue;

                    // Check for future repetition
                    if (i == 4 && randNum == fixedBlock[0])
                        continue;

                    // Check for future trill
                    if (i == 4 && sequence[sequence.Count - 1] == fixedBlock[0] && randNum == fixedBlock[1])
                        continue;

                    sequence.Add(randNum);
                    valid = true;
                }
            }

            return sequence;
        }

        public static List<int> BlockStringToList(string fixedBlockString)
        {
            List<int> fixedBlockList = new List<int>();
            int chartoint;

            for (int i = 0; i < fixedBlockString.Length; i++)
            {
                int.TryParse(fixedBlockString[i].ToString(), out chartoint);
                fixedBlockList.Add(chartoint);
            }

            return fixedBlockList;
        }

        public static void CreateSequence()
        {
            //sequenceOutput = new StreamWriter("sequence.txt");

            if (EntSetup.sequenceType == 0)
                mainSequence = CreateTrainingSequence(randomSeed);
            else
                mainSequence = CreateTestingSequence(randomSeed);

            /*
            string sequenceString = "";
            for (int i = 0; i < mainSequence.Count; i++)
            {
                sequenceString += mainSequence[i].ToString();
                if ((i + 1) % 5 == 0)
                    sequenceString += "\r\n";
                if ((i + 1) % 20 == 0)
                    sequenceString += "\r\n";
            }

            sequenceOutput.Write(sequenceString);
            sequenceOutput.Close();
            */
        }
    }
}