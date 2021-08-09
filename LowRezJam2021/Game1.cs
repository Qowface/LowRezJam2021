using LowRezJam2021.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LowRezJam2021
{
    public class Game1 : Game
    {
        public const int GameWidth = 64;
        public const int GameHeight = 64;
        public const int GameScale = 8;
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private RenderTarget2D _nativeRenderTarget;
        private Rectangle _actualScreenRectangle;

        public static Dictionary<string, Texture2D> Textures;

        private IState _gameState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _nativeRenderTarget = new RenderTarget2D(GraphicsDevice, GameWidth, GameHeight);
            _actualScreenRectangle = new Rectangle(x: 0, y: 0, width: GameWidth * GameScale, height: GameHeight * GameScale);
            _graphics.PreferredBackBufferWidth = GameWidth * GameScale;
            _graphics.PreferredBackBufferHeight = GameHeight * GameScale;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Textures = new Dictionary<string, Texture2D>();
            Textures.Add("0", Content.Load<Texture2D>("0"));
            Textures.Add("1", Content.Load<Texture2D>("1"));
            Textures.Add("2", Content.Load<Texture2D>("2"));
            Textures.Add("3", Content.Load<Texture2D>("3"));
            Textures.Add("cursor", Content.Load<Texture2D>("cursor"));

            _gameState = new PlayState();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _gameState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(_nativeRenderTarget);
            GraphicsDevice.Clear(Color.Transparent);
            _spriteBatch.Begin();

            _gameState.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_nativeRenderTarget, _actualScreenRectangle, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
