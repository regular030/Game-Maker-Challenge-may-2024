using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public GameObject Villagerr;
    public GameObject Player;
    public MonoBehaviour PlayerMovement;
    public MonoBehaviour Shoot;



    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Villagerr.SetActive(false);
            PlayerMovement.enabled = true;
        }
    }


    public void Exit()
    {
        Villagerr.SetActive(false);
        PlayerMovement.enabled = true;
        Shoot.enabled = true;
    }


}
