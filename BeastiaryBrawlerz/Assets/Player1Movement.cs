using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1Movement : MonoBehaviour
{
    //bool ground = true;
    // Start is called before the first frame update
    Animator theAnimator;
    Rigidbody2D Player1Engine;
    SpriteRenderer facing;
    void Start()
    {


        Player1Engine = GameObject.Find("Player1").GetComponent<Rigidbody2D>();
        theAnimator = GameObject.Find("Player1").GetComponent<Animator>();
        facing = GameObject.Find("Player1").GetComponent<SpriteRenderer>();
        //physicsEngine.AddForce(firstVector);
        Debug.Log("GameStart");

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 noMove = new Vector2(0, 0);
        Vector2 VelFriction = new Vector2(1, 0);
        Vector2 firstVector = new Vector2(-5, 5);
        Vector2 jumpForce = new Vector2(0, 100);
        Vector2 rightMove = new Vector2(5, 0);
        Vector2 leftMove = new Vector2(-5, 0);


        //bool move = Input.GetKey(KeyCode.D);

        // theAnimator.SetBool("Moving", move);


        Debug.Log(theAnimator.GetBool("OnGround"));
        if (Input.GetKey(KeyCode.D))
        {

            Player1Engine.velocity = rightMove;
            theAnimator.SetBool("Moving", true);
            facing.flipX = true;
            
            

        }

        else if (Input.GetKey(KeyCode.A))
        {
            Player1Engine.velocity = leftMove;
            theAnimator.SetBool("Moving", true);
            facing.flipX = false;
            Player1Engine.SetRotation(0);
        }
        //
        else if (Input.GetKeyDown(KeyCode.W) && theAnimator.GetBool("OnGround"))
        {
            Player1Engine.AddForce(jumpForce, ForceMode2D.Impulse);
            theAnimator.SetBool("OnGround", false);
           // ground = false;

        }
        else
        {
            if (Player1Engine.velocity.x > 0)
            {
                Player1Engine.velocity = Player1Engine.velocity - VelFriction;
                if (Player1Engine.velocity.x < 0)
                {
                    Player1Engine.velocity = noMove;
                    theAnimator.SetBool("Moving", false);
                }
            }
            else if (Player1Engine.velocity.x < 0)
            {
                Player1Engine.velocity = Player1Engine.velocity + VelFriction;
                if (Player1Engine.velocity.x > 0)
                {
                    Player1Engine.velocity = noMove;
                    theAnimator.SetBool("Moving", false);
                }
            }


        }
    }

    public void OnCollisionEnter2D(Collision2D TheCollision)
    {
        //gets called on collision

        if (TheCollision.gameObject.CompareTag("Ground"))
        {
            //if collision with ground
            theAnimator.SetBool("OnGround", true);
           // ground = true;

        }
        else
        {
            theAnimator.SetBool("OnGround", false);
        }

    }
}
