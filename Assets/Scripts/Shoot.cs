using UnityEngine;

public class Shoot : MonoBehaviour
{
    private PlayerMovement pm;

    public Transform ShootingPoint;
    public GameObject BulletPrefab;
    private Quaternion Rotation;

    void Start()
    {
        // Get a reference to the PlayerMovement script attached to the same GameObject
        pm = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Check the current direction of the player
        if (pm != null)
        {
            if (pm.currentDirection == 1f)
            {
                Rotation = Quaternion.Euler(0f, 0f, -90f); // No rotation for right direction
            }
            else if (pm.currentDirection == -1f)
            {
                Rotation = Quaternion.Euler(0f, 0f, 90f); // Rotated by -90 degrees for left direction
            }
        }

        // Check for shoot input
        if (Input.GetButtonDown("Shoot"))
        {
            Instantiate(BulletPrefab, ShootingPoint.position, Rotation);
        }
    }
}
