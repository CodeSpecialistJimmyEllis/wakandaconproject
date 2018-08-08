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
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace ResumeVideoGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    [DataContract]
    public class ResumeVideoGame : GameScreen
    {

        #region Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        Texture2D loadingImg;
        Rectangle loadingRect;
        bool displayLoading;

        #region Paths
        [DataMember]
        string boomPath;
        [DataMember]
        string JimmyEllisPath;
        [DataMember]
        string heroprojectilePath;
        [DataMember]
        string villianprojectilePath;
        [DataMember]
        string vilianOnePath;
        [DataMember]
        string villianTwoPath;
        [DataMember]
        string villianThreePath;
        [DataMember]
        string villianFourPath;
        [DataMember]
        string backgroundPath;
        [DataMember]
        string APath;
        [DataMember]
        string BPath;
        [DataMember]
        string XPath;
        [DataMember]
        string YPath;
        [DataMember]
        string fontPath;

        [DataMember]
        string deepestmasterofcodeSongPath;
        [DataMember]
        string scorePath;
        [DataMember]
        string spritefont1Path;
        [DataMember]
        string chooseImgPath; 
        #endregion
        LeapMotionButtons leapMotionButtons;
        SpriteFont font;
        bool playSound;
        Song deepestmasterofcode;
        Texture2D background;
        Texture2D chooseImg;
        bool isHit;
        public bool IsHit { get { return isHit; } set { isHit = value; }  }


        enum NextLevelDestination
        {
            CodeKing, HandColors, Strong, Rope, CodeCave, Deception
        }

        [DataMember]
        NextLevelDestination levelDestination;
       public enum WhichButtonHit
        {
            a, b, x, y, up, down, left, right
        }

        

        WhichButtonHit whichbuttonhit;
        public WhichButtonHit Whichbuttonhit 
        {
            get
            {
                return whichbuttonhit;
            }

            set
            {
                whichbuttonhit = value;
            }
        }
    
        WhichButtonHit thebuttonhit;
        /*
        enum ButtonToHit
        {
            hita,hitb,hitx,hity,hitup,hitdown,hitleft,hitright
        }

        ButtonToHit buttontohit;
        */
        //gamepad 
        GamePadState gamepadstate;

        // text appear and disappear engine code
        #region after several seconds disappear variable code
        string stateChangeTimeMarkString;
        int stateChangeTimeMarkNumber;
        bool isMarkGotten;
        bool isMarkTimeEqualToGameTime;
        bool textSeen;
        #endregion

        // Sprite Font for drawing words to the screen

        SpriteFont spritefont1;
        Color hitbuttoncolor;

        // Random number choosen
        Random random;
        int chosenrandom;


        //button textures and rectangles
        Texture2D A;
        Texture2D B;
        Texture2D X;
        Texture2D Y;

        [DataMember]
        Rectangle Arect;
        [DataMember]
        Rectangle Brect;
        [DataMember]
        Rectangle Xrect;
        [DataMember]
        Rectangle Yrect;
        [DataMember]
        Rectangle hitbuttonlocation;

        Texture2D start;

        [DataMember]
        Rectangle startrect;

        Texture2D select;

        [DataMember]
        Rectangle selectrect;

        Texture2D up;

        [DataMember]
        Rectangle uprect;

        Texture2D left;

        [DataMember]
        Rectangle leftrect;

        Texture2D down;

        [DataMember]
        Rectangle downrect;

        Texture2D right;

        [DataMember]
        Rectangle rightrect;

        Texture2D leftbutton;

        [DataMember]
        Rectangle leftbuttonrect;

        Texture2D rightbutton;

        [DataMember]
        Rectangle rightbuttonrect;

        Texture2D lefttrigger;

        [DataMember]
        Rectangle lefttriggerrect;

        Texture2D righttrigger;

        [DataMember]
        Rectangle righttriggerrect;

        Color buttoncolor;

        SoundEffect boom;
        // button hit variable locations and sizes

        [DataMember]
        int xaxis;
        [DataMember]
        int yaxis;
        [DataMember]
        int widthsize;
        [DataMember]
        int heightsize;
        Texture2D score;
        int scorenumber;

        // buton to hit variable location and sizes


        #region Code Fight GamePlay Code

        Texture2D JimmyEllis;
        [DataMember]
        Rectangle JimmyEllisRectangle;
        Color herocolor;
        Texture2D[] villians;
        [DataMember]
        Rectangle villiansrect;
        bool speedup;
        
        Texture2D heroprojectile;
        [DataMember]
        Rectangle heroprojectilerect;

        [DataMember]
        int heroprojectilespeed;
        Texture2D villianprojectile;
        [DataMember]
        Rectangle villianprojecticerect;
        Color villiancolor;
        [DataMember]
        int villianspeed;

        #endregion

        [DataMember]
        int hitxaxis;
        [DataMember]
        int hityaxis;
        [DataMember]
        int hitwidthsize;
        [DataMember]
        int hitheightsize;
        [DataMember]
        int state;
        #endregion
        /*
        #region Constructors

        
        public ResumeVideoGame(int newstate)
        {
            leapMotionButtons = new LeapMotionButtons();
            // TODO: Add your initialization logic here
            random = new Random();
            buttoncolor = new Color();
            buttoncolor = Color.White;

            #region after several seconds disappear constructor code
            isMarkTimeEqualToGameTime = false;
            textSeen = false;
            isMarkGotten = false;
            #endregion
            scorenumber = 0;

            this.state = newstate;
            playSound = false;
            // setting of button to hit variables
            xaxis = 0;
            yaxis = 150;
            widthsize = 128;
            heightsize = 128;


            #region Code Fight Initialize
            herocolor = Color.White;
            villiancolor = Color.White;
            villianspeed = 1;
            JimmyEllisRectangle = new Rectangle(0, 300, 128, 128);
            villiansrect = new Rectangle(670, 300, 128, 128);

            heroprojectilerect = new Rectangle(50, 320, 64, 128);
            heroprojectilespeed = 100;
            villianprojecticerect = new Rectangle(670, 300, 128, 128);

            #endregion
            hitbuttoncolor = Color.Magenta;

            // setting of hit button variables
            hitxaxis = 325; // hitxaxis = 650;
            hityaxis = 250; // hityaxis = 150;
            hitwidthsize = 128;
            hitheightsize = 128;
            hitbuttonlocation = new Rectangle(hitxaxis, hityaxis, hitwidthsize, hitheightsize);

            thebuttonhit = WhichButtonHit.a;

            #region Code Fight Code
            villians = new Texture2D[4];
        
            speedup = false;
         
            #endregion
            Arect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Brect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Xrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Yrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);



            isHit = false;
            uprect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            downrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            leftrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            rightrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);

            chosenrandom = 0;
            gamepadstate = new GamePadState();


            boomPath = "ResumeGamePlayState/boom";
            JimmyEllisPath = "ResumeGamePlayState/hero/hero";
            heroprojectilePath = "ResumeGamePlayState/hero/heroprojectile";
            villianprojectilePath = "ResumeGamePlayState/villians/villianprojectile";
            vilianOnePath = "ResumeGamePlayState/villians/villian01";
            villianTwoPath = "ResumeGamePlayState/villians/villian02";
            villianThreePath = "ResumeGamePlayState/villians/villian03";
            villianFourPath = "ResumeGamePlayState/villians/villian04";
            backgroundPath = "ResumeGamePlayState/background";
            APath = "ResumeGamePlayState/buttonfolder/A";
            BPath = "ResumeGamePlayState/buttonfolder/B";
            XPath = "ResumeGamePlayState/buttonfolder/X";
            YPath = "ResumeGamePlayState/buttonfolder/Y";
            deepestmasterofcodeSongPath = "ResumeGamePlayState/bgmusic01";
            fontPath = "content/Font1";
            chooseImgPath = "ResumeGamePlayState/choose";
            spritefont1Path = "ResumeGamePlayState/SpriteFont1";
            scorePath = "ResumeGamePlayState/scoretext";
            
        }
        

        public ResumeVideoGame()
        {
            leapMotionButtons = new LeapMotionButtons();
            // TODO: Add your initialization logic here
            random = new Random();
            buttoncolor = new Color();
            buttoncolor = Color.White;

            scorenumber = 0;

            #region after several seconds disappear constructor code
            isMarkTimeEqualToGameTime = false;
            textSeen = false;
            isMarkGotten = false;
            #endregion

            state = 0;
            playSound = false;
            // setting of button to hit variables
            xaxis = 0;
            yaxis = 150;
            widthsize = 128;
            heightsize = 128;


            #region Code Fight Initialize
            herocolor = Color.White;
            villiancolor = Color.White;
            villianspeed = 1;
            JimmyEllisRectangle = new Rectangle(0, 300, 128, 128);
            villiansrect = new Rectangle(670, 300, 128, 128);

            heroprojectilerect = new Rectangle(50, 320, 64, 128);
            heroprojectilespeed = 100;
            villianprojecticerect = new Rectangle(670, 300, 128, 128);

            #endregion
            hitbuttoncolor = Color.Magenta;

            // setting of hit button variables
            hitxaxis = 325; // hitxaxis = 650;
            hityaxis = 250; // hityaxis = 150;
            hitwidthsize = 128;
            hitheightsize = 128;
            hitbuttonlocation = new Rectangle(hitxaxis, hityaxis, hitwidthsize, hitheightsize);

            thebuttonhit = WhichButtonHit.a;

            #region Code Fight Code
            villians = new Texture2D[4];

            speedup = false;

            #endregion
            Arect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Brect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Xrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Yrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);



            isHit = false;
            uprect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            downrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            leftrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            rightrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);

            chosenrandom = 0;
            gamepadstate = new GamePadState();

                   boomPath = "ResumeGamePlayState/boom";
            JimmyEllisPath = "ResumeGamePlayState/hero/hero";
            heroprojectilePath = "ResumeGamePlayState/hero/heroprojectile";
            villianprojectilePath = "ResumeGamePlayState/villians/villianprojectile";
            vilianOnePath = "ResumeGamePlayState/villians/villian01";
            villianTwoPath = "ResumeGamePlayState/villians/villian02";
            villianThreePath = "ResumeGamePlayState/villians/villian03";
            villianFourPath = "ResumeGamePlayState/villians/villian04";
            backgroundPath = "ResumeGamePlayState/background";
            APath = "ResumeGamePlayState/buttonfolder/A";
            BPath = "ResumeGamePlayState/buttonfolder/B";
            XPath = "ResumeGamePlayState/buttonfolder/X";
            YPath = "ResumeGamePlayState/buttonfolder/Y";
            deepestmasterofcodeSongPath = "ResumeGamePlayState/bgmusic01";
            fontPath = "content/Font1";
            chooseImgPath = "ResumeGamePlayState/choose";
            spritefont1Path = "ResumeGamePlayState/SpriteFont1";
            scorePath = "ResumeGamePlayState/scoretext";

        }
         
        #endregion

        */
        
        #region Deserializing Constructor Replacement 
        [OnDeserializing]
        public void ResumeVideoGameDeserialization(StreamingContext context)
        {

            levelDestination = NextLevelDestination.CodeKing;
            leapMotionButtons = new LeapMotionButtons();
            // TODO: Add your initialization logic here
            random = new Random();
            buttoncolor = new Color();
            buttoncolor = Color.White;
            displayLoading = false;
            scorenumber = 0;

            #region after several seconds disappear constructor code
            isMarkTimeEqualToGameTime = false;
            textSeen = false;
            isMarkGotten = false;
            #endregion

            state = 1;
            playSound = false;
            // setting of button to hit variables
            xaxis = 0;
            yaxis = 150;
            widthsize = 128;
            heightsize = 128;


            #region Code Fight Initialize
            herocolor = Color.White;
            villiancolor = Color.White;
            villianspeed = 1;
            JimmyEllisRectangle = new Rectangle(0, 300, 128, 128);
            villiansrect = new Rectangle(670, 300, 128, 128);

            heroprojectilerect = new Rectangle(50, 320, 64, 128);
            heroprojectilespeed = 100;
            villianprojecticerect = new Rectangle(670, 300, 128, 128);

            #endregion
            hitbuttoncolor = Color.Magenta;

            // setting of hit button variables
            hitxaxis = 325; // hitxaxis = 650;
            hityaxis = 250; // hityaxis = 150;
            hitwidthsize = 128;
            hitheightsize = 128;
            hitbuttonlocation = new Rectangle(hitxaxis, hityaxis, hitwidthsize, hitheightsize);

            thebuttonhit = WhichButtonHit.a;

            #region Code Fight Code
            villians = new Texture2D[4];

            speedup = false;

            #endregion
            Arect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Brect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Xrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Yrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);

            

            isHit = false;
            uprect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            downrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            leftrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            rightrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);

            chosenrandom = 0;
            gamepadstate = new GamePadState();

            boomPath = "ResumeGamePlayState/boom";
            JimmyEllisPath = "ResumeGamePlayState/hero/hero";
            heroprojectilePath = "ResumeGamePlayState/hero/heroprojectile";
            villianprojectilePath = "ResumeGamePlayState/villians/villianprojectile";
            vilianOnePath = "ResumeGamePlayState/villians/villian01";
            villianTwoPath = "ResumeGamePlayState/villians/villian02";
            villianThreePath = "ResumeGamePlayState/villians/villian03";
            villianFourPath = "ResumeGamePlayState/villians/villian04";
            backgroundPath = "ResumeGamePlayState/background";
            APath = "ResumeGamePlayState/buttonfolder/A";
            BPath = "ResumeGamePlayState/buttonfolder/B";
            XPath = "ResumeGamePlayState/buttonfolder/X";
            YPath = "ResumeGamePlayState/buttonfolder/Y";
            deepestmasterofcodeSongPath = "ResumeGamePlayState/bgmusic01";
            fontPath = "content/Font1";
            chooseImgPath = "ResumeGamePlayState/choose";
            spritefont1Path = "ResumeGamePlayState/SpriteFont1";
            scorePath = "ResumeGamePlayState/scoretext";

        }
        #endregion 

        
        #region LoadContent
        public override void LoadContent(ContentManager Content)
        {
        
        
            // Create a new SpriteBatch, which can be used to draw textures.
            base.LoadContent(Content);
            boom = Content.Load<SoundEffect>(boomPath);
            leapMotionButtons.LoadContent(Content);
            JimmyEllis = Content.Load<Texture2D>(JimmyEllisPath);
            heroprojectile = Content.Load<Texture2D>(heroprojectilePath);
            villianprojectile = Content.Load<Texture2D>(villianprojectilePath);
            villians[0] = Content.Load<Texture2D>(vilianOnePath);
            villians[1] = Content.Load<Texture2D>(villianTwoPath);
            villians[2] = Content.Load<Texture2D>(villianThreePath);
            villians[3] = Content.Load<Texture2D>(villianFourPath);
            // backgroun
            background = Content.Load<Texture2D>(backgroundPath);
            A = Content.Load<Texture2D>(APath);
            B = Content.Load<Texture2D>(BPath);
            X = Content.Load<Texture2D>(XPath);
            Y = Content.Load<Texture2D>(YPath);
            /*
            start = Content.Load<Texture2D>("");
            select = Content.Load<Texture2D>("");
            */
            font = Content.Load<SpriteFont>(fontPath);
            deepestmasterofcode = Content.Load<Song>(deepestmasterofcodeSongPath);
            MediaPlayer.Play(deepestmasterofcode);
            //score image

            loadingImg = Content.Load<Texture2D>("content/waitloading");
            loadingRect = new Rectangle(0, 0, 400, 100);
            chooseImg = Content.Load<Texture2D>(chooseImgPath);
            spritefont1 = Content.Load<SpriteFont>(spritefont1Path);
            score = Content.Load<Texture2D>(scorePath);

            left = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/LEFT");
            right = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/RIGHT");
            up = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/UP");
            down = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/DOWN");


            /*
            leftbutton = Content.Load<Texture2D>("");
            lefttrigger = Content.Load<Texture2D>("");

            righttrigger = Content.Load<Texture2D>("");
            rightbutton = Content.Load<Texture2D>("");
            */

        }
        #endregion

        #region UnloadContent

        public override  void UnloadContent()
        {
            /*
            boom.Dispose();
                   
            JimmyEllis.Dispose();   
            heroprojectile.Dispose();
            villianprojectile.Dispose();
       
            villians[0].Dispose();
            villians[1].Dispose();
            villians[2].Dispose();
            villians[3].Dispose();
            // backgroun
      

            background.Dispose();

            A.Dispose();
            B.Dispose();
            X.Dispose();        
            Y.Dispose();

          //  deepestmasterofcode.Dispose();
     
            score.Dispose();
  */
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            // Allows the game to exit
           
            gamepadstate = GamePad.GetState(PlayerIndex.One);
            leapMotionButtons.Update(gameTime);
            #region read controller or keyboard to find out what is hit todo: leap motion support
            if (gamepadstate.IsButtonDown(Buttons.A) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.A))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.a;
                herocolor = Color.White;
            }

            else if (gamepadstate.IsButtonDown(Buttons.B) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.B))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.b;
                herocolor = Color.White;
            }

            else if (gamepadstate.IsButtonDown(Buttons.X) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.X))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.x;
                herocolor = Color.White;
            }

            else if (gamepadstate.IsButtonDown(Buttons.Y) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Y))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.y;
                herocolor = Color.White;
            }



            else if (gamepadstate.IsButtonDown(Buttons.DPadUp) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Up))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.up;
                herocolor = Color.White;
            }

            else if (gamepadstate.IsButtonDown(Buttons.DPadDown) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Down))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.down;
                herocolor = Color.White;
            }

            else if (gamepadstate.IsButtonDown(Buttons.DPadLeft) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Left))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.left;
                herocolor = Color.White;
            }
            else if (gamepadstate.IsButtonDown(Buttons.DPadRight) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Right))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.right;
                herocolor = Color.White;
            }

            #endregion
            // TODO: Add your update logic here
            #region code fight
            if (NextLevelDestination.CodeKing == levelDestination)
            {
                if (((scorenumber == 3) || (scorenumber > 3)) && (state == 0))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playOneDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayOneFs = new FileStream("DefaultPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayOneReader =
                        XmlDictionaryReader.CreateTextReader(PlayOneFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[0] = (PlayVideoState)playOneDs.ReadObject(PlayOneReader);
                    PlayOneFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[0]);
                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 1))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playTwoDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayTwoFs = new FileStream("SecondPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayTwoReader =
                        XmlDictionaryReader.CreateTextReader(PlayTwoFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[1] = (PlayVideoState)playTwoDs.ReadObject(PlayTwoReader);
                    PlayTwoFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[1]);

                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 2))
                {
                    //  UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer jobSkillsDs = new DataContractSerializer(typeof(JobSkills));
                    FileStream jobSkillsFs = new FileStream("DefaultEndScreen.xml", FileMode.Open);
                    XmlDictionaryReader jobSkillsReader =
                        XmlDictionaryReader.CreateTextReader(jobSkillsFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.jobskills = (JobSkills)jobSkillsDs.ReadObject(jobSkillsReader);

                    jobSkillsFs.Close();

                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.jobskills);

                }
            }

            else if (NextLevelDestination.Strong == levelDestination)
            {
                if (((scorenumber == 3) || (scorenumber > 3)) && (state == 0))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playOneDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayOneFs = new FileStream("StrongDefaultPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayOneReader =
                        XmlDictionaryReader.CreateTextReader(PlayOneFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[0] = (PlayVideoState)playOneDs.ReadObject(PlayOneReader);
                    PlayOneFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[0]);
                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 1))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playTwoDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayTwoFs = new FileStream("StrongSecondPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayTwoReader =
                        XmlDictionaryReader.CreateTextReader(PlayTwoFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[1] = (PlayVideoState)playTwoDs.ReadObject(PlayTwoReader);
                    PlayTwoFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[1]);

                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 2))
                {
                    //  UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer jobSkillsDs = new DataContractSerializer(typeof(JobSkills));
                    FileStream jobSkillsFs = new FileStream("StrongDefaultEndScreen.xml", FileMode.Open);
                    XmlDictionaryReader jobSkillsReader =
                        XmlDictionaryReader.CreateTextReader(jobSkillsFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.jobskills = (JobSkills)jobSkillsDs.ReadObject(jobSkillsReader);


                    jobSkillsFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.jobskills);

                }
            }

            else if (NextLevelDestination.HandColors == levelDestination)
            {

                // this is for the hand game to return to the hand game instead of the wakanda game
                /*
                if (((scorenumber == 3) || (scorenumber > 3)) && (state == 0))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playOneDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayOneFs = new FileStream("HandDefaultPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayOneReader =
                        XmlDictionaryReader.CreateTextReader(PlayOneFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[0] = (PlayVideoState)playOneDs.ReadObject(PlayOneReader);
                    PlayOneFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[0]);
                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 1))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playTwoDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayTwoFs = new FileStream("HandSecondPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayTwoReader =
                        XmlDictionaryReader.CreateTextReader(PlayTwoFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[1] = (PlayVideoState)playTwoDs.ReadObject(PlayTwoReader);
                    PlayTwoFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[1]);

                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 2))
                {
                    //  UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer jobSkillsDs = new DataContractSerializer(typeof(JobSkills));
                    FileStream jobSkillsFs = new FileStream("HandDefaultEndingScreen.xml", FileMode.Open);
                    XmlDictionaryReader jobSkillsReader =
                        XmlDictionaryReader.CreateTextReader(jobSkillsFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.jobskills = (JobSkills)jobSkillsDs.ReadObject(jobSkillsReader);


                    jobSkillsFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.jobskills);

                }
                 */

                if (((scorenumber == 3) || (scorenumber > 3)) && (state == 0))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playOneDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayOneFs = new FileStream("WakandaDefaultPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayOneReader =
                        XmlDictionaryReader.CreateTextReader(PlayOneFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[0] = (PlayVideoState)playOneDs.ReadObject(PlayOneReader);
                    PlayOneFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[0]);
                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 1))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playTwoDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayTwoFs = new FileStream("WakandaSecondPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayTwoReader =
                        XmlDictionaryReader.CreateTextReader(PlayTwoFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[1] = (PlayVideoState)playTwoDs.ReadObject(PlayTwoReader);
                    PlayTwoFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[1]);

                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 2))
                {
                    //  UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer jobSkillsDs = new DataContractSerializer(typeof(JobSkills));
                    FileStream jobSkillsFs = new FileStream("WakandaDefaultEndingScreen.xml", FileMode.Open);
                    XmlDictionaryReader jobSkillsReader =
                        XmlDictionaryReader.CreateTextReader(jobSkillsFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.jobskills = (JobSkills)jobSkillsDs.ReadObject(jobSkillsReader);


                    jobSkillsFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.jobskills);

                }
            }

            else if (NextLevelDestination.Rope == levelDestination)
            {
                if (((scorenumber == 3) || (scorenumber > 3)) && (state == 0))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playOneDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayOneFs = new FileStream("RopeDefaultPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayOneReader =
                        XmlDictionaryReader.CreateTextReader(PlayOneFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[0] = (PlayVideoState)playOneDs.ReadObject(PlayOneReader);
                    PlayOneFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[0]);
                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 1))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playTwoDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayTwoFs = new FileStream("RopeSecondPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayTwoReader =
                        XmlDictionaryReader.CreateTextReader(PlayTwoFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[1] = (PlayVideoState)playTwoDs.ReadObject(PlayTwoReader);
                    PlayTwoFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[1]);

                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 2))
                {
                    //  UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer jobSkillsDs = new DataContractSerializer(typeof(JobSkills));
                    FileStream jobSkillsFs = new FileStream("RopeDefaultEndScreen.xml", FileMode.Open);
                    XmlDictionaryReader jobSkillsReader =
                        XmlDictionaryReader.CreateTextReader(jobSkillsFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.jobskills = (JobSkills)jobSkillsDs.ReadObject(jobSkillsReader);

                    jobSkillsFs.Close();

                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.jobskills);

                }
            }

            if (NextLevelDestination.CodeCave == levelDestination)
            {
                if (((scorenumber == 3) || (scorenumber > 3)) && (state == 0))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playOneDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayOneFs = new FileStream("DefaultPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayOneReader =
                        XmlDictionaryReader.CreateTextReader(PlayOneFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[0] = (PlayVideoState)playOneDs.ReadObject(PlayOneReader);
                    PlayOneFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[0]);
                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 1))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playTwoDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayTwoFs = new FileStream("SecondPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayTwoReader =
                        XmlDictionaryReader.CreateTextReader(PlayTwoFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[1] = (PlayVideoState)playTwoDs.ReadObject(PlayTwoReader);
                    PlayTwoFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[1]);

                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 2))
                {
                    //  UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer jobSkillsDs = new DataContractSerializer(typeof(JobSkills));
                    FileStream jobSkillsFs = new FileStream("DefaultEndScreen.xml", FileMode.Open);
                    XmlDictionaryReader jobSkillsReader =
                        XmlDictionaryReader.CreateTextReader(jobSkillsFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.jobskills = (JobSkills)jobSkillsDs.ReadObject(jobSkillsReader);


                    jobSkillsFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.jobskills);

                }
            }


            if (NextLevelDestination.Deception == levelDestination)
            {
                if (((scorenumber == 3) || (scorenumber > 3)) && (state == 0))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playOneDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayOneFs = new FileStream("DeceptionDefaultPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayOneReader =
                        XmlDictionaryReader.CreateTextReader(PlayOneFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[0] = (PlayVideoState)playOneDs.ReadObject(PlayOneReader);
                    PlayOneFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[0]);
                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 1))
                {
                    // UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer playTwoDs = new DataContractSerializer(typeof(PlayVideoState));
                    FileStream PlayTwoFs = new FileStream("DeceptionSecondPlayVideoState.xml", FileMode.Open);
                    XmlDictionaryReader PlayTwoReader =
                        XmlDictionaryReader.CreateTextReader(PlayTwoFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.playvideoostates[1] = (PlayVideoState)playTwoDs.ReadObject(PlayTwoReader);
                    PlayTwoFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.playvideoostates[1]);

                }
                else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 2))
                {
                    //  UnloadContent();
                    displayLoading = true;
                    MediaPlayer.Stop();
                    DataContractSerializer jobSkillsDs = new DataContractSerializer(typeof(JobSkills));
                    FileStream jobSkillsFs = new FileStream("DeceptionDefaultEndScreen.xml", FileMode.Open);
                    XmlDictionaryReader jobSkillsReader =
                        XmlDictionaryReader.CreateTextReader(jobSkillsFs, new XmlDictionaryReaderQuotas());
                    ScreenManager.Instance.jobskills = (JobSkills)jobSkillsDs.ReadObject(jobSkillsReader);


                    jobSkillsFs.Close();
                    ScreenManager.Instance.AddScreen(ScreenManager.Instance.jobskills);

                }
            }
            if (villiansrect.Intersects(heroprojectilerect))
            {
                playSound = true;
                scorenumber += 1;
                villiancolor = Color.Blue;
                villianprojecticerect.X = 630;
                heroprojectilerect.X = 50;

                if (speedup == true)
                {
                    speedup = false;
                    villianspeed += 1;
                }

                if (playSound == true)
                {
                    playSound = false;
                    boom.Play();
                }
            }

            else if (!(villiansrect.Intersects(heroprojectilerect) && (villianprojecticerect.X < 500)))
            {
                villiancolor = Color.White;
            }

            if (JimmyEllisRectangle.Intersects(villianprojecticerect))
            {

                herocolor = Color.Blue;
                villianprojecticerect.X = 630;
                scorenumber -= 1;

                if (scorenumber < -3)
                {
                    scorenumber = -3;
                }

            }


            villianprojecticerect.X -= villianspeed;

            /*
                        else if ()
                        {

                        }

                        else ()
                        {

                        }*/

            #endregion
            #region random algorithim





            if ( (isHit == true) && (thebuttonhit == whichbuttonhit))
            {

                #region code fight
                if ((isHit == true) && (whichbuttonhit == thebuttonhit) )
                {
                    isHit = false;
                    heroprojectilerect.X += heroprojectilespeed;
                }
                #endregion code fight
                isHit = false;

                // change to 5 so that abxy only appears change to 8 or 9 so that all appear
                chosenrandom = random.Next(0, 5);
              
                if (chosenrandom == 1)
                {
                    thebuttonhit = WhichButtonHit.a;

                }

                else if (chosenrandom == 2)
                {
                    thebuttonhit = WhichButtonHit.b;
                }

                else if (chosenrandom == 3)
                {
                    thebuttonhit = WhichButtonHit.x;
                }
                else if (chosenrandom == 4)
                {
                    thebuttonhit = WhichButtonHit.y;
                }
                    /*
                else if (chosenrandom == 5)
                {
                    thebuttonhit = WhichButtonHit.up;
                }
                else if (chosenrandom == 6)
                {
                    thebuttonhit = WhichButtonHit.down;
                }
                else if (chosenrandom == 7)
                {
                    thebuttonhit = WhichButtonHit.left;
                }
                else if (chosenrandom == 8)
                {
                    thebuttonhit = WhichButtonHit.right;
                }
                */
            }

            #endregion


            #region Code Fight Update




            #endregion


            //text disappear based on time algorithim 


            #region after Several seconds disappear logic
            if (isMarkGotten == false)
            {
                stateChangeTimeMarkString = Game1.heldTimeCatcher.ToString();
                stateChangeTimeMarkNumber = System.Convert.ToInt32(stateChangeTimeMarkString);
                isMarkGotten = true;
            }



            if ((stateChangeTimeMarkNumber + 10) == System.Convert.ToInt32(Game1.heldTimeCatcher))
            {
                isMarkTimeEqualToGameTime = true;
                textSeen = true;
            }
            #endregion 
            
        }
        #endregion

        #region Draw
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
            // TODO: Add your drawing code here
        /*    
            #region Drawing What is Hit To The Screen
      


            
            if (WhichButtonHit.a == whichbuttonhit)
            {
                spriteBatch.Draw(A, Arect, buttoncolor);
            }
            else if (WhichButtonHit.b == whichbuttonhit)
            {
                spriteBatch.Draw(B, Brect, buttoncolor);
            }
            else if (WhichButtonHit.x == whichbuttonhit)
            {
                spriteBatch.Draw(X, Xrect, buttoncolor);
            }
            else if (WhichButtonHit.y == whichbuttonhit)
            {
                spriteBatch.Draw(Y, Yrect, buttoncolor);
            }

            else if (WhichButtonHit.up == whichbuttonhit)
            {
                spriteBatch.Draw(up, uprect, buttoncolor);
            }

            else if (WhichButtonHit.down == whichbuttonhit)
            {
                spriteBatch.Draw(down, uprect, buttoncolor);
            }

            else if (WhichButtonHit.left == whichbuttonhit)
            {
                spriteBatch.Draw(left, uprect, buttoncolor);
            }

            else if (WhichButtonHit.right == whichbuttonhit)
            {
                spriteBatch.Draw(right, uprect, buttoncolor);
            }
            

            #endregion
*/
           
            #region What to hit on the screen
            

            if (WhichButtonHit.a == thebuttonhit)
            {
                spriteBatch.Draw(A, hitbuttonlocation, hitbuttoncolor);
            }

            else if (WhichButtonHit.b == thebuttonhit)
            {
                spriteBatch.Draw(B, hitbuttonlocation, hitbuttoncolor);
            }

            else if (WhichButtonHit.x == thebuttonhit)
            {
                spriteBatch.Draw(X, hitbuttonlocation, hitbuttoncolor);
            }

            else if (WhichButtonHit.y == thebuttonhit)
            {
                spriteBatch.Draw(Y, hitbuttonlocation, hitbuttoncolor);
            }
                /*
            else if (WhichButtonHit.up == thebuttonhit)
            {
                spriteBatch.Draw(up, hitbuttonlocation, hitbuttoncolor);
            }


            else if (WhichButtonHit.down == thebuttonhit)
            {
                spriteBatch.Draw(down, hitbuttonlocation, hitbuttoncolor);
            }


            else if (WhichButtonHit.left == thebuttonhit)
            {
                spriteBatch.Draw(left, hitbuttonlocation, hitbuttoncolor);
            }


            else if (WhichButtonHit.right == thebuttonhit)
            {
                spriteBatch.Draw(right, hitbuttonlocation, hitbuttoncolor);
            }
            */



            #endregion
            spriteBatch.Draw(chooseImg, new Rectangle(300, 200, 201, 73), Color.White);
            





            

            spriteBatch.Draw(score, new Rectangle((400 - score.Height / 2), 500, 200, 100), Color.White);
            spriteBatch.DrawString(spritefont1, scorenumber.ToString(), new Vector2(460, 510), Color.White);
            

            #region Code Fight Draw
           

            spriteBatch.Draw(JimmyEllis, JimmyEllisRectangle, herocolor);
            spriteBatch.Draw(villians[0], villiansrect, villiancolor);
            spriteBatch.Draw(villianprojectile, villianprojecticerect, Color.White);
           spriteBatch.Draw(heroprojectile, heroprojectilerect, Color.White);

            leapMotionButtons.Draw(spriteBatch);

            #endregion

            /*  if (isMarkGotten == true)
            {
                spriteBatch.DrawString(font, stateChangeTimeMarkNumber.ToString() /* + " " + stateChangeTimeMarkString.ToString() + "" + isMarkGotten.ToString() + "" + textSeen.ToString() + "" + isMarkTimeEqualToGameTime.ToString() */
            //, new Vector2(0, 60), Color.Black);
            // } 

            if (textSeen == false)
            {
                spriteBatch.DrawString(font, "HIT THE BUTTON IT TELLS YOU TO ADVANCE THE BLACK PANTHER", new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(font, "DEFEAT HIM WITH YOUR BLACK PANTHER BEFORE HE DEFEATS YOU WITH HIS", new Vector2(0, 20), Color.White);
            }

            if (displayLoading == true)
            {
                spriteBatch.Draw(loadingImg, loadingRect, Color.White);
            }
            
        }
    }

        #endregion
}
