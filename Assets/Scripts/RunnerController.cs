using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RunnerController : MonoBehaviour 
{
    public string characterPrefabPath = "Prefabs/CharacterPrefab"; // Prefab'ın Resources içindeki yolu
    public Transform spawnPoint;

    private int characterCount = 1;
    private List<GameObject> CharacterFollower = new List<GameObject>();

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Collectitem")) {
            Destroy(other.gameObject);
            characterCount++;
            AddCharacterToFollower();
        }
    }

    void AddCharacterToFollower() {
        GameObject characterPrefab = Resources.Load<GameObject>(characterPrefabPath);
        GameObject newCharacter = Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);
        CharacterFollower.Add(newCharacter);

        // Yeni karakteri bir öncekine bağla
        
            if (CharacterFollower.Count > 1)
            {
                newCharacter.GetComponent<CharacterFollower>().SetTarget(CharacterFollower[CharacterFollower.Count - 2].transform);
            }
        
    }
}