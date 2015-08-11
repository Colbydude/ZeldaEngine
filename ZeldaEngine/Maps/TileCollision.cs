using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZeldaEngine.Controllers;

namespace ZeldaEngine.Maps
{
    public class TileCollision
    {
        public int XPos { get; set; }
        public int YPos { get; set; }

        public Rectangle Rectangle { get { return new Rectangle(XPos * 16, YPos * 16, 16, 16); }}

        public CameraController CameraController { get; set; }

        public bool Intersect(Rectangle rectangle)
        {
            var position = new Vector2(Rectangle.X, Rectangle.Y);
            return CameraController.InScreenCheck(position) && rectangle.Intersects(new Rectangle((int) position.X, (int) position.Y, 16, 16));
        }

        public TileCollision()
        {

        }

        public TileCollision(CameraController cameraController)
        {
            CameraController = cameraController;
        }
    }
}
