using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZeldaEngine.Controllers;

namespace ZeldaEngine.Components
{
    class PlayerInput : Component
    {
        public override ComponentType ComponentType
        {
            get { return ComponentType.PlayerInput; }
        }

        public PlayerInput()
        {
            InputController.FireNewInput += InputController_FireNewInput;
        }

        void InputController_FireNewInput(object sender, Events.NewInputEventArgs e)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);

            if (sprite == null)
                return;

            var collision = GetComponent<Collision>(ComponentType.Collision);

            var x = 0f;
            var y = 0f;

            var camera = GetComponent<Camera>(ComponentType.Camera);
            if (camera == null)
                return;

            var animation = GetComponent<Animation>(ComponentType.Animation);

            switch (e.Input)
            {
                case Input.Up:
                    y = -1.5f;
                break;
                case Input.Down:
                    y = 1.5f;
                break;
                case Input.Left:
                    x = -1.5f;
                break;
                case Input.Right:
                    x = 1.5f;
                break;
            }

            if (collision == null || !collision.CheckCollision(new Rectangle((int) (sprite.Position.X + x), (int) (sprite.Position.Y + y), sprite.Width, sprite.Height)))
                sprite.Move(x, y);

            Vector2 position;
            if (!camera.GetPosition(sprite.Position, out position))
            {
                camera.MoveCamera(animation.CurrentDirection);
            }
        }

        private void CheckCamera(Direction direction)
        {

        }

        public override void Update(double gameTime)
        {
            
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
        }
    }
}
