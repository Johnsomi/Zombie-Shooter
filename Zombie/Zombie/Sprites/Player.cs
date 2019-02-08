using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie.Sprites
{
    public class Player : Sprite
    {
        //-
        Rectangle HitBox;
        
        //-
        private Vector2 Origin2;

        public Bullet Bullet;
        
        //-
        public bool HasDied = false;

        public int Score;

        public Player(Texture2D texture)
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

            //___________________-
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();
            Vector2 MousePosition = new Vector2(_currentMouse.X, _currentMouse.Y);

            //
            Position = Vector2.Clamp(Position, new Vector2(0, 0), new Vector2(Game1.ScreenWidth - this.Rectangle.Width, Game1.ScreenHeight - this.Rectangle.Height));
            

            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            if (_currentKey.IsKeyDown(Keys.A))
                _rotation -= MathHelper.ToRadians(RotationVelocity - 2f);
            if (_currentKey.IsKeyDown(Keys.D))
                _rotation += MathHelper.ToRadians(RotationVelocity - 2f);

            Direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - _rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - _rotation));

            //Direction = MousePosition - Position;

            if (_currentKey.IsKeyDown(Keys.W))
                Position += Direction * (playerVelocity - 2f);

            if (_currentKey.IsKeyDown(Keys.S))
                Position -= Direction * (playerVelocity - 2f);

            //
            

            if (_currentKey.IsKeyDown(Keys.Space) &&
                _previousKey.IsKeyUp(Keys.Space))
            {
                var bullet = Bullet.Clone() as Bullet;
                AddBullet(sprites);
            }
            //-
            HitBox = new Rectangle(this.Rectangle.X, this.Rectangle.Y, 80, 80);
            //-
            Origin2 = new Vector2(50, 50);
            
            foreach (var sprite in sprites)
            {
                if (sprite is Player)
                    continue;
                if (sprite is Bullet)
                    continue;
                //if (sprite is Player2)
                  //  continue;

                //-
                if (sprite.Rectangle.Intersects(HitBox))
                {
                    
                    this.HasDied = true;
                    //Score++;
                    //sprite.IsRemoved = true;
                }
            }
        }

        private void AddBullet(List<Sprite> sprites)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Direction = this.Direction;
            bullet.Position = this.Position;
            bullet.LinearVelocity = this.LinearVelocity * 2;
            bullet.LifeSpan = 2f;
            bullet.Parent = this;

            sprites.Add(bullet);


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color, _rotation, Origin, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(_texture, HitBox, null, Color.Red, _rotation, Origin2, SpriteEffects.None, 0);

        }

    }
}
