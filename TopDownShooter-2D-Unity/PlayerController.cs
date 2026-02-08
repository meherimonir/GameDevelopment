using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootCooldown = 0.5f;

    public int maxHealth = 5;

    private int currentHealth;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private PlayerControls controls;
    private float lastShootTime;

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();
        currentHealth = maxHealth;
    }

    void OnEnable()
    {
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;
        controls.Player.Shoot.performed += OnShoot;
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Player.Move.performed -= OnMove;
        controls.Player.Move.canceled -= OnMove;
        controls.Player.Shoot.performed -= OnShoot;
        controls.Disable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void OnShoot(InputAction.CallbackContext context)
    {
        if (Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;

        Vector3 spawnPosition = firePoint != null ? firePoint.position : transform.position;
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (GameManager.instance != null)
        {
            GameManager.instance.UpdateUI();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.instance.GameOver();
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            TakeDamage(enemy.damageToPlayer);
            Destroy(collision.gameObject);
        }
    }

}