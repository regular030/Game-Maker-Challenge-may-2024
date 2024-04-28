using UnityEngine;

public class CursorController : MonoBehaviour
{
    void Update()
    {
        // Check if the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Toggle cursor visibility
            Cursor.visible = !Cursor.visible;
        }
    }
}
