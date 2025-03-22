using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    public static InputManager instance;

    public Vector2 Move { get; private set; }
    public Vector2 Look { get; private set; }

    private PlayerInput _playerInput;
    
    private InputAction _moveAction;
    private InputAction _lookAction;

    private void Awake() {

        if (instance == null) {
            instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();

        SetupInputControls();
    }

    private void Update() {
        UpdateInptuts();
    }

    private void SetupInputControls() {
        _moveAction = _playerInput.actions["Move"];
        _lookAction = _playerInput.actions["Look"];
    }

    private void UpdateInptuts() {
        Move = _moveAction.ReadValue<Vector2>();
        Look = _lookAction.ReadValue<Vector2>();
    }

}
