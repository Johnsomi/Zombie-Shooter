﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace shooting_ship.Sprites
{
    public class Ship : Sprite
    {
        public Bullet Bullet;

        public Ship(Texture2D texture)
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            if (_currentKey.IsKeyDown(Keys.A))
                _rotation -= MathHelper.ToRadians(RotationVelocity);
            if (_currentKey.IsKeyDown(Keys.D))
                _rotation += MathHelper.ToRadians(RotationVelocity);

            Direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - _rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - _rotation));

            if (_currentKey.IsKeyDown(Keys.W))
                Position += Direction * LinearVelocity;

            if (_currentKey.IsKeyDown(Keys.S))
                Position -= Direction * LinearVelocity;


            if (_currentKey.IsKeyDown(Keys.Space) &&
                _previousKey.IsKeyUp(Keys.Space))
            {
                var bullet = Bullet.Clone() as Bullet;
                AddBullet(sprites);
            }
        }

        private void AddBullet(List<Sprite> sprites)
        { 
                var bullet = Bullet.Clone() as Bullet;
                bullet.Direction = this.Direction;
                bullet.Position = this.Position;
                bullet.LinearVelocity = this.LinearVelocity * 2;
                bullet.LifeSpan = 2f;
                bullet.Parent = this;

                sprites.Add(bullet);

            
        }
    }
}
