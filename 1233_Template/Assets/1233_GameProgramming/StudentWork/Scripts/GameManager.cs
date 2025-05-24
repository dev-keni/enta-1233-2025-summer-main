using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Pattern
    // Encapsulation
    public static GameManager Instance { get; private set; }

    private CharacterManager characterManager;
    private LevelManager levelManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeGame();
    }

    public void InitializeGame()
    {
        //levelManager.LoadLevelAdditively("SimpleLevel");
        //characterManager.SpawnCharacter();
    }
}
