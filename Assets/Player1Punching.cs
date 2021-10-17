using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player1Punching : MonoBehaviour
{
    Animator anim;
    int p2Health;
    GameObject p2;
    bool hitting;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Player1").GetComponent<Animator>();
        p2Health = 10;
        p2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            anim.SetBool("IsPunch", true);
        
            // anim.speed = 4f; 
        }
        else
        {
            anim.SetBool("IsPunch", false);
            // anim.speed = f;
        }
        if (p2Health <= 0)
        {
            Object.Destroy(p2);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.T))
        {
            p2Health -= 5;
        }
    }
      
}






