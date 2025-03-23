using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Transform orientation;
    [SerializeField] private float sensivility;
    [SerializeField] private float moveSpeed = 6f;
    [Space(15)]

    [Header("Drags")]
    [SerializeField] private float groundDrag = 6f;
    [Space(15)]

    private Rigidbody rb;
    private float movementMultiplier = 10.0f;
    private Vector2 playerInputMove;
    private Vector3 moveDir;

    private Camera cam;
    private Vector2 playerInputCamera;
    private float xRotation, yRotation;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        ControlDrag();
        SetOrientation();
        Look();
    }

    private void FixedUpdate() {
        Move();
    }

    private void ControlDrag() {
        rb.linearDamping = groundDrag;
    }

    private void SetOrientation() {
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    private void Move() {

        playerInputMove = InputManager.instance.Move;

        moveDir = orientation.forward * playerInputMove.y + orientation.right * playerInputMove.x;

        rb.AddForce(moveDir.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
    }

    private void Look() {

        playerInputCamera = InputManager.instance.Look;

        yRotation += playerInputCamera.x * sensivility;
        xRotation -= playerInputCamera.y * sensivility;

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);

    }

}
