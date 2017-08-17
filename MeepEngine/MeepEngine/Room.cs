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
    public abstract class Room
        : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Game game;
        protected SpriteBatch spriteBatch;

        public Color bgColor;

        public List<Entity> entities = new List<Entity>();
        public bool active = true;

        public Room(Game game, SpriteBatch spriteBatch)
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
            // Update entities
            if (active)
            {
                for (int i = 0; i < entities.Count; i++)
                {
                    entities[i].Update(gameTime);
                }
            }

            // Queue disabled entities for removal
            for (int i = 0; i < entities.Count; i++)
            {
                if (!entities[i].Enabled)
                {
                    Main.instanceRemovalQueue.Add(entities[i]);
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // Draw visible entities
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Visible)
                {
                    entities[i].Draw(gameTime);
                }
            }

            base.Draw(gameTime);
        }

        // Enable a room
        public virtual void Enable()
        {
            RoomStart();
        }

        // Disable a room
        public virtual void Disable()
        {
            RoomEnd();
        }

        // Called when a room is enabled
        public virtual void RoomStart()
        {
            // Override with actions for when the room starts
        }

        // Called when a room is disabled
        public virtual void RoomEnd()
        {
            // Clear room of objects
            entities.Clear();
        }
    }
}
