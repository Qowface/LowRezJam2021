using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LowRezJam2021.States
{
    class EndState : IState
    {
        private bool _gameWon;

        public EndState(bool gameWon)
        {
            _gameWon = gameWon;
        }
        
        public void Update(GameTime gameTime)
        {
            if (Game1.Input.WasKeyJustDown(Keys.Space)) Game1.States.Set(new PlayState());
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // TODO: Display win/loss and option to play again
        }
    }
}
