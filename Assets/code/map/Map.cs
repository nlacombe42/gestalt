using System.Collections.Generic;
using code.objectscript;
using code.terrain;
using code.util;

namespace code.map
{
    public class Map
    {
        private static Map _instance;

        private List<Position3D> _renderedChunks;

        public Map()
        {
            _renderedChunks = new List<Position3D>();
        }

        public static Map Instance
        {
            get { return _instance ?? (_instance = new Map()); }
        }

        public void RenderChunkIfNotAlreadyRendered(Position3D chunkPosition)
        {
            if (_renderedChunks.Contains(chunkPosition))
                return;

            var chunkTerrainUnityMeshInfo = Chunk.GetChunkTerrainUnityMeshInfo(chunkPosition);

            if (chunkTerrainUnityMeshInfo.Triangles.Length > 0)
                GameObjectScript.CreateGameObject("TerrainChunk", chunkTerrainUnityMeshInfo);
            
            _renderedChunks.Add(chunkPosition);
        }
    }
}