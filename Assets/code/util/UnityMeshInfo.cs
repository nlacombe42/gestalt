using UnityEngine;

namespace code.util
{
    public class UnityMeshInfo
    {
        public UnityMeshInfo(Vector3[] vertices, int[] triangles, Vector2[] uv, Color color, Vector3 position)
        {
            Vertices = vertices;
            Triangles = triangles;
            Uv = uv;
            Color = color;
            Position = position;
        }

        public Vector3[] Vertices { get; set; }

        public int[] Triangles { get; set; }

        public Vector2[] Uv { get; set; }

        public Color Color { get; set; }

        public Vector3 Position { get; set; }
    }
}