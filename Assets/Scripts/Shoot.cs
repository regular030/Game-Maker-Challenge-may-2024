using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    private PlayerMovement pm;
    public Bullet B;
    SaveData SD = new SaveData();
    SaveData SDL;

    public Transform ShootingPoint;
    public GameObject BulletPrefabShotgun;
    public GameObject BulletPrefabPistolAR;
    private GameObject bullet;
    private Quaternion Rotation;

    public float BulletShotgunSpeed; 
    public float BulletPistolSpeed; 
    public float BulletArSpeed; 

    public float shotgunDelay = 0.2f;
    public float pistolDelay = 0.1f;
    public float arDelay = 0.15f;

    private float lastShotTime;
    private float currentDelay;
    private bool shooting;

    private int shotgunBulletsPerRound = 6;
    private int shotgunBulletsShot = 3;
    public float shotgunSpreadAngle;

    public int ShotgunDMG;
    public int PistolDMG;
    public int ArDMG;
    
    void Start()
    {
        // Get a reference to the PlayerMovement script attached to the same GameObject
        pm = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        SD = SaveManager.LoadData();
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
            shooting = true;
            Fire(); // Call Fire method immediately when the shoot button is pressed
        }
        else if (Input.GetButtonUp("Shoot"))
        {
            shooting = false;
        }
    }

    void Fire()
    {
        if (Time.time - lastShotTime >= currentDelay)
        {
            lastShotTime = Time.time;

            if (SD.shootgun == true)
            {
                currentDelay = shotgunDelay;
                Shotgun();
            }
            else if (SD.pistol == true)
            {
                currentDelay = pistolDelay;
                Pistol();
            }
            else if (SD.AR == true)
            {
                currentDelay = arDelay;
                AR();
            }
            else
            {
                Debug.Log("Default gun not set to shotgun!");
                currentDelay = shotgunDelay;
                Shotgun();
            }
        }

        // Call Fire function recursively while shooting is true
        if (shooting)
        {
            Invoke("Fire", 0);
        }
    }

    public void Shotgun()
    {
        // Fixed angle increment between bullets
        float angleIncrement = 5f; // Adjust this value to change the spread

        // Calculate the initial angle based on the player's direction
        float initialAngle = -90f; // Default angle for right direction
        if (pm.currentDirection == -1f)
        {
            initialAngle =55f; // Adjust for left direction
        }

        // Loop to spawn each bullet
        for (int i = 0; i < shotgunBulletsPerRound; i++)
        {
            B.dmg = ShotgunDMG;
            // Calculate the rotation angle for the current bullet with some variation
            float variation = Random.Range(-5f, 5f); // Adjust the variation to control spread randomness
            float currentAngle = initialAngle + i * angleIncrement + variation;

            // Create a rotation quaternion based on the calculated angle
            Quaternion bulletRotation = Quaternion.Euler(0f, 0f, currentAngle);

            // Instantiate the bullet with the calculated rotation
            GameObject bullet = Instantiate(BulletPrefabShotgun, ShootingPoint.position, bulletRotation);

            // Set bullet speed
            B.Speed = BulletShotgunSpeed;

            // Start a coroutine to destroy the bullet after a delay
            StartCoroutine(DestroyBulletAfterDelay(bullet, 0.3f));

            // Increment bullets shot count
            shotgunBulletsShot++;
        }

        // Reset bullet count for the next round
        shotgunBulletsShot = 0;

        // Wait for the next round delay
        currentDelay = shotgunDelay;
    }


    public void Pistol()
    {
        B.Speed = BulletPistolSpeed;
        B.dmg = PistolDMG;
        GameObject bullet = Instantiate(BulletPrefabPistolAR, ShootingPoint.position, Rotation);
        StartCoroutine(DestroyBulletAfterDelay(bullet, 3f));
    }

    public void AR()
    {
        B.Speed = BulletArSpeed;
        B.dmg = ArDMG;
        GameObject bullet = Instantiate(BulletPrefabPistolAR, ShootingPoint.position, Rotation);
        StartCoroutine(DestroyBulletAfterDelay(bullet, 1f));
    }

    IEnumerator DestroyBulletAfterDelay(GameObject bulletObject, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Check if the bulletObject is still present
        if (bulletObject != null)
        {
            // Destroy the bulletObject
            DestroyImmediate(bulletObject, true);
        }
    }
}
