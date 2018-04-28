using System.Linq;
using code.map;
using code.render;
using code.terrain;
using UnityEngine;

namespace code.objectscript
{
    [RequireComponent(typeof(Transform))]
    public class PlayerObjectScript : MonoBehaviour
    {
        private const float MouseSensitivity = 100.0f;

        private static PlayerObjectScript _instance;
        
        private Camera _playerCamera;
        private Rigidbody _playerRigidbody;
        private Vector3 _positionToSet;
        private bool _hasPositionToSet;
        private bool _freezePosition;
        private bool _unfreezePosition;

        public static PlayerObjectScript Instance
        {
            get { return _instance; }
        }

        public void SetPosition(Vector3 position)
        {
            _positionToSet = position;
            _hasPositionToSet = true;
        }

        public void FreezePosition()
        {
            _freezePosition = true;
            
        }
        
        public void UnfreezePosition()
        {
            _unfreezePosition = true;
        }

        private void Start()
        {
            _instance = this;
            
            _playerCamera = transform.Find("player camera").GetComponent<Camera>();
            _playerRigidbody = GetComponent<Rigidbody>();

            Cursor.lockState = CursorLockMode.Locked;
        }
        
        private void Update ()
        {
            if (_hasPositionToSet)
            {
                transform.position = _positionToSet;
                _hasPositionToSet = false;
            }

            if (_freezePosition)
            {
                _playerRigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
                _freezePosition = false;
            }
            
            if(_unfreezePosition)
            {
                _playerRigidbody.constraints ^= RigidbodyConstraints.FreezePositionY;
                _unfreezePosition = false;
            }
            
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

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, -Vector3.up, 10.1f);
        }

        private void RenderChunksNearPlayer()
        {
            var playerChunkPosition = MapPositionUtil.GetChunkPosition(transform.position);

            Chunk.Instance.RenderOnly(playerChunkPosition.GetPositionsInCubeRadius(1).ToList());
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