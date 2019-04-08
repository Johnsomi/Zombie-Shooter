﻿using Microsoft.Xna.Framework;
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
        public Weapon(Texture2D texture, Vector2 WeaponPos, int bulletType, Color color) : base(texture)
        {
            Position = WeaponPos;
            this.Color = color;
            weaponType = bulletType;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            
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
                IsRemoved = true;

            }
        }
    }
}