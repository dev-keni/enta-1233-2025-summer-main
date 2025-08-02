using MyCharacterInput;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Pattern
    // Encapsulation
    public static GameManager Instance { get; private set; }

    [SerializeField] private CharacterManager _characterManager;
    [SerializeField] private LevelManager _levelManager;
    private PlayerHUD _playerHud;
    [SerializeField] private TMP_Text _scoreText;

    public float Timer = 0.0f;
    public int EnemiesKilled = 0;
    public bool TimerEnabled = false;

    //Delta time timer
    private void Update()
    {
        if (TimerEnabled)
        {
            Timer += Time.deltaTime;
            _playerHud.Timer(Timer);
        }
    }

    //Load level, restart timer, score, spawn player and start timer
    public void InitializeGame()
    {
        _levelManager.LoadLevelAdditively("PrototypeScene");
        _characterManager.SpawnCharacter();
        _playerHud = _characterManager.CurrentCharacter.gameObject.transform.GetChild(0).GetChild(2).GetComponent<PlayerHUD>();
        EnemiesKilled = 0;
        Timer = 0.0f;
        TimerEnabled = true;
    }

    //Add score when an enemy dies
    public void UpScore()
    {
        EnemiesKilled += 1;
        _playerHud.OnScoreUpdated(EnemiesKilled);
    }

    //Game over stats displayed onto the menu
    public void GameOver()
    {
        StopTimer();
        float minutes = Mathf.FloorToInt(Timer / 60);
        float seconds = Mathf.FloorToInt(Timer % 60);
        float milliSeconds = (Timer % 1) * 1000;
        _scoreText.text = string.Format("You survived for {0:00}:{1:00}:{2:000} and you killed {3} Pills!", minutes, seconds, milliSeconds, EnemiesKilled);
    }

    public void StopTimer()
    {
        TimerEnabled = false;
    }
}
