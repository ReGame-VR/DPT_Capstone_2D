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
    public class EntMainMenu
        : Entity
    {
        public EntMainMenu(Game game, SpriteBatch spriteBatch)
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

        // Menu items
        List<string> menuItems = new List<string>();
        int menuIndex;
        int menuVertSpacing = 40;

        // Menu indent effect
        float[] indents;
        float selectionIndent = 10f;
        float selectionIndentGain = 0.25f;

        // To center menu
        float horOffset = 0;

        // Text colors
        Color colorSelected = Color.White;
        Color colorText = Color.Gray;
        Color colorRestricted = new Color(0.15f, 0.15f, 0.15f);

        public override void Update(GameTime gameTime)
        {
            // Indent effect
            for (int i = 0; i < menuItems.Count; i++)
                if (menuIndex == i)
                    indents[i] -= selectionIndentGain * (indents[i] - selectionIndent);
                else
                    indents[i] -= selectionIndentGain * indents[i];

            // Restrict menu while setup form is open
            if (EntSetup.formIsOpen)
                return;

            // Scroll through menu
            if (Main.KeyCheckPressed(Keys.Up))
                menuIndex = Math.Max(0, menuIndex - 1);

            if (Main.KeyCheckPressed(Keys.Down))
                menuIndex = Math.Min(menuItems.Count - 1, menuIndex + 1);

            // Select an option
            if (Main.KeyCheckPressed(Keys.Enter))
            {
                EntSetup.CheckMute();

                if (menuIndex == 0)
                {
                    // Start
                    Main.RoomGoto(Main.rmKinectGame);
                }
                if (menuIndex == 1)
                {
                    // Setup
                    EntSetup.ShowForm();
                }
                if (menuIndex == 2)
                {
                    // Calibration
                    Main.RoomGoto(Main.rmCalibrate);
                }
                if (menuIndex == 3)
                {
                    // Exit
                    game.Exit();
                }
            }

            base.Update(gameTime);
        }

        public override void Create()
        {
            // Add menu items
            menuItems.Add("Start");
            menuItems.Add("Setup");
            menuItems.Add("Calibration");
            menuItems.Add("Exit");

            // Determine starting menu index depending on if details have been loaded
                menuIndex = 0;

            // Initialize indent effect
            indents = new float[menuItems.Count];
            indents[menuIndex] = selectionIndent;

            // Determine horizontal offset to center menu
            for (int i = 1; i < menuItems.Count; i++)
            {
                Vector2 size = Assets.menu.MeasureString(menuItems[i]);
                if (size.X / 2 > horOffset)
                {
                    horOffset = size.X / 2;
                }
            }
        }

        public override void Destroy()
        {
            
        }


        public override void Draw(GameTime gameTime)
        {
            Color color;

            for (int i = 0; i < menuItems.Count; i++)
            {
                // Determine color of menu item
                if (menuIndex == i)
                {
                    color = colorSelected;
                }
                else
                {
                    color = colorText;
                }

                // Draw menu item text
                Main.DrawText(menuItems[i], new Vector2(0.5f * Main.roomWidth - horOffset + indents[i], 0.5f * Main.roomHeight + menuVertSpacing * i), color, Assets.menu);
            }

            base.Draw(gameTime);
        }
    }
}