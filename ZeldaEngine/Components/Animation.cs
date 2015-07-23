using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZeldaEngine.Components
{
    class Animation : Component
    {
        public override ComponentType ComponentType
        {
            get { return ComponentType.Animation; }
        }

        private int _width;
        private int _height;
        public Rectangle TextureRectangle { get; private set; }
        public State _currentState;
        public Direction _currentDirection;
        private double _counter;
        private int _animationIndex;

        public Animation(int width, int height)
        {
            _width = width;
            _height = height;
            _counter = 1;
            _animationIndex = 0;
            _currentState = State.Standing;
            _currentDirection = Direction.Down;
        }

        public override void Update(double gameTime)
        {
            switch (_currentState)
            {
                case State.Standing:
                    if (_counter > 0)
                    {
                        ChangeState();
                        _counter = 0;
                    }
                break;
                case State.Walking:
                    _counter += gameTime;
                    if (_counter > 200)
                    {
                        ChangeState();
                        _counter = 0;
                    }
                break;
            }
        }

        public void ResetCounter(State state, Direction direction)
        {
            if (_currentDirection != direction)
            {
                _counter = 1000;
                _animationIndex = 0;
            }

            _currentState = state;
            _currentDirection = direction;
        }

        public void ChangeState()
        {
            switch (_currentDirection)
            {
                case Direction.Down:
                    TextureRectangle = new Rectangle(_width * _animationIndex, 0, _width, _height);
                break;
                case Direction.Up:
                    TextureRectangle = new Rectangle(_width * _animationIndex, _height, _width, _height);
                break;
                case Direction.Left:
                    TextureRectangle = new Rectangle(_width * _animationIndex, _height * 2, _width, _height);
                break;
                case Direction.Right:
                    TextureRectangle = new Rectangle(_width * _animationIndex, _height * 3, _width, _height);
                break;
            }

            _animationIndex = _animationIndex == 0 ? 1 : 0;
            _currentState = State.Standing;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
        }
    }
}
