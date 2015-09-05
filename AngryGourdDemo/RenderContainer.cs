using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryGourdDemo
{
    /// <summary>
    /// A Container for needed objects and values for rendering
    /// </summary>
    public class RenderContainer
    {
        /// <summary>
        /// If you want to reset scaling after setting GraphicsDevice value, then you
        /// can use the method ResetScaling
        /// </summary>
        public GraphicsDevice GraphicsDevice { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public GameTime GameTime { get; set; }
        /// <summary>
        /// Get Screen height.
        /// </summary>
        public int BaseScreenHeight { get; private set;}
        /// <summary>
        /// Get Screen width.
        /// </summary>
        public int BaseScreenWidth {get; private set;}
        /// <summary>
        /// Get the ratio of the actual device screen width to the base screen width
        /// </summary>
        public float HorScaling { get; private set; }
        /// <summary>
        /// Get the ratio of the actual device screen height to the base screen height
        /// </summary>
        public float VerScaling { get; private set; }

        public RenderContainer()
        {
            HorScaling = 1;
            VerScaling = 1;
        }

        public RenderContainer(Vector2 baseScreenSize, Vector2 actualScreenSize)
        {
            ResetScaling(baseScreenSize, actualScreenSize);
        }

        public void ResetScaling(Vector2 baseScreenSize, Vector2 actualScreenSize)
        {
            HorScaling = actualScreenSize.X / baseScreenSize.X;
            VerScaling = actualScreenSize.Y / baseScreenSize.Y;
            BaseScreenWidth = (int)baseScreenSize.X;
            BaseScreenHeight = (int)baseScreenSize.Y;
        }

    }
}
