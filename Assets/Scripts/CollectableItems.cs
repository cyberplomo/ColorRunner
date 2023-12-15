using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItems : MonoBehaviour
{
    private Color characterColor; // Karakterin rengini saklamak için değişken
    private int collectedItems = 0;

    void Start()
    {
        // Karakterin başlangıç rengini ayarla (örneğin, rastgele bir renk atayabilirsiniz)
        characterColor = Random.ColorHSV();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectitem"))
        {
            // Çarptığımız nesnenin rengini kontrol et
            Color objectColor = other.GetComponent<Renderer>().material.color;

            // Eğer nesnenin rengi karakterin rengine eşitse, nesneyi topla
            if (objectColor == characterColor)
            {
                CollectItem(other.gameObject);
            }
        }
    }

    void CollectItem(GameObject collectedItem)
    {
        // Nesneyi toplama işlemleri buraya eklenir
        Destroy(collectedItem);
        collectedItems++;
        Debug.Log("Toplanan Nesne Sayısı: " + collectedItems);
    }
}
