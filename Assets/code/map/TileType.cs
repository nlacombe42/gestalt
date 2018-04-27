namespace code.map
{
    public class TileType
    {
        public static readonly TileType Air = new TileType(false, true, null);
        public static readonly TileType Grass = new TileType(true, false, new Position2D(1, 1));
        public static readonly TileType Stone = new TileType(true, false, new Position2D(0, 1));

        private bool _visible;
        private bool _transparent;
        private Position2D _textureTileOffset;

        public TileType(bool visible, bool transparent, Position2D textureTileOffset)
        {
            _visible = visible;
            _transparent = transparent;
            _textureTileOffset = textureTileOffset;
        }

        public bool Visible
        {
            get { return _visible; }
        }

        public bool Transparent
        {
            get { return _transparent; }
        }

        public Position2D TextureTileOffset
        {
            get { return _textureTileOffset; }
        }
    }
}