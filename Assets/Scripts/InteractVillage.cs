using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

interface IIIInteractable
{
    public void Interact();
}


public class InteractVillage : MonoBehaviour
{
    public Transform Player;
    public MonoBehaviour PlayerMovement;
    public MonoBehaviour Shoot;
    public GameObject ForgeMessage;
    public Transform Forge;
    public GameObject ForgeCanvas;
    public GameObject WeaponMessage;
    public Transform Weapon;
    public GameObject WeaponCanvas;
    public float InteractRange;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        ForgeMessage.SetActive(false);
        WeaponMessage.SetActive(false);
        ForgeCanvas.SetActive(false );
        WeaponCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceForge = Vector3.Distance(Player.position, Forge.position);
        float distanceWeapon = Vector3.Distance(Player.position, Weapon.position);

        if (distanceForge < InteractRange) 
        {
            ForgeMessage.SetActive(true);
        }
        else
        {
            ForgeMessage.SetActive(false);
        }

        if (distanceWeapon < InteractRange) 
        {
            WeaponMessage.SetActive(true);
        }
        else
        {
            WeaponMessage.SetActive(false);
        }



        if (Input.GetKeyDown(KeyCode.E))
        {
            if (distanceForge < InteractRange)
            {
                ForgeCanvas.SetActive(true);
                PlayerMovement.enabled = false;
                Shoot.enabled = false;
                //rb.bodyType = RigidbodyType2D.Static;
            }
            else if(distanceWeapon < InteractRange)
            {
                WeaponCanvas.SetActive(true);
                PlayerMovement.enabled = false;
                Shoot.enabled = false;
                //rb.bodyType = RigidbodyType2D.Static;
            }
        }
    }
}
