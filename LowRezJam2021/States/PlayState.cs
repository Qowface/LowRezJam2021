using LowRezJam2021.GameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LowRezJam2021.States
{
    class PlayState : IState
    {
        private Texture2D[] _tileTextures;
        private Texture2D _backTexture;
        private Texture2D _numsTexture;
        private Texture2D _cursorTexture;

        private KeyboardState _currentKeys;
        private KeyboardState _previousKeys;

        private Board _board;
        private Vector2 _cursor;

        public PlayState()
        {
            _tileTextures = new Texture2D[4];
            for (int i = 0; i < _tileTextures.Length; i++)
            {
                _tileTextures[i] = Game1.Textures[i+""];
            }
            _backTexture = Game1.Textures["back"];
            _numsTexture = Game1.Textures["nums"];
            _cursorTexture = Game1.Textures["cursor"];

            _currentKeys = _previousKeys = Keyboard.GetState();

            _board = new Board(5, 5);
            _cursor = new Vector2(2, 2);
        }
        
        public void Update(GameTime gameTime)
        {
            _currentKeys = Keyboard.GetState();

            if (WasKeyJustDown(Keys.Right) && _cursor.X < _board.Cols - 1) _cursor.X++;
            if (WasKeyJustDown(Keys.Left) && _cursor.X > 0) _cursor.X--;
            if (WasKeyJustDown(Keys.Down) && _cursor.Y < _board.Rows - 1) _cursor.Y++;
            if (WasKeyJustDown(Keys.Up) && _cursor.Y > 0) _cursor.Y--;

            if (WasKeyJustDown(Keys.Space)) _board.FlipTile((int)_cursor.Y, (int)_cursor.X);

            _previousKeys = _currentKeys;
        }

        public bool WasKeyJustDown(Keys key)
        {
            return _currentKeys.IsKeyDown(key) && !_previousKeys.IsKeyDown(key);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int row = 0; row < _board.Rows; row++)
            {
                for (int col = 0; col < _board.Cols; col++)
                {
                    Tile tile = _board.Tiles[row, col];
                    Texture2D texture = tile.Flipped ? _tileTextures[tile.Value] : _backTexture;
                    spriteBatch.Draw(texture, new Vector2(3 + col * 10, 13 + row * 10), Color.White);
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
