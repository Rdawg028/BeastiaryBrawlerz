using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2Movement : MonoBehaviour
{
    //bool ground = true;
    // Start is called before the first frame update
    Animator theAnimator;
    Rigidbody2D Player2Engine;
    SpriteRenderer facing;
    GameObject timer;
    TimerScript isRunning;


    void Start()
    {

        //code for pausing
        timer = GameObject.Find("Timer");
        isRunning = timer.GetComponent<TimerScript>();


        Player2Engine = GameObject.FindWithTag("Player 2").GetComponent<Rigidbody2D>();
        theAnimator = GameObject.FindWithTag("Player 2").GetComponent<Animator>();
        facing = Player2Engine.GetComponent<SpriteRenderer>();
        //physicsEngine.AddForce(firstVector);
        Debug.Log("GameStart");

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 noMove = new Vector2(0, 0);
        Vector2 VelFriction = new Vector2(1, 0);
        Vector2 firstVector = new Vector2(-5, 5);
        Vector2 jumpForce = new Vector2(0, 10);
        Vector2 rightMove = new Vector2(5, 0);
        Vector2 leftMove = new Vector2(-5, 0);


        //bool move = Input.GetKey(KeyCode.D);

        // theAnimator.SetBool("Moving", move);


        //Debug.Log(theAnimator.GetBool("OnGround"));

        if (isRunning.timeRunning)
        {

            if (Input.GetKey(KeyCode.RightArrow))
            {

                Player2Engine.velocity = rightMove;
                theAnimator.SetBool("Moving", true);
                if (Player2Engine.name == "CubertRight"||Player2Engine.name == "CubertRight(Clone)")
                {
                    facing.flipX = true;
                }
                else
                {
                    facing.flipX = false;
                }
                
                



            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Player2Engine.velocity = leftMove;
                theAnimator.SetBool("Moving", true);
                Player2Engine.SetRotation(0);
                if (Player2Engine.name == "CubertRight"|| Player2Engine.name == "CubertRight(Clone)")
                {
                    facing.flipX = false;
                }
                else
                {
                    facing.flipX = true;
                }

            }



            //&& theAnimator.GetBool("OnGround")
            //else if (Input.GetKeyDown(KeyCode.UpArrow) )
            //{
            //    //*Time.deltaTime
            //    Player2Engine.AddForce(jumpForce, ForceMode2D.Impulse);
            //    if (theAnimator.GetBool("InAir"))
            //    {
            //        theAnimator.SetBool("OnGround", false);
            //    }
            //    theAnimator.SetBool("OnGround", false);
            //    // ground = false;

            //}
            else
            {
                if (Player2Engine.velocity.x > 0)
                {
                    Player2Engine.velocity = Player2Engine.velocity - VelFriction;
                    if (Player2Engine.velocity.x <= 0)
                    {
                        Player2Engine.velocity = noMove;
                        theAnimator.SetBool("Moving", false);
                    }
                }
                else if (Player2Engine.velocity.x < 0)
                {
                    Player2Engine.velocity = Player2Engine.velocity + VelFriction;
                    if (Player2Engine.velocity.x >= 0)
                    {
                        Player2Engine.velocity = noMove;
                        theAnimator.SetBool("Moving", false);
                    }
                }

                

            }


           
        }


       
    }

    
}
