using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ZeldaEngine.Screens;

namespace ZeldaEngine.Controllers
{
    public class ScreenController
    {
        private Screen _lastScreen;
        private Screen _currentScreen;
        private ContentManager _content;

        public ScreenController(ContentManager content)
        {
            _content = content;
        }

        public void LoadNewScreen(Screen screen)
        {
            _lastScreen = _currentScreen;

            if (_lastScreen != null)
                _lastScreen.Uninitialize();

            _currentScreen = screen;
            _currentScreen.Initialize();
            _currentScreen.LoadContent(_content);
        }

        public void GoBackOneScreen()
        {
            if (_lastScreen == null)
                return;

            _lastScreen.Uninitialize();
            _currentScreen = _lastScreen;
            _currentScreen.Initialize();
        }

        public void Update(double gameTime)
        {
            _currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _currentScreen.Draw(spriteBatch);
        }
    }
}
