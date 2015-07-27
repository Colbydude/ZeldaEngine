using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ZeldaEngine.Maps
{
    public class Tile
    {
        private const int Width = 16;
        private const int Height = 16;

        public int XPos { get; set; }
        public int YPos { get; set; }
        public int ZPos { get; set; }

        public List<TileFrame> TileFrames { get; set; }
        public int AnimationSpeed { get; set; }
        private double _counter;
        private int _animationIndex;

        public string TextureName { get; set; }
        private Texture2D _texture;

        public Tile()
        {

        }

        public Tile(int xPos, int yPos, int zPos, List<TileFrame> tileFrames, int animationSpeed, string textureName)
        {
            XPos = xPos;
            YPos = yPos;
            ZPos = zPos;
            TileFrames = tileFrames;
            AnimationSpeed = animationSpeed;
            _counter = 0;
            _animationIndex = 0;
            TextureName = textureName;
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("Sprites\\" + TextureName);
        }

        public void Update(double gameTime)
        {
            if (TileFrames.Count == 1)
                return;

            _counter += gameTime;
            if (_counter > AnimationSpeed)
            {
                _counter = 0;
                _animationIndex++;
                if (_animationIndex >= TileFrames.Count)
                    _animationIndex = 0;
            }
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            SpriteBatch.Draw(_texture,
                             new Rectangle(XPos * Width, YPos * Height, Width, Height),
                             new Rectangle(TileFrames[_animationIndex].TextureXPos * (Width + 1) + 1, TileFrames[_animationIndex].TextureYPos * (Height + 1) + 1, Width, Height),
                             Color.White);
        }
    }
}
