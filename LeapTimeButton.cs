// JESUS IS LORD GOD HOLY!
// ONLY THROUGH CHRIST JESUS IS THIS POSSIBLE!
// THE NATION IS DECEIVED!!
// THIS IS THE DECEPTION THAT WILL DECEIVE THE NATION BACK IN THE NAME OF JESUS!!!


// SECONDS BEFORE EFFECT VARIABLE DECIDES HOW MANY COLORS YOU MUST SEND AND THE NUMBER YOU SET IN THE
// CONSTRUCTOR YOU MUST SEND THE APPROPRIATE AMOUNT OF COLORS 
// IF APPROPRIATE AMOUNT OF COLORS ARE NOT SEND EQUAL TO THE SECONDS YOU WILL GET AN ERROR FOR SURE.
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
using System.Runtime.Serialization;
using System.IO;

namespace ResumeVideoGame
{

    [DataContract]
    public class LeapTimeButton
    {
        #region Fields
        #region time leap button



        [IgnoreDataMember]

        Color menuItemColor;


        // [DataMember]
        [IgnoreDataMember]
        Texture2D menuItem;

        [DataMember]
        Rectangle menuItemRect;

        [IgnoreDataMember]
        Color[] colorChanger;

        [DataMember]
        int secondsBeforeEffect;

        [DataMember]
        public bool masterButtonEffect;

        // song for game







        #endregion

        #region after several seconds disappear variable code
        [DataMember]
        string stateChangeTimeMarkString;
        [DataMember]
        int stateChangeTimeMarkNumber;
        [DataMember]
        bool isMarkGotten;
        [DataMember]
        bool isMarkTimeEqualToGameTime;
        [DataMember]
        bool textSeen;
        #endregion


        #region sound functionality


        SoundEffect buttonSong;
        SoundEffectInstance buttonSongInstance;
       

        #endregion


        #region Constructor Control Fields


        enum ConstructorPath
        {
            Empty, One, Two,Three 
        }

        ConstructorPath constructorPath;
        #endregion

        #endregion

        #region Constructors

        // default constructor no control over picture or color | constructor One

        public LeapTimeButton(Color[] chosenColors, int chosenSecondsAmount, Texture2D buttonTexture, Rectangle buttonDimensions)
        {
            constructorPath = ConstructorPath.One;

            menuItem = buttonTexture;
            // seconds before effect
            secondsBeforeEffect = chosenSecondsAmount;

            menuItemColor = Color.White;
            menuItemRect = buttonDimensions; // new Rectangle(0, 0, 256, 256);

            #region after several seconds disappear constructor code
            isMarkTimeEqualToGameTime = false;
            textSeen = false;
            isMarkGotten = false;
            #endregion

            // colors

            colorChanger = new Color[secondsBeforeEffect];

            for (int i = 0; i < colorChanger.Length; i++)
            {
                colorChanger[i] = chosenColors[i];
            }





        }




        // control with sound | constructor path Two

        public LeapTimeButton(Color[] chosenColors, int chosenSecondsAmount, Texture2D buttonTexture, Rectangle buttonDimensions, SoundEffect newSong)
        {
            constructorPath = ConstructorPath.Two;

            menuItem = buttonTexture;
            // seconds before effect
            secondsBeforeEffect = chosenSecondsAmount;

            menuItemColor = Color.White;
            menuItemRect = buttonDimensions; // new Rectangle(0, 0, 256, 256);


            // song code 
            buttonSong = newSong;
            buttonSongInstance = buttonSong.CreateInstance();
            #region after several seconds disappear constructor code
            isMarkTimeEqualToGameTime = false;
            textSeen = false;
            isMarkGotten = false;
            #endregion

            // colors

            colorChanger = new Color[secondsBeforeEffect];

            for (int i = 0; i < colorChanger.Length; i++)
            {
                colorChanger[i] = chosenColors[i];
            }





        }

        // constructor THREE 
        public LeapTimeButton( Texture2D buttonTexture, Rectangle buttonDimensions, SoundEffect newSong)
        {
            constructorPath = ConstructorPath.Two;

            menuItem = buttonTexture;
            // seconds before effect
            secondsBeforeEffect = 3;

            menuItemColor = Color.White;
            menuItemRect = buttonDimensions; // new Rectangle(0, 0, 256, 256);


            // song code 
            buttonSong = newSong;
            buttonSongInstance = buttonSong.CreateInstance();
            #region after several seconds disappear constructor code
            isMarkTimeEqualToGameTime = false;
            textSeen = false;
            isMarkGotten = false;
            #endregion

            // colors

            colorChanger = new Color[3];

            colorChanger[0] = Color.LightBlue;
            colorChanger[1] = Color.Blue;
            colorChanger[2] = Color.DarkBlue;




        }


