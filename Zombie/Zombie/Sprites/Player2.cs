using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Zombie.Sprites
{
    /*public class Player2 : Sprite
    {
        public Bullet2 Bullet2;

        public int Score;

        public Player2(Texture2D texture)
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            //
            Position = Vector2.Clamp(Position, new Vector2(0, 0), new Vector2(Game1.ScreenWidth - this.Rectangle.Width, Game1.ScreenHeight - this.Rectangle.Height));

            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            if (_currentKey.IsKeyDown(Keys.Left))
                _rotation -= MathHelper.ToRadians(RotationVelocity);
            if (_currentKey.IsKeyDown(Keys.Right))
                _rotation += MathHelper.ToRadians(RotationVelocity);

            Direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - _rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - _rotation));

            if (_currentKey.IsKeyDown(Keys.Up))
                Position += Direction * LinearVelocity;

            if (_currentKey.IsKeyDown(Keys.Down))
                Position -= Direction * LinearVelocity;


            if (_currentKey.IsKeyDown(Keys.Enter) &&
                _previousKey.IsKeyUp(Keys.Enter))
            {
                var bullet2 = Bullet2.Clone() as Bullet2;
                AddBullet2(sprites);
            }

            //
            foreach (var sprite in sprites)
            {
                if (sprite is Player2)
                    continue;
                if (sprite is Bullet2)
                    continue;
                if (sprite is Player)
                    continue;
                if (sprite.Rectangle.Intersects(this.Rectangle))
                {
                    Score++;
                    sprite.IsRemoved = true;
                }
            }
        }

        private void AddBullet2(List<Sprite> sprites)
        {
            var bullet2 = Bullet2.Clone() as Bullet2;
            bullet2.Direction = this.Direction;
            bullet2.Position = this.Position;
            bullet2.LinearVelocity = this.LinearVelocity * 2;
            bullet2.LifeSpan = 2f;
            bullet2.Parent2 = this;

            sprites.Add(bullet2);


        }
    }*/
}
