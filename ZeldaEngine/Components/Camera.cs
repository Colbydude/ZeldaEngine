using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZeldaEngine.Controllers;

namespace ZeldaEngine.Components
{
    class Camera : Component
    {
        private CameraController _cameraController;

        public override ComponentType ComponentType
        {
            get { return ComponentType.Camera; }
        }

        public Camera(CameraController camera)
        {
            _cameraController = camera;
        }

        public bool GetPosition(Vector2 position, out Vector2 newPosition)
        {
            newPosition = _cameraController.WorldToScreenPosition(position);
            return _cameraController.InScreenCheck(position);
        }

        public void MoveCamera(Direction direction)
        {
            _cameraController.Move(direction);
        }

        public override void Update(double gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
