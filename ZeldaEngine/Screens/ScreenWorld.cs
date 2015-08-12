using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ZeldaEngine.Components;
using ZeldaEngine.Controllers;
using ZeldaEngine.Maps;

namespace ZeldaEngine.Screens
{
    class ScreenWorld : Screen
    {
        private MapController _mapController;
        private CameraController _cameraController;
        private Entities _entities;

        public ScreenWorld(ScreenController screenController) : base(screenController)
        {
            _cameraController = new CameraController();
            _mapController = new MapController("test", _cameraController);
            _entities = new Entities();
        }

        public override void Initialize()
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            _mapController.LoadContent(content);

            var player = new BaseObject();
            player.AddComponent(new Sprite(content.Load<Texture2D>("Sprites\\spr_link_full"), 16, 16, new Vector2(50, 50)));
            player.AddComponent(new PlayerInput());
            player.AddComponent(new Animation(16, 16));
            player.AddComponent(new Collision(_mapController));
            player.AddComponent(new Camera(_cameraController));

            var testNPC = new BaseObject();
            testNPC.AddComponent(new Sprite(content.Load<Texture2D>("Sprites\\spr_marin_full"), 16, 16, new Vector2(50, 50)));
            testNPC.AddComponent(new AIRandomMovement(500, 0.5f));
            testNPC.AddComponent(new Animation(16, 16));
            testNPC.AddComponent(new Collision(_mapController));
            testNPC.AddComponent(new Camera(_cameraController));

            var testEnemy = new BaseObject();
            testEnemy.AddComponent(new Sprite(content.Load<Texture2D>("Sprites\\spr_octorok_full"), 16, 16, new Vector2(50, 50)));
            testEnemy.AddComponent(new AIRandomMovement(1000, 0.5f));
            testEnemy.AddComponent(new Animation(16, 16));
            testEnemy.AddComponent(new Collision(_mapController));
            testEnemy.AddComponent(new Octorok(player, content.Load<Texture2D>("Sprites\\spr_octorok_bullet"), _mapController));
            testEnemy.AddComponent(new Camera(_cameraController));

            _entities.AddEntity(player);
            _entities.AddEntity(testNPC);
            _entities.AddEntity(testEnemy);
        }

        public override void Update(double gameTime)
        {
            _mapController.Update(gameTime);
            _cameraController.Update(gameTime);
            _entities.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _mapController.Draw(spriteBatch);
            _entities.Draw(spriteBatch);
        }
    }
}
