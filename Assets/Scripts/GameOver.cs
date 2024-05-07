using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public string levelToLoad;

    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Load the specified level
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
