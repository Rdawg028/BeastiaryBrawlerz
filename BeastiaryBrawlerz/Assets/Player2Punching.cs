using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player2Punching : MonoBehaviour
{
    Animator anim;
    int p1Health;
    GameObject p1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Player2").GetComponent<Animator>();
        p1Health = 10;
        p1 = GameObject.Find("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetBool("IsPunch", true);
            // anim.speed = 4f; 
        }
        else
        {
            anim.SetBool("IsPunch", false);
            // anim.speed = f;
        }
        
        if (p1Health <= 0)
        {
            Object.Destroy(p1);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            p1Health -= 5;
        }
    }
}
