using System.Linq;
using code.map;
using code.terrain;
using code.util;
using UnityEngine;

namespace code.objectscript
{
    [RequireComponent(typeof(Transform))]
    public class PlayerObjectScript : MonoBehaviour
    {
        private const float MouseSensitivity = 100.0f;

        private Camera _playerCamera;
        private Rigidbody _playerRigidbody;

        private void Start()
        {
            _playerCamera = transform.Find("player camera").GetComponent<Camera>();
            _playerRigidbody = GetComponent<Rigidbody>();

            Cursor.lockState = CursorLockMode.Locked;
            
            SetPlayerInitialPosition();
        }
        
        private void FixedUpdate()
        {
            UpdatePlayerFromMovementInput();
            UpdatePlayerFromViewRotation();
            RenderChunksNearPlayer();
        }

        private void SetPlayerInitialPosition()
        {
            var playerPosition = new Vector3
            {
                x = 12 * Tile.TileSize.x + Tile.TileSize.x / 2,
                y = TerrainGenerator.getHeight(12, 12) * Tile.TileSize.y + Tile.TileSize.y * 5,
                z = 12 * Tile.TileSize.z + Tile.TileSize.z / 2
            };

            transform.position = playerPosition;
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, -Vector3.up, 10.1f);
        }

        private void RenderChunksNearPlayer()
        {
            var playerChunkPosition = GetPlayerChunkPosition();

            Map.Instance.Render(playerChunkPosition.GetPositionsInCubeRadius(1).ToList());
        }

        private Position3D GetPlayerChunkPosition()
        {
            var chunkPositionX = Mathf.FloorToInt(transform.position.x / (Chunk.ChunkSize.x * Tile.TileSize.x));
            var chunkPositionY = Mathf.FloorToInt(transform.position.y / (Chunk.ChunkSize.y * Tile.TileSize.y));
            var chunkPositionZ = Mathf.FloorToInt(transform.position.z / (Chunk.ChunkSize.z * Tile.TileSize.z));

            return new Position3D(chunkPositionX, chunkPositionY, chunkPositionZ);
        }

        private void UpdatePlayerFromViewRotation()
        {   
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = -Input.GetAxis("Mouse Y");
 
            _playerCamera.transform.Rotate(new Vector3(mouseY * MouseSensitivity * Time.deltaTime, 0, 0));
            transform.Rotate(new Vector3(0, mouseX * MouseSensitivity * Time.deltaTime, 0));
        }

        private void UpdatePlayerFromMovementInput()
        {
            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector3.forward * Time.deltaTime * 10);

            if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector3.back * Time.deltaTime * 10);

            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector3.left * Time.deltaTime * 10);

            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * Time.deltaTime * 10);

            if (Input.GetKey(KeyCode.Space) && IsGrounded())
                _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, _playerRigidbody.velocity.y + 15, _playerRigidbody.velocity.z);
        }
    }
}