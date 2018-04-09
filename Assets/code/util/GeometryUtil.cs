using System.Collections.Generic;
using UnityEngine;

namespace code.util
{
    public static class GeometryUtil
    {      
        public static void AddTriangleVertice(List<Vector3> vertices, List<int> triangles, Vector3 vertice)
        {
            vertices.Add(vertice);
            triangles.Add(vertices.Count - 1);
        }
    }
}
