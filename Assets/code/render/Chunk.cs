using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using code.gui;
using code.map;
using code.objectscript;
using code.util;
using UnityEngine;
using Object = UnityEngine.Object;

namespace code.render
{
    public class Chunk
    {
        public static readonly Position3D ChunkSize = new Position3D(32, 32, 32);

        private static readonly Color Color = new Color(255, 255, 255);
        private static Chunk _instance;

        private Dictionary<Position3D, GameObject> _renderedChunks;
        private ElementLimitCache<Position3D, UnityMeshInfo> _chunkMeshInfoCache;
        private Queue<Position3D> _chunkMeshInfoToGenerate;
        private List<Position3D> _chunksToRerender;

        private Chunk()
        {
            _renderedChunks = new Dictionary<Position3D, GameObject>();
            _chunkMeshInfoCache = new ElementLimitCache<Position3D, UnityMeshInfo>(5 * 9);
            _chunkMeshInfoToGenerate = new Queue<Position3D>();
            _chunksToRerender = new List<Position3D>();

            new Thread(ChunkMeshInfoGeneration).Start();
        }

        public static Chunk Instance
        {
            get { return _instance ?? (_instance = new Chunk()); }
        }

        public void RenderOnly(List<Position3D> chunkPositionsToRender, ProgressBar progressBar = null, Action allChunksRenderedCallback = null)
        {
            List<Position3D> chunkPositionsToCreate;

            lock (_chunkMeshInfoToGenerate)
            {
                chunkPositionsToCreate = chunkPositionsToRender
                    .Where(chunkPositionToRender => _chunksToRerender.Contains(chunkPositionToRender) ||
                                                    !_renderedChunks.ContainsKey(chunkPositionToRender) &&
                                                    !_chunkMeshInfoToGenerate.Contains(chunkPositionToRender))
                    .ToList();
            }

            var chunkPositionsToDelete = _renderedChunks
                .Where(renderedChunkPair => !chunkPositionsToRender.Contains(renderedChunkPair.Key))
                .Select(renderedChunkPair => renderedChunkPair.Key).ToList();

            foreach (var chunkPosition in chunkPositionsToCreate)
                Render(chunkPosition);

            foreach (var chunkPositionToDelete in chunkPositionsToDelete)
                Unrender(chunkPositionToDelete);

            UpdateChunkRenderProgress(chunkPositionsToRender, progressBar, allChunksRenderedCallback);
        }

        public void Unrender(Position3D chunkPosition)
        {
            Object.Destroy(_renderedChunks[chunkPosition]);
            _renderedChunks.Remove(chunkPosition);
        }

        public void Rerender(Position3D chunkPosition)
        {
            lock (_chunkMeshInfoCache)
                _chunkMeshInfoCache.Remove(chunkPosition);

            _chunksToRerender.Add(chunkPosition);
        }

        private void UpdateChunkRenderProgress(List<Position3D> chunkPositionsToRender, ProgressBar progressBar, Action allChunksRenderedCallback)
        {
            if (progressBar == null && allChunksRenderedCallback == null)
                return;

            new Thread(delegate()
            {
                while (true)
                {
                    int numberOfUnrenderedChunks;

                    lock (_chunkMeshInfoToGenerate)
                        numberOfUnrenderedChunks = _chunkMeshInfoToGenerate.Intersect(chunkPositionsToRender).Count();

                    if (progressBar != null)
                    {
                        lock (progressBar)
                            progressBar.Progress = (float) (chunkPositionsToRender.Count - numberOfUnrenderedChunks) / chunkPositionsToRender.Count;
                    }

                    if (numberOfUnrenderedChunks == 0)
                    {
                        if (allChunksRenderedCallback != null)
                            allChunksRenderedCallback();

                        return;
                    }

                    Thread.Sleep(100);
                }
            }).Start();
        }

        private void Render(Position3D chunkPosition)
        {
            UnityMeshInfo chunkTerrainUnityMeshInfo;
            

            lock (_chunkMeshInfoCache)
            {
                chunkTerrainUnityMeshInfo = _chunkMeshInfoCache.ContainsKey(chunkPosition) ? _chunkMeshInfoCache[chunkPosition] : null;
            }
            
            if (chunkTerrainUnityMeshInfo != null)
            {
                if (_renderedChunks.ContainsKey(chunkPosition))
                    Unrender(chunkPosition);

                var gameObject = chunkTerrainUnityMeshInfo.Triangles.Length <= 0 ? null : GameObjectScript.CreateGameObject("TerrainChunk", chunkTerrainUnityMeshInfo);

                _renderedChunks.Add(chunkPosition, gameObject);

                if (_chunksToRerender.Contains(chunkPosition))
                {
                    _chunksToRerender.Remove(chunkPosition);
                }
            }
            else
            {
                lock (_chunkMeshInfoToGenerate)
                {
                    if (!_chunkMeshInfoToGenerate.Contains(chunkPosition))
                        _chunkMeshInfoToGenerate.Enqueue(chunkPosition);
                }
            }
        }

        private void ChunkMeshInfoGeneration()
        {
            while (true)
            {
                Position3D chunkPosition;

                lock (_chunkMeshInfoToGenerate)
                    chunkPosition = _chunkMeshInfoToGenerate.Count > 0 ? _chunkMeshInfoToGenerate.Dequeue() : null;

                if (chunkPosition == null)
                    Thread.Sleep(100);
                else
                {
                    var meshInfo = GenerateChunkTerrainUnityMeshInfo(chunkPosition);

                    lock (_chunkMeshInfoCache)
                        _chunkMeshInfoCache[chunkPosition] = meshInfo;
                }
            }
        }

        private static UnityMeshInfo GenerateChunkTerrainUnityMeshInfo(Position3D chunkPosition)
        {
            var chunkTilePosition = chunkPosition * ChunkSize;

            var vertices = new List<Vector3>();
            var uvs = new List<Vector2>();
            var triangles = new List<int>();

            for (var x = 0; x < ChunkSize.x; x++)
            for (var z = 0; z < ChunkSize.z; z++)
            for (var y = 0; y < ChunkSize.y; y++)
            {
                var tilePosition = chunkTilePosition + new Position3D(x, y, z);
                var tile = Map.Instance.GetTile(tilePosition);

                if (tile.TileType.Visible)
                    RenderUtil.AddCube(vertices, triangles, uvs, tilePosition);
            }

            var position = new Vector3(chunkTilePosition.x * Tile.TileSize.x, chunkTilePosition.y * Tile.TileSize.y, chunkTilePosition.z * Tile.TileSize.z);

            return new UnityMeshInfo(vertices.ToArray(), triangles.ToArray(), uvs.ToArray(), Color, position);
        }
    }
}