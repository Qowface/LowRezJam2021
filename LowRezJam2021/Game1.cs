using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        Texture2D[] numTextures;

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

            numTextures = new Texture2D[4];
            numTextures[0] = Content.Load<Texture2D>("0");
            numTextures[1] = Content.Load<Texture2D>("1");
            numTextures[2] = Content.Load<Texture2D>("2");
            numTextures[3] = Content.Load<Texture2D>("3");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(_nativeRenderTarget);
            GraphicsDevice.Clear(Color.Transparent);
            _spriteBatch.Begin();

            _spriteBatch.Draw(numTextures[0], new Vector2(2, 2), Color.White);
            _spriteBatch.Draw(numTextures[1], new Vector2(12, 12), Color.White);
            _spriteBatch.Draw(numTextures[2], new Vector2(22, 22), Color.White);
            _spriteBatch.Draw(numTextures[3], new Vector2(32, 32), Color.White);

            _spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_nativeRenderTarget, _actualScreenRectangle, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
