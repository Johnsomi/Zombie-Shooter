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

        public Bullet(Texture2D texture)
            : base(texture)
        {

        }



        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > LifeSpan)
                IsRemoved = true;

            Position += Direction * LinearVelocity;

          
           
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
            sprite.IsRemoved = true;
            IsRemoved = true;
            //player.Score++;
        }
    }
}
