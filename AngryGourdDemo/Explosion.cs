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
    public class Explosion : GObject2D
    {
        private GAnimatedSprite _explosionSprite;
        private const int FrameWidth = 105;

        public new Vector2 Position
        {
            get { return _explosionSprite.Position; }
            set { _explosionSprite.Position = value; }
        }

        public override void Initialize()
        {
            _explosionSprite = new GAnimatedSprite("Sprites/Explosion_Spritesheet", 16, 75, new Point(FrameWidth, 105),4);
            _explosionSprite.Position = new Vector2(25, 384);
            _explosionSprite.PlayAnimation(true);
            _explosionSprite.CreateBoundingRectangle(FrameWidth, FrameWidth);
            BoundingRectangle = _explosionSprite.BoundingRectangle.Value;
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _explosionSprite.LoadContent(contentManager);
        }
        public override void Update(RenderContainer renderContainer)
        {
            _explosionSprite.Update(renderContainer);
        }

        public override void Draw(RenderContainer renderContainer)
        {
            _explosionSprite.Draw(renderContainer);
        }
    }
}
