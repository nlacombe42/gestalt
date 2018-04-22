using code.util;

namespace code.map
{
    public class TileType
    {
        public static readonly TileType Air = new TileType(null);
        public static readonly TileType Grass = new TileType(new Position2D(1, 1));
        public static readonly TileType Stone = new TileType(new Position2D(0, 1));

        private Position2D _textureTileOffset;

        public TileType(Position2D textureTileOffset)
        {
            this._textureTileOffset = textureTileOffset;
        }

        public Position2D TextureTileOffset
        {
            get { return _textureTileOffset; }
        }
    }
}