using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZeldaEngine.Components
{
    class OctorokBullet
    {
        private Sprite _sprite;
        private Collision _collision;
        private BaseObject _player;
        private Direction _direction;
        private float _speed;

        public bool Dead { get; set; }

        public OctorokBullet(Sprite sprite, Collision collision, BaseObject player, Direction direction)
        {
            _sprite = sprite;
            _player = player;
            _direction = direction;
            _speed = 1.5f;
            _collision = collision;
        }

        public void Update(double gameTime)
        {
            float x = 0f;
            float y = 0f;

            switch (_direction)
            {
                case Direction.Up:
                    y = -1 * _speed;
                break;
                case Direction.Down:
                    y = _speed;
                break;
                case Direction.Left:
                    x = -1 * _speed;
                break;
                case Direction.Right:
                    x = _speed;
                break;
            }

            _sprite.Move(x, y);

            if (_collision.CheckCollision(new Rectangle((int)_sprite.Position.X, (int)_sprite.Position.Y, _sprite.Width, _sprite.Height), false))
                Dead = true;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }
    }
}
