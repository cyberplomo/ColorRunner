using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwitchColor"))
        {
            // Karakterin rengini değiştir.
            Renderer karakterRenderer = GetComponent<Renderer>();

            if (karakterRenderer != null)
            {
                karakterRenderer.material.color = other.GetComponent<Renderer>().material.color;
            }
            else
            {
                Debug.LogError("Renderer component not found on the Player game object!");
            }
        }
    }
    
}


