using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Loadlevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadLevelAdditively(string levelName)
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
    }

    public void UnloadLevel(string levelName)
    {
        Scene currentScene = SceneManager.GetSceneByName(levelName);
        EventSystem[] EventSystems = FindObjectsByType<EventSystem>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (EventSystem eventSys in EventSystems)
        {
            if (eventSys.gameObject.scene == currentScene)
            {
               eventSys.gameObject.SetActive(false);
               SceneManager.UnloadSceneAsync(levelName);
               return;
            }
        }
        SceneManager.UnloadSceneAsync(levelName);
    }
}
