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

            Unique[] Attendances = new Unique[10];

            foreach (Unique guest in Attendances)
                greetings("Welcome to Microsoft Club's event {0}", guest.FirstName );
        }

        void greetings(string s, params object[] a ) { }
        class Unique {
            public string FirstName;
        }
    }
}
