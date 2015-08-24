using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryGourdDemo
{
    public class RenderContainer
    {
        public GraphicsDevice GraphicsDevice { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public GameTime GameTime { get; set; }
        /// <summary>
        /// Get Screen height.
        /// </summary>
        public int Height
        {
            get
            {
                return GraphicsDevice.PresentationParameters.BackBufferHeight;
            }
        }
        /// <summary>
        /// Get Screen width.
        /// </summary>
        public int Width 
        {
            get 
            {
                return GraphicsDevice.PresentationParameters.BackBufferWidth;
            }
        }

    }
}
