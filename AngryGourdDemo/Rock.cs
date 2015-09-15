using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using AngryGourdDemo;

namespace AngryGourdDemo
{
    public class Rock : GSprite
    {
        //private GSprite _rockSprite;
        private const int moveSpeed = 160;
        
        private Rock(string contentPath) : base(contentPath) { }

        public Rock() : this("Sprites/Rock") { }

        public override void Update(RenderContainer renderContainer)
        {
            base.Update(renderContainer);

            var pos = this.Position;
            pos.Y += (float)(moveSpeed * renderContainer.GameTime.ElapsedGameTime.TotalSeconds);
            this.Position = pos;
            if (BoundingRectangle.HasValue)
            {
                BoundingRectangle.Value.Update(pos);
                //Debug.WriteLine("+ ROCK BoundingRectangle: X = {0}, Y = {1}", BoundingRectangle.Value.X, BoundingRectangle.Value.Y);
            }
        }
        public override void Initialize()
        {
            base.Initialize();
            this.CreateBoundingRectangle(80,66);
        }
    }
}
