﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie.Sprites
{
    public class Giygas : Zombies
    {
        public Giygas(Texture2D texture, Vector2 Position, Sprite FollowTarget, float FollowDistance, Color color) : base(texture, Position, FollowTarget, FollowDistance, color)
        {
            ZombieVelocity = 0.25f * changedZombieVelocity;
            this.zombieHealth = 2000;
            //color = Color.Red;
        }
    }
}
