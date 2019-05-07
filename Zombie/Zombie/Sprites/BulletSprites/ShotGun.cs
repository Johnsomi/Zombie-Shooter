using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie.Sprites.BulletSprites
{
    public class ShotGun : Bullet
    {
        public ShotGun(Texture2D texture) : base(texture)
        {
            Color = Color.Red;
            bulletDamage = 1;
            LifeSpan = 1f;
            LinearVelocity = 10f * changedBulletVelocity;
        }
    }
}
