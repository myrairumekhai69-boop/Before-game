using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 velocity;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction runAction;
    private InputAction jumpAction;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        runAction = playerInput.actions["Run"];
        jumpAction = playerInput.actions["Jump"];
    }

    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        bool isRunning = runAction.ReadValue<float>() > 0.1f;

        Vector3 move = (cameraTransform.forward * input.y + cameraTransform.right * input.x);
        move.y = 0f;
        move.Normalize();

        float speed = isRunning ? runSpeed : moveSpeed;
        controller.Move(move * speed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (jumpAction.triggered && controller.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
