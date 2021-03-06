﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie.Sprites
{
    public class ShotGun : Bullet
    {
        public ShotGun(Texture2D texture) : base(texture)
        {
            Color = Color.Brown;
            bulletDamage = bulletDamage - 1;
            LifeSpan = 0.5f;
            LinearVelocity = 20f * changedBulletVelocity;
        }
    }
}
