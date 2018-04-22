using AssemblyCSharp;
using code.util;
using UnityEngine;

namespace code.map
{
    public static class TerrainGenerator
    {
        public static int getHeight(int tilePositionX, int tilePositionZ)
        {
            var perlinRand = Perlin.CalcPixel2D(tilePositionX, tilePositionZ, 0.02f) / 255;
            var expRand = Mathf.Abs(Noise.ExpRand(perlinRand, 0.375f));
            var height = Mathf.FloorToInt(expRand * Tile.TileSize.y);

            return height < 1 ? 1 : height;
        }
    }
}