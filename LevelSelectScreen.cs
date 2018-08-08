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
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
namespace ResumeVideoGame
{
    [DataContract]
    public class LevelSelectScreen : GameScreen
    {

        bool displayLoading;
        Texture2D backgroundImage;
        Rectangle backgroundRect;
        Texture2D levelOneImage;
        Texture2D levelTwoImage;
        Texture2D levelThreeImage;
        Texture2D levelFourImage;
        Texture2D levelFiveImage;
        GamePadState gamepadstate;
        Texture2D Aimg;
        Texture2D Bimg;
        Texture2D Ximg;
        Texture2D Yimg;
        Texture2D startImage;
        Rectangle startRect;

        Texture2D mainMenuImage;
        Texture2D loadingImg;

        Rectangle levelOneRect;
        Rectangle levelTwoRect;
        Rectangle levelThreeRect;
        Rectangle levelFourRect;
        Rectangle levelFiveRect;

        Rectangle mainMenuRect;
        Rectangle loadingRect;

        Color[] buttonColors;

        SoundEffect buttonSound;
        Song backgroundMusic;
        int numberOfSecondsForButtons;

        LeapTimeButton levelOneButton;
        LeapTimeButton levelTwoButton;
        LeapTimeButton levelThreeButton;
        LeapTimeButton levelFourButton;
        LeapTimeButton levelFiveButton;
        
        public LevelSelectScreen()
        {
            gamepadstate = new GamePadState();
            numberOfSecondsForButtons = 3;
            displayLoading = false;
            levelOneRect = new Rectangle(50, 100, 300, 100);
            levelTwoRect = new Rectangle(400, 100, 300, 100);
            levelThreeRect = new Rectangle(50, 350, 300, 100);
            levelFourRect = new Rectangle(400, 350, 300, 100);
            levelFiveRect = new Rectangle(200, 225, 300, 100);
            backgroundRect = new Rectangle(0, 0, 800, 600);
            mainMenuRect = new Rectangle(600, 500, 400, 100);
            loadingRect = new Rectangle(0, 500, 300, 75);
            startRect = new Rectangle(150, 225, 220, 50);
            buttonColors = new Color[3];
            buttonColors[0] = Color.LightBlue;
            buttonColors[1] = Color.Blue;
            buttonColors[2] = Color.DarkBlue;
        }

        #region Content

        public override void LoadContent(ContentManager Content)
        {
            Aimg = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/A");
            Bimg = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/B");
            Ximg = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/X");
            Yimg = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/Y");
            startImage = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/START");
            levelOneImage = Content.Load<Texture2D>("content/levelone");
            levelTwoImage = Content.Load<Texture2D>("content/leveltwo");
            levelThreeImage = Content.Load<Texture2D>("content/levelthree");
            levelFourImage = Content.Load<Texture2D>("content/levelfour");
            levelFiveImage = Content.Load<Texture2D>("content/levelfive");
            backgroundImage = Content.Load<Texture2D>("backgrounds/deepestmaster");
            mainMenuImage = Content.Load<Texture2D>("content/mainmenu");
            loadingImg = Content.Load<Texture2D>("content/waitloading");

            buttonSound = Content.Load<SoundEffect>("ResumeGamePlayState/boom");
            backgroundMusic = Content.Load<Song>("ResumeGamePlayState/bgmusic01");

            MediaPlayer.Play(backgroundMusic);

            levelOneButton = new LeapTimeButton(buttonColors, numberOfSecondsForButtons, levelOneImage, levelOneRect, buttonSound);
            levelTwoButton = new LeapTimeButton(buttonColors, numberOfSecondsForButtons, levelTwoImage, levelTwoRect, buttonSound);
            levelThreeButton = new LeapTimeButton(buttonColors, numberOfSecondsForButtons, levelThreeImage, levelThreeRect, buttonSound);
            levelFourButton = new LeapTimeButton(buttonColors, numberOfSecondsForButtons, levelFourImage, levelFourRect, buttonSound);
            levelFiveButton = new LeapTimeButton(buttonColors, numberOfSecondsForButtons, levelFiveImage, levelFiveRect, buttonSound);
            levelOneButton.LoadContent(Content);
            levelTwoButton.LoadContent(Content);
            levelThreeButton.LoadContent(Content);
            levelFourButton.LoadContent(Content);
            levelFiveButton.LoadContent(Content);
           
        }

   

