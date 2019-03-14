using System;
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
        public Zombies(Texture2D texture) : base(texture)
        {
            Random random = new Random();
            health = random.Next(1, 4);
            //-
            //Speed = Game1.Random.Next(1, 6);
        }
    }
}
