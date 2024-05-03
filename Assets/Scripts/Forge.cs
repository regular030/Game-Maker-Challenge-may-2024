using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : MonoBehaviour
{
    public GameObject Forgee;
    public GameObject Player;
    public MonoBehaviour PlayerMovement;
    public MonoBehaviour Shoot;
    Rigidbody2D rb2d; 



    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb2d = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Forgee.SetActive(false);
            PlayerMovement.enabled = true;
            //rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void Exit()
    {
        Forgee.SetActive(false);
        PlayerMovement.enabled = true;
        Shoot.enabled = true;
        //rb2d.bodyType = RigidbodyType2D.Dynamic;

    }

    public void StartForge()
    {

    }
}
