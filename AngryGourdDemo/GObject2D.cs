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

        public GObject2D() 
        {
            CanDraw = true;
        }

        /// <summary>
        /// All new objects will be initialized in this method.
        /// </summary>
        public virtual void Initialize() { }
        public virtual void LoadContent(ContentManager contentManager) { }
        public virtual void Update(RenderContainer renderContainer) { }
        public virtual void Draw(RenderContainer renderContainer) { }
    }
}
