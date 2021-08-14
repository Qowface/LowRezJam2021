using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LowRezJam2021.States
{
    class MenuState : IState
    {
        private Texture2D _titleTexture;

        public MenuState()
        {
            _titleTexture = Game1.Textures["title"];
        }
        
        public void Update(GameTime gameTime)
        {
            if (Game1.Input.WasKeyJustDown(Keys.Space)) Game1.States.Set(new PlayState());
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_titleTexture, new Vector2(0, 16), Color.White);
        }
    }
}
