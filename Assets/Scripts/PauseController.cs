using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;


    void Start()
    {
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        // Check if the "Escape" key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the visibility of the pause menu
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        // Check if the pause menu is active or not
        bool isPaused = pauseMenu.activeSelf;

        // Toggle the pause menu
        pauseMenu.SetActive(!isPaused);

        // Pause or resume the game Time.timeScale based on pause menu state
        Time.timeScale = isPaused ? 1f : 0f;
    }
}
