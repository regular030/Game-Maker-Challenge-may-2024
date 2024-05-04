using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public int dmg;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Speed; 
    }

    void OnTriggerEnter2D (Collider2D hitInfo){
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
