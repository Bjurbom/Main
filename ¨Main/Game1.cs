using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace _Main
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //enum
        enum GameState {manu, ingame, pause, gameover, setting};

        //objects
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        GameState game;
        List<Shoot> shoot;
        

        Player player;
        Texture2D playerC;
        Camra camra;

        //variabler
        Vector2 menucurser, playerposistion;
        int menuposistion;
        double countdown;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //format
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //setting gamestate
            
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            IsMouseVisible = true;
            //shoot
            shoot = new List<Shoot>();

            game = GameState.manu;

            playerC = Content.Load<Texture2D>("cros");
            //inistierar variabler/objects
            playerposistion = new Vector2(500,500);
            player = new Player(playerposistion, Content.Load<Texture2D>("Player"),playerC);
     
            menucurser = new Vector2(350, 250);
            camra = new Camra();
            menuposistion = 1;

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
            font = Content.Load<SpriteFont>("Text");
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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



            //menu-menu
            //countdown 
            countdown -= gameTime.ElapsedGameTime.TotalMilliseconds;

            //upptaterar menyn saktare
            while (countdown <= 0 && game == GameState.manu)
            {
                    //meny händelser
                    //meny-ingame
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter) && menuposistion == 1)
                    {
                        game = GameState.ingame;
                    }
                    //menu-setting
                    else if (Keyboard.GetState().IsKeyDown(Keys.Enter) && menuposistion == 2)
                    {
                        game = GameState.setting;
                    }
                    //exit
                    else if (Keyboard.GetState().IsKeyDown(Keys.Enter) && menuposistion == 3)
                    {
                        Exit();
                    }
                    // navigation för mus
                    //ner
                    else if (Keyboard.GetState().IsKeyDown(Keys.S))
                    {
                        if (menuposistion != 3)
                        {
                            menucurser.Y += 50;
                            menuposistion++;
                        }
                        
                    }
                    //upp
                    else if (Keyboard.GetState().IsKeyDown(Keys.W))
                    {
                        if (menuposistion != 1)
                        {
                            menucurser.Y -= 50;
                            menuposistion--;
                        }
                        
                    }

                
                countdown = 100;
            }
            //setting
            if (game == GameState.setting)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    game = GameState.manu;
                }
            }
            //ingame
            if (game == GameState.ingame)
            {


     
                player.Update();
                camra.Update(player.posistion);
                if (Keyboard.GetState().IsKeyDown(Keys.T))
                {
                    shoot.Add(new Shoot(player.posistion,player.cposistion,playerC));
                }
                foreach (Shoot shoot in shoot.ToArray())
                {
                    shoot.Update();
                }
                
                //tillbacka till manu
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    game = GameState.manu;
                }
            }
            



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {


            // TODO: Add your drawing code here

            
            if(game == GameState.manu)
            {
                spriteBatch.Begin();
                GraphicsDevice.Clear(Color.CornflowerBlue);

                spriteBatch.DrawString(font, game.ToString(), new Vector2(0, 0), Color.White);
                //manue game-draw
                spriteBatch.DrawString(font, "Manu game", new Vector2(400, 200), Color.White);
                //Start Game-draw
                spriteBatch.DrawString(font, "Start Game", new Vector2(400, 250), Color.White);
                //setting-draw
                spriteBatch.DrawString(font, "Setting", new Vector2(400, 300), Color.White);
                //exit-draw
                spriteBatch.DrawString(font, "Exit", new Vector2(400, 350), Color.White);
                //curser-draw
                spriteBatch.DrawString(font, ">", menucurser, Color.White);
                spriteBatch.End();
            }
            
            else if (game == GameState.ingame)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camra.ViewMatrix);
                GraphicsDevice.Clear(Color.Gray);
                spriteBatch.DrawString(font, game.ToString(), new Vector2(0, 0), Color.Black);
                player.Draw(spriteBatch);
                foreach (Shoot shoot in shoot.ToArray())
                {
                    shoot.Draw(spriteBatch);
                }

            }
            else
            {
                spriteBatch.Begin();
                GraphicsDevice.Clear(Color.Yellow);
                spriteBatch.DrawString(font, game.ToString(), new Vector2(0, 0), Color.Black);
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
