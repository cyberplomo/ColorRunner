using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Eğer çarpışan nesne bir "Drone" ise ve "Red" tag'ine sahipse
        if (other.CompareTag("Drone") && other.CompareTag("Red"))
        {
            // Drone'u öldür ve oyunu bitir
            DroneDeath(other.gameObject);
        }
    }

    void DroneDeath(GameObject drone)
    {
        // Ölüm animasyonu, efekti, veya diğer işlemleri burada gerçekleştirin

        // Oyunu kapat
        QuitGame();
    }

    void QuitGame()
    {
        // Oyunu kapatma işlemleri
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
