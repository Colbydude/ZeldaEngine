using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            switch (e.Input)
            {
                case Input.Up:
                    sprite.Move(0, -1.5f);
                break;
                case Input.Down:
                    sprite.Move(0, 1.5f);
                break;
                case Input.Left:
                    sprite.Move(-1.5f, 0);
                break;
                case Input.Right:
                    sprite.Move(1.5f, 0);
                break;
            }
        }

        public override void Update(double gameTime)
        {
            
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
        }
    }
}
