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
    void Start()
    {


        Player2Engine = GameObject.Find("Player2").GetComponent<Rigidbody2D>();
        theAnimator = GameObject.Find("Player2").GetComponent<Animator>();
        facing = GameObject.Find("Player2").GetComponent<SpriteRenderer>();
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
        
        if (Input.GetKey(KeyCode.RightArrow))
        {

            Player2Engine.velocity = rightMove;
            theAnimator.SetBool("Moving", true);
            facing.flipX = true;



        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player2Engine.velocity = leftMove;
            theAnimator.SetBool("Moving", true);
            facing.flipX = false;
            Player2Engine.SetRotation(0);
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
                if (Player2Engine.velocity.x < 0)
                {
                    Player2Engine.velocity = noMove;
                    theAnimator.SetBool("Moving", false);
                }
            }
            else if (Player2Engine.velocity.x < 0)
            {
                Player2Engine.velocity = Player2Engine.velocity + VelFriction;
                if (Player2Engine.velocity.x > 0)
                {
                    Player2Engine.velocity = noMove;
                    theAnimator.SetBool("Moving", false);
                }
            }

            //if (Player2Engine.velocity.y == 0)
            //{
            //   // theAnimator.SetBool("OnGround", true);
            //}

        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            theAnimator.SetBool("IsBlocking", true);
            theAnimator.SetBool("BlockHolding", true);
           


        }
        else
        {
            theAnimator.SetBool("IsBlocking", false);
            theAnimator.SetBool("BlockHolding", false);


        }
    }


    //old Jumping code, now gone

    //public void OnCollisionEnter2D(Collision2D TheCollision)
    //{
    //    //gets called on collision

    //    if (TheCollision.gameObject.CompareTag("Ground"))
    //    {
           
    //        //if collision with ground
    //        theAnimator.SetBool("OnGround", true);
    //        //theAnimator.SetBool("InAir", false);
    //        // ground = true;

    //    }
    //    else
    //    {
    //        if (theAnimator.GetBool("InAir")){
    //            theAnimator.SetBool("OnGround", false);
    //        }
            
    //    }

    //}


    
}
