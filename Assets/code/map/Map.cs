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

        public Map()
        {
            _renderedChunks = new Dictionary<Position3D, GameObject>();
        }

        public static Map Instance
        {
            get { return _instance ?? (_instance = new Map()); }
        }

        public void Render(List<Position3D> chunkPositionsToRender)
        {
            var chunkPositionsToCreate = chunkPositionsToRender.Where(chunkPositionToRender => !_renderedChunks.ContainsKey(chunkPositionToRender));
            
            foreach (var chunkPosition in chunkPositionsToCreate)
            {
                var chunkTerrainUnityMeshInfo = Chunk.GetChunkTerrainUnityMeshInfo(chunkPosition);
                
                if (chunkTerrainUnityMeshInfo.Triangles.Length <= 0)
                    continue;

                var gameObject = GameObjectScript.CreateGameObject("TerrainChunk", chunkTerrainUnityMeshInfo);

                _renderedChunks.Add(chunkPosition, gameObject);
            }

            var chunkPositionsToDelete = _renderedChunks
                .Where(renderedChunkPair => !chunkPositionsToRender.Contains(renderedChunkPair.Key))
                .Select(renderedChunkPair => renderedChunkPair.Key).ToList();

            foreach (var chunkPositionToDelete in chunkPositionsToDelete)
            {
                Object.Destroy(_renderedChunks[chunkPositionToDelete]);
                _renderedChunks.Remove(chunkPositionToDelete);
            }
        }
    }
}