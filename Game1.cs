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
    /// <summary>
    /// This is the main type for your game
    /// </summary>  
    public class Game1 : Microsoft.Xna.Framework.Game
    {



     
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int count;
        //after several seconds disappear 
        public static GameTime gameTime;
        public static TimeSpan timeSpan;
        public static string heldTimeCatcher;
        SpriteFont font;

        #region leap
        public static LeapComponet leap;
        public static Rectangle leapCollision;
        Texture2D fingerTexture;
        Texture2D fingerTextureStrong;
        Texture2D fingerTextureRope;
        Texture2D fingerTextureHandColor;
        Texture2D fingerTextureDeception;
        
       public static Rectangle[] fingerLocations;
        #endregion

        ResumeVideoGame resumevideogame;

        public enum HandGraphic
        {
            CodeKing, CodeCave, HandColors, Rope, Strong, Deception
        }

        public static HandGraphic handGraphic;
        public ResumeVideoGame Resumevideogame { get { return resumevideogame; } }
        JobSkills jobskills;
        PlayVideoState playvideostate;
        public enum GameStates
        {
            gameplay, computerrepair, sourcecode, jobskills
        }

       public static GameStates gamestates;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            leap = new LeapComponet(this);
            this.Components.Add(leap);
            #region 
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            count = 0;
            // TODO: Add your initialization logic here
            handGraphic = HandGraphic.CodeKing;
            // resumevideogame = new ResumeVideoGame();
            jobskills = new JobSkills();
            gamestates = GameStates.gameplay;
            playvideostate = new PlayVideoState();
            #region leap 
            
            // leap collisions redone
            fingerLocations = new Rectangle[5];
            fingerLocations[0] = new Rectangle(800, 600, 128, 128);
            fingerLocations[1] = new Rectangle(800, 600, 128, 128);
            fingerLocations[2] = new Rectangle(800, 600, 128, 128);
            fingerLocations[3] = new Rectangle(800, 600, 128, 128);
            fingerLocations[4] = new Rectangle(800, 600, 128, 128);
            // leap collision
            leapCollision = new Rectangle(0, 0, 128, 128);
            // TODO: Add your initialization logic here
            
            #endregion 
            ScreenManager.Instance.Initialize();

            ScreenManager.Instance.Dimensions = new Vector2(800, 600);
            graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
            #endregion
            graphics.ApplyChanges();

            //after several seconds disappear 
            // gametime 
            gameTime = new GameTime();
            timeSpan = new TimeSpan();
            // gametime
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

          
            #region leap 

            // buttons art
           
            // leap component fingertips
            fingerTexture = Content.Load<Texture2D>("blackpanther/blackpantherfinger");
            fingerTextureStrong = Content.Load<Texture2D>("blackpanther/blackpantherfinger");
            fingerTextureRope = Content.Load<Texture2D>("blackpanther/blackpantherfinger");
            fingerTextureHandColor = Content.Load<Texture2D>("blackpanther/blackpantherfinger");
            fingerTextureDeception = Content.Load<Texture2D>("blackpanther/blackpantherfinger");
            #endregion 


            font = Content.Load<SpriteFont>("content/Font1");

            ScreenManager.Instance.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            if (this.IsActive == false)
            {
                return;
            }// end if
            
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftTrigger) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Delete))
            {

                this.Exit();
            }
            // Allows the game to exit

            //after several seconds disappear code
            gameTime.ElapsedGameTime.Add(timeSpan);

            //after several seconds disappear 
            heldTimeCatcher = gameTime.TotalGameTime.Seconds.ToString();

            ScreenManager.Instance.Update(gameTime);

    

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            if (this.IsActive == false)
            {
                return;
            }// end if

            

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            ScreenManager.Instance.Draw(spriteBatch);
            #region leap

            if(HandGraphic.CodeKing == handGraphic)
            {

                foreach (Vector2 fingerLoc in leap.FingerPoints)
                {

                    float tempX = fingerLoc.X;
                    float tempY = fingerLoc.Y;
                    fingerLocations[count].X = (int)tempX;
                    fingerLocations[count].Y = (int)tempY;
                    spriteBatch.Draw(fingerTexture, fingerLocations[count], Color.White);

                    count = count + 1;

                    if (count == 5)
                    {
                        count = 0;
                    }

                    if (count > 4)
                    {
                        count = 0;
                    }
                }
            
            }

            else if (HandGraphic.HandColors == handGraphic)
            {

                foreach (Vector2 fingerLoc in leap.FingerPoints)
                {

                    float tempX = fingerLoc.X;
                    float tempY = fingerLoc.Y;
                    fingerLocations[count].X = (int)tempX;
                    fingerLocations[count].Y = (int)tempY;
                    spriteBatch.Draw(fingerTextureHandColor, fingerLocations[count], Color.White);

                    count = count + 1;

                    if (count == 5)
                    {
                        count = 0;
                    }

                    if (count > 4)
                    {
                        count = 0;
                    }
                }
            
            }

            else if (HandGraphic.Rope == handGraphic)
            {
                foreach (Vector2 fingerLoc in leap.FingerPoints)
                {

                    float tempX = fingerLoc.X;
                    float tempY = fingerLoc.Y;
                    fingerLocations[count].X = (int)tempX;
                    fingerLocations[count].Y = (int)tempY;
                    spriteBatch.Draw(fingerTextureRope, fingerLocations[count], Color.White);

                    count = count + 1;

                    if (count == 5)
                    {
                        count = 0;
                    }

                    if (count > 4)
                    {
                        count = 0;
                    }
                }
            
            }

            else if (HandGraphic.Strong== handGraphic)
            {

                foreach (Vector2 fingerLoc in leap.FingerPoints)
                {

                    float tempX = fingerLoc.X;
                    float tempY = fingerLoc.Y;
                    fingerLocations[count].X = (int)tempX;
                    fingerLocations[count].Y = (int)tempY;
                    spriteBatch.Draw(fingerTextureStrong, fingerLocations[count], Color.White);

                    count = count + 1;

                    if (count == 5)
                    {
                        count = 0;
                    }

                    if (count > 4)
                    {
                        count = 0;
                    }
                }
            }


            else if (HandGraphic.Deception == handGraphic)
            {

                foreach (Vector2 fingerLoc in leap.FingerPoints)
                {

                    float tempX = fingerLoc.X;
                    float tempY = fingerLoc.Y;
                    fingerLocations[count].X = (int)tempX;
                    fingerLocations[count].Y = (int)tempY;
                    spriteBatch.Draw(fingerTextureDeception, fingerLocations[count], Color.White);

                    count = count + 1;

                    if (count == 5)
                    {
                        count = 0;
                    }

                    if (count > 4)
                    {
                        count = 0;
                    }
                }
            }
            

            #endregion 
          
            #region detect if leap is plugged in or not

          //  spriteBatch.DrawString(font, leap.LeapComputerConnection.ToString(), new Vector2(0, 60), Color.White);
            #endregion 
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
