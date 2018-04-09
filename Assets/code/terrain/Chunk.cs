using System.Collections.Generic;
using code.util;
using UnityEngine;
using Random = System.Random;

namespace code.terrain
{
    public static class Chunk
    {
        public static readonly Position3D ChunkSize = new Position3D(32, 32, 32);

        public static UnityMeshInfo GetChunkTerrainUnityMeshInfo(Position3D chunkPosition)
        {
            var heightMap = GenerateHeightMap(chunkPosition);

            var vertices = new List<Vector3>();
            var uvs = new List<Vector2>();
            var triangles = new List<int>();

            for (var x = 0; x < heightMap.GetLength(0); x++)
            for (var z = 0; z < heightMap.GetLength(1); z++)
            for (var y = 0; y <= heightMap[x, z]; y++)
                if (IsTileHeightInChunk(chunkPosition, y))
                    Tile.AddCube(vertices, triangles, uvs, heightMap, new Position3D(x, y, z));

            var chunkTilePosition = chunkPosition * ChunkSize;
            var position = new Vector3(chunkTilePosition.x * Tile.TileSize.x, chunkTilePosition.y * Tile.TileSize.y, chunkTilePosition.z * Tile.TileSize.z);

            var random = new Random();
            var color = new Color(random.Next(255), random.Next(255), random.Next(255));

            return new UnityMeshInfo(vertices.ToArray(), triangles.ToArray(), uvs.ToArray(), color, position);
        }

        private static bool IsTileHeightInChunk(Position3D chunkPosition, int y)
        {
            return y > chunkPosition.y * ChunkSize.y && y < (chunkPosition.y + 1) * ChunkSize.y;
        }

        private static int[,] GenerateHeightMap(Position3D chunkPosition)
        {
            var heightMap = new int[ChunkSize.x, ChunkSize.z];

            for (var x = 0; x < heightMap.GetLength(0); x++)
            for (var z = 0; z < heightMap.GetLength(1); z++)
                heightMap[x, z] = TerrainGenerator.getHeight(chunkPosition.x * ChunkSize.x + x, chunkPosition.z * ChunkSize.z + z);

            return heightMap;
        }
    }
}