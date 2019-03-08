﻿using System;
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

        private ScoreManager _scoreManager;

        

        public HighscoresState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

        }

        public override void LoadContent()
        {
            _font = _content.Load<SpriteFont>("Font");

            _scoreManager = ScoreManager.Load();

            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("ButtonFont");

            _components = new List<Component>()
            {
                new Button(buttonTexture, buttonFont)
                {
                    Text = "Main Menu",
                    Position = new Vector2((ScreenWidth / 2) - (buttonTexture.Width/2), 560),
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

            spriteBatch.Begin();

            spriteBatch.DrawString(_font, "Highscores:\n" + string.Join("\n", _scoreManager.Highscores.Select(c => c.PlayerName + ": " + c.Value).ToArray()), new Vector2((ScreenWidth / 2), 100), Color.Red);

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