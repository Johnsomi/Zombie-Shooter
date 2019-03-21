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
        public Matrix Transform1 { get; set; }

        public void CamFollow(Player target)
        {
            var Position = Matrix.CreateTranslation(
                -target.Position.X - (target.Rectangle.Width / 2),
                -target.Position.Y - (target.Rectangle.Height / 2),
                0);

            var offset = Matrix.CreateTranslation(
                    State.ScreenWidth / 2,
                    State.ScreenHeight / 2,
                    0);
            Transform1 = Position * offset;
        }
    }
}
