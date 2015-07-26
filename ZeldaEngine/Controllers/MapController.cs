using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ZeldaEngine.Maps;

namespace ZeldaEngine.Controllers
{
    class MapController
    {
        private List<Tile> _tiles;
        private string _mapName;

        public MapController(string mapName)
        {
            _tiles = new List<Tile>();
            _mapName = mapName;
        }

        public void LoadContent(ContentManager content)
        {
            var tiles = new List<Tile>();
            XMLSerialization.LoadXML(out tiles, string.Format("Content\\Maps\\{0}_map.xml", _mapName));
            if (tiles != null)
            {
                _tiles = tiles;
                _tiles.Sort((n, i) => n.ZPos > i.ZPos ? 1 : 0);

                foreach (var tile in _tiles)
                {
                    tile.LoadContent(content);
                }
            }
        }

        public void Update(double gameTime)
        {
            foreach (var tile in _tiles)
            {
                tile.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in _tiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
