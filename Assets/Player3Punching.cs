using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Punching : MonoBehaviour
{

    Animator anim;
    public float p3Health;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Player3").GetComponent<Animator>();
        p3Health = 25.0f;
        Physics2D.IgnoreLayerCollision(0, 8);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S)) // blocking
        {
            anim.SetBool("IsBlocking", true);
            anim.SetBool("BlockHolding", true);
        }
        else
        {
            anim.SetBool("IsBlocking", false);
            anim.SetBool("BlockHolding", false);
        }

        if (Input.GetKeyDown(KeyCode.U)) // range attack
        {
            anim.SetBool("IsRange", true);
        }
        else
        {
            anim.SetBool("IsRange", false);
        }
    }
}
