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
        private List<TileCollision> _tileCollisions;
        private string _mapName;
        private CameraController _cameraController;

        public MapController(string mapName, CameraController cameraController)
        {
            _tiles = new List<Tile>();
            _tileCollisions = new List<TileCollision>();
            _mapName = mapName;
            _cameraController = cameraController;
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
                    tile.CameraController = _cameraController;
                }
            }

            var tilesCollision = new List<TileCollision>();
            XMLSerialization.LoadXML(out tilesCollision, string.Format("Content\\Maps\\{0}_map_collision.xml", _mapName));
            if (tilesCollision != null)
            {
                _tileCollisions = tilesCollision;
                _tileCollisions.ForEach(t => t.CameraController = _cameraController);
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

        public bool CheckCollision(Rectangle rectangle)
        {
            return _tileCollisions.Any(tile => tile.Intersect(rectangle));
        }
    }
}
