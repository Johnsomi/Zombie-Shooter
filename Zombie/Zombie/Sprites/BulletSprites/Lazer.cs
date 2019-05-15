using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie.Sprites
{
    public class Lazer : Bullet
    {
        public Lazer(Texture2D texture) : base(texture)
        {
            Color = Color.White;
            bulletDamage = bulletDamage + 0;
            LifeSpan = 1f;
            LinearVelocity = 25f * changedBulletVelocity;
        }
    }
}
