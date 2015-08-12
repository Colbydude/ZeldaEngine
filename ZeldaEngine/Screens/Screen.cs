using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ZeldaEngine.Controllers;

namespace ZeldaEngine.Screens
{
    public abstract class Screen
    {
        protected ScreenController ScreenController;

        public Screen(ScreenController screenController)
        {
            ScreenController = screenController;
        }

        public virtual void Initialize() {}
        public virtual void Uninitialize() {}
        public abstract void LoadContent(ContentManager content);
        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
