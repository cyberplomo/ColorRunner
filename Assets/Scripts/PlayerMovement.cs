using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 5.0f; // Dönme hızı
    public float moveSpeed = 5.0f; // Hareket hızı

    void Update()
    {
        // Fare sol tuşuna basıldığında yön değiştirme
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up * mouseX * rotationSpeed);
        }

        // Sadece sol tuşa basılı tutulduğunda ileriye doğru hareket etme
        if (Input.GetMouseButton(0))
        {
            // Karakterin otomatik olarak ileriye gitmesi
            Vector3 forwardMovement = transform.TransformDirection(Vector3.forward);
            transform.Translate(forwardMovement * moveSpeed * Time.deltaTime);
        }
    }
}