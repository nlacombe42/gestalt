using System.Collections.Generic;
using System.Linq;
using code.map;
using code.objectscript;
using code.util;
using UnityEngine;

namespace code.render
{
    public class Chunk
    {
        public static readonly Position3D ChunkSize = new Position3D(32, 32, 32);

        private static readonly Color Color = new Color(255, 255, 255);
        private static Chunk _instance;

        private Dictionary<Position3D, GameObject> _renderedChunks;
        private ElementLimitCache<Position3D, UnityMeshInfo> _chunkMeshInfoCache;

        private Chunk()
        {
            _renderedChunks = new Dictionary<Position3D, GameObject>();
            _chunkMeshInfoCache = new ElementLimitCache<Position3D, UnityMeshInfo>(5*9);
        }

        public static Chunk Instance
        {
            get { return _instance ?? (_instance = new Chunk()); }
        }

        public void RenderOnly(List<Position3D> chunkPositionsToRender)
        {
            var chunkPositionsToCreate = chunkPositionsToRender
                .Where(chunkPositionToRender => !_renderedChunks.ContainsKey(chunkPositionToRender));

            var chunkPositionsToDelete = _renderedChunks
                .Where(renderedChunkPair => !chunkPositionsToRender.Contains(renderedChunkPair.Key))
                .Select(renderedChunkPair => renderedChunkPair.Key).ToList();

            foreach (var chunkPosition in chunkPositionsToCreate)
                Render(chunkPosition);

            foreach (var chunkPositionToDelete in chunkPositionsToDelete)
                Unrender(chunkPositionToDelete);
        }
        
        public void Unrender(Position3D chunkPosition)
        {
            Object.Destroy(_renderedChunks[chunkPosition]);
            _renderedChunks.Remove(chunkPosition);
        }
        
        public void Rerender(Position3D chunkPosition)
        {
            _chunkMeshInfoCache.Remove(chunkPosition);
            Unrender(chunkPosition);
        }
        
        private void Render(Position3D chunkPosition)
        {
            var chunkTerrainUnityMeshInfo = GetChunkTerrainUnityMeshInfo(chunkPosition);

            GameObject gameObject;

            if (chunkTerrainUnityMeshInfo.Triangles.Length <= 0)
                gameObject = null;
            else
                gameObject = GameObjectScript.CreateGameObject("TerrainChunk", chunkTerrainUnityMeshInfo);

            _renderedChunks.Add(chunkPosition, gameObject);
        }

        private UnityMeshInfo GetChunkTerrainUnityMeshInfo(Position3D chunkPosition)
        {
            if (_chunkMeshInfoCache.ContainsKey(chunkPosition))
                return _chunkMeshInfoCache[chunkPosition];
           
            var meshInfo = GenerateChunkTerrainUnityMeshInfo(chunkPosition);
            
            lock(_chunkMeshInfoCache)
                _chunkMeshInfoCache[chunkPosition] = meshInfo;

            return meshInfo;
        }

        private static UnityMeshInfo GenerateChunkTerrainUnityMeshInfo(Position3D chunkPosition)
        {
            var chunkTilePosition = chunkPosition * ChunkSize;

            var vertices = new List<Vector3>();
            var uvs = new List<Vector2>();
            var triangles = new List<int>();

            for (var x = 0; x < ChunkSize.x; x++)
            for (var z = 0; z < ChunkSize.z; z++)
            for (var y = 0; y < ChunkSize.y; y++)
            {
                var tilePosition = chunkTilePosition + new Position3D(x, y, z);
                var tile = Map.Instance.GetTile(tilePosition);

                if (tile.TileType.Visible)
                    RenderUtil.AddCube(vertices, triangles, uvs, tilePosition);
            }

            var position = new Vector3(chunkTilePosition.x * Tile.TileSize.x, chunkTilePosition.y * Tile.TileSize.y, chunkTilePosition.z * Tile.TileSize.z);

            return new UnityMeshInfo(vertices.ToArray(), triangles.ToArray(), uvs.ToArray(), Color, position);
        }
    }
}