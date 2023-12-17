using UnityEngine;

public class DroneController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 3f;
    public float altitudeForce = 10f;

    void Update()
    {
        // Drone'u kontrol etme işlemleri
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Rotation");
        float altitude = Input.GetAxis("Altitude");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = movement.normalized * speed * Time.deltaTime;
        transform.Translate(movement);

        // Drone'u döndürme
        transform.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);

        // Yükseklik kontrolü
        Vector3 upForce = Vector3.up * altitude * altitudeForce * Time.deltaTime;
        transform.Translate(upForce);
    }
}