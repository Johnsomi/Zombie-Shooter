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
    public class Sprite : ICloneable
    {
        protected Texture2D _texture;
        public float _rotation;
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

        public Vector2 Position;
        public Vector2 Origin;

        //______
        public Vector2 BulletPosition;

        //private float _timer3 = 0;

        public int zombieHealth;

        public Rectangle HitBox;
        //-
        public Rectangle HitBoxZ;
        //-
        public Rectangle HitBoxD1;

        public Rectangle HitBoxD2;

        Vector2 Origin3;
        
        // Was = Color.White;
        public Color Color { get; set; }
        public Color Color2 { get; set; }
        //_____________
        public Vector2 MouseDirection;
        public MouseState _currentMouse;
        public MouseState _previousMouse;

        public Vector2 Direction;
        public float RotationVelocity = 4f;
        public float LinearVelocity = 4f;

        public float playerVelocity = 4f;

        public float ZombieVelocity = 2f;

        //public float changedZombieVelocity;
        //public double CZVasD;
        //public Vector2 SpitPosition;
        

        //-
        public float Speed;

        public int bulletDamage = 5;

        public Sprite Parent;

        public float LifeSpan = 0f;

        public bool IsRemoved = false;

        public readonly Color[] TextureData;
        //-------
        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
                    Matrix.CreateRotationZ(_rotation) *
                    Matrix.CreateTranslation(new Vector3(Position, 0));
            }
        }
        //
        public float FollowDistance;
        //
        public Sprite FollowTarget;

        
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)(Position.X), (int)(Position.Y), (int)(_texture.Width * Game1.screenScale.X), (int)(_texture.Height * Game1.screenScale.Y));
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            Origin3 = new Vector2(_texture.Width / 2, _texture.Height / 2);

            TextureData = new Color[_texture.Width * _texture.Height];
            _texture.GetData(TextureData);

            //-----
            Color = Color.White;
            Color2 = Color.Blue;
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
                var t = MathHelper.Min((float)Math.Abs(currentDistance - FollowDistance), ZombieVelocity);
                var velocity = Direction * t;

                Position += velocity;
            }
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            //
            
            //CZVasD = Math.Sqrt((double)(Game1.screenScale.X * Game1.screenScale.Y));
            //changedZombieVelocity = (float)CZVasD;
            
            //ZombieVelocity = ZombieVelocity * changedZombieVelocity;
            
            Follow();

            //_timer3 += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //SpitPosition += Direction * ZombieVelocity;
            
            /*
            if (_timer3 > 3)
            {
                ZombieVelocity = ZombieVelocity + 0.5f;

                _timer3 = 0;
            }*/

            //-
            //Origin3 = new Vector2(35, 30);
            //HitBoxZ = new Rectangle(this.Rectangle.X, this.Rectangle.Y, 70, 60);
            //HitBoxZ = new Rectangle(this.Rectangle.X-_texture.Width / 3, this.Rectangle.Y- _texture.Height / 3, (int)((_texture.Width/1.5) * Game1.screenScale.X), (int)(_texture.Height/1.5 * Game1.screenScale.Y));

            double ZomX = (float)Math.Cos(MathHelper.ToRadians(90) + _rotation) - (int)(_texture.Width/3 * Game1.screenScale.X);
            double ZomY = (float)Math.Sin(MathHelper.ToRadians(90) + _rotation) - (int)(_texture.Height/3 * Game1.screenScale.Y);
            HitBoxZ = new Rectangle((int)(Position.X + ZomX), (int)(Position.Y + ZomY), (int)(_texture.Width/1.5 * Game1.screenScale.X), (int)(_texture.Height/1.5 * Game1.screenScale.Y));

            double newX = (float)Math.Cos(MathHelper.ToRadians(0) + _rotation) * 110 - (int)(80 * Game1.screenScale.X);
            double newY = (float)Math.Sin(MathHelper.ToRadians(0) + _rotation) * 110 - (int)(80 * Game1.screenScale.Y);
            HitBoxD1 = new Rectangle((int)(Position.X + newX), (int)(Position.Y + newY), (int)(160 * Game1.screenScale.X), (int)(160 * Game1.screenScale.Y));

            double newX2 = (float)Math.Cos(MathHelper.ToRadians(180) + _rotation) * 110 - (int)(80 * Game1.screenScale.X);
            double newY2 = (float)Math.Sin(MathHelper.ToRadians(180) + _rotation) * 110 - (int)(80 * Game1.screenScale.Y);
            HitBoxD2 = new Rectangle((int)(Position.X + newX2), (int)(Position.Y + newY2), (int)(160 * Game1.screenScale.X), (int)(160 * Game1.screenScale.Y));
            
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            /*
            if (zombieHealth == 3)
            {
                Color = Color.Green;
                ZombieVelocity = 5f;
            }
            if (zombieHealth == 2)
            {
                Color = Color.Yellow;
                ZombieVelocity = 3.5f;
            }
            if (zombieHealth == 1)
            {
                Color = Color.Red;
                ZombieVelocity = 2f;
            }
            */
            //if (Game1.ScreenWidth == 1920 && Game1.ScreenHeight == 1080)
            //{
            //    spriteBatch.Draw(_texture, Position, null, Color, _rotation, Origin, 1, SpriteEffects.None, 0);
            //}

            //if(Game1.ScreenWidth == 1600 && Game1.ScreenHeight == 900)
            //{
                spriteBatch.Draw(_texture, Position, null, Color, _rotation, Origin, Game1.screenScale, SpriteEffects.None, 0);
            //}
            spriteBatch.Draw(_texture, HitBox, null, Color.Black);
            spriteBatch.Draw(_texture, HitBoxZ, Color.White);
            //spriteBatch.Draw(_texture, HitBoxD1, null, Color.Black);
            //spriteBatch.Draw(_texture, HitBoxD2, null, Color.Black);
        }

        //-----
        public bool Intersects(Sprite sprite)
        {
            // Calculate a matrix which transforms from A's local space into
            // world space and then into B's local space
            var transformAToB = this.Transform * Matrix.Invert(sprite.Transform);

            // When a point moves in A's local space, it moves in B's local space with a
            // fixed direction and distance proportional to the movement in A.
            // This algorithm steps through A one pixel at a time along A's X and Y axes
            // Calculate the analogous steps in B:
            var stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
            var stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);

            // Calculate the top left corner of A in B's local space
            // This variable will be reused to keep track of the start of each row
            var yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);

            for (int yA = 0; yA < this.Rectangle.Height; yA++)
            {
                // Start at the beginning of the row
                var posInB = yPosInB;

                for (int xA = 0; xA < this.Rectangle.Width; xA++)
                {
                    // Round to the nearest pixel
                    var xB = (int)Math.Round(posInB.X);
                    var yB = (int)Math.Round(posInB.Y);

                    if (0 <= xB && xB < sprite.Rectangle.Width &&
                        0 <= yB && yB < sprite.Rectangle.Height)
                    {
                        // Get the colors of the overlapping pixels
                        var colourA = this.TextureData[xA + yA * this.Rectangle.Width];
                        var colourB = sprite.TextureData[xB + yB * sprite.Rectangle.Width];

                        // If both pixel are not completely transparent
                        if (colourA.A != 0 && colourB.A != 0)
                        {
                            return true;
                        }
                    }

                    // Move to the next pixel in the row
                    posInB += stepX;
                }

                // Move to the next row
                yPosInB += stepY;
            }

            // No intersection found
            return false;
        }

        //-----
        public virtual void OnCollide(Sprite sprite)
        {

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

        /*public override void Update(GameTime gameTime)
        {
            
        }*/

        //public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        //{
            
        //}
    }
}
