// JESUS IS LORD GOD HOLY!
// ONLY THROUGH CHRIST JESUS IS THIS POSSIBLE!
// THE NATION IS DECEIVED!!
// THIS IS THE DECEPTION THAT WILL DECEIVE THE NATION BACK IN THE NAME OF JESUS!!!


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
using LeapLibrary;


namespace ResumeVideoGame
{
    class LeapMotionButtons
    {
        int count;
        // leap components
        public static LeapComponet leap;
        public static Rectangle leapCollision;
        Texture2D fingerTexture;
        Rectangle[] fingerLocations;

        //
        Texture2D[] buttons;
        Rectangle[] buttonsRect;
        GameTime storedGameTime;
        Color[] buttonColor;
        SpriteFont fontLeapButtons;


        SoundEffect soundButtonA;
        SoundEffectInstance soundInstanceButtonA;

        SoundEffect soundButtonB;
        SoundEffectInstance soundInstanceButtonB;

        SoundEffect soundButtonX;
        SoundEffectInstance soundInstanceButtonX;

        SoundEffect soundButtonY;
        SoundEffectInstance soundInstanceButtonY;
        enum LeapButtons
        {
            A, B, X, Y, nohit
        }
        LeapButtons leapButtons;

        enum ConstructorPath
        {
            Empty, Serialized
        }
        ConstructorPath constructorPath;
        public LeapMotionButtons()
        {
            count = 0;

            // leap collisions redone
            fingerLocations = new Rectangle[5];
            fingerLocations[0] = new Rectangle(800, 600, 128, 128);
            fingerLocations[1] = new Rectangle(0, 0, 128, 128);
            fingerLocations[2] = new Rectangle(0, 0, 128, 128);
            fingerLocations[3] = new Rectangle(0, 0, 128, 128);
            fingerLocations[4] = new Rectangle(0, 0, 128, 128);
            // leap collision
            leapCollision = new Rectangle(0, 0, 128, 128);
            // TODO: Add your initialization logic here
            storedGameTime = new GameTime();
            buttons = new Texture2D[4];

            /* for (int i = 0; i < 4; i++)
             {
                 buttons = new Texture2D[i];
             }*/

            
            buttonsRect = new Rectangle[4];

            buttonsRect[0] = new Rectangle(80, 130, 64, 64);
            buttonsRect[3] = new Rectangle(700, 500, 64, 64);
            buttonsRect[2] = new Rectangle(50, 500, 64, 64);
            buttonsRect[1] = new Rectangle(660, 130, 64, 64);
            buttonColor = new Color[4];
            buttonColor[0] = Color.White;
            buttonColor[1] = Color.White;
            buttonColor[2] = Color.White;
            buttonColor[3] = Color.White;
            leapButtons = LeapButtons.nohit;

        }



        public void LoadContent(ContentManager Content)
        {

            fontLeapButtons = Content.Load<SpriteFont>("content/Font1");
            buttons[0] = Content.Load<Texture2D>("buttons/A");
            buttons[1] = Content.Load<Texture2D>("buttons/B");
            buttons[2] = Content.Load<Texture2D>("buttons/X");
            buttons[3] = Content.Load<Texture2D>("buttons/Y");

            // leap component fingertips
            fingerTexture = Content.Load<Texture2D>("content/transparentFinger");


            // sound 

            soundButtonA = Content.Load<SoundEffect>("ResumeGamePlayState/boom");
            soundButtonB = Content.Load<SoundEffect>("ResumeGamePlayState/boom");
            soundButtonX = Content.Load<SoundEffect>("ResumeGamePlayState/boom");
            soundButtonY = Content.Load<SoundEffect>("ResumeGamePlayState/boom");

            soundInstanceButtonA = soundButtonA.CreateInstance();
            soundInstanceButtonB = soundButtonB.CreateInstance();
            soundInstanceButtonX = soundButtonX.CreateInstance();
            soundInstanceButtonY = soundButtonY.CreateInstance();
        }

