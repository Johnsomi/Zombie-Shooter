using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie.Sprites
{
    public class ZombieSpit : Zombies
    {
        private float _timer;

        public ZombieSpit(Texture2D texture, Vector2 Position, Sprite FollowTarget, float FollowDistance, Color color) : base(texture, Position, FollowTarget, FollowDistance, color)
        {
            ZombieVelocity = 10f * changedZombieVelocity;
            zombieHealth = 999999;
            //color = Color.Red;
            LifeSpan = 2f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > LifeSpan)
                IsRemoved = true;

            
            this.ZombieVelocity = 10f * changedZombieVelocity;
            Follow();

            double ZomX = (float)Math.Cos(MathHelper.ToRadians(90) + _rotation) - (int)(_texture.Width / 2 * Game1.screenScale.X);
            double ZomY = (float)Math.Sin(MathHelper.ToRadians(90) + _rotation) - (int)(_texture.Height / 2 * Game1.screenScale.Y);
            this.HitBoxZ = new Rectangle((int)(Position.X + ZomX), (int)(Position.Y + ZomY), (int)(_texture.Width / 1 * Game1.screenScale.X), (int)(_texture.Height / 1 * Game1.screenScale.Y));
        }
    }
}
