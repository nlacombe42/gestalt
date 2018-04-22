using code.map;
using UnityEngine;

namespace code.util
{
    public static class MapPositionUtil
    {
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

        public static Position3D GetPositionInChunk(Position3D tilePosition)
        {
            var chunkPosition = GetChunkPositionFromTilePosition(tilePosition);

            var positionInChunkX = tilePosition.x - chunkPosition.x * Chunk.ChunkSize.x;
            var positionInChunkY = tilePosition.y - chunkPosition.y * Chunk.ChunkSize.y;
            var positionInChunkZ = tilePosition.z - chunkPosition.z * Chunk.ChunkSize.z;

            return new Position3D(positionInChunkX, positionInChunkY, positionInChunkZ);
        }
    }
}