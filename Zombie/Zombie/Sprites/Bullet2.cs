using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie.Sprites
{
    /*public class Bullet2 : Sprite
    {
        private float _timer;

        public int Score;

        public Bullet2(Texture2D texture)
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > LifeSpan)
                IsRemoved = true;

            Position += Direction * LinearVelocity;

            //
            Player2 player2 = (Player2)sprites[1];

            foreach (var sprite in sprites)
            {
                if (sprite is Player2)
                {
                    player2 = (Player2)sprite;
                    continue;
                }
                if (sprite is Bullet2)
                    continue;
                if (sprite.Rectangle.Intersects(this.Rectangle))
                {
                    player2.Score++;
                    sprite.IsRemoved = true;
                }
            }
        }
    }*/
}
