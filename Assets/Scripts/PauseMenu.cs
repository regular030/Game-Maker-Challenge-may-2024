using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI GameObject
    public string sceneName; // Name of the scene to load

    void Update()
    {
        // Check if the "Escape" key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the pause menu
            TogglePauseMenu(!pauseMenuUI.activeSelf);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
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

    // Function to toggle the pause menu
    public void TogglePauseMenu(bool isPaused)
    {
        pauseMenuUI.SetActive(isPaused); // Show/hide the pause menu UI
        Time.timeScale = isPaused ? 0f : 1f; // Pause/unpause the game time
    }

    // Function to resume the game
    public void ResumeGame()
    {
        TogglePauseMenu(false); // Hide the pause menu
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
