using System.Linq;
using code.gui;
using code.map;
using code.render;
using code.terrain;
using UnityEngine;

namespace code.objectscript
{
    public class GameObjectScript : MonoBehaviour
    {
        private ProgressBar _progressBar;

        private void Start()
        {
            DisplayProgressBar();

            Physics.gravity = new Vector3(0, -10, 0);

            var initialPlayerPosition = getInitialPlayerPosition();
            var chunkPositionsToRender = MapPositionUtil.GetChunkPosition(initialPlayerPosition).GetPositionsInCubeRadius(1).ToList();

            Chunk.Instance.RenderOnly(chunkPositionsToRender, _progressBar, () => { PlayerObjectScript.Instance.setPosition(initialPlayerPosition); });
        }

        private void DisplayProgressBar()
        {
            var size = new Vector2(Screen.width - 50, 100);
            var position = new Vector2((float) Screen.width / 2 - size.x / 2, (float) Screen.height / 2 - size.y / 2);
            _progressBar = new ProgressBar(position, size, Color.black, Color.blue);
        }

        private Vector3 getInitialPlayerPosition()
        {
            var tilePosition = new Position3D(Chunk.ChunkSize.x / 2, Chunk.ChunkSize.y / 2, Chunk.ChunkSize.z / 2);

            return new Vector3
            {
                x = tilePosition.x * Tile.TileSize.x + Tile.TileSize.x / 2,
                y = TerrainGenerator.getHeight(tilePosition.x, tilePosition.z) * Tile.TileSize.y + Tile.TileSize.y * 5,
                z = tilePosition.z * Tile.TileSize.z + Tile.TileSize.z / 2
            };
        }

        private void OnGUI()
        {
            if (_progressBar.Progress < 1)
            {
                lock (_progressBar)
                    _progressBar.Draw();
            }
        }

        public static GameObject CreateGameObject(string resourceName, UnityMeshInfo unityMeshInfo)
        {
            var gameObject = (GameObject) Instantiate(Resources.Load(resourceName));

            var mesh = gameObject.GetComponent<MeshFilter>().mesh;
            mesh.Clear();
            mesh.vertices = unityMeshInfo.Vertices;
            mesh.triangles = unityMeshInfo.Triangles;
            mesh.uv = unityMeshInfo.Uv;
            mesh.colors = Enumerable.Repeat(unityMeshInfo.Color, unityMeshInfo.Uv.Length).ToArray();
            mesh.RecalculateNormals();

            gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
            gameObject.transform.position = unityMeshInfo.Position;

            return gameObject;
        }
    }
}