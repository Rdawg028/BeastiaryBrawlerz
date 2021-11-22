using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Range3 : MonoBehaviour
{
    GameObject Player3;
    GameObject Player2;
    Player3Punching Player3Var;
    GameObject tmpHealth;
    Slider HealthBar;
    Player2Punching scr;
    Animator anim;
    


    // Start is called before the first frame update
    void Start()
    {
        Player3 = GameObject.FindWithTag("Player 1");
        Player3Var = Player3.GetComponent<Player3Punching>();

        tmpHealth = GameObject.Find("HealthBar");
        HealthBar = tmpHealth.GetComponent<Slider>();
        HealthBar.value = Player3Var.p3Health;

        Player2 = GameObject.FindWithTag("Player 2");
        scr = Player2.GetComponent<Player2Punching>();


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player 2")
        {
            Player3Var.p2Health = scr.TakeRangeDamage(Player3Var.p2Health);
            Debug.Log("Fist Hit");
            HealthBar.value = Player3Var.p2Health;
            Debug.Log("health bar");
            anim.SetBool("IsHit", true);
            
        }
    }
}

