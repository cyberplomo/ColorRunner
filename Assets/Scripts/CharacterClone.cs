using UnityEngine;

public class CharacterClone : MonoBehaviour 
{
    public string characterPrefabPath = "Prefabs/CharacterPrefab";
    public Transform spawnPoint;

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
    }

    void AddCharacterToFollower() 
    {
        GameObject characterPrefab = Resources.Load<GameObject>(characterPrefabPath);
        GameObject newCharacter = Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);

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
}