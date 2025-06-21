using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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

    }

    public void OnScoreUpdated(int score)
    {
        ScoreText.text = $"{score} baddies killed";
    }
}
