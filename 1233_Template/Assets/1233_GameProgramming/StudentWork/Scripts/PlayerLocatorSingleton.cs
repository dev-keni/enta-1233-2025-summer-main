using UnityEngine;


//Monobehaviour that only exists while game is in play mode
public class PlayerLocatorSingleton : MonoBehaviour
{
    //Static field that exists for the entire project's duration
    // important can be null if game is not playing
    public static PlayerLocatorSingleton Instance;

    public void Awake()
    {
        // Instance will be null only if no PlayerLocator game object exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is more than one PlayerLocatorSingleton");
            Destroy(gameObject);
        }
    }
}
