using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool scored = false;
    private GameManager gameManager;
    private Transform player;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager == null)
            Debug.LogError("GameManager not found!");

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
            Debug.LogError("Player not found! Make sure it has tag 'Player'");
    }

    void Update()
    {
        // Check if obstacle has passed below the player
        if (!scored && player != null && transform.position.y < player.position.y)
        {
            scored = true;
            gameManager.AddScore(1);
        }
    }
}