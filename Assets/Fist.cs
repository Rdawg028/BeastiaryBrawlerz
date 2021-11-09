using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{

    GameObject Player2;
    Player2Punching health;
    // Start is called before the first frame update
    void Start()
    {
       Player2 = GameObject.Find("Player2");
       health = Player2.GetComponent<Player2Punching>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if   (collision.collider.gameObject.name == "Player1")
        {
            health.TakeDamageLight(health.p1Health);
            Debug.Log("Fist Hit");
            //HealthBar.value = p1Health;
        }
    }
}
