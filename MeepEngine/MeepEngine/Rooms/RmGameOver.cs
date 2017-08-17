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
    public class RmGameOver
        : Room
    {
        public RmGameOver(Game game, SpriteBatch spriteBatch)
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
            if (Main.KeyCheckPressed(Keys.Back))
            {
                Main.RoomGoto(Main.rmMenu);
            }

            base.Update(gameTime);
        }

        Vector2 txtCongratsPos;
        Vector2 txtCongratsPosTarget;
        Vector2 txtScorePos;
        Vector2 txtScorePosTarget;
        float textRiseGain = 0.1f;

        public override void RoomStart()
        {
            txtCongratsPos = new Vector2(Main.roomWidth / 2 - Assets.font.MeasureString("Congratulations!").X / 2, Main.roomHeight / 2 - Assets.font.MeasureString("Congratulations!").Y / 2);
            txtCongratsPosTarget = new Vector2(Main.roomWidth / 2 - Assets.font.MeasureString("Congratulations!").X / 2, Main.roomHeight / 2 - Assets.font.MeasureString("Congratulations!").Y / 2 - 32);

            txtScorePos = new Vector2(Main.roomWidth / 2 - Assets.menu.MeasureString("Score: " + EntGameManager.score.ToString()).X / 2, Main.roomHeight / 2 - Assets.menu.MeasureString("Score: " + EntGameManager.score.ToString()).Y / 2 + 32 + 10);
            txtScorePosTarget = new Vector2(Main.roomWidth / 2 - Assets.menu.MeasureString("Score: " + EntGameManager.score.ToString()).X / 2, Main.roomHeight / 2 - Assets.menu.MeasureString("Score: " + EntGameManager.score.ToString()).Y / 2 + 10);
        }

        public override void Draw(GameTime gameTime)
        {
            txtCongratsPos.Y -= textRiseGain * (txtCongratsPos.Y - txtCongratsPosTarget.Y);
            txtScorePos.Y -= textRiseGain * (txtScorePos.Y - txtScorePosTarget.Y);

            Main.DrawText("Congratulations!", txtCongratsPos, Color.White, Assets.font);
            Main.DrawText("Score: " + EntGameManager.score.ToString(), txtScorePos, Color.White, Assets.menu);

            base.Draw(gameTime);
        }
    }
}
