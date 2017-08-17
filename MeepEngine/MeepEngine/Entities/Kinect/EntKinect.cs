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
using Microsoft.Kinect;

namespace MeepEngine
{
    public class EntKinect
        : Entity
    {
        public EntKinect(Game game, SpriteBatch spriteBatch)
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

        // Kinect sensor
        public static KinectSensor kinect;

        // Hand details
        public static JointType handType = JointType.HandRight;
        public static Vector2 handPos = new Vector2();

        static bool InitializeKinect()
        {
            // Color stream
            kinect.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            kinect.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(kinect_ColorFrameReady);

            // Skeleton stream
            kinect.SkeletonStream.Enable(new TransformSmoothParameters()
            {
                Smoothing = 0.5f,
                Correction = 0.5f,
                Prediction = 0.5f,
                JitterRadius = 0.05f,
                MaxDeviationRadius = 0.04f
            });

            kinect.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(kinect_SkeletonFrameReady);

            try
            {
                kinect.Start();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static void FindKinect()
        {
            // Try to find sensor
            foreach (KinectSensor sensor in KinectSensor.KinectSensors)
            {
                if (sensor.Status == KinectStatus.Connected)
                {
                    kinect = sensor;
                    break;
                }
            }

            // Return if no sensor found
            if (kinect == null)
            {
                return;
            }

            // Initialize if connected
            if (kinect.Status == KinectStatus.Connected)
            {
                InitializeKinect();
            }
        }

        static void kinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame colorImageFrame = e.OpenColorImageFrame())
            {
                if (colorImageFrame != null)
                {

                    byte[] pixelsFromFrame = new byte[colorImageFrame.PixelDataLength];

                    colorImageFrame.CopyPixelDataTo(pixelsFromFrame);

                    Color[] color = new Color[colorImageFrame.Height * colorImageFrame.Width];
                    Assets.kinectRGBVideo = new Texture2D(Main.graphics.GraphicsDevice, colorImageFrame.Width, colorImageFrame.Height);

                    int index = 0;
                    for (int y = 0; y < colorImageFrame.Height; y++)
                    {
                        for (int x = 0; x < colorImageFrame.Width; x++, index += 4)
                        {
                            color[y * colorImageFrame.Width + x] = new Color(pixelsFromFrame[index + 2], pixelsFromFrame[index + 1], pixelsFromFrame[index + 0]);
                        }
                    }

                    // Set pixeldata from the ColorImageFrame to a Texture2D
                    Assets.kinectRGBVideo.SetData(color);
                }
            }
        }

        static void kinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    Skeleton[] skeletonData = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletonData);

                    Skeleton playerSkeleton = (from s in skeletonData where s.TrackingState == SkeletonTrackingState.Tracked select s).FirstOrDefault();
                    
                    if (playerSkeleton != null)
                    {
                        Joint hand = playerSkeleton.Joints[handType];
                        handPos = new Vector2(((hand.Position.X + 1) / 2) * Main.roomWidth, ((-hand.Position.Y + 1) / 2) * Main.roomHeight);

                        //new Vector2(((playerSkeleton.Joints[JointType.HipCenter].Position.X + 1) / 2) * Main.roomWidth, ((-playerSkeleton.Joints[JointType.HipCenter].Position.Y + 1) / 2) * Main.roomHeight + 64);
                    }
                }
            }
        }
    }
}