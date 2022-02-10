using UnityEngine;

namespace TigerTail.FPSController
{
    [RequireComponent(typeof(Camera))]
    [DisallowMultipleComponent]
    public class FPSCamera : MonoBehaviour
    {
        [Tooltip("Mouse sensitivity for camera rotation.")]
        [Range(50, 500)]
        [SerializeField] private float mouseSensitivity = 100f;

        [Tooltip("Transform of the player's body so that it can be rotated with the camera.")]
        [SerializeField] private Transform playerBody;

        /// <summary>Rotation around the x-axis for looking up and down.</summary>
        /// <remarks>Looking left and right is handled by rotating the actual player controller.
        /// This ensures that moving the player object in its forward direction will make it move in the direction we're looking.</remarks>
        private float xRotation = 0f;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked; // Prevents our mouse from exiting the screen. Doesn't always work in the editor but does for builds.
        }

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
