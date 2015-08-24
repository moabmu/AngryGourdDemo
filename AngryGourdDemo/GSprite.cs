using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryGourdDemo
{
    public class GSprite : GObject2D
    {
        private readonly string _contentFilepath;
        private Texture2D _texture;
        
        public SpriteEffects Effect { get; set; }
        public Rectangle? DrawRectangle { get; set; }
        public Color Color { get; set; }
        public float Depth { get; set; }

        public float Height
        {
            get
            {
                return _texture.Height;
            }
        }
        public float Width
        {
            get
            {
                return _texture.Width;
            }
        }

        public GSprite(string contentFilepath) 
        {
            _contentFilepath = contentFilepath;
            Color = Color.White;
            Effect = SpriteEffects.None;
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager contentManager)
        {
            base.LoadContent(contentManager);
            _texture = contentManager.Load<Texture2D>(_contentFilepath);
        }

        public override void Draw(RenderContainer renderContainer)
        {
            if(this.CanDraw)
            {
                renderContainer.SpriteBatch
                    .Draw(
                    texture: _texture, // The sprite texture.
                    position: Position, // The location, in screen coordinates, where the sprite will be drawn.
                    sourceRectangle: DrawRectangle, // Which section of the rectangle to draw. Use null to draw the entire texture.
                    color: Color,
                    rotation: MathHelper.ToRadians(Rotation), // Rotate the sprite around the origin.
                    origin: Vector2.Zero, // The origin of the sprite. Specify (0,0) for the upper-left corner.
                    effects: Effect, // Rotations to apply before rendering.
                    layerDepth: Depth); // The sorting depth of the sprite, between 0 (front) and 1 (back). You must specify either SpriteSortMode.FrontToBack or SpriteSortMode.BackToFront for this parameter to affect sprite drawing.
                base.Draw(renderContainer);
            }
        }
    }
}
