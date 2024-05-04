using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float SpeedMultiplier = 10;
    public LayerMask groundLayer;
    private bool isGrounded;
    public float currentDirection = 1f;
    private Animator anim;
    SaveData SD = new SaveData();
    SaveData SDL;

    // Parameters for air resistance
    public float airResistance = 0.1f; // Adjust this value to add air resistance
    public float maxFallSpeed = -10f; // Adjust this value to limit the maximum fall speed

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Save the updated SaveData object
        SaveManager.SaveData(SD);

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

        // Apply air resistance
        if (!isGrounded)
        {
            body.velocity -= new Vector2(body.velocity.x * airResistance, 0f);

            // Limit maximum fall speed
            if (body.velocity.y < maxFallSpeed)
            {
                body.velocity = new Vector2(body.velocity.x, maxFallSpeed);
            }
        }

        anim.SetBool("Running", InputX != 0);
        anim.SetBool("Jumping", !isGrounded == true);
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

    public void animm()
    {
    }
}
