using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie.Sprites
{
    public class Weapon : Sprite
    {
        public int weaponType;
        public Weapon(Texture2D texture, Vector2 WeaponPos, int bulletType) : base(texture)
        {
            Position = WeaponPos;
            weaponType = bulletType;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            
        }
        
    }
}
