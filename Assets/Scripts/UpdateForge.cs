using UnityEngine;
using TMPro;

public class UpdateForge : MonoBehaviour
{
    public TMP_Text scrapText; // Reference to the UI Text component for coins
    public TMP_Text goldText; // Reference to the UI Text component for gold
    public TMP_Text silverText; // Reference to the UI Text component for silver
    public TMP_Text copperText; // Reference to the UI Text component for copper
    public TMP_Text ironText; // Reference to the UI Text component for iron

    SaveData SD = new SaveData();

    void Start()
    {
        // Load the SaveData object
        SD = SaveManager.LoadData(); // Load data into SD
        SD.scrapMetal = 10;
        SD.gold = 10; //works + saves
        SD.silver = 10;
        SD.copper = 10;
        SD.iron = 10;
        SaveManager.SaveData(SD);
        
    }

    void Update()
    {
        SD = SaveManager.LoadData(); // Load data into SD
        // Update the UI Text components with the corresponding resource values
        scrapText.text = "Scrap: " + SD.scrapMetal.ToString();
        goldText.text = "Gold: " + SD.gold.ToString();
        silverText.text = "Silver: " + SD.silver.ToString();
        copperText.text = "Copper: " + SD.copper.ToString();
        ironText.text = "Iron: " + SD.iron.ToString();
        SaveManager.SaveData(SD);
    }
}
