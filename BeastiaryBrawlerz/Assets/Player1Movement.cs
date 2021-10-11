using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1Movement : MonoBehaviour
{
    //bool ground = true;
    // Start is called before the first frame update
    Animator theAnimator;
    Rigidbody2D CubertEngine;
    SpriteRenderer facing;
    void Start()
    {


        CubertEngine = GameObject.Find("Cubert").GetComponent<Rigidbody2D>();
        theAnimator = GameObject.Find("Cubert").GetComponent<Animator>();
        facing = GameObject.Find("Cubert").GetComponent<SpriteRenderer>();
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

            CubertEngine.velocity = rightMove;
            theAnimator.SetBool("Moving", true);
            facing.flipX = true;
            
            

        }

        else if (Input.GetKey(KeyCode.A))
        {
            CubertEngine.velocity = leftMove;
            theAnimator.SetBool("Moving", true);
            facing.flipX = false;
            CubertEngine.SetRotation(0);
        }
        //
        else if (Input.GetKeyDown(KeyCode.W) && theAnimator.GetBool("OnGround"))
        {
            CubertEngine.AddForce(jumpForce, ForceMode2D.Impulse);
            theAnimator.SetBool("OnGround", false);
           // ground = false;

        }
        else
        {
            if (CubertEngine.velocity.x > 0)
            {
                CubertEngine.velocity = CubertEngine.velocity - VelFriction;
                if (CubertEngine.velocity.x < 0)
                {
                    CubertEngine.velocity = noMove;
                    theAnimator.SetBool("Moving", false);
                }
            }
            else if (CubertEngine.velocity.x < 0)
            {
                CubertEngine.velocity = CubertEngine.velocity + VelFriction;
                if (CubertEngine.velocity.x > 0)
                {
                    CubertEngine.velocity = noMove;
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
