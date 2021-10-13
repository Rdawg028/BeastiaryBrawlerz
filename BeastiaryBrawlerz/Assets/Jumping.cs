using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    Animator theAnimator;
    // Start is called before the first frame update
    void Start()
    {
        theAnimator = GameObject.Find("Player2").GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D TheTrigger)
    {
        
            theAnimator.SetBool("InAir", false);

    }
    public void OnTriggerExit2D(Collider2D TheTrigger)
    {

        theAnimator.SetBool("InAir", true);

    }
   
}