        public override void UnloadContent()
        {


       
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            gamepadstate = GamePad.GetState(PlayerIndex.One);

            levelOneButton.Update(gameTime);
            levelTwoButton.Update(gameTime);
            levelThreeButton.Update(gameTime);
            levelFourButton.Update(gameTime);
            levelFiveButton.Update(gameTime);
            /*
            if (levelOneButton.masterButtonEffect == true || (gamepadstate.IsButtonDown(Buttons.A)) || (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.A)))
            {

                displayLoading = true;
                MediaPlayer.Stop();
                DataContractSerializer ds = new DataContractSerializer(typeof(OpeningTitleScreen));
                FileStream fs = new FileStream("StrongTitleScreen.xml", FileMode.Open);
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                ScreenManager.Instance.currentTitleScreen = (OpeningTitleScreen)ds.ReadObject(reader);
                fs.Close();
                ScreenManager.Instance.AddScreen(ScreenManager.Instance.currentTitleScreen);
            }*/

            if (levelTwoButton.masterButtonEffect == true || (gamepadstate.IsButtonDown(Buttons.B)) || (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.B)))
            {
                // this is for the hands gaame. uncomment this for hands game effects
                /*
                displayLoading = true;
                MediaPlayer.Stop();
                DataContractSerializer ds = new DataContractSerializer(typeof(OpeningTitleScreen));
                FileStream fs = new FileStream("HandsTitleScreen.xml", FileMode.Open);
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                ScreenManager.Instance.currentTitleScreen = (OpeningTitleScreen)ds.ReadObject(reader);
                fs.Close();
                ScreenManager.Instance.AddScreen(ScreenManager.Instance.currentTitleScreen);
                 */

                //this is for the wakanda con version of the game

                displayLoading = true;
                MediaPlayer.Stop();
                DataContractSerializer ds = new DataContractSerializer(typeof(OpeningTitleScreen));
                FileStream fs = new FileStream("WakandaTitleScreen.xml", FileMode.Open);
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                ScreenManager.Instance.currentTitleScreen = (OpeningTitleScreen)ds.ReadObject(reader);
                fs.Close();
                ScreenManager.Instance.AddScreen(ScreenManager.Instance.currentTitleScreen);
            }
            /*
            if (levelThreeButton.masterButtonEffect == true || (gamepadstate.IsButtonDown(Buttons.X)) || (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.X)))
            {
                displayLoading = true;
                MediaPlayer.Stop();
                DataContractSerializer ds = new DataContractSerializer(typeof(OpeningTitleScreen));
                FileStream fs = new FileStream("RopeTitleScreen.xml", FileMode.Open);
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                ScreenManager.Instance.currentTitleScreen = (OpeningTitleScreen)ds.ReadObject(reader);
                fs.Close();
                ScreenManager.Instance.AddScreen(ScreenManager.Instance.currentTitleScreen);
            }
            */
            /*
            if (levelFourButton.masterButtonEffect == true || (gamepadstate.IsButtonDown(Buttons.Y)) || (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Y)))
            {
                displayLoading = true;
                MediaPlayer.Stop();
                DataContractSerializer ds = new DataContractSerializer(typeof(OpeningTitleScreen));
                FileStream fs = new FileStream("LevelTwoTitleScreen.xml", FileMode.Open);
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                ScreenManager.Instance.currentTitleScreen = (OpeningTitleScreen)ds.ReadObject(reader);
                fs.Close();
                ScreenManager.Instance.AddScreen(ScreenManager.Instance.currentTitleScreen);
            }

            if (levelFiveButton.masterButtonEffect == true || (gamepadstate.IsButtonDown(Buttons.Start)) || (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)))
            {
                displayLoading = true;
                MediaPlayer.Stop();
                DataContractSerializer ds = new DataContractSerializer(typeof(OpeningTitleScreen));
                FileStream fs = new FileStream("DeceptionLevelTwoTitleScreen.xml", FileMode.Open);
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                ScreenManager.Instance.currentTitleScreen = (OpeningTitleScreen)ds.ReadObject(reader);
                fs.Close();
                ScreenManager.Instance.AddScreen(ScreenManager.Instance.currentTitleScreen);
            }
              */

        }


        #endregion

        #region Draw
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(backgroundImage, backgroundRect, Color.White);
            //levelOneButton.Draw(spriteBatch);
            levelTwoButton.Draw(spriteBatch);
            //levelThreeButton.Draw(spriteBatch);
            //levelFourButton.Draw(spriteBatch);
            //levelFiveButton.Draw(spriteBatch);
            if (displayLoading == true)
            {
                spriteBatch.Draw(loadingImg, loadingRect, Color.White);
            }

            //spriteBatch.Draw(Aimg, new Rectangle(50,100, 50,50), Color.White);
            spriteBatch.Draw(Bimg, new Rectangle(400, 100, 50, 50), Color.White);
            //spriteBatch.Draw(Ximg, new Rectangle(50, 350, 50, 50), Color.White);
            //spriteBatch.Draw(Yimg, new Rectangle(400, 350, 50, 50), Color.White);
            //spriteBatch.Draw(startImage, startRect, Color.White);
          

        }
        #endregion
    }
}
