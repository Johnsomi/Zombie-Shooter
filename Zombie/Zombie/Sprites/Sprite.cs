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
    public class Sprite : Component ,  ICloneable 
    {
        protected Texture2D _texture;
        protected float _rotation;
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;
        //
        protected float _layer { get; set; }
        //
        protected Vector2 _origin1 { get; set; }
        //
        protected Vector2 _position1 { get; set; }
        //
        protected float _rotation1 { get; set; }

        public Vector2 Position;
        public Vector2 Origin;

        
        public Color Color = Color.White;
        //
        public Sprite FollowTarget { get; set; }
        //
        public float FollowDistance { get; set; }

        public Vector2 Direction;
        //
        public Vector2 Direction1;
        public float RotationVelocity = 3f;
        public float LinearVelocity = 4f;

        public Sprite Parent;

        public float LifeSpan = 0f;

        public bool IsRemoved { get; set; }

        //public bool IsRemoved = false;

        //public readonly Color[] TextureData;

        //
        public float Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
            }
        }
        //
        public Vector2 Origin1
        {
            get { return _origin1; }
            set
            {
                _origin1 = value;
            }
        }
        //
        public Vector2 Position1
        {
            get { return _position1; }
            set
            {
                _position1 = value;
            }
        }
        //
        public Rectangle Rectangle1
        {
            get
            {
                return new Rectangle((int)Position1.X - (int)Origin1.X, (int)Position1.Y - (int)Origin1.Y, _texture.Width, _texture.Height);
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        //
        public float Rotation1
        {
            get { return _rotation1; }
            set
            {
                _rotation1 = value;
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
            //
            Origin1 = new Vector2(_texture.Width / 2, _texture.Height / 2);



            //TextureData = new Color[_texture.Width * _texture.Height];
            //_texture.GetData(TextureData);
        }

        //
        public override void Update(GameTime gameTime)
        {
            Follow();
        }

        //
        protected void Follow()
        {
            if (FollowTarget == null)
                return;

            var distance1 = FollowTarget.Position1 - this.Position1;
            _rotation1 = (float)Math.Atan2(distance1.Y, distance1.X);

            Direction1 = new Vector2((float)Math.Cos(_rotation1), (float)Math.Sin(_rotation1));

            var currentDistance = Vector2.Distance(this.Position1, FollowTarget.Position1);
            if (currentDistance > FollowDistance)
            {
                var t = MathHelper.Min((float)Math.Abs(currentDistance - FollowDistance), LinearVelocity);
                var velocity1 = Direction1 * t;

                Position1 += velocity1;
            }
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }
        //
        public virtual void Draw1(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position1, null, Color, _rotation1, Origin1, 1, SpriteEffects.None, Layer);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color, _rotation, Origin, 1, SpriteEffects.None, 0);
        }
        //
        public Sprite SetFollowTarget(Sprite followTarget, float followDistance)
        {
            FollowTarget = followTarget;

            FollowDistance = followDistance;

            return this;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
