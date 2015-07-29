using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ZeldaEngine.Components;
using ZeldaEngine.Controllers;
using ZeldaEngine.Maps;

namespace ZeldaEngine
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private BaseObject _player;
        private BaseObject _testNPC;
        private BaseObject _testEnemy;
        private InputController _inputController;
        private MapController _mapController;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.graphics.PreferredBackBufferWidth = 160; //160
            this.graphics.PreferredBackBufferHeight = 144; //144

            _player = new BaseObject();
            _testNPC = new BaseObject();
            _testEnemy = new BaseObject();
            _inputController = new InputController();
            _mapController = new MapController("test");
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

            _mapController.LoadContent(Content);

            _player.AddComponent(new Sprite(Content.Load<Texture2D>("Sprites\\spr_link_full"), 16, 16, new Vector2(50, 50)));
            _player.AddComponent(new PlayerInput());
            _player.AddComponent(new Animation(16, 16));
            _player.AddComponent(new Collision(_mapController));

            _testNPC.AddComponent(new Sprite(Content.Load<Texture2D>("Sprites\\spr_marin_full"), 16, 16, new Vector2(50, 50)));
            _testNPC.AddComponent(new AIRandomMovement(200));
            _testNPC.AddComponent(new Animation(16, 16));
            _testNPC.AddComponent(new Collision(_mapController));

            _testEnemy.AddComponent(new Sprite(Content.Load<Texture2D>("Sprites\\spr_octorok_full"), 16, 16, new Vector2(50, 50)));
            _testEnemy.AddComponent(new AIRandomMovement(1000, 0.5f));
            _testEnemy.AddComponent(new Animation(16, 16));
            _testEnemy.AddComponent(new Collision(_mapController));
            _testEnemy.AddComponent(new Octorok(_player, Content.Load<Texture2D>("Sprites\\spr_octorok_bullet"), _mapController));
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _inputController.Update(gameTime.ElapsedGameTime.Milliseconds);
            _player.Update(gameTime.ElapsedGameTime.Milliseconds);
            _testNPC.Update(gameTime.ElapsedGameTime.Milliseconds);
            _testEnemy.Update(gameTime.ElapsedGameTime.Milliseconds);
            _mapController.Update(gameTime.ElapsedGameTime.Milliseconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
                _mapController.Draw(spriteBatch);
                _player.Draw(spriteBatch);
                _testNPC.Draw(spriteBatch);
                _testEnemy.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
