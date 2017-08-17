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
    public abstract class Entity
        : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Game game;
        protected SpriteBatch spriteBatch;

        public Texture2D sprite;
        public Vector2 pos;
        public float imageAngle;
        public float imageScale;
        public float layer;
        public double[] alarm = {0,0,0,0,0,0,0,0,0,0};

        public Entity(Game game, SpriteBatch spriteBatch)
            : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            UpdateAlarms(gameTime);
        }
        
        public override void Draw(GameTime gameTime)
        {
            if (this.Visible)
            {
                Main.DrawSprite(sprite, pos, imageAngle, imageScale, layer, 1f);
            }

            base.Draw(gameTime);
        }

        // Called when an instance of an entity is created
        public virtual void Create()
        {
            // Override with actions for when object is created
        }

        // Called when an instance of an entity is destroyed
        public virtual void Destroy()
        {
            // Override with actions for when object is deleted
        }

        // Alarms
        #region Alarms

        public virtual void UpdateAlarms(GameTime gameTime)
        {
            for (int i = 0; i < 10; i++)
            {
                if (alarm[i] > 0)
                {
                    alarm[i] -= gameTime.ElapsedGameTime.TotalSeconds;
                    if (alarm[i] <= 0)
                    {
                        alarm[i] = 0;
                        if (i == 0)
                            Alarm0();
                        if (i == 1)
                            Alarm1();
                        if (i == 2)
                            Alarm2();
                        if (i == 3)
                            Alarm3();
                        if (i == 4)
                            Alarm5();
                        if (i == 5)
                            Alarm5();
                        if (i == 6)
                            Alarm6();
                        if (i == 7)
                            Alarm7();
                        if (i == 8)
                            Alarm8();
                        if (i == 9)
                            Alarm9();
                    }
                }
            }
        }

        // Override the following with actions for when an alarm goes off
        public virtual void Alarm0()
        {

        }
        public virtual void Alarm1()
        {

        }
        public virtual void Alarm2()
        {

        }
        public virtual void Alarm3()
        {

        }
        public virtual void Alarm4()
        {

        }
        public virtual void Alarm5()
        {

        }
        public virtual void Alarm6()
        {

        }
        public virtual void Alarm7()
        {

        }
        public virtual void Alarm8()
        {

        }
        public virtual void Alarm9()
        {

        }

        #endregion

        // Delete this instance
        public void Kill()
        {
            Enabled = false;
        }
    }
}
