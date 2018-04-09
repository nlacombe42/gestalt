using System.Collections.Generic;
using code.util;
using UnityEngine;

namespace code.terrain
{
    public static class CubeGenerator
    {
        public static void AddSquareFaceYPositive(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            addUv(uvs, 0, 0, true);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            addUv(uvs, 1, 1, true);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            addUv(uvs, 1, 0, true);

            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            addUv(uvs, 0, 0, true);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            addUv(uvs, 0, 1, true);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            addUv(uvs, 1, 1, true);
        }

        private static void addUv(List<Vector2> uvs, float texturePercentPositionU, float texturePercentPositionV)
        {
            addUv(uvs, texturePercentPositionU, texturePercentPositionV, false);
        }
        
        private static void addUv(List<Vector2> uvs, float texturePercentPositionU, float texturePercentPositionV, bool grass)
        {
            if(grass)
                uvs.Add(new Vector2(texturePercentPositionU / 2 + 0.5f, texturePercentPositionV / 2 + 0.5f));
            else
                uvs.Add(new Vector2(texturePercentPositionU / 2, texturePercentPositionV / 2 + 0.5f));
        }

        public static void AddSquareFaceYNegative(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            addUv(uvs, 0, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            addUv(uvs, 1, 1);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            addUv(uvs, 0, 1);

            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            addUv(uvs, 0, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            addUv(uvs, 1, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            addUv(uvs, 1, 1);
        }

        public static void AddSquareFaceZNegative(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            addUv(uvs, 0, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            addUv(uvs, 1, 1);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            addUv(uvs, 1, 0);

            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            addUv(uvs, 0, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            addUv(uvs, 0, 1);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            addUv(uvs, 1, 1);
        }

        public static void AddSquareFaceZPositive(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            addUv(uvs, 0, 1);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            addUv(uvs, 1, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            addUv(uvs, 1, 1);

            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            addUv(uvs, 0, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            addUv(uvs, 1, 1);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            addUv(uvs, 0, 1);
        }

        public static void AddSquareFaceXNegative(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            addUv(uvs, 0, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            addUv(uvs, 1, 1);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            addUv(uvs, 1, 0);

            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            addUv(uvs, 0, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            addUv(uvs, 0, 1);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            addUv(uvs, 1, 1);
        }

        public static void AddSquareFaceXPositive(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize)
        {
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            addUv(uvs, 0, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            addUv(uvs, 1, 1);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            addUv(uvs, 0, 1);

            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            addUv(uvs, 0, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            addUv(uvs, 1, 0);
            GeometryUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            addUv(uvs, 1, 1);
        }
    }
}