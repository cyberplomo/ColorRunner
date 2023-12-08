using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float jumpForce;

    [SerializeField] private Joystick joystick;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float leftrightSpeed;
    [SerializeField] private Vector2 minMaxX;
    [SerializeField] private Vector2 minMaxY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // Joystick'in null olup olmadığını kontrol et
        if (joystick == null)
        {
            Debug.LogError("Joystick not assigned to PlayerMovement script!");
        }
    }

    private void Update()
    {
        ApplyGravity();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (joystick == null)
        {
            return; // Joystick null ise işlemi geç
        }

        float horizontalMovement = joystick.Horizontal * leftrightSpeed * Time.deltaTime;
        float forwardMovement = forwardSpeed * Time.deltaTime;

        Vector3 newPosition = new Vector3(
            Mathf.Clamp(transform.position.x, minMaxX.x, minMaxX.y),
            transform.position.y,
            transform.position.z
        );

        rb.velocity = new Vector3(horizontalMovement, jumpForce, forwardMovement);
        transform.position = newPosition;
    }

    public void Jump()
    {
        jumpForce = 5f;
    }

    private void ApplyGravity()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1);

        Physics.gravity = isGrounded ? new Vector3(0, -9.81f, 0) : new Vector3(0, -100f, 0);
    }
}