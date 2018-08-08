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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    [DataContract]
    public class JobSkills : GameScreen
    {

        bool displayLoading;
        Texture2D loadingImg;
        Rectangle loadingRect;

        Texture2D csharp;
        Texture2D xna;
        Texture2D computerrepair;
        Texture2D hardwarespecialist;

        Song backgroundmusic;

        GamePadState gamepadstate;

        Texture2D background;
        [DataMember]
        Rectangle backgroundRect;

        [DataMember]
        string backgroundmusicPath;

        [DataMember]
        string backgroundPath;

        Texture2D mainMenuImg;
        Rectangle mainMenuRect;
        SoundEffect mainMenuButtonSound;
        Color[] mainMenuColors;
        LeapTimeButton mainMenuButton;
        
        public JobSkills()
        {
            gamepadstate = new GamePadState();
            mainMenuColors = new Color[3];
            mainMenuColors[0] = Color.LightBlue;
            mainMenuColors[1] = Color.Blue;
            mainMenuColors[2] = Color.DarkBlue;
            mainMenuRect = new Rectangle(200, 400, 300, 75);
            backgroundRect = new Rectangle(0, 0, 800, 600);
            backgroundmusicPath = "jobskills/bgmusic01";
            backgroundPath = "jobskills/jobskills";

            displayLoading = false;
        }
        

        /*
        [OnDeserializing]
        public void JobSkillsDeserialization(StreamingContext context)
        {
            backgroundRect = new Rectangle(0, 0, 800, 600);
            backgroundmusicPath = "jobskills/bgmusic01";
            backgroundPath = "jobskills/jobskills";
        }*/

   
       public override void LoadContent(ContentManager Content)
        {
            displayLoading = false;
            gamepadstate = new GamePadState();
            mainMenuColors = new Color[3];
            mainMenuColors[0] = Color.LightBlue;
            mainMenuColors[1] = Color.Blue;
            mainMenuColors[2] = Color.DarkBlue;
            mainMenuRect = new Rectangle(200, 400, 300, 75);
            backgroundRect = new Rectangle(0, 0, 800, 600);
            base.LoadContent(Content);
            // Create a new SpriteBatch, which can be used to draw textures.

            loadingImg = Content.Load<Texture2D>("content/waitloading");
            loadingRect = new Rectangle(0, 0, 400, 100);

            backgroundmusic = Content.Load<Song>(backgroundmusicPath);
            MediaPlayer.Play(backgroundmusic);
            background = Content.Load<Texture2D>(backgroundPath);
            // TODO: use this.Content to load your game content here

            mainMenuImg = Content.Load<Texture2D>("content/mainmenu");

            mainMenuButtonSound = Content.Load<SoundEffect>("ResumeGamePlayState/boom");

            mainMenuButton = new LeapTimeButton(mainMenuColors, 3, mainMenuImg, mainMenuRect, mainMenuButtonSound);

            mainMenuButton.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        public override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
           // background.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            gamepadstate = GamePad.GetState(PlayerIndex.One);
            // Allows the game to exit
            mainMenuButton.Update(gameTime);

            if (mainMenuButton.masterButtonEffect == true)
            {
                displayLoading = true;
                MediaPlayer.Stop();
                
                ScreenManager.Instance.AddScreen(new LevelSelectScreen());
              
            }
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Start))
            {
                UnloadContent();
                displayLoading = true;
                ScreenManager.Instance.AddScreen(new LevelSelectScreen());
            }
             
            // TODO: Add your update logic here

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
           
            // TODO: Add your drawing code here

           
            spriteBatch.Draw(background, backgroundRect, Color.White);

            mainMenuButton.Draw(spriteBatch);

            if (displayLoading == true)
            {
                spriteBatch.Draw(loadingImg, loadingRect, Color.White);
            }
        }
    }
}
