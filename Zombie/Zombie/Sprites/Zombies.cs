﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Zombie.Sprites
{
    public class Zombies : Sprite
    {
        public float changedZombieVelocity;
        public double CZVasD;

        public Zombies(Texture2D texture,Vector2 Position, Sprite FollowTarget, float FollowDistance) : base(texture)
        {
            //Random random = new Random();
            zombieHealth = 15;
            this.Position = Position;
            this.FollowTarget = FollowTarget;
            this.FollowDistance = FollowDistance;

            CZVasD = Math.Sqrt((double)(Game1.screenScale.X * Game1.screenScale.Y));
            changedZombieVelocity = (float)CZVasD;

            ZombieVelocity = ZombieVelocity * changedZombieVelocity;
            //Random randomSpeed = new Random();
            //ZombieVelocity = randomSpeed.Next(2, 5);
            //-
            //Speed = Game1.Random.Next(1, 6);
        }

        public Zombies(Texture2D texture, Vector2 Position, Sprite FollowTarget, float FollowDistance, Color color) : this(texture, Position, FollowTarget, FollowDistance)
        {
            Color = color;
        }
    }
}
