using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie.Sprites
{
    public class Blackhole : Bullet
    {
        public Blackhole(Texture2D texture) : base(texture)
        {
            Color = Color.Black;
            bulletDamage = bulletDamage + 195;
            LifeSpan = 20f;
            LinearVelocity = 1f * changedBulletVelocity;
        }
    }
}
