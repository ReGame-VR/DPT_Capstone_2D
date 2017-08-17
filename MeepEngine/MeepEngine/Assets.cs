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
    public class Assets
        : Microsoft.Xna.Framework.Game
    {
        // Font
        public static SpriteFont font;
        public static SpriteFont menu;

        // Sprites
        public static Texture2D nosprite;

        public static Texture2D circleWhite;
        public static Texture2D circleRed;
        public static Texture2D plusWhite;

        public static Texture2D sprAsteroid;
        public static Texture2D sprAsteroidBit;
        public static Texture2D sprAsteroidExpired;
        public static Texture2D sprAsteroidUsed;
        public static Texture2D sprSun;
        public static Texture2D sprRocket;
        public static Texture2D sprFlame;
        public static Texture2D sprSmoke;

        public static Texture2D sprBackground;

        public static Texture2D sprAsteroidSterile;
        public static Texture2D sprRocketSterile;
        public static Texture2D sprBackgroundSterile;

        // Sounds
        public static SoundEffect sndCatch;
        public static SoundEffect sndExplode;
        public static SoundEffect sndMiss;
        public static SoundEffect sndFlame;

        public static Song sndMusic;

        // Kinect video stream
        public static Texture2D kinectRGBVideo;

        public static void Load(ContentManager Content)
        {
            // Font
            font = Content.Load<SpriteFont>("font");
            menu = Content.Load<SpriteFont>("menu");

            // Sprites
            nosprite = Content.Load<Texture2D>(@"Sprites\nosprite");

            circleWhite = Content.Load<Texture2D>(@"Sprites\circleWhite");
            circleRed = Content.Load<Texture2D>(@"Sprites\circleRed");
            plusWhite = Content.Load<Texture2D>(@"Sprites\plusWhite");

            sprAsteroid = Content.Load<Texture2D>(@"Sprites\sprAsteroid");
            sprAsteroidBit = Content.Load<Texture2D>(@"Sprites\sprAsteroidBit");
            sprAsteroidExpired = Content.Load<Texture2D>(@"Sprites\sprAsteroidExpired");
            sprAsteroidUsed = Content.Load<Texture2D>(@"Sprites\sprAsteroidUsed");
            sprSun = Content.Load<Texture2D>(@"Sprites\sprSun");
            sprRocket = Content.Load<Texture2D>(@"Sprites\sprRocket");
            sprFlame = Content.Load<Texture2D>(@"Sprites\sprFlame");
            sprSmoke = Content.Load<Texture2D>(@"Sprites\sprSmoke");

            sprBackground = Content.Load<Texture2D>(@"Sprites\sprBackground");

            sprAsteroidSterile = Content.Load<Texture2D>(@"Sprites\sprAsteroidSterile");
            sprRocketSterile = Content.Load<Texture2D>(@"Sprites\sprRocketSterile");
            sprBackgroundSterile = Content.Load<Texture2D>(@"Sprites\sprBackgroundSterile");

            // Sounds
            sndCatch = Content.Load<SoundEffect>(@"Sounds\Catch");
            sndExplode = Content.Load<SoundEffect>(@"Sounds\Explode");
            sndMiss = Content.Load<SoundEffect>(@"Sounds\Miss");
            sndFlame = Content.Load<SoundEffect>(@"Sounds\Flame");

            sndMusic = Content.Load<Song>(@"Sounds\Music");

            // Kinect video stream
            kinectRGBVideo = new Texture2D(Main.graphics.GraphicsDevice, 640, 480);
        }
    }
}
