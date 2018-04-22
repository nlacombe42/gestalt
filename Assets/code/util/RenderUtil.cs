using System.Collections.Generic;
using code.map;
using UnityEngine;

namespace code.util
{
    public static class RenderUtil
    {
        public static void AddTriangleVertice(List<Vector3> vertices, List<int> triangles, Vector3 vertice)
        {
            vertices.Add(vertice);
            triangles.Add(vertices.Count - 1);
        }

        public static void AddCube(List<Vector3> vertices, List<int> triangles, List<Vector2> uvs, Position3D tileMapIndex)
        {
            var tilePositionInChunk = MapPositionUtil.GetPositionInChunk(tileMapIndex);
            var tilePositionRelativeToChunk =
                new Vector3(tilePositionInChunk.x * Tile.TileSize.x, tilePositionInChunk.y * Tile.TileSize.y, tilePositionInChunk.z * Tile.TileSize.z);
            var tile = Map.Instance.GetTile(tileMapIndex);

            if (Map.Instance.IsTransparent(tileMapIndex.getPositionPlusY(1)))
                CubeGenerator.AddSquareFaceYPositive(vertices, triangles, uvs, tilePositionRelativeToChunk, Tile.TileSize, tile.TileType.TextureTileOffset);

            if (Map.Instance.IsTransparent(tileMapIndex.getPositionPlusY(-1)))
                CubeGenerator.AddSquareFaceYNegative(vertices, triangles, uvs, tilePositionRelativeToChunk, Tile.TileSize, tile.TileType.TextureTileOffset);

            if (Map.Instance.IsTransparent(tileMapIndex.getPositionPlusZ(-1)))
                CubeGenerator.AddSquareFaceZNegative(vertices, triangles, uvs, tilePositionRelativeToChunk, Tile.TileSize, tile.TileType.TextureTileOffset);

            if (Map.Instance.IsTransparent(tileMapIndex.getPositionPlusZ(1)))
                CubeGenerator.AddSquareFaceZPositive(vertices, triangles, uvs, tilePositionRelativeToChunk, Tile.TileSize, tile.TileType.TextureTileOffset);

            if (Map.Instance.IsTransparent(tileMapIndex.getPositionPlusX(-1)))
                CubeGenerator.AddSquareFaceXNegative(vertices, triangles, uvs, tilePositionRelativeToChunk, Tile.TileSize, tile.TileType.TextureTileOffset);

            if (Map.Instance.IsTransparent(tileMapIndex.getPositionPlusX(1)))
                CubeGenerator.AddSquareFaceXPositive(vertices, triangles, uvs, tilePositionRelativeToChunk, Tile.TileSize, tile.TileType.TextureTileOffset);
        }

        public static void addUv(List<Vector2> uvs, float texturePercentPositionU, float texturePercentPositionV, Position2D textureTileOffset)
        {
            const int numberOfTextureTileU = 2;
            const int numberOfTextureTileV = 2;

            var u = texturePercentPositionU / numberOfTextureTileU + (float) textureTileOffset.x / numberOfTextureTileU;
            var v = texturePercentPositionV / numberOfTextureTileV + (float) textureTileOffset.y / numberOfTextureTileV;

            uvs.Add(new Vector2(u, v));
        }
    }
}