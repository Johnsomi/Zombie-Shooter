using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zombie.Core;

namespace Zombie.Sprites
{
    public class Player : Sprite
    {
        //-
        //Rectangle HitBox;

        //Rectangle BulletBox;
        
        //-
        private Vector2 Origin2;

        private Vector2 OriginB;

        public float _timer;

        public Bullet Bullet;
        public Bullet DefaultBullet;
        public FlameThrower flameBullet;
        public SniperRifle sniperBullet;
        public ShotGun shotGun;
        public Lazer lazerBullet;
        public Blackhole cannonBullet;
        Vector2 SpawnLocation;

        //-
        public bool HasDied = false;

        public int Score;

        public Player(Texture2D texture)
            : base(texture)
        {
            SpawnLocation = new Vector2(this.Position.X , Position.Y);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Bullet is FlameThrower)
            {
                
                if (_timer > 10)
                {
                    Bullet = DefaultBullet;
                }
            }
            if (Bullet is SniperRifle)
            {

                if (_timer > 10)
                {
                    Bullet = DefaultBullet;
                }
            }
            if (Bullet is ShotGun)
            {

                if (_timer > 10)
                {
                    Bullet = DefaultBullet;
                }
            }
            if (Bullet is Lazer)
            {

                if (_timer > 10)
                {
                    Bullet = DefaultBullet;
                }
            }
            if (Bullet is Blackhole)
            {

                if (_timer > 10)
                {
                    Bullet = DefaultBullet;
                }
            }
            //___________________-
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();
            Vector2 MousePosition = new Vector2(_currentMouse.X, _currentMouse.Y);
            //MousePosition = Vector2.Clamp(MousePosition, new Vector2(0, 0), new Vector2(Game1.ScreenWidth, Game1.ScreenHeight));
            float DistanceX = MousePosition.X - (Position.X); //+ Origin.X);
            float DistanceY = MousePosition.Y - (Position.Y); //+ Origin.Y);
            //DistanceX = DistanceX * Game1.screenScale.X;
            //DistanceY = DistanceY * Game1.screenScale.Y;
            _rotation = (float)Math.Atan2(DistanceY, DistanceX)+(float)(Math.PI*0.5f);

            //
            this.Position = Vector2.Clamp(Position, new Vector2(0, 0), new Vector2(Game1.ScreenWidth, Game1.ScreenHeight));
            BulletPosition = Vector2.Clamp(Position, new Vector2(0, 0), new Vector2(Game1.ScreenWidth, Game1.ScreenHeight));



            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

