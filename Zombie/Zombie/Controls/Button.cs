using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Zombie.Controls
{
    public class Button : Component
    {
        #region Fields

        private MouseState _currentMouse;

        private SpriteFont _font;

        private bool _isHovering;

        private MouseState _previousMouse;

        private Texture2D _texture;

        #endregion

        #region Properties

        public EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)(_texture.Width * Game1.screenScale.X), (int)(_texture.Height * Game1.screenScale.Y));
            }
        }

        public string Text { get; set; }

        #endregion

        #region Methods

        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;

            _font = font;

            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (_isHovering)
                colour = Color.Gray;
            Rectangle scaledRectangle = new Rectangle(Rectangle.X, Rectangle.Y, (int)(Rectangle.Width), (int)(Rectangle.Height));
            spriteBatch.Draw(_texture, scaledRectangle, colour);
            
            if (!string.IsNullOrEmpty(Text))
            {
                var x = (scaledRectangle.X + (scaledRectangle.Width / 2)) - (_font.MeasureString(Text).X / 2 * Game1.screenScale.X);
                var y = (scaledRectangle.Y + (scaledRectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2 * Game1.screenScale.Y);

                //spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour, 0, new Vector2(0, 0), Game1.screenScale, SpriteEffects.None, 0);
                
            }
        }
        
        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y - (int)(25f * Game1.screenScale.Y), 1, 1);
            
            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        #endregion
    }
}
