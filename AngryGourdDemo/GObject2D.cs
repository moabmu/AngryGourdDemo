using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryGourdDemo
{
    public class GObject2D
    {
        public Vector2 Position { get; set; }

        public float Rotation { get; set; }

        public bool CanDraw { get; set; }

        private Rectangle? _relativeBoundingRectangle;
        public Rectangle? BoundingRectangle { get; set; } //protected set; }

        public GObject2D() 
        {
            CanDraw = true;
        }

        /// <summary>
        /// All new objects will be initialized in this method.
        /// </summary>
        public virtual void Initialize() { }
        public virtual void LoadContent(ContentManager contentManager) { }
        public virtual void Update(RenderContainer renderContainer)
        {
            if (_relativeBoundingRectangle.HasValue)
                BoundingRectangle = _relativeBoundingRectangle.Value.Update(Position);
        }
        public virtual void Draw(RenderContainer renderContainer) { }

        public void CreateBoundingRectangle(int width, int height, Vector2 offset)
        {
            _relativeBoundingRectangle = new Rectangle(0, 0, width +
            (int)offset.X, height + (int)offset.Y);
            BoundingRectangle = _relativeBoundingRectangle;
        }
        public void CreateBoundingRectangle(int width, int height)
        {
            CreateBoundingRectangle(width, height, Vector2.Zero);
        }
        public bool TestCollision(GObject2D gameObj)
        {
            if (!gameObj.BoundingRectangle.HasValue) return false;
            if (BoundingRectangle.HasValue && BoundingRectangle.Value.Intersects(gameObj.BoundingRectangle.Value))
                return true;
            return false;
        }
    }
}
