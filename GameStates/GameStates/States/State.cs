using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStates.States
{
    public abstract class State
    {
        #region Fields

        protected ContentManager _content;

        protected GraphicsDeviceManager graphics;

        protected Game1 _game;

        public static float ScreenWidth;
        public static float ScreenHeight;

        #endregion

        #region Methods

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        public State(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
            _game = game;

            graphics = Game1.graphics;

            _content = content;

            
  
            //
            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;
        }

        public abstract void Update(GameTime gameTime);

        #endregion
    }
}
