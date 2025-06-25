using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
namespace MyCharacterInput {
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text HealthText;
        [SerializeField] private TMP_Text ScoreText;
        [SerializeField] private TMP_Text AmmoText;

        void Update()
        {

        }

        public void AddScore() { }

        public void OnHealthUpdated()
        {
            //HealthText = gameObject.GetComponent<PlayerHealth>();
        }

        public void OnScoreUpdated(int score)
        {
            ScoreText.text = $"{score} baddies killed";
        }
    }
}


