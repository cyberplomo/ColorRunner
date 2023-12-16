using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    private Material originalMaterial;
    private Color newColor;

    private void Start()
    {
        // Karakterin orijinal materyalini kaydet
        originalMaterial = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwitchColor"))
        {
            // Yeni renk alınacak
            newColor = other.GetComponent<Renderer>().material.color;

            // Karakterin materyalini değiştir
            GetComponent<Renderer>().material.color = newColor;

            // Tüm klonların renklerini değiştir
            ChangeAllClonesColor(newColor);
        }
    }

    private void ChangeAllClonesColor(Color newColor)
    {
        // Tüm klonları bul
        GameObject[] clones = GameObject.FindGameObjectsWithTag("PlayerClone");

        // Her klonun rengini değiştir
        foreach (GameObject clone in clones)
        {
            Renderer cloneRenderer = clone.GetComponent<Renderer>();
            if (cloneRenderer != null)
            {
                cloneRenderer.material.color = newColor;
            }
        }
    }
}
