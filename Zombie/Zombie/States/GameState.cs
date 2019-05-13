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
        public static string HardModeName = "666";
        //private Camera _camera;

        private List<Component> _components;
        //private List<Component> soldierComponents;
        public double G = 2.0;

        public int GCount;

        public int ZSCount;

        public float enemySpawnTimer;

        public float difficultyTimer;

        //public float SpitTimer;

        public float totalGameTime;

        public float ZombieVelocity = 2f;

        private int _score;

        private ScoreManager _scoreManager;

        Player soldier;

        private Texture2D TestWeapon;
        public float _weaponTimer;
        
        private SpriteFont _font;

        private List<Sprite> _sprites;

        private List<Sprite> ZomList;

        private List<Sprite> WeaponsList;
        //
        private float _timer2;
        //
        private Texture2D _targetTexture;

        private Texture2D zombieGiantTexture;

        private Texture2D ExploderDeathSlime;

        private Texture2D ZombiesSpit;

        private Texture2D TentacleFace;

        private bool _hasStarted = false;

        

        //private Texture2D background;

        public GameState(Game1 game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Random = new Random();
        
            _scoreManager = ScoreManager.Load();
            TestWeapon = _content.Load<Texture2D>("target2-grey");
            _targetTexture = _content.Load<Texture2D>("ZombieT1");
            _font = _content.Load<SpriteFont>("Font");
            zombieGiantTexture = _content.Load<Texture2D>("ZombieGiantT1");
            TentacleFace = _content.Load<Texture2D>("Red-tentaclefaceT1");
            ExploderDeathSlime = _content.Load<Texture2D>("Slime-Explosion-PlaceHolder");
            ZombiesSpit = _content.Load<Texture2D>("circle");
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
                    Position = new Vector2(Game1.ScreenWidth - (buttonTexture.Width * Game1.screenScale.X / 2) - (buttonTexture.Width * Game1.screenScale.X), 40 * Game1.screenScale.Y),
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
                Position = new Vector2((Game1.ScreenWidth / 2), (Game1.ScreenHeight / 2)),
                Bullet = new Bullet(_content.Load<Texture2D>("circle")),
                flameBullet = new FlameThrower(_content.Load<Texture2D>("circle")),
                DefaultBullet = new Bullet(_content.Load<Texture2D>("circle")),
                sniperBullet = new SniperRifle(_content.Load<Texture2D>("circle")),
                shotGun = new ShotGun(_content.Load<Texture2D>("circle"))
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

            WeaponsList = new List<Sprite>()
            {

            };

            //-
            //TestWeapon = _content.Load<Texture2D>("target2");
            _hasStarted = false;
            //_font = Content.Load<SpriteFont>("Font");
            //--------------------------------------------------------------------
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //var viewMatrix = Camera.Transform;
            //spriteBatch.Begin();//SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, viewMatrix);
            //foreach (var component in _sprites)
            //component.Draw(gameTime, spriteBatch);
            //spriteBatch.End();
            spriteBatch.Begin();

           // foreach (var component in _components)
            //    component.Draw(gameTime, spriteBatch);
            
            

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
                
            //weapon try
            foreach (var sprite in WeaponsList)
            {
                sprite.Draw(gameTime, spriteBatch);
            }

            //_____
            //spriteBatch.DrawString(_font, "Highscores:\n" + string.Join("\n", _scoreManager.Highscores.Select(c => c.PlayerName + ": " + c.Value).ToArray()), new Vector2(10, ScreenHeight / 2), Color.Red);

            var fontY = 10;
            var i = 0;
            foreach (var sprite in _sprites)
            {
                if (sprite is Player)
                    spriteBatch.DrawString(_font, string.Format("Player {0}: {1}", ++i, ((Player)sprite).Score), new Vector2(10, fontY += 30), Color.Red);
                //if (sprite is Player2)
                //  spriteBatch.DrawString(_font, string.Format("Player {0}: {1}", ++i, ((Player2)sprite).Score), new Vector2(10, fontY += 30), Color.Green);
            }
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Button_MainMenu_Clicked(this, new EventArgs());
            //button in game
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

            enemySpawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            difficultyTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (username.Equals("666"))
            {
                difficultyTimer = difficultyTimer + 100;
                G = 1.0;
                
            }

            totalGameTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            

            if (enemySpawnTimer > 5.0)
            {
                GCount++;
                enemySpawnTimer = 0;
            }

            
            _weaponTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (var sprite in _sprites.ToArray())
            {
                sprite.Update(gameTime, _sprites);
            }


            foreach (var sprite in ZomList.ToArray())
            {
                sprite.Update(gameTime, ZomList);
            }

            foreach (var sprite in WeaponsList.ToArray())
            {
                sprite.Update(gameTime, WeaponsList);
            }

            /*foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, ZomList);
            }*/

            PostUpdate(gameTime);
            //
            SpawnTarget();

            WeaponSpawnTest();
        }

        

        public override void PostUpdate(GameTime gameTime)
        {
            foreach (var spriteA in _sprites)
            {
                foreach (var spriteB in ZomList)
                {
                    if (spriteA == spriteB)
                        continue;

                    if (!(spriteB is TentacleFace))
                    { 
                        if (spriteA.HitBox.Intersects(spriteB.HitBoxZ))
                            spriteA.OnCollide(spriteB);
                    }

                    if (spriteB is TentacleFace)
                    { 
                        if (spriteA.HitBox.Intersects(spriteB.HitBoxD1))
                            spriteA.OnCollide(spriteB);

                        if (spriteA.HitBox.Intersects(spriteB.HitBoxD2))
                            spriteA.OnCollide(spriteB);
                    }
                }
            }
            foreach(var spriteA in _sprites)
            {
                foreach(var spriteB in WeaponsList)
                {
                    if (spriteA is Player)
                    {
                        if (spriteA == spriteB)
                            continue;

                        if (spriteB.Rectangle.Intersects(spriteA.HitBox))
                            spriteB.OnCollide(spriteA);
                    }
                }
            }
            try
            {
                Player player = (Player)_sprites[0];
                
                //Player player = (Player)_sprites[0];
                //probably useless
                for (int i = 0; i < _sprites.Count; i++)
                {
                    //-
                    //Player player = (Player)_sprites[0];
                    var sprite = _sprites[i];

                    if (_sprites[i].IsRemoved)
                    {
                        //-----

                        if (sprite is Zombies)
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
                            if (username.Equals("") && player.Score == 22)
                            {
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
                            _weaponTimer = 0;
                            GCount = 0;
                            ZSCount = 0;
                            G = 2.0;
                            difficultyTimer = 0;
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
                            player.Score = player.Score + 4;
                            _score = _score + 4;
                            ZomList.Add(GiantDeath((int)sprite.Position.X, (int)sprite.Position.Y, soldier));
                        }

                        if(ZomList[i] is Exploder)
                        {
                            player.Score = player.Score + 0;
                            _score = _score + 0;
                            ZomList.Add(ExploderDeath((int)sprite.Position.X, (int)sprite.Position.Y, soldier));
                        }

                        if(ZomList[i] is ExploderDeath)
                        {
                            player.Score = player.Score + 0;
                            _score = _score + 0;
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

                for (int i = 0; i < WeaponsList.Count; i++)
                {
                    var sprite = WeaponsList[i];

                    if (WeaponsList[i].IsRemoved)
                    {
                        WeaponsList.RemoveAt(i);
                        i--;
                    }
                }
            }
            catch (Exception)
            {


                // var soldier = sprite as Player;
                if (soldier.IsRemoved)
                {
                    if (username.Equals("") && soldier.Score == 22)
                    {
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
                    _weaponTimer = 0;
                    GCount = 0;
                    ZSCount = 0;
                    G = 2.0;
                    difficultyTimer = 0;
                    Restart();
                }    
                
            }
        }
        private void WeaponSpawnTest()
        {

            //get rand number
            //if rand num ==0 set TestWeapon to texture1
            if (_weaponTimer > 8.0)
            {
                _weaponTimer = 0;

                var weaponPosX = Random.Next(0, (int)Game1.ScreenWidth - TestWeapon.Width);
                var weaponPosY = Random.Next(0, (int)Game1.ScreenHeight - TestWeapon.Height);
                Random weaponRandom = new Random();
                int WeaponRandom = weaponRandom.Next(0, 3);
                if (WeaponRandom == 0)
                { 
                    WeaponsList.Add(new Weapon(TestWeapon, new Vector2(weaponPosX, weaponPosY), 1, Color.RosyBrown)
                    );
                }
                else if (WeaponRandom == 1)
                {
                    WeaponsList.Add(new Weapon(TestWeapon, new Vector2(weaponPosX, weaponPosY), 2, Color.Black)
                    );
                }
                else if (WeaponRandom == 2)
                {
                    WeaponsList.Add(new Weapon(TestWeapon, new Vector2(weaponPosX, weaponPosY), 3, Color.Aqua)
                    );
                }
                else
                {
                    //WeaponsList.Add(new Weapon(TestWeapon, new Vector2(weaponPosX, weaponPosY), 0, Color.Red)
                    //);
                }
            }
        }

        private void SpawnTarget()
        {
            if (_timer2 > G)
            {
                //GCount++;

                ZSCount++;



                if (ZSCount == 5)
                {
                    ZSCount = 0;

                }

                if (GCount == 3 && G > 0.6)
                {
                    G = G - 0.1;
                    GCount = 0;
                }

                _timer2 = 0;

                int SpawnSelector = Random.Next(0, 4);
                var xPos = 0;
                var yPos = 0;
                int XTop = ((int)Game1.ScreenWidth / 2) - (_targetTexture.Width * 2);

                Rectangle SpawnTop = new Rectangle(XTop, 1, (int)Game1.ScreenWidth - XTop - _targetTexture.Width, 1);
                Rectangle SpawnBottom = new Rectangle(XTop, ((int)Game1.ScreenHeight - 1 - _targetTexture.Height), (int)Game1.ScreenWidth - XTop - _targetTexture.Width, 1);

                Rectangle SpawnRight = new Rectangle(((int)Game1.ScreenWidth - 1 - _targetTexture.Width), 1, 1, ((int)Game1.ScreenHeight - _targetTexture.Height));
                Rectangle SpawnLeft = new Rectangle(1, 1, 1, ((int)Game1.ScreenHeight - _targetTexture.Height));
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

                else if (SpawnSelector == 2)
                {
                    xPos = Random.Next(SpawnRight.X, SpawnRight.X + SpawnRight.Width);
                    yPos = Random.Next(SpawnRight.Y, SpawnRight.Y + SpawnRight.Height);
                }

                else
                {
                    xPos = Random.Next(SpawnLeft.X, SpawnLeft.X + SpawnLeft.Width);
                    yPos = Random.Next(SpawnLeft.Y, SpawnLeft.Y + SpawnLeft.Height);
                    
                }
                ZomList.Add(GetZombies(xPos, yPos, soldier));
            }
        }
        
        public Zombies GetZombies(int xPos, int yPos, Sprite soldier)
        {
            Random randomType = new Random();
            
            int ZombieType = randomType.Next(0, 200);
            if (ZombieType <= 4)
            {   
                return new ZombieGiant(zombieGiantTexture, new Vector2(xPos, yPos), soldier, 10f, Color.Red);
            }

            
            if(difficultyTimer > 20f & ZombieType <=29 & ZombieType >= 5)
            { 
                return new ZomDog(_targetTexture, new Vector2(xPos, yPos), soldier, 10f, Color.Orange);
            }

            if(difficultyTimer > 35f & ZombieType <= 49 & ZombieType >= 30)
            {
                return new Exploder(_targetTexture, new Vector2(xPos, yPos), soldier, 10f, Color.DarkGreen);
            }

            if(difficultyTimer > 45f & ZombieType <= 198 & ZombieType >= 195)
            {
                return new TentacleFace(TentacleFace, new Vector2(xPos, yPos), soldier, 10f, Color.White);
            }

            if(difficultyTimer > 55f & ZombieType <=69 & ZombieType >= 50)
            {
                return new Spitter(_targetTexture, ZombiesSpit, new Vector2(xPos, yPos), soldier, 10f, Color.Turquoise);
            }
            
            else
            {
                return new Zombies(_targetTexture, new Vector2(xPos, yPos), soldier, 10f, Color.White);
                //return new Spitter(_targetTexture, ZombiesSpit, new Vector2(xPos, yPos), soldier, 10f, Color.Turquoise);
            }
            
        }

        public Zombies GiantDeath(int xPos, int yPos, Sprite soldier)
        {
            return new ZombieImp(_targetTexture, new Vector2(xPos, yPos), soldier, 10f, Color.Green);
        }

        public Zombies ExploderDeath(int xPos, int yPos, Sprite soldier)
        {
            return new ExploderDeath(ExploderDeathSlime, new Vector2(xPos, yPos), soldier, 0f, Color.White);
        }

        
    }
}
