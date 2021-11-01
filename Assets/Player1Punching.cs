using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum scene { Arena=0,P1=1,P2=2};


public class Player1Punching : MonoBehaviour
{
    Animator anim;
    public int p2Health;
    GameObject p2;
    scene current = scene.Arena;
    Player2Punching scr;
    bool blocking; 
    bool hitting;
 
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Player1").GetComponent<Animator>();
        p2Health = 25;
        p2 = GameObject.Find("Player2");
        scr = p2.GetComponent<Player2Punching>();
        Physics2D.IgnoreLayerCollision(0, 6);
        
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))  // light attack
        {
            anim.SetBool("IsPunch", true);
        }
        else
        {
            anim.SetBool("IsPunch", false);
        }

        if (Input.GetKeyDown(KeyCode.Y)) // heavy attack
        {
            anim.SetBool("Heavy", true);
            
        }
        else
        {
            anim.SetBool("Heavy", false);
        }
        
        if (Input.GetKeyDown(KeyCode.U)) // range attack
        {
            anim.SetBool("Range", true);
        }
        else
        {
            anim.SetBool("Range", false);
        }

        if (p2Health <= 0 && current==scene.Arena)
        {
            GameObject Player1 = GameObject.Find("Player1");
            DontDestroyOnLoad(Player1);
            GameObject theCamera = GameObject.FindWithTag("MainCamera");
            DontDestroyOnLoad(theCamera);
            GameObject floor = GameObject.FindWithTag("Ground");
            DontDestroyOnLoad(floor);

            //GameObject gameManager = GameObject.FindWithTag("gameManager");
            //DontDestroyOnLoad(gameManager);
            //move character
            //collision.gameObject.transform.position = new Vector2(-16.07f, 4.06f);

            SceneManager.LoadScene("player1Win");
            Object.Destroy(p2);
            current=scene.P1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("IsBlocking", true);
            anim.SetBool("BlockHolding", true);
        }
        else
        {
            anim.SetBool("IsBlocking", false);
            anim.SetBool("BlockHolding", false);
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            blocking = true;
        }
        if (Input.GetKey(KeyCode.T) && !blocking)
        {
            p2Health = scr.takeDamageLight(p2Health);
            
        }
        if (Input.GetKey(KeyCode.Y) && blocking)
        {
            anim.SetBool("IsBlocking", false);
            p2Health = scr.takeDamageHeavy(p2Health);
            Debug.Log("Heavy Attack Hit");
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            p2Health = scr.takeDamageHeavy(p2Health);
            Debug.Log("Heavy Attack Hit");
        }

        if (Input.GetKey(KeyCode.U) && !blocking)
        {
            p2Health = scr.takeRangeDamage(p2Health);
            Debug.Log("RangeAttack");
        }
    }
      
}






