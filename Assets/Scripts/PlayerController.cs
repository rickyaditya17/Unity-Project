using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions controls;
    private Vector2 moveInput;
    private CharacterController characterController;
    public Transform camTransform;
    private Vector3 moveChar;

    [SerializeField]private float gravity =  -9.81f;
    private Vector3 velocity;
    public float speed;

    void Awake()
    {
        controls = new InputSystem_Actions();
        characterController = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 camforward = camTransform.forward;
        Vector3 camRight = camTransform.right;

        camforward.y = 0f;
        camRight.y = 0f;

        camforward.Normalize();
        camRight.Normalize();

        moveInput = controls.Player.Move.ReadValue<Vector2>();

        moveChar = camRight * moveInput.x + camforward * moveInput.y;

        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMove = (moveChar * speed) + new Vector3(0, velocity.y, 0);
        characterController.Move(finalMove * Time.deltaTime);

    }
}
