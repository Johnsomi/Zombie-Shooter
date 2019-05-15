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
        private float Timer;

        public int weaponType;
        public Weapon(Texture2D texture, Vector2 WeaponPos, int bulletType, Color color) : base(texture)
        {
            LifeSpan = 10f;
            Position = WeaponPos;
            this.Color = color;
            weaponType = bulletType;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Timer > LifeSpan)
                IsRemoved = true;
        }
        public override void OnCollide(Sprite sprite)
        {
            if (Rectangle.Intersects(sprite.HitBox) && sprite is Player)
            {
                Player player = (Player)sprite;
                if (weaponType == 1)
                {
                    player.Bullet = player.flameBullet;
                    player._timer = 0;
                }
                else if (weaponType == 0)
                {
                    player.Bullet = player.DefaultBullet;
                }
                else if (weaponType == 2)
                {
                    player.Bullet = player.sniperBullet;
                    player._timer = 0;
                }
                else if(weaponType == 3)
                {
                    player.Bullet = player.shotGun;
                    player._timer = 0;
                }
                else if(weaponType == 4)
                {
                    player.Bullet = player.lazerBullet;
                    player._timer = 0;
                }
                else if(weaponType == 5)
                {
                    player.Bullet = player.cannonBullet;
                    player._timer = 0;
                }
                IsRemoved = true;

            }
        }
    }
}
