using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
namespace MyCharacterInput {
    public class PlayerHUD : MonoBehaviour
    {

        [SerializeField] private MeInputs _inputs;

        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _timerText;

        [SerializeField] private UnityEngine.UI.Image _crosshair;

        [SerializeField] private GameManager _gameManager;

        [SerializeField] private Canvas _pauseMenu;
        [SerializeField] private Button _quit;

        public PlayerHealth PlayerHealth;

        private bool _paused = false;

        //Display health
        void Awake()
        {
            _healthText.text = $"+{PlayerHealth.Health}";
            _quit.onClick.AddListener(QuitGame);
        }

        //Checks if player is aiming, then shows crosshair
        private void Update()
        {
            if (_inputs.Aim == true)
            {
                _crosshair.gameObject.SetActive(true);
            }
            else
            {
                _crosshair.gameObject.SetActive(false);
            }
            if (_inputs.Pause == true)
            {
               _pauseMenu.gameObject.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _paused = !_paused;
                Time.timeScale = _paused ? 0 : 1;
                _pauseMenu.gameObject.SetActive(_paused);
                if (_paused == false)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
                if (_paused == true)
                {
                    Cursor.lockState = CursorLockMode.None;
                }

            }
        }

        //Timer function, converts time into minutes, seconds and milliseconds
        public void Timer(float currentTimer)
        {
            float minutes = Mathf.FloorToInt(currentTimer / 60);
            float seconds = Mathf.FloorToInt(currentTimer % 60);
            float milliSeconds = (currentTimer % 1) * 1000;
            _timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
        }

        //Update player health text
        public void OnHealthUpdated()
        {
            _healthText.text = $"+{PlayerHealth.Health}";
        }

        //Update player Kills text
        public void OnScoreUpdated(int score)
        {
            _scoreText.text = $"{score} Pills killed";
        }
        
        //Close game
        void QuitGame()
        {
            UnityEngine.Application.Quit();
        }
    }
}