        // control picture only | constructor Empty
        public LeapTimeButton()
        {

            constructorPath = ConstructorPath.Empty;
            menuItemColor = Color.White;
            menuItemRect = new Rectangle(0, 0, 256, 256);

            #region after several seconds disappear constructor code
            isMarkTimeEqualToGameTime = false;
            textSeen = false;
            isMarkGotten = false;
            #endregion

        }

        /*
        // control color only | constructor 3
        public LeapTimeButton()
        {

            menuItemColor = Color.White;
            menuItemRect = new Rectangle(0, 0, 256, 256);

            #region after several seconds disappear constructor code
            isMarkTimeEqualToGameTime = false;
            textSeen = false;
            isMarkGotten = false;
            #endregion

        }

        // control picture and color | constructor 4

        public LeapTimeButton()
        {

            menuItemColor = Color.White;
            menuItemRect = new Rectangle(0, 0, 256, 256);

            #region after several seconds disappear constructor code
            isMarkTimeEqualToGameTime = false;
            textSeen = false;
            isMarkGotten = false;
            #endregion

        }*/

        #endregion

        #region Load Content
        public void LoadContent(ContentManager Content)
        {


            
            #region sound features

            //  startSoundEffect = Content.Load<SoundEffect>("SongPath/SoundEffect - Start");
            //   startSoundSong = Content.Load<Song>("SongPath/SoundEffect - Start");
            #endregion

            //   menuItem = Content.Load<Texture2D>("LeapTimeButton/menuItemStart");
        }
        #endregion


        #region Update
        public void Update(GameTime gameTime)
        {
            #region after Several seconds disappear logic





            if (menuItemRect.Intersects(Game1.fingerLocations[0]) || menuItemRect.Intersects(Game1.fingerLocations[1]) || menuItemRect.Intersects(Game1.fingerLocations[2]) || menuItemRect.Intersects(Game1.fingerLocations[3]) || menuItemRect.Intersects(Game1.fingerLocations[4]))
            {

                if (isMarkGotten == false)
                {
                    stateChangeTimeMarkString = Game1.heldTimeCatcher.ToString();
                    stateChangeTimeMarkNumber = System.Convert.ToInt32(stateChangeTimeMarkString);

                    #region test sound engine

                    if (ConstructorPath.Two == constructorPath || ConstructorPath.Three == constructorPath)
                    {
                        
                        if (SoundState.Stopped == buttonSongInstance.State)
                        {
                            buttonSongInstance.Play();
                        }
                        
                    }

                    #endregion
                    isMarkGotten = true;
                }

                #region Color Changing Based On Time Choice From Constructor
                if (secondsBeforeEffect == 1)
                {
                    if ((stateChangeTimeMarkNumber + 1) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[0];
                    }


                    if ((stateChangeTimeMarkNumber + 2) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {

                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;

                        masterButtonEffect = true;
                    }
                }

                if (secondsBeforeEffect == 2)
                {
                    if ((stateChangeTimeMarkNumber + 1) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[0];
                    }

                    if ((stateChangeTimeMarkNumber + 2) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[1];
                    }

                    if ((stateChangeTimeMarkNumber + 3) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {

                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;

                        masterButtonEffect = true;
                    }
                }

                if (secondsBeforeEffect == 3)
                {
                    if ((stateChangeTimeMarkNumber + 1) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[0];
                    }

                    if ((stateChangeTimeMarkNumber + 2) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[1];
                    }

                    if ((stateChangeTimeMarkNumber + 3) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[2];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 4) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {

                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;

                        masterButtonEffect = true;
                    }
                }

                if (secondsBeforeEffect == 4)
                {
                    if ((stateChangeTimeMarkNumber + 1) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[0];
                    }

                    if ((stateChangeTimeMarkNumber + 2) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[1];
                    }

                    if ((stateChangeTimeMarkNumber + 3) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[2];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 4) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[3];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 5) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {

                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;

                        masterButtonEffect = true;
                    }
                }


                if (secondsBeforeEffect == 5)
                {

                    if ((stateChangeTimeMarkNumber + 1) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[0];
                    }

                    if ((stateChangeTimeMarkNumber + 2) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[1];
                    }

                    if ((stateChangeTimeMarkNumber + 3) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[2];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 4) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[3];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 5) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {

                        menuItemColor = colorChanger[4];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }
                    if ((stateChangeTimeMarkNumber + 6) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {


                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                        masterButtonEffect = true;

                    }

                }

                if (secondsBeforeEffect == 6)
                {

                    if ((stateChangeTimeMarkNumber + 1) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[0];
                    }

                    if ((stateChangeTimeMarkNumber + 2) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[1];
                    }

                    if ((stateChangeTimeMarkNumber + 3) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[2];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 4) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[3];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 5) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {

                        menuItemColor = colorChanger[4];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }
                    if ((stateChangeTimeMarkNumber + 6) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[5];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 7) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                        masterButtonEffect = true;

                    }

                }

                if (secondsBeforeEffect == 7)
                {

                    if ((stateChangeTimeMarkNumber + 1) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[0];
                    }

                    if ((stateChangeTimeMarkNumber + 2) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[1];
                    }

                    if ((stateChangeTimeMarkNumber + 3) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[2];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 4) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[3];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 5) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {

                        menuItemColor = colorChanger[4];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }
                    if ((stateChangeTimeMarkNumber + 6) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[5];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 7) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[6];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }

