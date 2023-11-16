using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscoreText;

    private string playerPrefsKey = "PlayerScore"; // Key for storing the player's score in PlayerPrefs

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Do not destroy this object when loading a new scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ResetScore();
        UpdateHighScoreText();
    }

    public void IncreasePoints()
    {
        score += 1;

        // Check if the current score is higher than the saved high score
        int highScore = GetHighScore();
        if (score > highScore)
        {
            SetHighScore(score); // Update the high score
        }

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = ("Score: " + score.ToString());
        }
    }

    private void UpdateHighScoreText()
    {
        if (highscoreText != null)
        {
            int highScore = GetHighScore();
            highscoreText.text = ("Highscore: " + highScore.ToString());
        }
    }

    private int GetHighScore()
    {
        // Retrieve the high score from PlayerPrefs
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    private void SetHighScore(int newHighScore)
    {
        // Save the new high score to PlayerPrefs
        PlayerPrefs.SetInt("HighScore", newHighScore);
        PlayerPrefs.Save();
    }

    // Reset the score to 0
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
        SaveScore(); // Save the reset score to PlayerPrefs
    }

    private void SaveScore()
    {
        // Save the player's score to PlayerPrefs
        PlayerPrefs.SetInt(playerPrefsKey, score);
        PlayerPrefs.Save();
    }

}
