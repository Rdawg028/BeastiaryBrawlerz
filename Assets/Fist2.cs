using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fist2 : MonoBehaviour
{

    GameObject Player2;
    GameObject Player1;
    Player2Punching Player2Var;
    GameObject tmpHealth;
    Slider HealthBar;
    Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
       Player2 = GameObject.FindWithTag("Player 2");
       Player2Var = Player2.GetComponent<Player2Punching>();

       tmpHealth = GameObject.Find("HealthBar");
       HealthBar = tmpHealth.GetComponent<Slider>();
       

       Player1 = GameObject.FindWithTag("Player 1");
       anim = Player1.GetComponent<Animator>();

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player 1")
        {
            Player2Var.p1Health = Player2Var.TakeDamageLight(Player2Var.p1Health);
            Debug.Log("Fist Hit");
            HealthBar.value = Player2Var.p1Health;
            Debug.Log("health bar");

            anim.SetBool("IsHit", true);
        }
       
        
    }
}
