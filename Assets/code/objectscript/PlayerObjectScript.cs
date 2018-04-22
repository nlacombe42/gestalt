using System.Collections.Generic;
using System.Linq;
using code.map;
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
        
        private void Update ()
        {
            HandlePlayerClick();
            RenderChunksNearPlayer();
        }

        private void FixedUpdate()
        {
            UpdatePlayerFromMovementInput();
            UpdatePlayerFromViewRotation();
        }

        private void HandlePlayerClick()
        {
            if (!Input.GetMouseButtonDown(0))
                return;
            
            var ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit))
                return;

            var pointInTile = hit.point + ray.direction.normalized * (Tile.TileSize.x / 2);

            var tilePosition = MapPositionUtil.GetTilePosition(pointInTile);

            Map.Instance.SetTile(tilePosition, new Tile(TileType.Air));
        }

        private void OnGUI()
        {
            GUI.Box(new Rect(Screen.width / 2f, Screen.height / 2f, 10, 10), "");
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
            var playerChunkPosition = MapPositionUtil.GetChunkPosition(transform.position);

            Chunk.Instance.Render(playerChunkPosition.GetPositionsInCubeRadius(1).ToList());
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