using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZeldaEngine.Controllers;

namespace ZeldaEngine.Components
{
    class AIRandomMovement : Component
    {
        private Direction _currentDirection;
        private readonly int _frequency;
        private double _counter;
        private float _speed;

        public AIRandomMovement(int frequency, float speed = 1.5f)
        {
            _frequency = frequency;
            ChangeDirection();
            _speed = speed;
        }

        public override ComponentType ComponentType
        {
            get { return ComponentType.AIMovement; }
        }

        public override void Update(double gameTime)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            if (sprite == null)
                return;

            _counter += gameTime;

            if (_counter > _frequency)
            {
                ChangeDirection();
            }

            var collision = GetComponent<Collision>(ComponentType.Collision);

            var x = 0f;
            var y = 0f;

            switch (_currentDirection)
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

            if (collision.CheckCollision(new Rectangle((int)(sprite.Position.X + x), (int)(sprite.Position.Y + y), sprite.Width, sprite.Height)))
            {
                ChangeDirection();
                return;
            }
            
            sprite.Move(x, y);
        }

        private void ChangeDirection()
        {
            _counter = 0;
            _currentDirection = (Direction)FunctionController.Random(0, 3);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
