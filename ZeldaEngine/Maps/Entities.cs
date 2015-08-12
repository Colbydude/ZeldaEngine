using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZeldaEngine.Maps
{
    class Entities
    {
        private List<BaseObject> _entities;

        public Entities()
        {
            _entities = new List<BaseObject>();
        }

        public void CreatePlayer(Vector2 position)
        {

        }

        public void AddEntity(BaseObject newObject)
        {
            _entities.Add(newObject);
        }

        public void Update(double gameTime)
        {
            foreach (var baseObject in _entities)
            {
                baseObject.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var baseObject in _entities)
            {
                baseObject.Draw(spriteBatch);
            }
        }
    }
}
