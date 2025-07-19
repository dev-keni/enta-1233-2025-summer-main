using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public Canvas Main;
    [SerializeField] public Canvas SettingsScreen;
    [SerializeField] public Canvas GameOver;
    [SerializeField] public Button Play;
    [SerializeField] public Button Replay;
    [SerializeField] private Button Settings;
    [SerializeField] private Button Quit;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject eventSystem;
    [SerializeField] private GameObject menuCamera;

    void Awake()
    {
        Play.onClick.AddListener(ClickPlay);
        Replay.onClick.AddListener(ClickPlay);
        mainMenu.SetActive(true);
        eventSystem.SetActive(true);
        menuCamera.SetActive(true);
    }

    void ClickPlay()
    {
        gameManager.InitializeGame();
        mainMenu.SetActive(false);
        eventSystem.SetActive(false);
        menuCamera.SetActive(false);
    }

    public void Reawaken()
    {
        mainMenu.SetActive(true);
        Controls.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(true);
        eventSystem.SetActive(true);
        menuCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
