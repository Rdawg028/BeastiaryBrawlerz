using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player1Punching : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Player1").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
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
