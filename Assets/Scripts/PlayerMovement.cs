using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float jumpForce;

    [SerializeField] private Joystick handle;
    [SerializeField] private float leftrightSpeed;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float maxForwardSpeed;
    [SerializeField] private Vector2 minMaxX;

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
        if (handle == null)
        {
            return;
        }

        float horizontalMovement = handle.Horizontal * leftrightSpeed * Time.deltaTime;
        float forwardMovement = handle.Vertical * forwardSpeed * Time.deltaTime;

        // Yatay konumu sınırla
        float newXPosition = Mathf.Clamp(transform.position.x + horizontalMovement, minMaxX.x, minMaxX.y);

        // Yeni konumu uygula
        rb.MovePosition(new Vector3(newXPosition, transform.position.y, transform.position.z));

        // Sadece yatay eksende ve pozitif y ekseninde hareket ettiğinde hızı ayarla
        if (handle.Vertical > 0)
        {
            rb.velocity = new Vector3(0, jumpForce, Mathf.Clamp(forwardMovement, 0, maxForwardSpeed));
        }
        else
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
        }
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