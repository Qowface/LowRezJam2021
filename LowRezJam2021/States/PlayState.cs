using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LowRezJam2021.States
{
    class PlayState : IState
    {
        private Texture2D[] _numTextures;

        public PlayState()
        {
            _numTextures = new Texture2D[4];
            for (int i = 0; i < _numTextures.Length; i++)
            {
                _numTextures[i] = Game1.Textures[i+""];
            }
        }
        
        public void Update(GameTime gameTime)
        {
            //
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_numTextures[0], new Vector2(2, 2), Color.White);
            spriteBatch.Draw(_numTextures[1], new Vector2(12, 12), Color.White);
            spriteBatch.Draw(_numTextures[2], new Vector2(22, 22), Color.White);
            spriteBatch.Draw(_numTextures[3], new Vector2(32, 32), Color.White);
        }
    }
}
