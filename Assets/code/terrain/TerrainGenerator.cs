using AssemblyCSharp;
using UnityEngine;

namespace code.terrain
{
    public static class TerrainGenerator
    {
        public static int getHeight(int tilePositionX, int tilePositionZ)
        {
            return Mathf.FloorToInt(Perlin.CalcPixel2D(tilePositionX, tilePositionZ, 0.05f) / 255 * Tile.TileSize.y);
        }
    }
}