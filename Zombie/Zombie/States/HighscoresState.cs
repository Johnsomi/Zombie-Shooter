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
using Zombie.Managers;

namespace Zombie.States
{
    public class HighscoresState : State
    {
        private List<Component> _components;

        private SpriteFont _font;
        private SpriteFont ScoreFont;
        private SpriteFont buttonFont;
        private ScoreManager _scoreManager;

        

        public HighscoresState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

        }

        public override void LoadContent()
        {
            _font = _content.Load<SpriteFont>("Font");
            ScoreFont = _content.Load<SpriteFont>("ScoreFont");
            _scoreManager = ScoreManager.Load();

            var buttonTexture = _content.Load<Texture2D>("Button");
            buttonFont = _content.Load<SpriteFont>("ButtonFont");
            
            _components = new List<Component>()
            {
                new Button(buttonTexture, buttonFont)
                {
                    Text = "Main Menu",
                    Position = new Vector2((Game1.ScreenWidth / 2) - (buttonTexture.Width/2 * Game1.screenScale.X), 560 * Game1.screenScale.Y),
                    Click = new EventHandler(Button_MainMenu_Clicked),
                },
            };
        }

        private void Button_MainMenu_Clicked(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, graphics, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            var WordLength = _font.MeasureString("Highscores:").X;
            var WordLengthA = _font.MeasureString("");
            spriteBatch.Begin();
            var i = 0;
            spriteBatch.DrawString(_font, "Highscores:\n" + string.Join("\n", _scoreManager.Highscores.Select(c => ++i + ". " + c.PlayerName + ": " + c.Value).ToArray()), new Vector2((Game1.ScreenWidth / 2) - (WordLength / 2), 100), Color.Red);
       
            spriteBatch.End();
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
