using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZeldaEngine.Controllers;

namespace ZeldaEngine.Components
{
    class Collision : Component
    {
        private MapController _mapController;

        public Collision(MapController mapController)
        {
            _mapController = mapController;
        }

        public override ComponentType ComponentType
        {
            get { return ComponentType.Collision; }
        }

        public bool CheckCollision(Rectangle rectangle, bool fixBox = true)
        {
            rectangle = new Rectangle((int)(rectangle.X + (rectangle.Width * 0.4) / 2), (int)(rectangle.Y + rectangle.Height * 0.5), (int)(rectangle.Width * 0.6), (int)(rectangle.Height * 0.5));
            return _mapController.CheckCollision(rectangle);
        }

        public override void Update(double gameTime)
        {
            
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
        }
    }
}
