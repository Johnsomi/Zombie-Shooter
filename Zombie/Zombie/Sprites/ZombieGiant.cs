using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie.Sprites
{
    public class ZombieGiant : Zombies
    {
        public ZombieGiant(Texture2D texture, Vector2 Position, Sprite FollowTarget, float FollowDistance) : base(texture, Position, FollowTarget, FollowDistance)
        {
            ZombieVelocity = 1f;
            zombieHealth = 25;
        }
    }
}
