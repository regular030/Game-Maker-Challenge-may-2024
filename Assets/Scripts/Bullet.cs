using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public int damage;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Speed; 
    }

    void OnTriggerEnter2D (Collider2D hitInfo){
        Debug.Log(hitInfo.name);
        Debug.Log(damage);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        PlayerHealth PlayerHealth = hitInfo.GetComponent<PlayerHealth>();
        if(PlayerHealth != null){
            PlayerHealth. TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
