using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LowRezJam2021.States
{
    public interface IState
    {
        void Update(GameTime gameTime);

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
