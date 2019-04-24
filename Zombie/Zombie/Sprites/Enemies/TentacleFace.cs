using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie.Sprites
{
    public class TentacleFace : Zombies
    {
        public TentacleFace(Texture2D texture, Vector2 Position, Sprite FollowTarget, float FollowDistance, Color color) : base(texture, Position, FollowTarget, FollowDistance, color)
        {
            ZombieVelocity = 0.5f;
            zombieHealth = 250;
            
            //color = Color.Red;
        }
    }
}
