using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        float randomDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.linearVelocity = new Vector2(randomDirection * 2f, -1f).normalized * ballSpeed;
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.zero;
        Invoke("LaunchBall", 1f);
    }
}