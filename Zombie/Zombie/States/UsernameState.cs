using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private SpriteFont ScoreFont;

        private List<Component> _components;

        KeyboardState keyboardState;
        KeyboardState oldKeyboardState;

        public UsernameState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            keyboardState = Keyboard.GetState();
            oldKeyboardState = keyboardState;
            GameState.username = "";
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            var WordLength = _font.MeasureString("Enter Name").X;
            
            
            spriteBatch.Begin();
            
            spriteBatch.DrawString(_font, "Enter Name", new Vector2((Game1.ScreenWidth / 2) - (WordLength / 2), 40),Color.Red);
            
            try
            {
                var WordLength0 = ScoreFont.MeasureString(GameState.username.Substring(0, 1)).X;
                spriteBatch.DrawString(ScoreFont, GameState.username.Substring(0, 1), new Vector2((Game1.ScreenWidth / 3) - (WordLength0 / 2), 100), Color.Red);
                var WordLength1 = ScoreFont.MeasureString(GameState.username.Substring(1, 1)).X;
                spriteBatch.DrawString(ScoreFont, GameState.username.Substring(1, 1), new Vector2((Game1.ScreenWidth / 2) - (WordLength1 / 2), 100), Color.Red);
                var WordLength2 = ScoreFont.MeasureString(GameState.username.Substring(2, 1)).X;
                spriteBatch.DrawString(ScoreFont, GameState.username.Substring(2, 1), new Vector2((Game1.ScreenWidth / 1.5f) - (WordLength2 / 2), 100), Color.Red);
            }
            catch (ArgumentOutOfRangeException) { }
            spriteBatch.End();
        }

        public override void LoadContent()
        {
            _font = _content.Load<SpriteFont>("Font");
            ScoreFont = _content.Load<SpriteFont>("ScoreFont");
            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("ButtonFont");

            _components = new List<Component>()
            {
                new Button(buttonTexture, buttonFont)
                {
                    Text = "Main Menu",
                    Position = new Vector2(Game1.ScreenWidth - (buttonTexture.Width / 2 * Game1.screenScale.X) - (buttonTexture.Width * Game1.screenScale.X), 80 * Game1.screenScale.Y),
                    Click = new EventHandler(Button_MainMenu_Clicked),
                },

                new Button(buttonTexture, buttonFont)
                {
                    Text = "Start Game",
                    Position = new Vector2(Game1.ScreenWidth - (buttonTexture.Width / 2 * Game1.screenScale.X) - (buttonTexture.Width * Game1.screenScale.X), 40 * Game1.screenScale.Y),
                    Click = new EventHandler(NewGameButton_Clicked),
                },
            };
        }

        private void Button_MainMenu_Clicked(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, graphics, _content));
        }

        private void NewGameButton_Clicked(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, graphics, _content));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
                Button_MainMenu_Clicked(this, new EventArgs());
            char key;
            bool newKeyEntered =TryConvertKeyboardInput(keyboardState, oldKeyboardState, out key);
            if (newKeyEntered == true && GameState.username.Length<3)
            {
                GameState.username += key;
                Debug.WriteLine(GameState.username);
            }

            
           // GameState.username = "blah";
            foreach (var component in _components)
                component.Update(gameTime);
            oldKeyboardState = keyboardState;
        }
        public static bool TryConvertKeyboardInput(KeyboardState keyboard, KeyboardState oldKeyboard, out char key)
        {
            Keys[] keys = keyboard.GetPressedKeys();
            Keys[] oldkeys = oldKeyboard.GetPressedKeys();
            bool shift = keyboard.IsKeyDown(Keys.LeftShift) || keyboard.IsKeyDown(Keys.RightShift);

            if (keys.Length > 0 )
            {
                int newKeyIndex = -1;
                for(int i = 0; i<keys.Length; i++)
                {
                    if(oldkeys.Length <= i)
                    {
                        //new key is at i
                        newKeyIndex = i;
                        break;
                    }
                    if(oldkeys[i] != keys[i])
                    {
                        //new key is at i
                        newKeyIndex = i;
                        break;
                    }
                }
                if (newKeyIndex != -1)
                {
                    switch (keys[newKeyIndex])
                    {
                        //Alphabet keys
                        case Keys.A: { key = 'A'; } return true;
                        case Keys.B: { key = 'B'; } return true;
                        case Keys.C: { key = 'C'; } return true;
                        case Keys.D: { key = 'D'; } return true;
                        case Keys.E: { key = 'E'; } return true;
                        case Keys.F: { key = 'F'; } return true;
                        case Keys.G: { key = 'G'; } return true;
                        case Keys.H: { key = 'H'; } return true;
                        case Keys.I: { key = 'I'; } return true;
                        case Keys.J: { key = 'J'; } return true;
                        case Keys.K: { key = 'K'; } return true;
                        case Keys.L: { key = 'L'; } return true;
                        case Keys.M: { key = 'M'; } return true;
                        case Keys.N: { key = 'N'; } return true;
                        case Keys.O: { key = 'O'; } return true;
                        case Keys.P: { key = 'P'; } return true;
                        case Keys.Q: { key = 'Q'; } return true;
                        case Keys.R: { key = 'R'; } return true;
                        case Keys.S: { key = 'S'; } return true;
                        case Keys.T: { key = 'T'; } return true;
                        case Keys.U: { key = 'U'; } return true;
                        case Keys.V: { key = 'V'; } return true;
                        case Keys.W: { key = 'W'; } return true;
                        case Keys.X: { key = 'X'; } return true;
                        case Keys.Y: { key = 'Y'; } return true;
                        case Keys.Z: { key = 'Z'; } return true;

                        //Decimal keys
                        case Keys.D0: if (shift) { key = ')'; } else { key = '0'; } return true;
                        case Keys.D1: if (shift) { key = '!'; } else { key = '1'; } return true;
                        case Keys.D2: if (shift) { key = '@'; } else { key = '2'; } return true;
                        case Keys.D3: if (shift) { key = '#'; } else { key = '3'; } return true;
                        case Keys.D4: if (shift) { key = '$'; } else { key = '4'; } return true;
                        case Keys.D5: if (shift) { key = '%'; } else { key = '5'; } return true;
                        case Keys.D6: if (shift) { key = '^'; } else { key = '6'; } return true;
                        case Keys.D7: if (shift) { key = '&'; } else { key = '7'; } return true;
                        case Keys.D8: if (shift) { key = '*'; } else { key = '8'; } return true;
                        case Keys.D9: if (shift) { key = '('; } else { key = '9'; } return true;

                        //Decimal numpad keys
                        case Keys.NumPad0: key = '0'; return true;
                        case Keys.NumPad1: key = '1'; return true;
                        case Keys.NumPad2: key = '2'; return true;
                        case Keys.NumPad3: key = '3'; return true;
                        case Keys.NumPad4: key = '4'; return true;
                        case Keys.NumPad5: key = '5'; return true;
                        case Keys.NumPad6: key = '6'; return true;
                        case Keys.NumPad7: key = '7'; return true;
                        case Keys.NumPad8: key = '8'; return true;
                        case Keys.NumPad9: key = '9'; return true;

                        //Special keys
                        case Keys.OemTilde: if (shift) { key = '~'; } else { key = '`'; } return true;
                        case Keys.OemSemicolon: if (shift) { key = ':'; } else { key = ';'; } return true;
                        case Keys.OemQuotes: if (shift) { key = '"'; } else { key = '\''; } return true;
                        case Keys.OemQuestion: if (shift) { key = '?'; } else { key = '/'; } return true;
                        case Keys.OemPlus: if (shift) { key = '+'; } else { key = '='; } return true;
                        case Keys.OemPipe: if (shift) { key = '|'; } else { key = '\\'; } return true;
                        case Keys.OemPeriod: if (shift) { key = '>'; } else { key = '.'; } return true;
                        case Keys.OemOpenBrackets: if (shift) { key = '{'; } else { key = '['; } return true;
                        case Keys.OemCloseBrackets: if (shift) { key = '}'; } else { key = ']'; } return true;
                        case Keys.OemMinus: if (shift) { key = '_'; } else { key = '-'; } return true;
                        case Keys.OemComma: if (shift) { key = '<'; } else { key = ','; } return true;
                        case Keys.Space: key = ' '; return true;
                    }
                }
            }

            key = (char)0;
            return false;
        }
    }
}
