using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float SpeedMultiplier = 10;
    public LayerMask groundLayer;
    private bool isGrounded;
    public float currentDirection = 1f;



    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float InputX = Input.GetAxis("Horizontal") * SpeedMultiplier;

        if (InputX > 0 && currentDirection < 0)
        {
        transform.Rotate(0f, 180f, 0f);
        currentDirection = 1f;
        }

        else if (InputX < 0 && currentDirection > 0)
        {
        transform.Rotate(0f, 180f, 0f);
        currentDirection = -1f;
        }

        body.velocity = new Vector2(InputX, body.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
                body.velocity = new Vector2(body.velocity.x, SpeedMultiplier);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((groundLayer.value & 1 << other.gameObject.layer) != 0)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((groundLayer.value & 1 << other.gameObject.layer) != 0)
        {
            isGrounded = false;
        }
    }

}
