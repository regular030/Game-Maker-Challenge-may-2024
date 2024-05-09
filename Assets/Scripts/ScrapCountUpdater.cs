using UnityEngine;
using TMPro;

public class ScrapCountUpdater : MonoBehaviour
{
    public ScrapManager SM;
    public TMP_Text scrapCountText; // Reference to the TextMeshPro component

    // Update is called once per frame
    void Update()
    {
        // Check if ScrapManager instance is assigned and the TMP text component exists
        if (SM != null && scrapCountText != null)
        {
            // Update the TMP text with the ScrapCountLevel value
            scrapCountText.text = SM.ScrapCountLevel.ToString();
        }
        else
        {
            Debug.LogWarning("ScrapManager or TMP text component is not assigned.");
        }
    }
}
