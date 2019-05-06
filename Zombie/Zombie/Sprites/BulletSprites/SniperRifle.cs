using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie.Sprites
{
    public class SniperRifle : Bullet
    {
        public SniperRifle(Texture2D texture) : base(texture)
        {
            Color = Color.Black;
            LifeSpan = 5f;
            LinearVelocity = 25f * changedBulletVelocity;
            bulletDamage = 20;
        }
    }
}
