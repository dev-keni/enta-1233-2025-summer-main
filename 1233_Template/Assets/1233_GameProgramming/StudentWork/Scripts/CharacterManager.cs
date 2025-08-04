using MyCharacterInput;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private MainMenu _mainMenu;

    public GameObject CurrentCharacter;
    
    //Spawn the player at set position
    public void SpawnCharacter()
    {
        Vector3 spawnPosition = new Vector3(-3.17000008f, 1.61314762f, 19.2000008f);
        CurrentCharacter = Instantiate(_characterPrefab, spawnPosition, Quaternion.identity, transform);
        AudioListener.volume = _mainMenu.GetComponent<MainMenu>().GameVolume;
    }

    //Unloads the level and turns the menu back on
    public void ResetMenu()
    {
        _levelManager.UnloadLevel("PrototypeScene");
        _mainMenu.Reawaken();
    }
}
