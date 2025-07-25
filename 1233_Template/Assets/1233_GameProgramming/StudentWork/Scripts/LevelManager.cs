using UnityEngine;
using System.Collections;
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
        StartCoroutine(DelaySetActive(levelName));
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