                    if ((stateChangeTimeMarkNumber + 8) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                        masterButtonEffect = true;

                    }

                }

                if (secondsBeforeEffect == 8)
                {
                    if ((stateChangeTimeMarkNumber + 1) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[0];
                    }

                    if ((stateChangeTimeMarkNumber + 2) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[1];
                    }

                    if ((stateChangeTimeMarkNumber + 3) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[2];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 4) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[3];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 5) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {

                        menuItemColor = colorChanger[4];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }
                    if ((stateChangeTimeMarkNumber + 6) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[5];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 7) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[6];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }

                    if ((stateChangeTimeMarkNumber + 8) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[7];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }
                    if ((stateChangeTimeMarkNumber + 9) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                        masterButtonEffect = true;

                    }
                }

                if (secondsBeforeEffect == 9)
                {
                    if ((stateChangeTimeMarkNumber + 1) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[0];
                    }

                    if ((stateChangeTimeMarkNumber + 2) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[1];
                    }

                    if ((stateChangeTimeMarkNumber + 3) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[2];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 4) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[3];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 5) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {

                        menuItemColor = colorChanger[4];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }
                    if ((stateChangeTimeMarkNumber + 6) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[5];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 7) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[6];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }

                    if ((stateChangeTimeMarkNumber + 8) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[7];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }
                    if ((stateChangeTimeMarkNumber + 9) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[8];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;

                    }
                    if ((stateChangeTimeMarkNumber + 10) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                        masterButtonEffect = true;
                    }

                }

                if (secondsBeforeEffect == 10)
                {
                    if ((stateChangeTimeMarkNumber + 1) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[0];
                    }

                    if ((stateChangeTimeMarkNumber + 2) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[1];
                    }

                    if ((stateChangeTimeMarkNumber + 3) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[2];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 4) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[3];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 5) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {

                        menuItemColor = colorChanger[4];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }
                    if ((stateChangeTimeMarkNumber + 6) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[5];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                    }

                    if ((stateChangeTimeMarkNumber + 7) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[6];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }

                    if ((stateChangeTimeMarkNumber + 8) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[7];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;


                    }
                    if ((stateChangeTimeMarkNumber + 9) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[8];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;

                    }
                    if ((stateChangeTimeMarkNumber + 10) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        menuItemColor = colorChanger[9];
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;

                    }
                    if ((stateChangeTimeMarkNumber + 11) == System.Convert.ToInt32(Game1.heldTimeCatcher))
                    {
                        isMarkTimeEqualToGameTime = true;
                        textSeen = true;
                        masterButtonEffect = true;
                    }
                }
                #endregion
            }

            else if (!menuItemRect.Intersects(Game1.fingerLocations[0]) && !menuItemRect.Intersects(Game1.fingerLocations[1]) && !menuItemRect.Intersects(Game1.fingerLocations[2]) && !menuItemRect.Intersects(Game1.fingerLocations[3]) && !menuItemRect.Intersects(Game1.fingerLocations[4]))
            {
                isMarkGotten = false;
                menuItemColor = Color.White;
                masterButtonEffect = false;
            }
            #endregion
        }
        #endregion

        #region Draw
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(menuItem, menuItemRect, menuItemColor);
        }

        #endregion


        #region Deserialization Commands Only


        #endregion
    }
}
