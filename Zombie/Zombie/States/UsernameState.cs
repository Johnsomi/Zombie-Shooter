using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zombie.Controls;

namespace Zombie.States
{
    public class UsernameState : State
    {
        private SpriteFont _font;

        private List<Component> _components;

        public UsernameState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void LoadContent()
        {
            _font = _content.Load<SpriteFont>("Font");

            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("ButtonFont");

            _components = new List<Component>()
            {
                new Button(buttonTexture, buttonFont)
                {
                    Text = "Main Menu",
                    Position = new Vector2(Game1.ScreenWidth - (buttonTexture.Width / 2) - (buttonTexture.Width), 40),
                    Click = new EventHandler(Button_MainMenu_Clicked),
                },
            };
        }

        private void Button_MainMenu_Clicked(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, graphics, _content));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Button_MainMenu_Clicked(this, new EventArgs());

            foreach (var component in _components)
                component.Update(gameTime);
        }
    }
}
