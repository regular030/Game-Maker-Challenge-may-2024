using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapCheckerr : MonoBehaviour
{

    public ScrapManager SM;
    private bool canPickUpScrap = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Scrap") && canPickUpScrap)
        {
            canPickUpScrap = false;
            Destroy(other.gameObject);
            StartCoroutine(WaitAndIncreaseScrapCount());
        }
    }

    private IEnumerator WaitAndIncreaseScrapCount()
    {
        yield return new WaitForSeconds(0.1f);

        // Assuming SM is an instance of the script containing ScrapCountLevel
        SM.ScrapCountLevel += 1;

        // Reset the flag after the delay
        canPickUpScrap = true;
    }
}
