using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _spawnPoint1;
    [SerializeField] private GameObject _spawnPoint2;
    [SerializeField] private GameObject _spawnPoint3;
    [SerializeField] private GameObject _spawnPoint4;
    [SerializeField] private GameObject _spawnPoint5;
    [SerializeField] private GameObject _spawnPoint6;
    private GameManager _gameManager;

    //Get GameManager from main menu
    void Awake()
    {
        Scene menuScene = SceneManager.GetSceneByName("BootScene");
        GameManager[] gameManagers = FindObjectsByType<GameManager>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (GameManager gameManager in gameManagers)
        {
            if (gameManager.gameObject.scene == menuScene)
            {
                _gameManager = gameManager;
                return;
            }
        }
    }

    //Update score and spawn two more enemies
    public void OnDeath()
    {
        _gameManager.UpScore();
        CalculateSpawn(2);
    }

    //Picks a random spawn out of 6
    private void CalculateSpawn(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            int randomNum = Random.Range(0, 6);
            switch (randomNum)
            {
                case 0:
                    SpawnEnemy(_spawnPoint1);
                    break;
                case 1:
                    SpawnEnemy(_spawnPoint2);
                    break;
                case 2:
                    SpawnEnemy(_spawnPoint3);
                    break;
                case 3:
                    SpawnEnemy(_spawnPoint4);
                    break;
                case 4:
                    SpawnEnemy(_spawnPoint5);
                    break;
                case 5:
                    SpawnEnemy(_spawnPoint6);
                    break;
            }
        }
    }
    //Spawns enemy on spawn
    private void SpawnEnemy(GameObject spawnPoint)
    {
        Instantiate(_enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
