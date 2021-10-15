using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player2Punching : MonoBehaviour
{
    Animator anim;
    int p2Health;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Player2").GetComponent<Animator>();
       
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

    }
}
