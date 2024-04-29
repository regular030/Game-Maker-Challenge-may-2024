using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}


public class InteractForge : MonoBehaviour
{
    public Transform Player;
    public MonoBehaviour PlayerMovement;
    public Transform InteractorSource;
    public GameObject Message;
    public GameObject Forge;
    public float InteractRange;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Message.SetActive(false);
        Forge.SetActive(false );
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.position, InteractorSource.position);
        if (distance < InteractRange) 
        {
            Message.SetActive(true);
        }
        else
        {
            Message.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (distance < InteractRange)
            {
                Forge.SetActive(true);
                PlayerMovement.enabled = false;
                rb.bodyType = RigidbodyType2D.Static;
            }
        }
    }
}
