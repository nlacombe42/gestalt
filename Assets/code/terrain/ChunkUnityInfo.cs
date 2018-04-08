using UnityEngine;

namespace code
{
    public class ChunkUnityInfo
    {
        public ChunkUnityInfo(Vector3[] vertices, int[] triangles, Vector2[] uv, Vector3 position)
        {
            this.vertices = vertices;
            this.triangles = triangles;
            this.uv = uv;
            this.position = position;
        }

        public Vector3[] vertices { get; set; }
        
        public int[] triangles { get; set; }
        
        public Vector2[] uv { get; set; }

        public Vector3 position { get; set; }
    }
}