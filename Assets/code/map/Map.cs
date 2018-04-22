using System.Collections.Generic;
using code.util;

namespace code.map
{
    public class Map
    {
        private static Map _instance;

        private Dictionary<Position3D, Tile> _tileMap;

        public Map()
        {
            _tileMap = new Dictionary<Position3D, Tile>();
        }

        public static Map Instance
        {
            get { return _instance ?? (_instance = new Map()); }
        }

        public Tile GetTile(Position3D tilePosition)
        {
            if (!_tileMap.ContainsKey(tilePosition))
                _tileMap.Add(tilePosition, GenerateTile(tilePosition));

            return _tileMap[tilePosition];
        }

        public void SetTile(Position3D tilePosition, Tile tile)
        {
            _tileMap[tilePosition] = tile;
            
            Chunk.Instance.Unrender(MapPositionUtil.GetChunkPositionFromTilePosition(tilePosition));
        }

        public bool IsTransparent(Position3D tilePosition)
        {
            return GetTile(tilePosition).TileType == TileType.Air;
        }

        private Tile GenerateTile(Position3D tilePosition)
        {
            var height = TerrainGenerator.getHeight(tilePosition.x, tilePosition.z);

            if (tilePosition.y > height)
                return new Tile(TileType.Air);
            else if (tilePosition.y <= 2)
                return new Tile(TileType.Grass);
            else
                return new Tile(TileType.Stone);
        }
    }
}