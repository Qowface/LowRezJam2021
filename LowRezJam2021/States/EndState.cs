using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LowRezJam2021.States
{
    class EndState : IState
    {
        private Texture2D _gameoverTexture;
        private Texture2D _youwinTexture;
        private Texture2D _restartTexture;

        private bool _gameWon;

        public EndState(bool gameWon)
        {
            _gameoverTexture = Game1.Textures["gameover"];
            _youwinTexture = Game1.Textures["youwin"];
            _restartTexture = Game1.Textures["restart"];
            
            _gameWon = gameWon;
        }
        
        public void Update(GameTime gameTime)
        {
            if (Game1.Input.WasKeyJustDown(Keys.Space))
            {
                Game1.Sounds["ding"].Play(0.5f, 0.0f, 0.0f);
                Game1.States.Set(new PlayState());
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_gameWon)
            {
                spriteBatch.Draw(_youwinTexture, new Vector2(20, 16), new Color(56, 142, 60));
            }
            else
            {
                spriteBatch.Draw(_gameoverTexture, new Vector2(16, 16), new Color(211, 47, 47));
            }
            spriteBatch.Draw(_restartTexture, new Vector2(10, 46), Color.White);
        }
    }
}
