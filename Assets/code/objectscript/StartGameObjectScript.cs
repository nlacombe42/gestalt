using code.terrain;
using code.util;
using UnityEngine;

namespace code.objectscript
{
    public class StartGameObjectScript : MonoBehaviour
    {
        private void Start()
        {   
            CreateChunk();
        }

        private static void CreateChunk()
        {
            var chunkUnityInfo = Chunk.GetChunkMesh(new Position3D(0, 0, 0));
            var chunk = (GameObject) Instantiate(Resources.Load("TerrainChunk"));
            
            var mesh = chunk.GetComponent<MeshFilter>().mesh;
            mesh.Clear();
            mesh.vertices = chunkUnityInfo.vertices;
            mesh.triangles = chunkUnityInfo.triangles;
            mesh.uv = chunkUnityInfo.uv;
            mesh.RecalculateNormals();

            chunk.GetComponent<MeshCollider>().sharedMesh = mesh;

            chunk.transform.position = chunkUnityInfo.position;
        }
    }
}
