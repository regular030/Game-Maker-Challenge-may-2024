using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
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
