using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Forge : MonoBehaviour
{
    public GameObject Forgee;
    public GameObject Player;
    public MonoBehaviour PlayerMovement;
    public MonoBehaviour Shoot;
    public TextMeshProUGUI forgeButtonText;
    Rigidbody2D rb2d; 

    public Image scrapMetalImage; // Image representing the scrap metal
    public Image copperImage; // Image representing copper
    public Image ironImage; // Image representing iron
    public Image silverImage; // Image representing silver
    public Image goldImage; // Image representing gold

    public void StartForge()
    {
        // Hide all metal images
        copperImage.gameObject.SetActive(false);
        ironImage.gameObject.SetActive(false);
        silverImage.gameObject.SetActive(false);
        goldImage.gameObject.SetActive(false);

        // Show the scrap metal image
        scrapMetalImage.gameObject.SetActive(true);

        // Use 1 scrap metal
        SaveData saveData = SaveManager.LoadData();
        if (saveData != null && saveData.scrapMetal > 0)
        {
            saveData.scrapMetal--;
            SaveManager.SaveData(saveData);

            // Show the corresponding metal image and hide the scrap metal image after a delay
            Invoke("ShowMetal", 2f);
            forgeButtonText.text = "Forging...";
        }
        else
        {
            Debug.Log("Not enough scrap metal to start forging!");
        }
    }

    void ShowMetal()
    {
        // Randomly select a metal
        int rng = Random.Range(1, 101);
        Image metalImage = copperImage; // Default to copper

        SaveData saveData = SaveManager.LoadData();

        if (rng <= 10)
        {
            metalImage = goldImage;
            saveData.gold++;
        }
        else if (rng <= 30)
        {
            metalImage = silverImage;
            saveData.silver++;
        }
        else if (rng <= 60)
        {
            metalImage = ironImage;
            saveData.iron++;
        }
        else
        {
            saveData.copper++;
        }

        // Save the updated data
        SaveManager.SaveData(saveData);

        // Show the corresponding metal image and hide the scrap metal image
        metalImage.gameObject.SetActive(true);
        scrapMetalImage.gameObject.SetActive(false);

        // Reset forge button text
        forgeButtonText.text = "Click To Forge";
    }

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb2d = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Forgee.SetActive(false);
            PlayerMovement.enabled = true;
            //rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void Exit()
    {
        Forgee.SetActive(false);
        PlayerMovement.enabled = true;
        Shoot.enabled = true;
        //rb2d.bodyType = RigidbodyType2D.Dynamic;
    }
}