           /* if (_currentKey.IsKeyDown(Keys.A))
                _rotation -= MathHelper.ToRadians(RotationVelocity - 2f);
            if (_currentKey.IsKeyDown(Keys.D))
                _rotation += MathHelper.ToRadians(RotationVelocity - 2f);
                */
            Direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - _rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - _rotation));

            //Direction = MousePosition - Position;

            if (_currentKey.IsKeyDown(Keys.W))
                Position += Direction * (playerVelocity);

            if (_currentKey.IsKeyDown(Keys.S))
                Position -= Direction * (playerVelocity);
            //Camera.Update(this);
            if(Bullet is FlameThrower)
            {
                if (_currentMouse.LeftButton == ButtonState.Pressed)
                {
                    var bullet = Bullet.Clone() as Bullet;
                    AddBullet(sprites, 0);
                }
            }
            else if (Bullet is Lazer)
            {
                if (_currentMouse.LeftButton == ButtonState.Pressed)
                {
                    var bullet = Bullet.Clone() as Bullet;
                    AddBullet(sprites, 0);
                }
            }
            else if(Bullet is SniperRifle)
            {
                if (_currentMouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Released)
                {
                    var bullet = Bullet.Clone() as Bullet;
                    AddBullet(sprites, 0);
                }
            }
            else if (Bullet is ShotGun)
            {
                if (_currentMouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Released)
                {
                    var bullet = Bullet.Clone() as Bullet;
                    AddBullet(sprites, 0);
                    AddBullet(sprites, 8);
                    AddBullet(sprites, 16);
                    AddBullet(sprites, -8);
                    AddBullet(sprites, -16);
                }
            }
            else if (Bullet is Blackhole)
            {
                if (_currentMouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Released)
                {
                    var bullet = Bullet.Clone() as Bullet;
                    AddBullet(sprites, 0);
                }
            }
            else
            {
                if(_currentMouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Released)
                {
                    var bullet = Bullet.Clone() as Bullet;
                    AddBullet(sprites, 0);
                }
            }



            /*if (_currentKey.IsKeyDown(Keys.Space) &&
                _previousKey.IsKeyUp(Keys.Space))
            {
                var bullet = Bullet.Clone() as Bullet;
                AddBullet(sprites);

            double newX = Origin.X * Math.Cos(_rotation);
            double newY = Origin.X * Math.Sin(_rotation);
            SpawnLocation = new Vector2(this.Position.X + (float)newX, Position.Y + (float)newY);

            }*/
            //-
            double newX = (float)Math.Cos(MathHelper.ToRadians(90) + _rotation) * 20 - (int)(40 * Game1.screenScale.X);
            double newY = (float)Math.Sin(MathHelper.ToRadians(90) + _rotation) * 20 - (int)(40 * Game1.screenScale.Y);
            HitBox = new Rectangle((int)(Position.X + newX), (int)(Position.Y + newY), (int)(80 * Game1.screenScale.X), (int)(80 * Game1.screenScale.Y));
            //-
            Origin2 = new Vector2(50, 50);

            //BulletBox = new Rectangle(this.Rectangle.X, this.Rectangle.Y, (int)(80 * Game1.screenScale.X), (int)(80 * Game1.screenScale.Y));

            //OriginB = new Vector2((int)(16 * Game1.screenScale.X), 20);
            OriginB = new Vector2((int)(70 * Game1.screenScale.X), 0);
            //Was 16


            foreach (var sprite in sprites)
            {
                if (sprite is Player)
                    continue;
                
                if (sprite is Bullet)
                    continue;
                //if (sprite is Player2)
                //  continue;
                if (sprite.Rectangle.Intersects(HitBox) && sprite is Weapon)
                {
                    Weapon weapon = (Weapon)sprite;
                    if(weapon.weaponType == 1)
                    {
                        Bullet = flameBullet;
                    }
                    if(weapon.weaponType == 2)
                    {
                        Bullet = sniperBullet;
                    }
                    if(weapon.weaponType == 3)
                    {
                        Bullet = shotGun;
                    }
                    if(weapon.weaponType == 4)
                    {
                        Bullet = lazerBullet;
                    }
                    if(weapon.weaponType == 5)
                    {
                        Bullet = cannonBullet;
                    }
                    sprite.IsRemoved = true;

                }
                //-

                if (sprite.HitBoxZ.Intersects(HitBox) && sprite is Zombies)
                {
                    IsRemoved = true;
                    this.HasDied = true;
                    //Score++;
                    //sprite.IsRemoved = true;
                }

                if (sprite.HitBoxD1.Intersects(HitBox) && sprite is TentacleFace)
                {
                    IsRemoved = true;
                    this.HasDied = true;
                }

                if (sprite.HitBoxD2.Intersects(HitBox) && sprite is TentacleFace)
                {
                    IsRemoved = true;
                    this.HasDied = true;
                }
            }
        }

        private void AddBullet(List<Sprite> sprites,int offset)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90+offset) - _rotation), -(float)Math.Sin(MathHelper.ToRadians(90+offset) - _rotation));
            //bullet.Direction = this.Direction;
            double newX = OriginB.X * Math.Cos(_rotation+MathHelper.ToRadians(-75));
            double newY = OriginB.X * Math.Sin(_rotation+MathHelper.ToRadians(-75));
            //double newX2 = OriginB.Y * Math.Cos(_rotation);
            //double newY2 = OriginB.Y * Math.Sin(_rotation);
            SpawnLocation = new Vector2(this.Position.X + (float)newX, Position.Y + (float)newY);
            bullet.Position = SpawnLocation;
            //bullet.LinearVelocity = this.LinearVelocity * 3;
            //bullet.LifeSpan = 2f;
            bullet.Parent = this;

            sprites.Add(bullet);


        }

        public override void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(_texture, SpawnLocation, null, Color2, _rotation, OriginB, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(_texture, Position, null, Color, _rotation , Origin, Game1.screenScale, SpriteEffects.None, 0);
            //spriteBatch.Draw(_texture, HitBox, null, Color.Red);
            //spriteBatch.Draw(_texture, Position, null, Color2, _rotation, OriginB, 1, SpriteEffects.None, 0);
            

        }

        public override void OnCollide(Sprite sprite)
        {
            IsRemoved = true;
        }

    }
}
