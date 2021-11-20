using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range3 : MonoBehaviour
{
    GameObject Player1;
    Player1Punching Player1Var;
    GameObject Player2;
    Player2Punching scr;

    // Start is called before the first frame update
    void Start()
    {
        Player2 = GameObject.FindWithTag("Player 2");
        scr = Player2.GetComponent<Player2Punching>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player 2")
        {
            Player1Var.p2Health = scr.TakeRangeDamage(Player1Var.p2Health);
            Debug.Log("Fist Hit");
            //HealthBar.value = Player1Var.p2Health;
           // Debug.Log("health bar");
        }
    }
}
