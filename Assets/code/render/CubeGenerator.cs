using System.Collections.Generic;
using code.map;
using UnityEngine;

namespace code.render
{
    public static class CubeGenerator
    {
        public static void AddSquareFaceYPositive(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize, Position2D textureTileOffset)
        {
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            RenderUtil.addUv(uvs, 0, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            RenderUtil.addUv(uvs, 1, 0, textureTileOffset);

            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            RenderUtil.addUv(uvs, 0, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            RenderUtil.addUv(uvs, 0, 1, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);
        }

        public static void AddSquareFaceYNegative(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize, Position2D textureTileOffset)
        {
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            RenderUtil.addUv(uvs, 0, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            RenderUtil.addUv(uvs, 0, 1, textureTileOffset);

            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            RenderUtil.addUv(uvs, 0, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            RenderUtil.addUv(uvs, 1, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);
        }

        public static void AddSquareFaceZNegative(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize, Position2D textureTileOffset)
        {
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            RenderUtil.addUv(uvs, 0, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            RenderUtil.addUv(uvs, 1, 0, textureTileOffset);

            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            RenderUtil.addUv(uvs, 0, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            RenderUtil.addUv(uvs, 0, 1, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);
        }

        public static void AddSquareFaceZPositive(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize, Position2D textureTileOffset)
        {
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            RenderUtil.addUv(uvs, 0, 1, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            RenderUtil.addUv(uvs, 1, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);

            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            RenderUtil.addUv(uvs, 0, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            RenderUtil.addUv(uvs, 0, 1, textureTileOffset);
        }

        public static void AddSquareFaceXNegative(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize, Position2D textureTileOffset)
        {
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            RenderUtil.addUv(uvs, 0, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, 0));
            RenderUtil.addUv(uvs, 1, 0, textureTileOffset);

            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, 0));
            RenderUtil.addUv(uvs, 0, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, 0, tileSize.z));
            RenderUtil.addUv(uvs, 0, 1, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(0, tileSize.y, tileSize.z));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);
        }

        public static void AddSquareFaceXPositive(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Vector3 cubePosition, Vector3 tileSize, Position2D textureTileOffset)
        {
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            RenderUtil.addUv(uvs, 0, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, tileSize.z));
            RenderUtil.addUv(uvs, 0, 1, textureTileOffset);

            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, 0, 0));
            RenderUtil.addUv(uvs, 0, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, 0));
            RenderUtil.addUv(uvs, 1, 0, textureTileOffset);
            RenderUtil.AddTriangleVertice(vertices, triangles, cubePosition + new Vector3(tileSize.x, tileSize.y, tileSize.z));
            RenderUtil.addUv(uvs, 1, 1, textureTileOffset);
        }
    }
}