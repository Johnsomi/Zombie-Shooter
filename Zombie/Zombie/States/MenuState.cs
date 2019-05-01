using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Zombie.Controls;

namespace Zombie.States
{
    public class MenuState : State
    {
        private List<Component> _components;



        public MenuState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("ButtonFont");



            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((Game1.ScreenWidth / 2) - (buttonTexture.Width / 2 * Game1.screenScale.X), (Game1.ScreenHeight / 2) - (buttonTexture.Height * 4)),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var UsernameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((Game1.ScreenWidth / 2) - (buttonTexture.Width * Game1.screenScale.X / 2), (Game1.ScreenHeight / 2) - (buttonTexture.Height * 2)),
                Text = "Set Name",
            };

            UsernameButton.Click += UsernameButton_Click;

            var HighscoresButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((Game1.ScreenWidth / 2) - (buttonTexture.Width / 2 * Game1.screenScale.X), Game1.ScreenHeight / 2),
                Text = "Highscores",
            };

            HighscoresButton.Click += HighscoresButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2((Game1.ScreenWidth / 2) - (buttonTexture.Width / 2 * Game1.screenScale.X), (Game1.ScreenHeight / 2) + (buttonTexture.Height * 2)),
                Text = "Quit",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                UsernameButton,
                HighscoresButton,
                quitGameButton,
            };
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void HighscoresButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new HighscoresState(_game, graphics, _content));
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, graphics, _content));
        }

        private void UsernameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new UsernameState(_game, graphics, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //remove sprites if they're not needed

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        public override void LoadContent()
        {
            
        }
    }
}
