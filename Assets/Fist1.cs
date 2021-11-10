using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fist1 : MonoBehaviour
{

    GameObject Player1;
    Player2Punching Player1Var;
    GameObject tmpHealth;
    Slider HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find("Player1");
        Player1Var = Player1.GetComponent<Player2Punching>();

        tmpHealth = GameObject.Find("HealthBar2");
        HealthBar = tmpHealth.GetComponent<Slider>();
        HealthBar.value = Player1Var.p1Health;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Player1")
        {
            Player1Var.p1Health = Player1Var.TakeDamageLight(Player1Var.p1Health);
            Debug.Log("Fist Hit");
            HealthBar.value = Player1Var.p1Health;
            Debug.Log("health bar");

        }
    }


}
