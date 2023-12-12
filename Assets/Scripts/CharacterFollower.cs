using UnityEngine;

public class CharacterFollower : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin transformu
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("Line Renderer component not found!");
        }

        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if (target != null)
        {
            // İlk nokta, takip eden karakterin pozisyonu
            lineRenderer.SetPosition(0, transform.position);

            // İkinci nokta, takip edilen karakterin pozisyonu
            lineRenderer.SetPosition(1, target.position);
        }
    }
} 