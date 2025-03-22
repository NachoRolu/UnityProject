using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float sensivility;

    private Camera cam;
    private Vector2 playerInputCamera;
    private float xRotation, yRotation;

    private void Awake() {
        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        Look();
    }

    private void Look() {

        playerInputCamera = InputManager.instance.Look;

        yRotation += playerInputCamera.x * sensivility;
        xRotation -= playerInputCamera.y * sensivility;

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);

    }

}
