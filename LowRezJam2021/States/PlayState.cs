using LowRezJam2021.GameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LowRezJam2021.States
{
    class PlayState : IState
    {
        private Texture2D[] _tileTextures;
        private Texture2D _numsTexture;
        private Texture2D _cursorTexture;

        private Board _board;
        private Vector2 _cursor;

        public PlayState()
        {
            _tileTextures = new Texture2D[4];
            for (int i = 0; i < _tileTextures.Length; i++)
            {
                _tileTextures[i] = Game1.Textures[i+""];
            }
            _numsTexture = Game1.Textures["nums"];
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
                    spriteBatch.Draw(_tileTextures[_board.Tiles[row, col].Value], new Vector2(3 + col * 10, 13 + row * 10), Color.White);
                }
            }

            for (int row = 0; row < _board.Rows; row++)
            {
                DrawCounter(spriteBatch, _board.RowCounters[row], new Vector2(53, 13 + row * 10));
            }
            for (int col = 0; col < _board.Cols; col++)
            {
                DrawCounter(spriteBatch, _board.ColCounters[col], new Vector2(3 + col * 10, 3));
            }

            spriteBatch.Draw(_cursorTexture, new Vector2(2 +_cursor.X * 10, 12 + _cursor.Y * 10), Color.White);
        }

        public void DrawCounter(SpriteBatch spriteBatch, Counter counter, Vector2 position)
        {
            DrawNumber(spriteBatch, counter.Total / 10, position, Color.White);
            DrawNumber(spriteBatch, counter.Total % 10, Vector2.Add(position, new Vector2(4, 0)), Color.White);
            DrawNumber(spriteBatch, counter.ZeroCount, Vector2.Add(position, new Vector2(2, 4)), new Color(211, 47, 47));
        }

        public void DrawNumber(SpriteBatch spriteBatch, int number, Vector2 position, Color color)
        {
            Rectangle rectangle = new Rectangle(number * 3, 0, 3, 4);
            spriteBatch.Draw(_numsTexture, position, rectangle, color);
        }
    }
}
