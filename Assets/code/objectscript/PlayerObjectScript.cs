using code.terrain;
using UnityEngine;

namespace code.objectscript
{
    [RequireComponent(typeof(Transform))]
    public class PlayerObjectScript : MonoBehaviour
    {
        private const float CameraRotationSpeed = 75f;

        private Camera _playerCamera;
        
        private void Start()
        {
            _playerCamera = transform.Find("player camera").GetComponent<Camera>();
            
            var playerPosition = new Vector3
            {
                x = 12 * Tile.TileSize.x + Tile.TileSize.x / 2,
                y = TerrainGenerator.getHeight(12, 12) * Tile.TileSize.y + Tile.TileSize.y * 5,
                z = 12 * Tile.TileSize.z + Tile.TileSize.z / 2
            };

            transform.position = playerPosition;
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector3.forward * Time.deltaTime * 10);

            if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector3.back * Time.deltaTime * 10);

            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.left * Time.deltaTime * 10);

            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * Time.deltaTime * 10);

            if (Input.GetKey(KeyCode.Space))
                transform.Translate(Vector3.up * Time.deltaTime * 10);

            if (Input.GetKey(KeyCode.LeftControl))
                transform.Translate(Vector3.down * Time.deltaTime * 10);

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(Vector3.up * Time.deltaTime * -CameraRotationSpeed);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(Vector3.up * Time.deltaTime * CameraRotationSpeed);

            if (Input.GetKey(KeyCode.UpArrow))
                _playerCamera.transform.Rotate(Vector3.right * Time.deltaTime * -CameraRotationSpeed);

            if (Input.GetKey(KeyCode.DownArrow))
                _playerCamera.transform.Rotate(Vector3.right * Time.deltaTime * CameraRotationSpeed);
        }
    }
}