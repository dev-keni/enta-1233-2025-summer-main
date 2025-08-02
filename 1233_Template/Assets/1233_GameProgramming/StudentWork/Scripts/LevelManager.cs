using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameManager _gameManager;
    //Game Manager
    void Awake()
    {
        GameObject foundObject = GameObject.Find("GameManager");
        _gameManager = foundObject.GetComponent<GameManager>();
    }
    //Load Level
    public void Loadlevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    //Load level, then set active after a delay so there aren't any errors
    public void LoadLevelAdditively(string levelName)
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
        StartCoroutine(DelaySetActive(levelName));
    }

    //Unload level, set menu scene as active, reset event system
    public void UnloadLevel(string levelName)
    {
        _gameManager.GameOver();
        Scene currentScene = SceneManager.GetSceneByName(levelName);
        EventSystem[] eventSystems = FindObjectsByType<EventSystem>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (EventSystem eventSys in eventSystems)
        {
            if (eventSys.gameObject.scene == currentScene)
            {
               eventSys.gameObject.SetActive(false);
               SceneManager.UnloadSceneAsync(levelName);
               SceneManager.SetActiveScene(SceneManager.GetSceneByName("BootScene"));
               return;
            }
        }
        SceneManager.UnloadSceneAsync(levelName);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("BootScene"));
    }

    //Delayed SetActiveScene, might need to change 
    IEnumerator DelaySetActive(string levelName)
    {
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelName));
    }
}
