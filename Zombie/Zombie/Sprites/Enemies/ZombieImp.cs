﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie.Sprites
{
    public class ZombieImp : Zombies
    {
        public ZombieImp(Texture2D texture, Vector2 Position, Sprite FollowTarget, float FollowDistance, Color color) : base(texture, Position, FollowTarget, FollowDistance, color)
        {
            ZombieVelocity = 5f * changedZombieVelocity;
            zombieHealth = 3;
            //color = Color.DarkSlateBlue;
        }
    }
}
