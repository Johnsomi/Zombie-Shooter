using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Zombie.Managers;
using Zombie.Sprites;
using Zombie.States;

namespace Zombie
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //before
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private State _currentState;

        private State _nextState;

        public void ChangeState(State state)
        {
            _nextState = state;
        }
        //
        //public static Random Random;
        //
        public static int ScreenWidth;
        public static int ScreenHeight;

        /*public double G = 2.0;

        public int GCount;

        public int ZSCount;

        public float ZomTimer;

        public float ZombieVelocity = 2f;

        private int _score;

        private ScoreManager _scoreManager;

        Sprite soldier;

        private SpriteFont _font;

        private List<Sprite> _sprites;

        private List<Sprite> ZomList;
        //
        private float _timer2;
        //
        private Texture2D _targetTexture;

        private bool _hasStarted = false;*/

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //
            //Random = new Random();

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;
            
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
            //------
            //_scoreManager = ScoreManager.Load();
            //-----
            _currentState = new MenuState(this, graphics, Content);
            _currentState.LoadContent();
            _nextState = null;
            /*_targetTexture = Content.Load<Texture2D>("ZombieT1");
            _font = Content.Load<SpriteFont>("Font");

            
            //-
            Restart();*/
        }

        /*private void Restart()
        {
            var playerTexture = Content.Load<Texture2D>("topDownSoldier2");
            //_targetTexture = Content.Load<Texture2D>("target2");
            //------------------------------------------------------------------
            //
            soldier = new Player(playerTexture)
            {
                Position = new Vector2((ScreenWidth / 4), (ScreenHeight / 2)),
                Bullet = new Bullet(Content.Load<Texture2D>("circle")),
                
            };

            _sprites = new List<Sprite>()
            {
                soldier,             
            };

            ZomList = new List<Sprite>()
            {
                
            };

            //-
            _hasStarted = false;
            //_font = Content.Load<SpriteFont>("Font");
            //--------------------------------------------------------------------
        }*/

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
            //-
            /*if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _hasStarted = true;

            if (!_hasStarted)
                return;

            _timer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;

            ZomTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;


            foreach (var sprite in _sprites.ToArray())
            {
                sprite.Update(gameTime, _sprites);
            }


            foreach (var sprite in ZomList.ToArray())
            {
                sprite.Update(gameTime, ZomList);
            }

            foreach(var sprite in _sprites.ToArray())
            {
                sprite.Update(gameTime, ZomList);
            }*/

            if (_nextState != null)
            {
                _currentState = _nextState;
                _currentState.LoadContent();
                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            //PostUpdate();
            //
            //SpawnTarget();



            base.Update(gameTime);
        }
        //
        /*private void SpawnTarget()
        {
            if (_timer2 > G)
            {
                GCount++;

                ZSCount++;

                

                if (ZSCount == 5)
                {
                    ZSCount = 0;
                    
                }

                if (GCount == 2 && G > 0.4)
                {
                    G = G - 0.1;
                    GCount = 0;
                }

                _timer2 = 0;

                int SpawnSelector = Random.Next(0, 3);
                var xPos = 0;
                var yPos = 0;
                int XTop = (ScreenWidth / 2) - (_targetTexture.Width * 2);
                
                Rectangle SpawnTop = new Rectangle(XTop, 1, ScreenWidth - XTop - _targetTexture.Width, 1);
                Rectangle SpawnBottom = new Rectangle(XTop, (ScreenHeight - 1 - _targetTexture.Height), ScreenWidth - XTop - _targetTexture.Width, 1);

                Rectangle SpawnRight = new Rectangle((ScreenWidth - 1 - _targetTexture.Width), 1, 1, (ScreenHeight - _targetTexture.Height));
                Rectangle SpawnLeft = new Rectangle(1, 1, 1, (ScreenHeight - _targetTexture.Height));
                if(SpawnSelector == 0)
                {
                    xPos = Random.Next(SpawnTop.X, SpawnTop.X + SpawnTop.Width);
                    yPos = Random.Next(SpawnTop.Y, SpawnTop.Y + SpawnTop.Height);

                }
                else if (SpawnSelector == 1)
                {
                    xPos = Random.Next(SpawnBottom.X, SpawnBottom.X + SpawnBottom.Width);
                    yPos = Random.Next(SpawnBottom.Y, SpawnBottom.Y + SpawnBottom.Height);
                }
                
                else
                {
                    xPos = Random.Next(SpawnRight.X, SpawnRight.X + SpawnRight.Width);
                    yPos = Random.Next(SpawnRight.Y, SpawnRight.Y + SpawnRight.Height);
                }

                if(ZomTimer >= 60)
                {
                    xPos = Random.Next(SpawnLeft.X, SpawnLeft.X + SpawnLeft.Width);
                    yPos = Random.Next(SpawnLeft.Y, SpawnLeft.Y + SpawnLeft.Height);
                    ZomTimer = 0;
                }
                ZomList.Add(new Sprite(_targetTexture)
                {
                    Position = new Vector2(xPos, yPos),
                    //
                    FollowTarget = soldier,
                    //
                    FollowDistance = 10f,
                  
                });
            }
        }*/

        /*private void PostUpdate()
        {
            //-----
            foreach(var spriteA in _sprites)
            {
                foreach(var spriteB in ZomList)
                {
                    if (spriteA == spriteB)
                        continue;

                    if (spriteA.Rectangle.Intersects(spriteB.HitBoxZ))
                        spriteA.OnCollide(spriteB);
                }
            }
            Player player = (Player)_sprites[0];

            for (int i = 0; i < _sprites.Count; i++)
            {
                //-
                var sprite = _sprites[i];

                if (_sprites[i].IsRemoved)
                {
                    //-----
                    
                    if (sprite is Sprite)
                    {
                        player.Score++;
                        

                        if (sprite is Bullet)
                        {
                            player.Score--;
                            
                        }
                    }


                    _sprites.RemoveAt(i);
                    i--;

                }

                //Keep down part
                

                //-
                if (sprite is Player)
                {
                    var soldier = sprite as Player;
                    if (soldier.HasDied)
                    {
                        _scoreManager.Add(new Models.Score()
                        {
                            PlayerName = "Me",
                            Value = _score,
                        }
                        );

                        ScoreManager.Save(_scoreManager);
                        _score = 0;

                        GCount = 0;
                        ZSCount = 0;
                        G = 2.0;
                        
                        Restart();
                    }
                }
            }
            for (int i = 0; i < ZomList.Count; i++)
            {
                //-
                var sprite = ZomList[i];

                if (ZomList[i].IsRemoved)
                {
                    //-----
                    player.Score++;
                    _score++;


                    ZomList.RemoveAt(i);
                    i--;

                }

                //Keep down part
                
            }
        }*/

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

           /* spriteBatch.Begin();

            // foreach(var sprite in _sprites)
            //     sprite.Draw(spriteBatch);

            for (int SpriteIndex = _sprites.Count - 1; SpriteIndex >= 0; SpriteIndex-- )
            {
                _sprites[SpriteIndex].Draw(spriteBatch);
            }
            foreach (var sprite in ZomList)
                sprite.Draw(spriteBatch);

            //_____
            spriteBatch.DrawString(_font, "Highscores:\n" + string.Join("\n", _scoreManager.Highscores.Select(c => c.PlayerName + ": " + c.Value).ToArray()), new Vector2(10, ScreenHeight/2), Color.Red);

            var fontY = 10;
            var i = 0;
            foreach (var sprite in _sprites)
            {
                if (sprite is Player)
                    spriteBatch.DrawString(_font, string.Format("Player {0}: {1}", ++i, ((Player)sprite).Score), new Vector2(10, fontY += 30), Color.Green);
                //if (sprite is Player2)
                  //  spriteBatch.DrawString(_font, string.Format("Player {0}: {1}", ++i, ((Player2)sprite).Score), new Vector2(10, fontY += 30), Color.Green);
            }


            spriteBatch.End();*/

            _currentState.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }
    }
}
