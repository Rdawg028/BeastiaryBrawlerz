using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3Punching : MonoBehaviour
{

    Animator anim;
    public float p1Health;
    GameObject tmpHealth;
    Slider HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindWithTag("Player 1").GetComponent<Animator>();
        p1Health = 25.0f;
        Physics2D.IgnoreLayerCollision(0, 8);

        tmpHealth = GameObject.Find("HealthBar");
        HealthBar = tmpHealth.GetComponent<Slider>();
        HealthBar.value = p1Health;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T)) // light attack
        {
            anim.SetBool("Light", true);
        }
        else
        {
            anim.SetBool("Light", false);
        }

        if (Input.GetKeyDown(KeyCode.Y)) // heavy attack
        {
            anim.SetBool("Heavy", true);

        }
        else
        {
            anim.SetBool("Heavy", false);
        }

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
