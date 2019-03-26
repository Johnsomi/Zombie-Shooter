using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zombie.Managers;
using Zombie.Sprites;
using Microsoft.Xna.Framework.Input;
using Zombie.Controls;
using Zombie.Core;

namespace Zombie.States
{
    public class GameState : State
    {
        public static Random Random;
        public static string username = " ";
        public static string secretName = "YUNOWERK";
        //private Camera _camera;

        private List<Component> _components;
        //private List<Component> soldierComponents;
        public double G = 2.0;

        public int GCount;

        public int ZSCount;

        public float ZomTimer;

        public float ZombieVelocity = 2f;

        private int _score;

        private ScoreManager _scoreManager;

        Player soldier;
        
        
        private SpriteFont _font;

        private List<Sprite> _sprites;

        private List<Sprite> ZomList;
        //
        private float _timer2;
        //
        private Texture2D _targetTexture;

        private bool _hasStarted = false;

        

        //private Texture2D background;

        public GameState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Random = new Random();
        
            _scoreManager = ScoreManager.Load();

            _targetTexture = _content.Load<Texture2D>("ZombieT1");
            _font = _content.Load<SpriteFont>("Font");
            //background = _content.Load<Texture2D>("ZomGameBackground");

            Restart();
        }

        public override void LoadContent()
        {
            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("ButtonFont");

            //soldier = new Player(_content.Load<Texture2D>("topDownSoldier2"));

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

        private void Restart()
        {
            //_camera = new Camera();
            var playerTexture = _content.Load<Texture2D>("topDownSoldier2");
            //_targetTexture = Content.Load<Texture2D>("target2");
            //------------------------------------------------------------------
            //
            soldier = new Player(playerTexture)
            {
                Position = new Vector2((ScreenWidth / 2), (ScreenHeight / 2)),
                Bullet = new Bullet(_content.Load<Texture2D>("circle")),

            };

            //soldierComponents = new List<Component>()
            //{
                //soldier,
            //};

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
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //var viewMatrix = Camera.Transform;
            //spriteBatch.Begin();//SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, viewMatrix);
            //foreach (var component in _sprites)
              //  component.Draw(gameTime, spriteBatch);
            //spriteBatch.End();
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            

            // foreach(var sprite in _sprites)
            //     sprite.Draw(spriteBatch);
            /*spriteBatch.Draw(background,
                new Rectangle(0, 0, (int)ScreenWidth, (int)ScreenHeight),
                new Rectangle(0, 0, background.Width, background.Height),
                Color.White);*/

            for (int SpriteIndex = _sprites.Count - 1; SpriteIndex >= 0; SpriteIndex--)
            {
                _sprites[SpriteIndex].Draw(gameTime,spriteBatch);
            }
            foreach (var sprite in ZomList)
            {
                sprite.Draw(gameTime,spriteBatch);
            }
                

            //_____
            //spriteBatch.DrawString(_font, "Highscores:\n" + string.Join("\n", _scoreManager.Highscores.Select(c => c.PlayerName + ": " + c.Value).ToArray()), new Vector2(10, ScreenHeight / 2), Color.Red);

            var fontY = 10;
            var i = 0;
            foreach (var sprite in _sprites)
            {
                if (sprite is Player)
                    spriteBatch.DrawString(_font, string.Format("Player {0}: {1}", ++i, ((Player)sprite).Score), new Vector2(10, fontY += 30), Color.Green);
                //if (sprite is Player2)
                //  spriteBatch.DrawString(_font, string.Format("Player {0}: {1}", ++i, ((Player2)sprite).Score), new Vector2(10, fontY += 30), Color.Green);
            }


            spriteBatch.End();
        }

        

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Button_MainMenu_Clicked(this, new EventArgs());

            foreach (var component in _components)
                component.Update(gameTime);
            //foreach (var component in _sprites)
              //  component.Update(gameTime);
            if (_sprites.Count >= 1)
            {
               // _camera.CamFollow(_sprites[0]);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
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

            foreach (var sprite in _sprites.ToArray())
            {
                sprite.Update(gameTime, ZomList);
            }

            PostUpdate(gameTime);
            //
            SpawnTarget();
        }

        

        public override void PostUpdate(GameTime gameTime)
        {
            foreach (var spriteA in _sprites)
            {
                foreach (var spriteB in ZomList)
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
                        if (username.Equals("") && player.Score == 22) {
                            _scoreManager.Add(new Models.Score()
                            {
                                PlayerName = secretName,
                                Value = _score,
                            }
                            );
                        }
                        else
                        {
                            _scoreManager.Add(new Models.Score()
                            {
                                PlayerName = username,
                                Value = _score,
                            }
                            );
                        }

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
                    if (ZomList[i] is ZombieGiant)
                    {
                        player.Score = player.Score + 6;
                        _score = _score + 6;
                        ZomList.Add(GiantDeath((int)sprite.Position.X, (int)sprite.Position.Y, soldier));
                    }
                    else
                    {
                        player.Score++;
                        _score++;
                    }

                    ZomList.RemoveAt(i);
                    i--;

                }

                //Keep down part

            }
        }

        private void SpawnTarget()
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
                int XTop = ((int)ScreenWidth / 2) - (_targetTexture.Width * 2);

                Rectangle SpawnTop = new Rectangle(XTop, 1, (int)ScreenWidth - XTop - _targetTexture.Width, 1);
                Rectangle SpawnBottom = new Rectangle(XTop, ((int)ScreenHeight - 1 - _targetTexture.Height), (int)ScreenWidth - XTop - _targetTexture.Width, 1);

                Rectangle SpawnRight = new Rectangle(((int)ScreenWidth - 1 - _targetTexture.Width), 1, 1, ((int)ScreenHeight - _targetTexture.Height));
                Rectangle SpawnLeft = new Rectangle(1, 1, 1, ((int)ScreenHeight - _targetTexture.Height));
                if (SpawnSelector == 0)
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

                if (ZomTimer >= 60)
                {
                    xPos = Random.Next(SpawnLeft.X, SpawnLeft.X + SpawnLeft.Width);
                    yPos = Random.Next(SpawnLeft.Y, SpawnLeft.Y + SpawnLeft.Height);
                    ZomTimer = 0;
                }
                ZomList.Add(GetZombies(xPos, yPos, soldier));
            }
        }

        public Zombies GetZombies(int xPos, int yPos, Sprite soldier)
        {
            Random randomType = new Random();
            int ZombieType = randomType.Next(0, 10);
            if (ZombieType == 0)
            {
                
                return new ZombieGiant(_targetTexture, new Vector2(xPos, yPos), soldier, 10f, Color.Red);
            }
            
            else
            {
                return new Zombies(_targetTexture, new Vector2(xPos, yPos), soldier, 10f);
            }
        }

        public Zombies GiantDeath(int xPos, int yPos, Sprite soldier)
        {
            return new ZombieImp(_targetTexture, new Vector2(xPos, yPos), soldier, 10f, Color.Green);
        }
    }
}
