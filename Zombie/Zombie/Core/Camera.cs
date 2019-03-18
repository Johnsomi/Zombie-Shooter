using Microsoft.Xna.Framework;
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
        public Matrix Transform { get; private set; }

        public void CamFollow(Sprite target)
        {
            var Position = Matrix.CreateTranslation(
                -target.Position.X - (target.Rectangle.Width / 2),
                -target.Position.Y - (target.Rectangle.Height / 2),
                0);

            var offset = Matrix.CreateTranslation(
                    GameState.ScreenWidth / 2,
                    GameState.ScreenHeight / 2,
                    0);
            Transform = Position * offset;
        }
    }
}
