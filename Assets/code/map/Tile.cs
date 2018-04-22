using UnityEngine;

namespace code.map
{
    public class Tile
    {
        public static readonly Vector3 TileSize = new Vector3(10, 10, 10);

        public Tile(TileType tileType)
        {
            TileType = tileType;
        }

        public TileType TileType { get; set; }
    }
}