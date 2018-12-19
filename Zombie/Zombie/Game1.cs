using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zombie.Sprites;

namespace Zombie
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //
        public static Random Random;
        //
        public static int ScreenWidth;
        public static int ScreenHeight;

        private SpriteFont _font;

        private List<Sprite> _sprites;
        //
        private float _timer2;
        //
        private Texture2D _targetTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //
            Random = new Random();

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            //
            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var playerTexture = Content.Load<Texture2D>("topDownSoldier2");

            //------------------------------------------------------------------
            _sprites = new List<Sprite>()
            {
                new Player(playerTexture)
                {
                    Position = new Vector2(960, 540),
                    Bullet = new Bullet(Content.Load<Texture2D>("circle")),
                },
                new Player2(playerTexture)
                {
                    Position = new Vector2(200,200),
                    Bullet2 = new Bullet2(Content.Load<Texture2D>("circle")),
                    Color = Color.Red,
                }               
            };
            //
            _targetTexture = Content.Load<Texture2D>("target2");
            _font = Content.Load<SpriteFont>("Font");
            //--------------------------------------------------------------------
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //
            _timer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var sprite in _sprites.ToArray())
            sprite.Update(gameTime, _sprites);

            //foreach (var sprite in _sprites)
              //  sprite.Update(gameTime, _sprites);

            PostUpdate();
            //
            SpawnTarget();

            base.Update(gameTime);
        }
        //
        private void SpawnTarget()
        {
            if (_timer2 > 0.5)
            {
                _timer2 = 0;

                var xPos = Random.Next(0, ScreenWidth - _targetTexture.Width);
                var yPos = Random.Next(0, ScreenHeight - _targetTexture.Height);

                _sprites.Add(new Sprite(_targetTexture)
                {
                    Position = new Vector2(xPos, yPos),
                });
            }
        }

        private void PostUpdate()
        {
            //Keep down part
            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            var fontY = 10;
            var i = 0;
            foreach (var sprite in _sprites)
            {
                if (sprite is Player)
                    spriteBatch.DrawString(_font, string.Format("Player {0}: {1}", ++i, ((Player)sprite).Score), new Vector2(10, fontY += 30), Color.Green);
                if (sprite is Player2)
                    spriteBatch.DrawString(_font, string.Format("Player {0}: {1}", ++i, ((Player2)sprite).Score), new Vector2(10, fontY += 30), Color.Green);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
