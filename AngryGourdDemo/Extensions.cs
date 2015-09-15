using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryGourdDemo
{
    public static class Extensions
    {
        public static Rectangle Update(this Rectangle rectangle, Vector2 position, Vector2 size)
        {
            return new Rectangle(
                (int)position.X, 
                (int)position.Y, 
                (int)size.X, 
                (int)size.Y);
        }

        public static Rectangle Update(this Rectangle rectangle, Vector2 position)
        {
            return Update(rectangle, position, new Vector2(rectangle.Width, rectangle.Height));
        }
    }
}
