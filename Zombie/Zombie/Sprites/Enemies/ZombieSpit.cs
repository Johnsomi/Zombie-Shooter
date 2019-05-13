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

        Vector2 SpitDirection;

        public ZombieSpit(Texture2D texture, Vector2 Position, Sprite FollowTarget, float FollowDistance, Color color) : base(texture, Position, FollowTarget, FollowDistance, color)
        {
            this.ZombieVelocity = 5f * changedZombieVelocity;
            zombieHealth = 1;
            //color = Color.Red;
            LifeSpan = 2f;
            var distance = FollowTarget.Position - this.Position;
            _rotation = (float)Math.Atan2(distance.Y, distance.X);
            SpitDirection = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > LifeSpan)
                IsRemoved = true;
            Position += SpitDirection * ZombieVelocity;
            
            this.ZombieVelocity = 5f * changedZombieVelocity;
            //Follow();

            double ZomX = (float)Math.Cos(MathHelper.ToRadians(90) + _rotation) - (int)(_texture.Width / 2 * Game1.screenScale.X);
            double ZomY = (float)Math.Sin(MathHelper.ToRadians(90) + _rotation) - (int)(_texture.Height / 2 * Game1.screenScale.Y);
            this.HitBoxZ = new Rectangle((int)(Position.X + ZomX), (int)(Position.Y + ZomY), (int)(_texture.Width / 1 * Game1.screenScale.X), (int)(_texture.Height / 1 * Game1.screenScale.Y));
        }
    }
}
