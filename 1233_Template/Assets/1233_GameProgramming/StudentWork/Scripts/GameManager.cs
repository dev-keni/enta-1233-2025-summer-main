using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Pattern
    // Encapsulation
    public static GameManager Instance { get; private set; }

    [SerializeField] private CharacterManager _characterManager;
    [SerializeField] private LevelManager _levelManager;

    //Load level and spawn player
    public void InitializeGame()
    {
        _levelManager.LoadLevelAdditively("PrototypeScene");
        _characterManager.SpawnCharacter();
    }
}
