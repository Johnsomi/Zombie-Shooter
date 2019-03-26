using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zombie.Sprites;
using Zombie.States;

namespace Zombie.Core
{
    public class Camera
    {
        /*KeyboardState _currentKey;
        KeyboardState _previousKey;
        static Vector2 Origin;
        static float _rotation;

        public static Vector2 CamPos;

        static public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
                    Matrix.CreateRotationZ(_rotation) *
                    Matrix.CreateTranslation(new Vector3(CamPos, 0));
            }
        }

        public Camera()
        {
            Origin = new Vector2(GameState.ScreenWidth / 2, GameState.ScreenHeight / 2); 
        }

        public Matrix Transform1 { get; private set; }

        public void CamFollow(Sprite target)
        {
            CamPos = target.Position;

            var Position = Matrix.CreateTranslation(
                -target.Position.X,
                -target.Position.Y,
                0);

            var offset = Matrix.CreateTranslation(
                    State.ScreenWidth / 2,
                    State.ScreenHeight / 2,
                    0);
            Transform1 = Position * offset;
        }

        public static void Update(Sprite target)
        {
            CamPos = target.Position;
            _rotation = target._rotation;
            Origin = new Vector2(GameState.ScreenWidth / 2, GameState.ScreenHeight / 2);


        }
        */
    }
}
