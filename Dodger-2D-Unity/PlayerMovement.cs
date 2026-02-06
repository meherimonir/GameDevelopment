using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager == null)
            Debug.LogError("GameManager not found in scene!");
    }

    void Update()
    {
        if (gameManager.IsGameOver() && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (!gameManager.IsGameOver())
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over! Press R to restart");
            gameManager.GameOver();
            Time.timeScale = 0f; // pause game
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}