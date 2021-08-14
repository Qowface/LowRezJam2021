using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LowRezJam2021.States
{
    class MenuState : IState
    {
        private Texture2D _titleTexture;
        private Texture2D _startTexture;

        public MenuState()
        {
            _titleTexture = Game1.Textures["title"];
            _startTexture = Game1.Textures["start"];
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
            spriteBatch.Draw(_titleTexture, new Vector2(0, 16), Color.White);
            spriteBatch.Draw(_startTexture, new Vector2(10, 42), Color.White);
        }
    }
}
