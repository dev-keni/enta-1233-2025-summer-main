using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
namespace MyCharacterInput {
    public class PlayerHUD : MonoBehaviour
    {

        [SerializeField] private MeInputs Inputs;

        [SerializeField] private TMP_Text HealthText;
        [SerializeField] private TMP_Text ScoreText;
        [SerializeField] private TMP_Text AmmoText;

        [SerializeField] private Image Crosshair;

        public PlayerHealth PlayerHealth;

        void Awake()
        {
            HealthText.text = $"+{PlayerHealth.Health}";
        }

        private void Update()
        {
            if (Inputs.Aim == true)
            {
                Crosshair.gameObject.SetActive(true);
            }
            else
            {
                Crosshair.gameObject.SetActive(false);
            }
        }

        public void AddScore() { }

        public void OnHealthUpdated()
        {
            HealthText.text = $"+{PlayerHealth.Health}";
        }

        public void OnScoreUpdated(int score)
        {
            ScoreText.text = $"{score} baddies killed";
        }
    }
}


