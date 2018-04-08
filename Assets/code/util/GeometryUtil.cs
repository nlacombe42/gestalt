using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp.Code.util
{
    public class GeometryUtil
    {      
        public static void addTriangleVertice(List<Vector3> vertices, List<int> triangles, Vector3 vertice)
        {
            vertices.Add(vertice);
            triangles.Add(vertices.Count - 1);
        }
    }
}
