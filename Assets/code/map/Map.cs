using System.Collections.Generic;
using System.Linq;
using code.objectscript;
using code.terrain;
using code.util;
using UnityEngine;

namespace code.map
{
    public class Map
    {
        private static Map _instance;

        private Dictionary<Position3D, GameObject> _renderedChunks;
        private Dictionary<Position2D, int> _modifiedTilesHeight;

        public Map()
        {
            _renderedChunks = new Dictionary<Position3D, GameObject>();
            _modifiedTilesHeight = new Dictionary<Position2D, int>();
        }

        public static Map Instance
        {
            get { return _instance ?? (_instance = new Map()); }
        }

        public static Position3D GetTilePosition(Vector3 position)
        {
            var chunkPositionX = Mathf.FloorToInt(position.x / Tile.TileSize.x);
            var chunkPositionY = Mathf.FloorToInt(position.y / Tile.TileSize.y);
            var chunkPositionZ = Mathf.FloorToInt(position.z / Tile.TileSize.z);

            return new Position3D(chunkPositionX, chunkPositionY, chunkPositionZ);
        }

        public static Position3D GetChunkPosition(Vector3 position)
        {
            var chunkPositionX = Mathf.FloorToInt(position.x / (Chunk.ChunkSize.x * Tile.TileSize.x));
            var chunkPositionY = Mathf.FloorToInt(position.y / (Chunk.ChunkSize.y * Tile.TileSize.y));
            var chunkPositionZ = Mathf.FloorToInt(position.z / (Chunk.ChunkSize.z * Tile.TileSize.z));

            return new Position3D(chunkPositionX, chunkPositionY, chunkPositionZ);
        }

        public static Position3D GetChunkPositionFromTilePosition(Position3D tilePosition)
        {
            var chunkPositionX = Mathf.FloorToInt(tilePosition.x / (float) Chunk.ChunkSize.x);
            var chunkPositionY = Mathf.FloorToInt(tilePosition.y / (float) Chunk.ChunkSize.y);
            var chunkPositionZ = Mathf.FloorToInt(tilePosition.z / (float) Chunk.ChunkSize.z);

            return new Position3D(chunkPositionX, chunkPositionY, chunkPositionZ);
        }

        public static Position3D GetPositionInChunk(Vector3 position)
        {
            var chunkPosition = GetChunkPosition(position);

            var positionInChunkX = Mathf.FloorToInt((position.x - chunkPosition.x * Chunk.ChunkSize.x * Tile.TileSize.x) / Tile.TileSize.x);
            var positionInChunkY = Mathf.FloorToInt((position.y - chunkPosition.y * Chunk.ChunkSize.y * Tile.TileSize.y) / Tile.TileSize.y);
            var positionInChunkZ = Mathf.FloorToInt((position.z - chunkPosition.z * Chunk.ChunkSize.z * Tile.TileSize.z) / Tile.TileSize.z);

            return new Position3D(positionInChunkX, positionInChunkY, positionInChunkZ);
        }

        public void Render(List<Position3D> chunkPositionsToRender)
        {
            var chunkPositionsToCreate = chunkPositionsToRender.Where(chunkPositionToRender => !_renderedChunks.ContainsKey(chunkPositionToRender));

            foreach (var chunkPosition in chunkPositionsToCreate)
            {
                var heightMap = GenerateHeightMap(chunkPosition);
                var chunkTerrainUnityMeshInfo = Chunk.Instance.GetChunkTerrainUnityMeshInfo(heightMap, chunkPosition);

                if (chunkTerrainUnityMeshInfo.Triangles.Length <= 0)
                    continue;

                var gameObject = GameObjectScript.CreateGameObject("TerrainChunk", chunkTerrainUnityMeshInfo);

                _renderedChunks.Add(chunkPosition, gameObject);
            }

            var chunkPositionsToDelete = _renderedChunks
                .Where(renderedChunkPair => !chunkPositionsToRender.Contains(renderedChunkPair.Key))
                .Select(renderedChunkPair => renderedChunkPair.Key).ToList();

            foreach (var chunkPositionToDelete in chunkPositionsToDelete)
                UnrenderChunk(chunkPositionToDelete);
        }

        public void setTileHeight(Position2D tilePosition, int height)
        {
            _modifiedTilesHeight[tilePosition] = height;

            var chunkPosition = GetChunkPositionFromTilePosition(new Position3D(tilePosition.x, height, tilePosition.y));

            UnrenderChunk(chunkPosition);
        }

        private void UnrenderChunk(Position3D chunkPosition)
        {
            Object.Destroy(_renderedChunks[chunkPosition]);
            _renderedChunks.Remove(chunkPosition);
        }

        private int[,] GenerateHeightMap(Position3D chunkPosition)
        {
            var heightMap = new int[Chunk.ChunkSize.x, Chunk.ChunkSize.z];

            for (var x = 0; x < heightMap.GetLength(0); x++)
            for (var z = 0; z < heightMap.GetLength(1); z++)
            {
                var tilePosition = new Position2D(chunkPosition.x * Chunk.ChunkSize.x + x, chunkPosition.z * Chunk.ChunkSize.z + z);
                
                if (_modifiedTilesHeight.ContainsKey(tilePosition))
                    heightMap[x, z] = _modifiedTilesHeight[tilePosition];
                else
                    heightMap[x, z] = TerrainGenerator.getHeight(tilePosition.x, tilePosition.y);
            }

            return heightMap;
        }
    }
}