using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heavy1 : MonoBehaviour
{
    GameObject Player1;
    GameObject Player2;
    Player1Punching Player1Var;
    GameObject tmpHealth;
    Slider HealthBar;
    Player2Punching scr;
    Animator anim;
   

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.FindWithTag("Player 1");
        Player1Var = Player1.GetComponent<Player1Punching>();

        tmpHealth = GameObject.Find("HealthBar2");
        HealthBar = tmpHealth.GetComponent<Slider>();
        //HealthBar.value = Player1Var.p2Health;

        Player2 = GameObject.FindWithTag("Player 2");
        scr = Player2.GetComponent<Player2Punching>();

        anim = Player2.GetComponent<Animator>();
        anim.SetBool("IsHit", false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player 2")
        {
            Player1Var.p2Health = scr.TakeDamageHeavy(Player1Var.p2Health);
            Debug.Log("Fist Hit");
            HealthBar.value = Player1Var.p2Health;
            Debug.Log("health bar");
            anim.SetBool("IsHit", true);
        }
    }
}
