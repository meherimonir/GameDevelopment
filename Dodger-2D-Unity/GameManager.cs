using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // assign in Inspector
    private int score = 0;
    private bool gameOver = false;

    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("ScoreText is NOT assigned in GameManager!");
        }
        UpdateScoreUI();
    }

    public void AddScore(int points = 1)
    {
        if (!gameOver)
        {
            score += points;
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}