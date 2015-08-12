using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ZeldaEngine.Controllers;

namespace ZeldaEngine.Screens
{
    class ScreenStart : Screen
    {
        private Texture2D _image;

        public ScreenStart(ScreenController screenController) : base(screenController)
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            _image = content.Load<Texture2D>("Sprites\\start_screen");
        }

        public override void Initialize()
        {
            InputController.FireNewInput += InputController_FireNewInput;
        }

        public override void Uninitialize()
        {
            InputController.FireNewInput -= InputController_FireNewInput;
        }

        void InputController_FireNewInput(object Sender, Events.NewInputEventArgs e)
        {
            if (e.Input == Input.Enter)
            {
                ScreenController.LoadNewScreen(new ScreenWorld(ScreenController));
            }
        }

        public override void Update(double gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image, new Rectangle(0, 0, 160, 144), Color.White);   
        }
    }
}
