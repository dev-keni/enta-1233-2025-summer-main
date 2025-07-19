using MyCharacterInput;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private MainMenu mainMenu;

    public GameObject currentCharacter;
    

    public void SpawnCharacter()
    {
        Vector3 spawnPosition = new Vector3(-3.17000008f, 1.61314762f, 19.2000008f);
        currentCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity, transform);
    }

    public void ResetMenu()
    {
        levelManager.UnloadLevel("PrototypeScene");
        mainMenu.Reawaken();
    }
}
