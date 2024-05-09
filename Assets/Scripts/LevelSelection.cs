using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public SaveData saveData; // Reference to the save data

    public Button levelButton1;
    public Button levelButton2;
    public Button levelButton3;
    public Button levelButton4;
    public Button levelButton5;

    public string levelScene1;
    public string levelScene2;
    public string levelScene3;
    public string levelScene4;
    public string levelScene5;

    void Start()
    {
        saveData = SaveManager.LoadData(); // Load data into saveData
        UpdateButtonStates(); // Update button states when the script starts
    }

    // Function to update the button states based on key availability
    void UpdateButtonStates()
    {
        saveData = SaveManager.LoadData(); // Load data into saveData

        // Level 1 is always unlocked
        levelButton1.GetComponentInChildren<TMP_Text>().text = "Level 1";
        levelButton1.interactable = true;

        // Update button text and interaction status for other levels based on key availability
        levelButton2.GetComponentInChildren<TMP_Text>().text = saveData.key2 ? "Level 2" : "Not Unlocked";
        levelButton2.interactable = saveData.key2;

        levelButton3.GetComponentInChildren<TMP_Text>().text = saveData.key3 ? "Level 3" : "Not Unlocked";
        levelButton3.interactable = saveData.key3;

        levelButton4.GetComponentInChildren<TMP_Text>().text = saveData.key4 ? "Level 4" : "Not Unlocked";
        levelButton4.interactable = saveData.key4;

        levelButton5.GetComponentInChildren<TMP_Text>().text = saveData.key5 ? "Level 5" : "Not Unlocked";
        levelButton5.interactable = saveData.key5;
    }

    // Function to handle button click events for each level button
    public void LoadLevel1()
    {
        SceneManager.LoadScene(levelScene1);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(levelScene2);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(levelScene3);
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene(levelScene4);
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene(levelScene5);
    }
}
