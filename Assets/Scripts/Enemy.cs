using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Bullet B;
    public Transform player;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public int spawnDis; // Spawn distance
    public float bulletSpeed = 20f;
    public float shootInterval = 0.5f; // Time between each shot
    public float shootDistance;
    public float moveSpeed;
    private float lastShootTime;
    private bool canShoot = true;
    private bool left;
    private bool good2go = false;
    public int dmg = 10;

    public int maxHealth = 100;
    public int currentHealth;

    private Vector3 initialScale; // Store the initial scale of the enemy

    void Start()
    {
        currentHealth = maxHealth;
        B.damage = dmg;

        // Store the initial scale of the enemy
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If the enemy is not active and the player is within the spawn distance, activate the enemy
        if (distanceToPlayer <= spawnDis)
        {
            good2go = true;
        }

        // Check if the enemy can shoot and is within shooting range
        if (canShoot && distanceToPlayer <= shootDistance && Time.time - lastShootTime >= shootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }

        // Flip the enemy to face the player
        if (player.position.x < transform.position.x)
        {
            // Player is to the left, flip the enemy
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
            left = true;
        }
        else
        {
            // Player is to the right, flip the enemy back
            transform.localScale = initialScale;
            left = false;
        }

        if (good2go)
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        if (player.position.x < transform.position.x)
        {
            // Player is to the left, rotate the bullet by 90 degrees
            if (left)
            {
                bullet.transform.Rotate(Vector3.forward, 90f);
            }
            else
            {
                bullet.transform.Rotate(Vector3.forward, 90f);
            }
            // Calculate direction towards player
            Vector2 direction = (player.position - shootPoint.position).normalized;
            // Set bullet velocity
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed;
        }
        else
        {
            // Player is to the right, rotate the bullet by 180 degrees
            bullet.transform.Rotate(Vector3.forward, 270f);
            // Calculate direction towards player
            Vector2 direction = (player.position - shootPoint.position).normalized;
            // Set bullet velocity
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Current Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
