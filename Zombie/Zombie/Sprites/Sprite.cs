using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie.Sprites
{
    public class Sprite :  ICloneable
    {
        protected Texture2D _texture;
        protected float _rotation;
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

        public Vector2 Position;
        public Vector2 Origin;
        

        
        public Color Color = Color.White;

        public Vector2 Direction;
        public float RotationVelocity = 3f;
        public float LinearVelocity = 4f;

        public Sprite Parent;

        public float LifeSpan = 0f;

        public bool IsRemoved = false;

        public readonly Color[] TextureData;
        //
        public float FollowDistance;
        //
        public Sprite FollowTarget;

        
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            TextureData = new Color[_texture.Width * _texture.Height];
            _texture.GetData(TextureData);

        }

        //
        
        //
        protected void Follow()
        {
            if (FollowTarget == null)
                return;

            var distance = FollowTarget.Position - this.Position;
            _rotation = (float)Math.Atan2(distance.Y, distance.X);

            Direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));

            var currentDistance = Vector2.Distance(this.Position, FollowTarget.Position);
            if (currentDistance > FollowDistance)
            {
                var t = MathHelper.Min((float)Math.Abs(currentDistance - FollowDistance), LinearVelocity);
                var velocity = Direction * t;

                Position += velocity;
            }
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            //
            Follow();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color, _rotation, Origin, 1, SpriteEffects.None, 0);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        //
        public Sprite SetFollowTarget(Sprite followTarget, float followDistance)
        {
            FollowTarget = followTarget;

            FollowDistance = followDistance;

            return this;
        }
    }
}
