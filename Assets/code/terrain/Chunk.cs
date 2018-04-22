using System.Collections.Generic;
using code.util;
using UnityEngine;

namespace code.terrain
{
    public class Chunk
    {
        public static readonly Position3D ChunkSize = new Position3D(32, 32, 32);

        private static readonly Color Color = new Color(255, 255, 255);
        private static Chunk _instance;

        private Chunk()
        {
        }

        public static Chunk Instance
        {
            get { return _instance ?? (_instance = new Chunk()); }
        }

        public UnityMeshInfo GetChunkTerrainUnityMeshInfo(int[,] heightMap, Position3D chunkPosition)
        {
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

            return new UnityMeshInfo(vertices.ToArray(), triangles.ToArray(), uvs.ToArray(), Color, position);
        }

        private bool IsTileHeightInChunk(Position3D chunkPosition, int y)
        {
            return y > chunkPosition.y * ChunkSize.y && y < (chunkPosition.y + 1) * ChunkSize.y;
        }
    }
}