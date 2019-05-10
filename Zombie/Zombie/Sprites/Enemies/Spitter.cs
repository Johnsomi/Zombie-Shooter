using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie.Sprites
{
    public class Spitter : Zombies
    {
        private float _timer;
        Texture2D spitTexture;
        //Vector2 SpitPosition;
        public Spitter(Texture2D texture, Texture2D spitTexture, Vector2 Position, Sprite FollowTarget, float FollowDistance, Color color) : base(texture, Position, FollowTarget, FollowDistance, color)
        {
            ZombieVelocity = 1.5f * changedZombieVelocity;
            zombieHealth = 15;
            //color = Color.Red;
            this.spitTexture = spitTexture;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            //Position += Direction * ZombieVelocity;
            if (_timer > 2f)
            {
                sprites.Add(new ZombieSpit(spitTexture, Position, null, 0, Color.Green));
                _timer = 0f;
            }
            //_timer = 0;
            /*if (_timer > LifeSpan)
                IsRemoved = true;



            double ZomX = (float)Math.Cos(MathHelper.ToRadians(90) + _rotation) - (int)(_texture.Width / 2 * Game1.screenScale.X);
            double ZomY = (float)Math.Sin(MathHelper.ToRadians(90) + _rotation) - (int)(_texture.Height / 2 * Game1.screenScale.Y);
            this.HitBoxZ = new Rectangle((int)(Position.X + ZomX), (int)(Position.Y + ZomY), (int)(_texture.Width / 1 * Game1.screenScale.X), (int)(_texture.Height / 1 * Game1.screenScale.Y));*/
            base.Update(gameTime, sprites);
        }
    }
}
