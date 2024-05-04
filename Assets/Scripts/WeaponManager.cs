using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    SaveData SD = new SaveData();
    SaveData SDL;
    private Animator anim;

    private void Awake()
    {
        // Get the Animator component attached to this GameObject
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animator component not found!");
        }

        // Load saved data into SDL
        SD = SaveManager.LoadData(); // Load data into SD
    }

    void Update()
    {
            SD = SaveManager.LoadData(); // Load data into SD
            if (SD.shootgun == true)
            {                
                Debug.Log("anim shot");
                anim.SetBool("Shotgun", true);
                anim.SetBool("Pistol", false);
                anim.SetBool("AR", false);
            }
            if (SD.pistol == true)
            {
                Debug.Log("anim pistol");
                anim.SetBool("Shotgun", false);
                anim.SetBool("Pistol", true);
                anim.SetBool("AR", false);
            }
            if (SD.AR == true)
            {
                Debug.Log("anim AR");
                anim.SetBool("Shotgun", false);
                anim.SetBool("Pistol", false);
                anim.SetBool("AR", true);
            }
    }   
}
