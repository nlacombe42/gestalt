using System.Linq;
using code.util;
using UnityEngine;

namespace code.objectscript
{
    public class GameObjectScript : MonoBehaviour
    {
        private void Start()
        {
            Physics.gravity = new Vector3(0, -10, 0);
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