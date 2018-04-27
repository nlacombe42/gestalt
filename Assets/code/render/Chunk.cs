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

        private Chunk()
        {
            _renderedChunks = new Dictionary<Position3D, GameObject>();
        }

        public static Chunk Instance
        {
            get { return _instance ?? (_instance = new Chunk()); }
        }

        public void Render(List<Position3D> chunkPositionsToRender)
        {
            var chunkPositionsToCreate = chunkPositionsToRender.Where(chunkPositionToRender => !_renderedChunks.ContainsKey(chunkPositionToRender));

            foreach (var chunkPosition in chunkPositionsToCreate)
            {
                var chunkTerrainUnityMeshInfo = GetChunkTerrainUnityMeshInfo(chunkPosition);

                GameObject gameObject;

                if (chunkTerrainUnityMeshInfo.Triangles.Length <= 0)
                    gameObject = null;
                else
                    gameObject = GameObjectScript.CreateGameObject("TerrainChunk", chunkTerrainUnityMeshInfo);

                _renderedChunks.Add(chunkPosition, gameObject);
            }

            var chunkPositionsToDelete = _renderedChunks
                .Where(renderedChunkPair => !chunkPositionsToRender.Contains(renderedChunkPair.Key))
                .Select(renderedChunkPair => renderedChunkPair.Key).ToList();

            foreach (var chunkPositionToDelete in chunkPositionsToDelete)
                Unrender(chunkPositionToDelete);
        }

        public void Unrender(Position3D chunkPosition)
        {
            Object.Destroy(_renderedChunks[chunkPosition]);
            _renderedChunks.Remove(chunkPosition);
        }

        private UnityMeshInfo GetChunkTerrainUnityMeshInfo(Position3D chunkPosition)
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

                if (tile.TileType != TileType.Air)
                    RenderUtil.AddCube(vertices, triangles, uvs, tilePosition);
            }

            var position = new Vector3(chunkTilePosition.x * Tile.TileSize.x, chunkTilePosition.y * Tile.TileSize.y, chunkTilePosition.z * Tile.TileSize.z);

            return new UnityMeshInfo(vertices.ToArray(), triangles.ToArray(), uvs.ToArray(), Color, position);
        }
    }
}