using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;

namespace AngryGourdDemo
{
    public class Explosion : GAnimatedSprite
    {
        private const int FrameWidth = 210;

        public Explosion():base("Sprites/Explosion_Large_Spritesheet", 16, 75, new Point(FrameWidth, FrameWidth), 4)
        { }

        public override void Initialize()
        {
            Position = new Vector2(25, 330);
            //PlayAnimation(false);
            CreateBoundingRectangle(FrameWidth, FrameWidth);
        }
    }
}
