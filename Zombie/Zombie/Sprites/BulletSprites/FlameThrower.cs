using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie.Sprites
{
    public class FlameThrower : Bullet
    {
        
        public FlameThrower(Texture2D texture) : base(texture)
        {
            Color = Color.Red;
            bulletDamage = 1;
            LifeSpan = 1f;
        }
    }
}