        public void Update(GameTime gameTime)
        {

            #region button algorithim to change color

            // a button
            if (fingerLocations[0].Intersects(buttonsRect[0]) || fingerLocations[1].Intersects(buttonsRect[0]) || fingerLocations[2].Intersects(buttonsRect[0]) || fingerLocations[3].Intersects(buttonsRect[0]) || fingerLocations[4].Intersects(buttonsRect[0]))  //if (fingerLocations[0].Intersects(buttonsRect[0]))
            {

                if(SoundState.Stopped == soundInstanceButtonA.State)
                {
                    soundInstanceButtonA.Play();
                }
                buttonColor[0] = Color.Black;
                leapButtons = LeapButtons.A;
                ScreenManager.Instance.resumevideogame.Whichbuttonhit = ResumeVideoGame.WhichButtonHit.a;
                ScreenManager.Instance.resumevideogame.IsHit = true;
            }
            else
            {
                buttonColor[0] = Color.White;
             
            }

            // b button
            if (fingerLocations[0].Intersects(buttonsRect[1]) || fingerLocations[1].Intersects(buttonsRect[1]) || fingerLocations[2].Intersects(buttonsRect[1]) || fingerLocations[3].Intersects(buttonsRect[1]) || fingerLocations[4].Intersects(buttonsRect[1]))
            {

                if (SoundState.Stopped == soundInstanceButtonB.State)
                {
                    soundInstanceButtonB.Play();
                }
                buttonColor[1] = Color.Black;
                leapButtons = LeapButtons.B;
                ScreenManager.Instance.resumevideogame.Whichbuttonhit = ResumeVideoGame.WhichButtonHit.b;
                ScreenManager.Instance.resumevideogame.IsHit = true;
            }
            else
            {
                buttonColor[1] = Color.White;
          
            }

            // x button

            if (fingerLocations[0].Intersects(buttonsRect[2]) || fingerLocations[1].Intersects(buttonsRect[2]) || fingerLocations[2].Intersects(buttonsRect[2]) || fingerLocations[3].Intersects(buttonsRect[2]) || fingerLocations[4].Intersects(buttonsRect[2]))
            {
                if (SoundState.Stopped == soundInstanceButtonX.State)
                {
                    soundInstanceButtonX.Play();
                }
                buttonColor[2] = Color.Black;
                leapButtons = LeapButtons.X;
                ScreenManager.Instance.resumevideogame.Whichbuttonhit = ResumeVideoGame.WhichButtonHit.x;
                ScreenManager.Instance.resumevideogame.IsHit = true;
            }
            else
            {
                buttonColor[2] = Color.White;
               
            }


            // y button

            if (fingerLocations[0].Intersects(buttonsRect[3]) || fingerLocations[1].Intersects(buttonsRect[3]) || fingerLocations[2].Intersects(buttonsRect[3]) || fingerLocations[3].Intersects(buttonsRect[3]) || fingerLocations[4].Intersects(buttonsRect[3]))
            {

                if (SoundState.Stopped == soundInstanceButtonY.State)
                {
                    soundInstanceButtonY.Play();
                }
                buttonColor[3] = Color.Black;
                leapButtons = LeapButtons.Y;
                ScreenManager.Instance.resumevideogame.Whichbuttonhit = ResumeVideoGame.WhichButtonHit.y;
                ScreenManager.Instance.resumevideogame.IsHit = true;
            }
            else
            {
                buttonColor[3] = Color.White;
               
            }



            #endregion




        }
       
        public void Draw(SpriteBatch spriteBatch)
        {



            spriteBatch.Draw(buttons[0], buttonsRect[0], buttonColor[0]);
            spriteBatch.Draw(buttons[1], buttonsRect[1], buttonColor[1]);
            spriteBatch.Draw(buttons[2], buttonsRect[2], buttonColor[2]);
            spriteBatch.Draw(buttons[3], buttonsRect[3], buttonColor[3]);

            
            foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
            {
              
                
                float tempX = fingerLoc.X;
                float tempY = fingerLoc.Y;
                fingerLocations[count].X = (int)tempX;
                fingerLocations[count].Y = (int)tempY;
                spriteBatch.Draw(fingerTexture, fingerLocations[count], Color.White);

                count = count + 1;

                if ( count == 5)
                {
                    count = 0;
                }

                if ( count > 4 )
                {
                    count = 0;
                }


            } 
       
      
 



        }
    }
}
