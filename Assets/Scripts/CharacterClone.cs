using UnityEngine;

public class CharacterClone : MonoBehaviour
{
    public GameObject characterPrefab;
    public Transform spawnPoint;
    public float spawnDistance = 1.0f; // Karakterler arasındaki mesafe
    public Transform mergeZone; // Birleşme bölgesi

    private int characterCount = 1;
    private GameObject lastSpawnedCharacter;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectitem"))
        {
            Destroy(other.gameObject);
            AddCharacterToFollower();
        }
        else if (other.CompareTag("Obstacle"))
        {
            ReduceCharacterCount();
        }
        else if (other.CompareTag("MergeZone"))
        {
            MergeCharacters();
        }
    }

    void AddCharacterToFollower()
    {
        if (characterPrefab == null)
        {
            Debug.LogError("Character prefab is not assigned!");
            return;
        }

        Vector3 nextSpawnPosition = spawnPoint.position + new Vector3(0f, 0f, spawnDistance);
        GameObject newCharacter = Instantiate(characterPrefab, nextSpawnPosition, spawnPoint.rotation);

        ConnectCharacterToPrevious(newCharacter);

        lastSpawnedCharacter = newCharacter;
    }

    void ConnectCharacterToPrevious(GameObject newCharacter)
    {
        if (lastSpawnedCharacter != null)
        {
            CharacterFollower characterFollowerComponent = newCharacter.GetComponent<CharacterFollower>();
            if (characterFollowerComponent != null)
            {
                characterFollowerComponent.SetTarget(lastSpawnedCharacter.transform);
            }
        }
    }

    void ReduceCharacterCount()
    {
        if (lastSpawnedCharacter != null)
        {
            characterCount--;
            Destroy(lastSpawnedCharacter);

            if (characterCount == 0)
            {
                MergeCharacters();
            }
        }
    }

    void MergeCharacters()
    {
        // Tüm karakterlerin birleşme bölgesindeki pozisyonunu al
        Vector3 mergePosition = mergeZone.position;

        // Tüm karakterleri birleşme bölgesine taşı ve birleştir
        CharacterFollower[] followers = GetComponentsInChildren<CharacterFollower>();
        foreach (CharacterFollower follower in followers)
        {
            follower.transform.position = mergePosition;
            follower.transform.localScale *= 2f; // Karakterleri büyüt
        }

        // Oyunun sonunu ilan et
        Debug.Log("Oyun bitti! Tüm karakterler birleşti ve büyüdü.");
    }
}
