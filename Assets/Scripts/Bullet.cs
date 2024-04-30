using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Speed; 
    }

}
