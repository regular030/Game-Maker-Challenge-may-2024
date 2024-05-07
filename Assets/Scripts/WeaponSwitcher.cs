using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    SaveData SD = new SaveData();
    SaveData SDL;

    //basic GUI things
    public GameObject Canvas;
    public GameObject Player;
    public MonoBehaviour PlayerMovement;
    public MonoBehaviour Shoot;
    Rigidbody2D rb2d; 

    //activate button 
    public GameObject ShootgunButton;
    public GameObject NoShootgunButton;
    public GameObject PistolButton;
    public GameObject NoPistolButton;
    public GameObject ArButton;
    public GameObject NoArButton;


    void Start()
    {
        Rigidbody2D rb2d = Player.GetComponent<Rigidbody2D>();
        NoShootgunButton.SetActive(false);
        NoPistolButton.SetActive(false);
        NoArButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Canvas.SetActive(false);
            PlayerMovement.enabled = true;
            //rb2d.bodyType = RigidbodyType2D.Dynamic;
        }

        SD = SaveManager.LoadData(); // Load data into SD
        buttons();
        // No need to save SD here
        Debug.Log("shotgun" + SD.shootgun);
        Debug.Log("pistol" + SD.pistol);
        Debug.Log("AR" + SD.AR);
    }


    public void buttons(){
        if(SD.HasShootgun == true)
        {
            ShootgunButton.SetActive(true);
            NoShootgunButton.SetActive(false);
        }
        if(SD.HasShootgun == false){
            ShootgunButton.SetActive(false);
            NoShootgunButton.SetActive(true);
        }

        if(SD.HasPistol == true)
        {
            PistolButton.SetActive(true);
            NoPistolButton.SetActive(false);
        }
        if(SD.HasPistol == false){
            PistolButton.SetActive(false);
            NoPistolButton.SetActive(true);
        }

        if(SD.HasAR == true)
        {
            ArButton.SetActive(true);
            NoArButton.SetActive(false);
        }
        if(SD.HasAR == false){
            ArButton.SetActive(false);
            NoArButton.SetActive(true);
        }
    }

    public void Exit()
    {
        Canvas.SetActive(false);
        PlayerMovement.enabled = true;
        Shoot.enabled = true;
        //rb2d.bodyType = RigidbodyType2D.Dynamic;

    }

    public void SelectShootgun()
    {
        if(SD.HasShootgun == true)
        {
            Debug.Log("pressed Shotgun");

            SD.shootgun = true;
            SD.pistol = false;
            SD.AR = false;
            SaveManager.SaveData(SD);
        }
    }

    public void SelectPistol()
    {
        if(SD.HasPistol == true)
        {
            Debug.Log("pressed Pistol");
            SD.shootgun = false;
            SD.pistol = true;
            SD.AR = false;
            SaveManager.SaveData(SD);
        }
    }

    public void SelectAR()
    {
        if(SD.HasAR == true)
        {
            Debug.Log("pressed AR");
            SD.shootgun = false;
            SD.pistol = false;
            SD.AR = true;
            SaveManager.SaveData(SD);
        }
    }
}