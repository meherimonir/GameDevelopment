using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;

    private bool isGameOver = false;

    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
        UpdateUI();
    }

    void Update()
    {
        if (isGameOver && Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartGame();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreText.text = "Score: " + score;

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            PlayerController player = playerObject.GetComponent<PlayerController>();
            if (player != null)
            {
                healthText.text = "Health: " + player.GetCurrentHealth();
            }
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "GAME OVER\nFinal Score: " + score + "\n\nPress R to Restart";
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}