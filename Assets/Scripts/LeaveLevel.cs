using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveLevel : MonoBehaviour
{
    public Transform Player;
    public MonoBehaviour PlayerMovement;
    public MonoBehaviour Shoot;

    public GameObject DoorMessage;
    public Transform Door;
    public GameObject DoorCanvas;

    public float InteractRange;

    void Start()
    {
        DoorCanvas.SetActive(false);
    }

    void Update()
    {
        float distanceDoor = Vector3.Distance(Player.position, Door.position);


        if (distanceDoor < InteractRange) 
        {
            DoorMessage.SetActive(true);
        }
        else
        {
            DoorMessage.SetActive(false);
        }

       if (Input.GetKeyDown(KeyCode.E))
        {
            if (distanceDoor < InteractRange)
            {
                DoorCanvas.SetActive(true);
                PlayerMovement.enabled = false;
                Shoot.enabled = false;
            }
        }
    }
}
