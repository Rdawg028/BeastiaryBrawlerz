using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3Punching : MonoBehaviour
{

    Animator anim;
    public float p1Health;
    GameObject tmpHealth;
    Slider HealthBar;
    GameObject p1;
    GameObject p2;
    Player2Punching scr;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindWithTag("Player 1").GetComponent<Animator>();
        p1Health = 25.0f;
        Physics2D.IgnoreLayerCollision(0, 8);

        tmpHealth = GameObject.Find("HealthBar");
        HealthBar = tmpHealth.GetComponent<Slider>();
        HealthBar.value = p1Health;

        p1 = GameObject.FindWithTag("Player 1");
        anim.SetBool("IsLose", false);
        anim.SetBool("IsWin", false);

        scr = p2.GetComponent<Player2Punching>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T)) // light attack
        {
            anim.SetBool("IsLight", true);
        }
        else
        {
            anim.SetBool("IsLight", false);
        }

        if (Input.GetKeyDown(KeyCode.Y)) // heavy attack
        {
            anim.SetBool("Heavy", true);

        }
        else
        {
            anim.SetBool("Heavy", false);
        }

        if (Input.GetKey(KeyCode.S)) // blocking
        {
            anim.SetBool("IsBlocking", true);
            anim.SetBool("BlockHolding", true);
        }
        else
        {
            anim.SetBool("IsBlocking", false);
            anim.SetBool("BlockHolding", false);
        }

        if (Input.GetKeyDown(KeyCode.U)) // range attack
        {
            anim.SetBool("Range", true);
        }
        else
        {
            anim.SetBool("Range", false);
        }

        if (p1Health <= 0)
        {
            anim.SetBool("IsLose", true);
        }
        else if (scr.p2Health <= 0)
        {
            anim.SetBool("IsWin", true);
        }

       
        
    }
}
