using UnityEngine;

public class CharacterClone : MonoBehaviour 
{
    public GameObject characterPrefab;
    public Transform spawnPoint;
    public float spawnDistance = 1.0f; // Karakterler arasındaki mesafe

    private int characterCount = 1;
    private GameObject lastSpawnedCharacter;

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Collectitem")) 
        {
            Destroy(other.gameObject);
            characterCount++;
            AddCharacterToFollower();
        }
        else if (other.CompareTag("Obstacle")) // "Obstacle" olarak adlandırılmış engel tag'i
        {
            ReduceCharacterCount();
        }
    }

    void AddCharacterToFollower() 
    {
        if (characterPrefab == null)
        {
            Debug.LogError("Character prefab is not assigned!");
            return;
        }

        Vector3 nextSpawnPosition = spawnPoint.position + new Vector3(0f, 0f, spawnDistance * characterCount);
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
        if (characterCount > 1)
        {
            characterCount--;
            // Burada gerekirse bir önceki karakteri yok edebilir veya belirli bir işlemi gerçekleştirebilirsiniz.
            Destroy(lastSpawnedCharacter);
        }
    }
}
