using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fist : MonoBehaviour
{

    GameObject Player2;
    GameObject Player1;
    Player2Punching Player2Var;
    GameObject tmpHealth;
    Slider HealthBar;
    

    // Start is called before the first frame update
    void Start()
    {
       Player2 = GameObject.Find("Player2");
       Player2Var = Player2.GetComponent<Player2Punching>();

       tmpHealth = GameObject.Find("HealthBar");
       HealthBar = tmpHealth.GetComponent<Slider>();
       HealthBar.value = Player2Var.p1Health;

      

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Player1")
        {
            Player2Var.p1Health = Player2Var.TakeDamageLight(Player2Var.p1Health);
            Debug.Log("Fist Hit");
            HealthBar.value = Player2Var.p1Health;
            Debug.Log("health bar");
            
        }
        
    }
}
