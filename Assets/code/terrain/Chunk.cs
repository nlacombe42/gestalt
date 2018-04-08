using System.Collections.Generic;
using code.util;
using UnityEngine;

namespace code.terrain
{
    public class Chunk
    {
        private static readonly Position3D ChunkSize = new Position3D(32, 32, 32);

        public static ChunkUnityInfo GetChunkMesh(Position3D chunkPosition)
        {
            var heightMap = GenerateHeightMap(chunkPosition);

            var vertices = new List<Vector3>();
            var uvs = new List<Vector2>();
            var triangles = new List<int>();

            for (var x = 0; x < heightMap.GetLength(0); x++)
            for (var z = 0; z < heightMap.GetLength(1); z++)
            for (var y = 0; y <= heightMap[x, z]; y++)
                Tile.AddCube(vertices, triangles, uvs, heightMap, new Position3D(x, y, z));

            var chunkTilePosition = chunkPosition * ChunkSize;
            var position = new Vector3(chunkTilePosition.x * Tile.TileSize.x, chunkTilePosition.y * Tile.TileSize.y, chunkTilePosition.z * Tile.TileSize.z);

            return new ChunkUnityInfo(vertices.ToArray(), triangles.ToArray(), uvs.ToArray(), position);
        }

        private static int[,] GenerateHeightMap(Position3D chunkPosition)
        {
            var heightMap = new int[ChunkSize.x, ChunkSize.y];

            for (var x = 0; x < heightMap.GetLength(0); x++)
            for (var z = 0; z < heightMap.GetLength(1); z++)
                heightMap[x, z] = TerrainGenerator.getHeight(chunkPosition.x + x, chunkPosition.z + z);

            return heightMap;
        }
    }
}
