using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace AngryGourdDemo
{
    public class Hero : GObject2D
    {
        private GAnimatedSprite _heroSprite;
        private const int FrameWidth = 64;
        private const int moveSpeed = 130;
        private sbyte _direction = 1;

        public override void Initialize()
        {
            _heroSprite = new GAnimatedSprite("Sprites/Hero_Run_Spritesheet", 10 , 75, new Point(FrameWidth,64));
            _heroSprite.Position = new Vector2(25, 384);
            _heroSprite.PlayAnimation(true);
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _heroSprite.LoadContent(contentManager);
        }

        public override void Update(RenderContainer renderContainer)
        {
            _heroSprite.Update(renderContainer);

            var pos = _heroSprite.Position;

            if(pos.X >= renderContainer.GraphicsDevice.Viewport.Width - FrameWidth && _direction != -1)
            {
                _direction = -1;
                _heroSprite.Effect = Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally;
            }
            else if ( pos.X < 0 && _direction != 1)
            {
                _direction = 1;
                _heroSprite.Effect = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
            }

            pos.X += (float)(moveSpeed * renderContainer.GameTime.ElapsedGameTime.TotalSeconds * _direction);
            _heroSprite.Position = pos;
        }

        public override void Draw(RenderContainer renderContainer)
        {
            _heroSprite.Draw(renderContainer);
        }

    }
}
