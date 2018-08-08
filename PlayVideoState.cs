// JESUS IS LORD! JESUS IS LORD!
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
    public class PlayVideoState : GameScreen
    {
        #region Fields
     bool displayLoading;
     Texture2D loadingImg;
     Rectangle loadingRect;
        [DataMember]
        string backgroundPath;

        [DataMember]
        string videoPath;

        GamePadState gamepadstate;
        [DataMember]
        string video2Path;

        [DataMember]
        string videogamemusicPath;

        [DataMember]
        string fontPath;

        [DataMember]
        string continueButtonImgPath;

        [DataMember]
        string soundContinueButtonPath;

        Texture2D background;
        SpriteFont font;
     [DataMember]
        Rectangle backgroundRect;
        VideoPlayer videoplayer;
        Video video;
        Video video2;
        Song videogamemusic;
        Texture2D videotexture;
     [DataMember]
        Rectangle videotexturerect;
     [DataMember]
        int state;


     enum PlayTheMusic
     {
         Yes, No
     }
     [DataMember]
     PlayTheMusic playTheMusic;

        LeapTimeButton continueButton;
        Texture2D continueButtonImg;
     [DataMember]
        Rectangle continueButtonRect;
        SoundEffect soundContinueButton;

     enum LevelChoice
     {
         LevelOne, LevelTwo,LevelThree,LevelFour,LevelFive
     }
     [DataMember]
     LevelChoice levelChoice;
        #endregion
/*
        #region Constructors
        public PlayVideoState()
        {
   
            // TODO: Add your initialization logic here
            videotexturerect = new Rectangle(0, 120, 512, 256);
            state = 0;
            backgroundRect = new Rectangle(0, 0, 800, 600);
            backgroundPath = "PlayVideoState/backgroundcode";
            videoPath = "PlayVideoState/deepestmasterofcode";
            video2Path = "PlayVideoState/computerrepairspeedvideofinal";
            videogamemusicPath = "PlayVideoState/bgmusic01";
            fontPath = "ResumeGamePlayState/SpriteFont1";
            continueButtonImgPath = "LeapTimeButton/continue";
            soundContinueButtonPath = "ResumeGamePlayState/boom";
            levelChoice = LevelChoice.LevelOne;
        }
        
        public PlayVideoState(int newstate)
        {

            // TODO: Add your initialization logic here
            videotexturerect = new Rectangle(0, 120, 512, 256);
            this.state = newstate;
            backgroundRect = new Rectangle(0, 0, 800, 600);
            backgroundPath = "PlayVideoState/backgroundcode";
            videoPath = "PlayVideoState/deepestmasterofcode";
            video2Path = "PlayVideoState/computerrepairspeedvideofinal";
            videogamemusicPath = "PlayVideoState/bgmusic01";
            fontPath = "ResumeGamePlayState/SpriteFont1";
            continueButtonImgPath = "LeapTimeButton/continue";
            soundContinueButtonPath = "ResumeGamePlayState/boom";
            levelChoice = LevelChoice.LevelOne;
        }
        #endregion
 */
        [OnDeserializing]
        public void PlayVideoStateDeserialization(StreamingContext context)
        {

            gamepadstate = new GamePadState();
            playTheMusic = PlayTheMusic.Yes;
            // TODO: Add your initialization logic here
            videotexturerect = new Rectangle(0, 120, 512, 256);
            this.state = 0;
            backgroundRect = new Rectangle(0, 0, 800, 600);
            backgroundPath = "PlayVideoState/backgroundcode";
            videoPath = "PlayVideoState/deepestmasterofcode";
            video2Path = "PlayVideoState/computerrepairspeedvideofinal";
            videogamemusicPath = "PlayVideoState/bgmusic01";
            fontPath = "ResumeGamePlayState/SpriteFont1";
            continueButtonImgPath = "LeapTimeButton/continue";
            soundContinueButtonPath = "ResumeGamePlayState/boom";
            levelChoice = LevelChoice.LevelOne;

            displayLoading = false;
        }
  
        #region Content
   
        public override void LoadContent(ContentManager Content)
        {

    
            // Create a new SpriteBatch, which can be used to draw textures.
            base.LoadContent(Content);
            background = Content.Load<Texture2D>(backgroundPath);
            videoplayer = new VideoPlayer();
            video = Content.Load<Video>(videoPath);
            video2 = Content.Load<Video>(video2Path);
            // TODO: use this.Content to load your game content here
            videogamemusic = Content.Load<Song>(videogamemusicPath);
            font = Content.Load<SpriteFont>(fontPath);
            if (state == 0)
                videoplayer.Play(video2);
            else if (state == 1)
                videoplayer.Play(video);

            if (PlayTheMusic.Yes == playTheMusic)
            {
                MediaPlayer.Play(videogamemusic);
            }

            else if (PlayTheMusic.No == playTheMusic)
            {
                MediaPlayer.Stop();
            }
            loadingImg = Content.Load<Texture2D>("content/waitloading");
            loadingRect = new Rectangle(0, 0, 400, 100);
            continueButtonImg = Content.Load<Texture2D>(continueButtonImgPath);
            continueButtonRect = new Rectangle(50,200,239,59);
            soundContinueButton = Content.Load<SoundEffect>(soundContinueButtonPath);
            continueButton = new LeapTimeButton(continueButtonImg, continueButtonRect, soundContinueButton);
            continueButton.LoadContent(Content);
        }
        
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        /// 
        
        public override void UnloadContent()
        {


         //   background.Dispose();
           
          
           // content.Unload();
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {

            gamepadstate = GamePad.GetState(PlayerIndex.One);

            if (videoplayer.State == MediaState.Stopped)
            {
                continueButton.Update(gameTime);
            }

            if (LevelChoice.LevelOne == levelChoice)
            {
                if (((Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)) && (state == 0) && (MediaState.Stopped == videoplayer.State)) || ((continueButton.masterButtonEffect == true) && (state == 0) && (MediaState.Stopped == videoplayer.State)) || (gamepadstate.IsButtonDown(Buttons.Start)) && (state == 0) && (MediaState.Stopped == videoplayer.State))
                {
                    UnloadContent();

                    
                    //   ScreenManager.resumevideogame = new ResumeVideoGame(1);
                    displayLoading = true;
                    MediaPlayer.Stop();

                    DataContractSerializer ds = new DataContractSerializer(typeof(ResumeVideoGame));
                    FileStream fs = new FileStream("StateOneDefaultResumeGamePlay.xml", FileMode.Open);
                    XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.resumevideogame = (ResumeVideoGame)ds.ReadObject(reader);

                    fs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.resumevideogame);
                }

                if (((Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)) && (state == 1) && (MediaState.Stopped == videoplayer.State)) || (continueButton.masterButtonEffect == true) && (state == 1) && (MediaState.Stopped == videoplayer.State) || (gamepadstate.IsButtonDown(Buttons.Start) && (state == 1) && (MediaState.Stopped == videoplayer.State)))
                {
                    UnloadContent();
                    // ScreenManager.resumevideogame = new ResumeVideoGame(2);
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer ds = new DataContractSerializer(typeof(ResumeVideoGame));
                    FileStream fs = new FileStream("StateTwoDefaultResumeGamePlay.xml", FileMode.Open);
                    XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.resumevideogame = (ResumeVideoGame)ds.ReadObject(reader);
                    fs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.resumevideogame);
                }
            }

            else if (LevelChoice.LevelTwo == levelChoice)
            {

                if (((Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)) && (state == 0) && (MediaState.Stopped == videoplayer.State)) || (continueButton.masterButtonEffect == true) && (state == 0) && (MediaState.Stopped == videoplayer.State) || (gamepadstate.IsButtonDown(Buttons.Start) && (state == 0) && (MediaState.Stopped == videoplayer.State)))
                {
                    UnloadContent();


                    //   ScreenManager.resumevideogame = new ResumeVideoGame(1);
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer ds = new DataContractSerializer(typeof(ResumeVideoGame));
                    FileStream fs = new FileStream("StrongStateOneDefaultResumeGamePlay.xml", FileMode.Open);
                    XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.resumevideogame = (ResumeVideoGame)ds.ReadObject(reader);
                    fs.Close();

                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.resumevideogame);
                }

                if (((Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)) && (state == 1) && (MediaState.Stopped == videoplayer.State)) || ((continueButton.masterButtonEffect == true) && (state == 1) && (MediaState.Stopped == videoplayer.State)) || (gamepadstate.IsButtonDown(Buttons.Start) && (state == 1)) && (MediaState.Stopped == videoplayer.State))
                {
                    UnloadContent();
                    // ScreenManager.resumevideogame = new ResumeVideoGame(2);
                    DataContractSerializer ds = new DataContractSerializer(typeof(ResumeVideoGame));
                    FileStream fs = new FileStream("StrongStateTwoDefaultResumeGamePlay.xml", FileMode.Open);
                    XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.resumevideogame = (ResumeVideoGame)ds.ReadObject(reader);
                    fs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.resumevideogame);
                }
            
            }

            else if (LevelChoice.LevelThree == levelChoice)
            {

                if (((Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)) && (state == 0) && (MediaState.Stopped == videoplayer.State)) || ((continueButton.masterButtonEffect == true) && (state == 0) && (MediaState.Stopped == videoplayer.State)) || (gamepadstate.IsButtonDown(Buttons.Start) && (state == 0) && (MediaState.Stopped == videoplayer.State)))
                {
                    UnloadContent();


                    //   ScreenManager.resumevideogame = new ResumeVideoGame(1);
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer ds = new DataContractSerializer(typeof(ResumeVideoGame));
                    //FileStream fs = new FileStream("HandStateOneDefaultResumeGamePlay.xml", FileMode.Open);
                    FileStream fs = new FileStream("WakandaStateOneDefaultResumeGamePlay.xml", FileMode.Open);
                    XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.resumevideogame = (ResumeVideoGame)ds.ReadObject(reader);
                    fs.Close();

                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.resumevideogame);
                }

                if (((Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)) && (state == 1) && (MediaState.Stopped == videoplayer.State)) || ((continueButton.masterButtonEffect == true) && (state == 1) && (MediaState.Stopped == videoplayer.State)) || (gamepadstate.IsButtonDown(Buttons.Start) && (state == 1) && (MediaState.Stopped == videoplayer.State)))
                {
                    UnloadContent();
                    // ScreenManager.resumevideogame = new ResumeVideoGame(2);
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer ds = new DataContractSerializer(typeof(ResumeVideoGame));
                   // FileStream fs = new FileStream("HandStateTwoDefaultResumeGamePlay.xml", FileMode.Open);
                    FileStream fs = new FileStream("WakandaStateTwoDefaultResumeGamePlay.xml", FileMode.Open);
                    XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.resumevideogame = (ResumeVideoGame)ds.ReadObject(reader);
                    fs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.resumevideogame);
                }
            
            }

            else if (LevelChoice.LevelFour == levelChoice)
            {
                if (((Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)) && (state == 0) && (MediaState.Stopped == videoplayer.State)) || ((continueButton.masterButtonEffect == true) && (state == 0) && (MediaState.Stopped == videoplayer.State)) || (gamepadstate.IsButtonDown(Buttons.Start) && (state == 0) && (MediaState.Stopped == videoplayer.State)))
                {
                    UnloadContent();


                    //   ScreenManager.resumevideogame = new ResumeVideoGame(1);
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer ds = new DataContractSerializer(typeof(ResumeVideoGame));
                    FileStream fs = new FileStream("RopeStateOneDefaultResumeGamePlay.xml", FileMode.Open);
                    XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.resumevideogame = (ResumeVideoGame)ds.ReadObject(reader);

                    fs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.resumevideogame);
                }

                if (((Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)) && (state == 1) && (MediaState.Stopped == videoplayer.State)) || ((continueButton.masterButtonEffect == true) && (state == 1) && (MediaState.Stopped == videoplayer.State)) || (gamepadstate.IsButtonDown(Buttons.Start) && (state == 1) && (MediaState.Stopped == videoplayer.State)))
                {
                    UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    // ScreenManager.resumevideogame = new ResumeVideoGame(2);
                    DataContractSerializer ds = new DataContractSerializer(typeof(ResumeVideoGame));
                    FileStream fs = new FileStream("RopeStateTwoDefaultResumeGamePlay.xml", FileMode.Open);
                    XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.resumevideogame = (ResumeVideoGame)ds.ReadObject(reader);
                    fs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.resumevideogame);
                }
            
            }

            else if (LevelChoice.LevelFive == levelChoice)
            {

                if (((Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)) && (state == 0) && (MediaState.Stopped == videoplayer.State)) || ((continueButton.masterButtonEffect == true) && (state == 0) && (MediaState.Stopped == videoplayer.State)) || (gamepadstate.IsButtonDown(Buttons.Start) && (state == 0) && (MediaState.Stopped == videoplayer.State)))
                {
                    UnloadContent();


                    //   ScreenManager.resumevideogame = new ResumeVideoGame(1);
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer ds = new DataContractSerializer(typeof(ResumeVideoGame));
                    FileStream fs = new FileStream("DeceptionStateOneDefaultResumeGamePlay.xml", FileMode.Open);
                    XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.resumevideogame = (ResumeVideoGame)ds.ReadObject(reader);

                    fs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.resumevideogame);
                }

                if (((Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter)) && (state == 1) && (MediaState.Stopped == videoplayer.State)) || ((continueButton.masterButtonEffect == true) && (state == 1) && (MediaState.Stopped == videoplayer.State)) || (gamepadstate.IsButtonDown(Buttons.Start) && (state == 1) && (MediaState.Stopped == videoplayer.State)))
                {
                    UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    // ScreenManager.resumevideogame = new ResumeVideoGame(2);
                    DataContractSerializer ds = new DataContractSerializer(typeof(ResumeVideoGame));
                    FileStream fs = new FileStream("DeceptionStateTwoDefaultResumeGamePlay.xml", FileMode.Open);
                    XmlDictionaryReader reader =
                        XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.resumevideogame = (ResumeVideoGame)ds.ReadObject(reader);
                    fs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.resumevideogame);
                }
            
            
            }
        }


        #endregion

        #region Draw
        public override void Draw(SpriteBatch spriteBatch)
        {

          
            videotexture = videoplayer.GetTexture();
            // TODO: Add your drawing code here



            spriteBatch.Draw(background, backgroundRect, Color.White);
            spriteBatch.Draw(videotexture, videotexturerect, Color.White);


            if (videoplayer.State == MediaState.Stopped)
            {
              //  spriteBatch.DrawString(font, "HOLD CONTINUE", new Vector2(0, 0), Color.White);
                continueButton.Draw(spriteBatch);
            }

            if (displayLoading == true)
            {
                spriteBatch.Draw(loadingImg, loadingRect, Color.White);
            }
        }
        #endregion
    }
}
