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
    public class Hero : GObject2D
    {
        private GAnimatedSprite _heroSprite;
        private const int FrameWidth = 64;
        private const int moveSpeed = 130;
        public sbyte Direction { get; set; }
        public float MoveSpeedMultiplier { get; set; }

        public new Vector2 Position
        {
            get { return _heroSprite.Position; }
            set { _heroSprite.Position = value; }
        }

        public override void Initialize()
        {
            _heroSprite = new GAnimatedSprite("Sprites/Hero_Run_Spritesheet", 10 , 75, new Point(FrameWidth,64));
            _heroSprite.Position = new Vector2(25, 384);
            _heroSprite.PlayAnimation(true);
            Direction = 1;
            MoveSpeedMultiplier = 0;
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _heroSprite.LoadContent(contentManager);
        }

        public override void Update(RenderContainer renderContainer)
        {
            _heroSprite.Update(renderContainer);

            var pos = _heroSprite.Position;
            var m =  MoveSpeedMultiplier;
            if (Direction == 1)
                m = -m;

            if(pos.X >= renderContainer.GraphicsDevice.Viewport.Width - FrameWidth && Direction != -1)
            {
                Direction = -1;
                _heroSprite.Effect = SpriteEffects.FlipHorizontally;
            }
            else if ( pos.X < 0 && Direction != 1)
            {
                Direction = 1;
                _heroSprite.Effect = SpriteEffects.None;
            }

            pos.X += (float)((moveSpeed + (moveSpeed * m)) * renderContainer.GameTime.ElapsedGameTime.TotalSeconds * Direction);
            _heroSprite.Position = pos;
        }

        public override void Draw(RenderContainer renderContainer)
        {
            _heroSprite.Draw(renderContainer);
        }

        public void FlipDirection()
        {
            if (Direction == 1)
            {
                Direction = -1;
                _heroSprite.Effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                Direction = 1;
                _heroSprite.Effect = SpriteEffects.None;
            }
        }
    }
}
