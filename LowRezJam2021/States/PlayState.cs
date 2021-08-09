using LowRezJam2021.GameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LowRezJam2021.States
{
    class PlayState : IState
    {
        private Texture2D[] _numTextures;
        private Texture2D _cursorTexture;

        private Board _board;
        private Vector2 _cursor;

        public PlayState()
        {
            _numTextures = new Texture2D[4];
            for (int i = 0; i < _numTextures.Length; i++)
            {
                _numTextures[i] = Game1.Textures[i+""];
            }
            _cursorTexture = Game1.Textures["cursor"];

            _board = new Board(5, 5);
            
            _cursor = new Vector2(2, 2);
        }
        
        public void Update(GameTime gameTime)
        {
            //
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int row = 0; row < _board.Rows; row++)
            {
                for (int col = 0; col < _board.Cols; col++)
                {
                    spriteBatch.Draw(_numTextures[_board.Tiles[row, col].Value], new Vector2(3 + col * 10, 13 + row * 10), Color.White);
                }
            }

            spriteBatch.Draw(_cursorTexture, new Vector2(2 +_cursor.X * 10, 12 + _cursor.Y * 10), Color.White);
        }
    }
}
