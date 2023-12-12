using UnityEngine;

public class RunnerController : MonoBehaviour
{
    public GameObject characterPrefab;
    public float cloneDistance = 2.0f; // Karakterler arasındaki mesafe

    private int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectitem"))
        {
            Destroy(other.gameObject); // Coin'i yok et, isteğe bağlı
            coinCount++;
            UpdateCharacterCount(); // Karakter sayısını güncelle
        }
        
        if (other.CompareTag("Collectitem"))
        {
            Debug.Log("Coin collected!");
            Destroy(other.gameObject); // Coin'i yok et, isteğe bağlı
            coinCount++;
            UpdateCharacterCount(); // Karakter sayısını güncelle
            Debug.Log("Karakter sayısını güncelle");
        }
        
    }

    private void UpdateCharacterCount()
    {
        // Önceki karakterleri temizle
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Yeni karakterleri oluştur
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 spawnPosition = new Vector3(0, 0, i * cloneDistance);
            GameObject characterClone = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
            characterClone.transform.parent = transform; // Ana karakterin altında klonu oluştur
        }
    }
    
}