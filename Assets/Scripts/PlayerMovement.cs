using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float jumpForce;

    [SerializeField] private Joystick Handle;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float leftrightSpeed;
    [SerializeField] private Vector2 minMaxX;
    [SerializeField] private Vector2 minMaxY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ApplyGravity();
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalMovement = Handle.Horizontal * leftrightSpeed * Time.deltaTime;
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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwitchColor"))
        {
            // Karakter, renk değiştiren nesne ile etkileşime geçti.
            // Burada renk değiştirme işlemini gerçekleştirebilirsiniz.
        }
    }

}