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
    public class Gourd : GObject2D
    {
        private GSprite _gourdSprite;
        //private const int moveSpeed = 130;
        private double _timeCounter = 0;
        private int _timeInterval = 1;

        //public Hero HuntedHero { get; set; }

        public sbyte Direction { get; set; }

        public List<Rock> ThrownRocks { get; set; }

        public override void Initialize()
        {
            _gourdSprite = new GSprite("Sprites/Gourd");
            _gourdSprite.Position = new Vector2(15, 25);
            ThrownRocks = new List<Rock>();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _gourdSprite.LoadContent(contentManager);
        }

        public override void Update(RenderContainer renderContainer)
        {
            _gourdSprite.Position = this.Position;

            _timeCounter += renderContainer.GameTime.ElapsedGameTime.TotalSeconds;
            //Debug.WriteLine(_timeCounter);
            if (_timeCounter >= _timeInterval)
            {
                _timeCounter = 0;

                Rock rock = new Rock();
                rock.Initialize();
                rock.LoadContent(renderContainer.ContentManager);
                rock.Position = _gourdSprite.Position;
                rock.Update(renderContainer);
                ThrownRocks.Add(rock);
            }
            foreach (Rock r in ThrownRocks)
                r.Update(renderContainer);

            //Debug.WriteLine("- Rocks count before remove: {0}", ThrownRocks.Count);
            ThrownRocks.RemoveAll(p => p.Position.Y >= renderContainer.BaseScreenHeight);
            //Debug.WriteLine("# Rocks count after remove: {0}", ThrownRocks.Count);
        }

        public override void Draw(RenderContainer renderContainer)
        {
            foreach (Rock r in ThrownRocks)
            {
                //Debug.WriteLine(r.Position.X + ", " + r.Position.Y);
                r.Draw(renderContainer);
            }
            _gourdSprite.Draw(renderContainer);
        }

        //public void FlipDirection()
        //{
        //    if (Direction == 1)
        //    {
        //        Direction = -1;
        //        _gourdSprite.Effect = SpriteEffects.FlipHorizontally;
        //    }
        //    else
        //    {
        //        Direction = 1;
        //        _gourdSprite.Effect = SpriteEffects.None;
        //    }
        //}
    }
}
