using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Squared.Tiled;
using System.IO;

namespace TiledExampleGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Map variables
        Map map,map1,map2;

        //variables for player texture and position to focus map
        Texture2D player;
        Vector2 viewPort;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            //Load maps
            map1 = Map.Load(Path.Combine(Content.RootDirectory, "SimpleRPG.tmx"), Content);
            map2 = Map.Load(Path.Combine(Content.RootDirectory, "SimpleRPGiso.tmx"), Content);

            player = Content.Load<Texture2D>("hero");

            //Access objects in map
            map1.ObjectGroups["Objects"].Objects["Player"].Texture = player;
            map2.ObjectGroups["Objects"].Objects["Player"].Texture = player;

            map = map1;

            //starting view port for starting map
            viewPort = new Vector2(map.ObjectGroups["Objects"].Objects["Player"].X - (graphics.PreferredBackBufferWidth / 2), map.ObjectGroups["Objects"].Objects["Player"].Y - (graphics.PreferredBackBufferHeight / 2));

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
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                map = map1;
                //Set view port for normal map, need to minus half the width and height
                viewPort = new Vector2(map.ObjectGroups["Objects"].Objects["Player"].X - (graphics.PreferredBackBufferWidth / 2), map.ObjectGroups["Objects"].Objects["Player"].Y - (graphics.PreferredBackBufferHeight / 2));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                map = map2;
                //Set view port for isometric map, you just need provide x and y of player
                viewPort = new Vector2(map.ObjectGroups["Objects"].Objects["Player"].X, map.ObjectGroups["Objects"].Objects["Player"].Y);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            //Draw a map
            spriteBatch.Begin();
            map.Draw(spriteBatch, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), viewPort);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
