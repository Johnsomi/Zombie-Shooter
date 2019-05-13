using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie.Sprites
{
    public class Bullet : Sprite
    {
        private float _timer;

        public int Score;

        public float changedBulletVelocity;
        public double CBVasD;

        public Bullet(Texture2D texture)
            : base(texture)
        {
            LifeSpan = 2f;

            CBVasD = Math.Sqrt((double)(Game1.screenScale.X * Game1.screenScale.Y));
            changedBulletVelocity = (float)CBVasD;

            
            LinearVelocity = 15f * changedBulletVelocity;
            
        }



        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > LifeSpan)
                IsRemoved = true;

            Position += Direction * LinearVelocity;

            double BX = (float)Math.Cos(MathHelper.ToRadians(90) + _rotation) - (int)(_texture.Width/2 * Game1.screenScale.X);
            double BY = (float)Math.Sin(MathHelper.ToRadians(90) + _rotation) - (int)(_texture.Height/2 * Game1.screenScale.Y);
            this.HitBox = new Rectangle((int)(Position.X + BX), (int)(Position.Y + BY), (int)(_texture.Width * Game1.screenScale.X), (int)(_texture.Height * Game1.screenScale.Y));

            //this.HitBox = Rectangle;
            //HitBox = new Rectangle((int)(Position.X), (int)(Position.Y), (int)(_texture.Width * Game1.screenScale.X), (int)(_texture.Height * Game1.screenScale.Y));
        }

        //-----
        public override void OnCollide(Sprite sprite)
        {
            /*  if (sprite == this.Parent)
                  return;

              if (sprite is Bullet)
              

              if (sprite is Sprite)
                  return;
                  */
            
            sprite.zombieHealth = sprite.zombieHealth - bulletDamage;
            if (sprite.zombieHealth <= -1001)
            {
                sprite.IsRemoved = false;
                
            }
            if (sprite.zombieHealth <= 0 & sprite.zombieHealth >= -1000)
            {
                sprite.IsRemoved = true;
                IsRemoved = true;
            }
            
            //sprite.IsRemoved = true;
            //IsRemoved = true;
            //player.Score++;
        }
    }
}
