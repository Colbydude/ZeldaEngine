using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZeldaEngine.Maps
{
    public class TileCollision
    {
        public int XPos { get; set; }
        public int YPos { get; set; }

        public Rectangle Rectangle { get { return new Rectangle(XPos * 16, YPos * 16, 16, 16); }}

        public bool Intersect(Rectangle rectangle)
        {
            return Rectangle.Intersects(rectangle);
        }

        public TileCollision()
        {

        }
    }
}
