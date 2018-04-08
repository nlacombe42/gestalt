using System.Collections.Generic;
using AssemblyCSharp.Code.util;
using UnityEngine;

namespace code.terrain
{
    public static class CubeGenerator
    {
        public static void AddSquareFaceYPositive(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));

            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));
        }

        public static void AddSquareFaceYNegative(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));

            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].z / tileSize.z));
        }

        public static void AddSquareFaceZNegative(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));

            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));
        }

        public static void AddSquareFaceZPositive(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));

            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].x / tileSize.x, vertices[vertices.Count - 1].y / tileSize.y));
        }

        public static void AddSquareFaceXNegative(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));

            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));
        }

        public static void AddSquareFaceXPositive(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));

            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));
            GeometryUtil.addTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            uvs.Add(new Vector2(vertices[vertices.Count - 1].y / tileSize.y, vertices[vertices.Count - 1].z / tileSize.z));
        }
    }
}