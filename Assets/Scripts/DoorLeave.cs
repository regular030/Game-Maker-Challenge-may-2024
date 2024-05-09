using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLeave : MonoBehaviour
{
    public string sceneName; // Name of the scene to load

    SaveData SD = new SaveData();
    public ScrapManager SM;

    void Update()
    {
        // Check if any button is pressed
        if (Input.anyKeyDown)
        {
            SD = SaveManager.LoadData();
            Debug.Log(SD.scrapMetal);
            SD.scrapMetal += SM.ScrapCountLevel;
            Debug.Log(SD.scrapMetal);
            SaveManager.SaveData(SD);
            // Load the specified scene
            LoadScene();
        }
    }

    // Function to load the specified scene
    public void LoadScene()
    {
        // Check if the scene name is not empty
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is not specified.");
        }
    }
}
