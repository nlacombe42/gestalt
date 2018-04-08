using System.Collections.Generic;
using code.util;
using UnityEngine;

namespace code.terrain
{
    public class Tile
    {
        public static readonly Vector3 TileSize = new Vector3(10, 10, 10);

        public static void AddCube(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, int[,] heightMap, Position3D tileMapIndex)
        {
            if (tileMapIndex.y > heightMap[tileMapIndex.x, tileMapIndex.z])
                return;

            var tilePosition = new Vector3(tileMapIndex.x * TileSize.x, tileMapIndex.y * TileSize.y, tileMapIndex.z * TileSize.z);

            if (tileMapIndex.y == heightMap[tileMapIndex.x, tileMapIndex.z])
                CubeGenerator.AddSquareFaceYPositive(vertices, triangles, uvs, tilePosition, TileSize);

            if (tileMapIndex.z - 1 < 0 || tileMapIndex.y > heightMap[tileMapIndex.x, tileMapIndex.z - 1])
                CubeGenerator.AddSquareFaceZNegative(vertices, triangles, uvs, tilePosition, TileSize);

            if (tileMapIndex.z + 1 > heightMap.GetLength(1) - 1 ||
                tileMapIndex.y > heightMap[tileMapIndex.x, tileMapIndex.z + 1])
                CubeGenerator.AddSquareFaceZPositive(vertices, triangles, uvs, tilePosition, TileSize);

            if (tileMapIndex.x - 1 < 0 || tileMapIndex.y > heightMap[tileMapIndex.x - 1, tileMapIndex.z])
                CubeGenerator.AddSquareFaceXNegative(vertices, triangles, uvs, tilePosition, TileSize);

            if (tileMapIndex.x + 1 > heightMap.GetLength(0) - 1 ||
                tileMapIndex.y > heightMap[tileMapIndex.x + 1, tileMapIndex.z])
                CubeGenerator.AddSquareFaceXPositive(vertices, triangles, uvs, tilePosition, TileSize);
        }
    }
}