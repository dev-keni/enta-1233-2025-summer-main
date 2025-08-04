using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public float GameVolume = 1.0f;
    //Screens
    [SerializeField] private Canvas _main;
    [FormerlySerializedAs("Controls")] [SerializeField] private Canvas _controls;
    [FormerlySerializedAs("SettingsScreen")] [SerializeField] private Canvas _settingsScreen;
    [FormerlySerializedAs("GameOver")] [SerializeField] private Canvas _gameOver;

    //Play Buttons
    [FormerlySerializedAs("Play")] [SerializeField] private Button _play;
    [FormerlySerializedAs("Replay")] [SerializeField] private Button _replay;

    //Main Screen Buttons
    [FormerlySerializedAs("MenuPlay")][SerializeField] private Button _menuPlay;
    [FormerlySerializedAs("Settings")] [SerializeField] private Button _settings;

    //Settings Buttons
    [SerializeField] private Button _settingsBack;
    [SerializeField] private Button _menuBack;
    [SerializeField] private Slider _slider;

    //Quit Buttons
    [FormerlySerializedAs("Quit")] [SerializeField] private Button _quit;
    [SerializeField] private Button _gameOverQuit;

    //Scripts
    [FormerlySerializedAs("gameManager")] [SerializeField] private GameManager _gameManager;
    [FormerlySerializedAs("mainMenu")] [SerializeField] private GameObject _mainMenu;
    [FormerlySerializedAs("eventSystem")] [SerializeField] private GameObject _eventSystem;
    [FormerlySerializedAs("menuCamera")] [SerializeField] private GameObject _menuCamera;

    //Make buttons listen for click
    void Awake()
    {
        //Main Menu
        _menuPlay.onClick.AddListener(OpenControls);
        _quit.onClick.AddListener(QuitGame);

        //Controls/How To Play
        _play.onClick.AddListener(ClickPlay);

        //Settings
        _settings.onClick.AddListener(OpenSettings);

        //Game Over
        _replay.onClick.AddListener(ClickPlay);
        _gameOverQuit.onClick.AddListener(QuitGame);

        //All Back Buttons
        _settingsBack.onClick.AddListener(OpenMainMenu);
        _menuBack.onClick.AddListener(OpenMainMenu);

        //Make sure things are active if accidentally disabled
        _mainMenu.SetActive(true);
        _eventSystem.SetActive(true);
        _menuCamera.SetActive(true);
    }

    //Open Controls screen
    void OpenControls()
    {
        _main.gameObject.SetActive(false);
        _controls.gameObject.SetActive(true);
    }

    void OpenSettings()
    {
        _main.gameObject.SetActive(false);
        _settingsScreen.gameObject.SetActive(true);
    }

    //Opens main menu and closes all other possible tabs
    void OpenMainMenu()
    {
        _main.gameObject.SetActive(true);
        _controls.gameObject.SetActive(false);
        _settingsScreen.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(false);
    }

    //Start level and disable menu elements
    void ClickPlay()
    {
        _gameManager.InitializeGame();
        _mainMenu.SetActive(false);
        _eventSystem.SetActive(false);
        _menuCamera.SetActive(false);
    }

    public void ChangeVolume()
    {
        GameVolume = _slider.value;
    }

    //Close game
    void QuitGame()
    {
        Application.Quit();
    }

    //Relock mouse and set the appropriate screen elements active
    public void Reawaken()
    {
        _mainMenu.SetActive(true);
        _controls.gameObject.SetActive(false);
        _gameOver.gameObject.SetActive(true);
        _eventSystem.SetActive(true);
        _menuCamera.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
