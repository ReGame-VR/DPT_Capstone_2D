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
    public class Main
        : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        // Room dimensions
        public static int roomWidth = 800;
        public static int roomHeight = 600;

        // Instance creation/removal queue
        public static List<Entity> instanceCreationQueue = new List<Entity>();
        public static List<Entity> instanceRemovalQueue = new List<Entity>();

        // Keyboard input
        public static KeyboardState keyState;
        public static KeyboardState keyStatePrev;

        // Mouse input
        public static MouseState mouseState;
        public static MouseState mouseStatePrev;

        // Declare rooms
        public static List<Room> rooms = new List<Room>();
        public static Room activeRoom;

        public static RmMenu rmMenu;
        public static RmKinectGame rmKinectGame;
        public static RmCalibrate rmCalibrate;
        public static RmGameOver rmGameOver;

        // RNG
        public static Random rand = new Random();

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);

            // Set room dimensions
            graphics.PreferredBackBufferWidth = roomWidth;
            graphics.PreferredBackBufferHeight = roomHeight;

            // Set full screen
            graphics.IsFullScreen = false;

            // Is mouse visible
            IsMouseVisible = true;

            // Setup Kinect
            EntKinect.FindKinect();

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load sprites and fonts
            Assets.Load(Content);

            // Add all rooms
            rmMenu = (RmMenu)AddRoom(new RmMenu(this, spriteBatch));
            rmKinectGame = (RmKinectGame)AddRoom(new RmKinectGame(this, spriteBatch));
            rmCalibrate = (RmCalibrate)AddRoom(new RmCalibrate(this, spriteBatch));
            rmGameOver = (RmGameOver)AddRoom(new RmGameOver(this, spriteBatch));

            // Set active room
            ActiveRoom(rmMenu);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            
            // Create queued instances
            for (int i = 0; i < instanceCreationQueue.Count; i++)
            {
                activeRoom.entities.Add(instanceCreationQueue[i]);
                instanceCreationQueue[i].Create();
            }
            instanceCreationQueue.Clear();

            // Update active room
            activeRoom.Update(gameTime);

            // Remove queued instances
            for (int i = 0; i < instanceRemovalQueue.Count; i++)
            {
                activeRoom.entities.Remove(instanceRemovalQueue[i]);
                instanceRemovalQueue[i].Destroy();
            }
            instanceRemovalQueue.Clear();

            base.Update(gameTime);

            keyStatePrev = keyState;
            mouseStatePrev = mouseState;
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            GraphicsDevice.Clear(activeRoom.bgColor);

            // Draw active room
            activeRoom.Draw(gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        // Add a room
        static Room AddRoom(Room room)
        {
            rooms.Add(room);

            return room;
        }

        // Set active room
        static void ActiveRoom(Room room)
        {
            activeRoom = room;
            activeRoom.Enable();
        }


        //// STATIC METHODS

        // Go to a given room
        public static void RoomGoto(Room room)
        {
            activeRoom.Disable();
            ActiveRoom(room);
        }

        // Check if a key is down
        public static bool KeyCheck(Keys key)
        {
            return keyState.IsKeyDown(key);
        }

        // Check if a key is pressed
        public static bool KeyCheckPressed(Keys key)
        {
            return keyState.IsKeyDown(key) && keyStatePrev.IsKeyUp(key);
        }

        // Check if a key is released
        public static bool KeyCheckReleased(Keys key)
        { 
            return keyState.IsKeyUp(key) && keyStatePrev.IsKeyDown(key);
        }

        // Check if left mouse button is down
        public static bool MouseLeft()
        {
            return (mouseState.LeftButton == ButtonState.Pressed);
        }

        // Check if left mouse button is pressed
        public static bool MouseLeftPressed()
        {
            return (mouseState.LeftButton == ButtonState.Pressed) && (mouseStatePrev.LeftButton == ButtonState.Released);
        }

        // Check if left mouse button is released
        public static bool MouseLeftReleased()
        {
            return (mouseState.LeftButton == ButtonState.Released) && (mouseStatePrev.LeftButton == ButtonState.Pressed);
        }

        // Check if right mouse button is down
        public static bool MouseRight()
        {
            return (mouseState.RightButton == ButtonState.Pressed);
        }

        // Check if right mouse button is pressed
        public static bool MouseRightPressed()
        {
            return (mouseState.RightButton == ButtonState.Pressed) && (mouseStatePrev.RightButton == ButtonState.Released);
        }

        // Check if right mouse button is released
        public static bool MouseRightReleased()
        {
            return (mouseState.RightButton == ButtonState.Released) && (mouseStatePrev.RightButton == ButtonState.Pressed);
        }

        // Create an instance of an entity at given coordinates
        public static Entity InstanceCreate(Entity entity, Vector2 coords)
        {
            entity.pos = coords;
            instanceCreationQueue.Add(entity);

            return entity;
        }

        // Create list of entities of a given type
        public static List<Entity> FindEntity(Type searchtype)
        {
            List<Entity> typelist = new List<Entity>();
            for (int i = 0; i < activeRoom.entities.Count; i++)
            {
                if (activeRoom.entities[i].GetType() == searchtype)
                {
                    typelist.Add(activeRoom.entities[i]);
                }
            }

            return typelist;
        }

        // Count number of instances of a given type
        public static int CountEntity(Type type)
        {
            return FindEntity(type).Count;
        }

        // Check if an instance of a given type exists
        public static bool InstanceExists(Type type)
        {
            return FindEntity(type).Count > 0;
        }

        // Find the nearest instance of a given type to given coordinates
        public static Entity InstanceNearest(Type type, Vector2 coords)
        {
            List<Entity> entityList = FindEntity(type);
            Entity nearest = null;
            float dist;
            float nearestDist;

            if (entityList.Count > 0)
            {
                nearestDist = (entityList[0].pos.X - coords.X) * (entityList[0].pos.X - coords.X) + (entityList[0].pos.Y - coords.Y) * (entityList[0].pos.Y - coords.Y);
                nearest = entityList[0];

                for (int i = 1; i < entityList.Count; i++)
                {
                    dist = (entityList[i].pos.X - coords.X) * (entityList[i].pos.X - coords.X) + (entityList[i].pos.Y - coords.Y) * (entityList[i].pos.Y - coords.Y);
                    if (dist < nearestDist)
                    {
                        nearestDist = dist;
                        nearest = entityList[i];
                    }
                }
            }

            return nearest;
        }

        // Draw a sprite to the screen at a given location
        public static void DrawSprite(Texture2D sprite, Vector2 coords, float imageangle, float imagescale, float layer , float imagealpha)
        {
            spriteBatch.Draw(sprite, coords, null, Color.White * imagealpha, imageangle, new Vector2(sprite.Width / 2, sprite.Height / 2), imagescale, SpriteEffects.None, layer);
        }

        // Draw text to the screen at a given location
        public static void DrawText(string text, Vector2 coords, Color color, SpriteFont font)
        {
            spriteBatch.DrawString(font, text, coords, color);
        }

        // Make game full screen
        public static void GameFullScreen()
        {
            if (graphics.IsFullScreen == false)
            {
                graphics.ToggleFullScreen();
            }
        }

        // Make game windowed
        public static void GameWindowed()
        {
            if (graphics.IsFullScreen == true)
            {
                graphics.ToggleFullScreen();
            }
        }
    }
}
