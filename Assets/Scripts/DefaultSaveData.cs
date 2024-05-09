using UnityEngine;

public class DefaultSaveData : MonoBehaviour
{
    private void Awake()
    {
        // Check if the SaveData exists in the PlayerPrefs
        if (!PlayerPrefs.HasKey("SaveData"))
        {
            // If SaveData doesn't exist, create a new SaveData object with default values
            SaveData defaultSaveData = new SaveData();

            // Set default values
            defaultSaveData.scrapMetal = 0;
            defaultSaveData.coins = 0;
            defaultSaveData.gold = 0;
            defaultSaveData.silver = 0;
            defaultSaveData.copper = 0;
            defaultSaveData.iron = 0;

            defaultSaveData.key2 = false;
            defaultSaveData.key3 = false;
            defaultSaveData.key4 = false;
            defaultSaveData.key5 = false;

            defaultSaveData.shootgun = true;
            defaultSaveData.pistol = false;
            defaultSaveData.AR = false;
            defaultSaveData.HasShootgun = true;
            defaultSaveData.HasPistol = false; 
            defaultSaveData.HasAR = false;

            // Convert the SaveData object to JSON string
            string json = JsonUtility.ToJson(defaultSaveData);

            // Save the JSON string to PlayerPrefs
            PlayerPrefs.SetString("SaveData", json);
            PlayerPrefs.Save();
        }
    }
}
