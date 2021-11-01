using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Player2Punching : MonoBehaviour
{
    Animator anim;
    int p1Health;
    GameObject p1;
    GameObject win1;
    scene current = scene.Arena;
    bool blocking;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Player2").GetComponent<Animator>();
        p1Health = 25;
        p1 = GameObject.Find("Player1");
        blocking = false;
        // debugging stuff, basically ignoring collisions with colliders on the same layer
        Physics2D.IgnoreLayerCollision(0, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // light attack
        {
            anim.SetBool("IsPunch", true); 
        }
        else
        {
            anim.SetBool("IsPunch", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // heavy attack
        {
            anim.SetBool("Heavy", true);
        }
        else
        {
            anim.SetBool("Heavy", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3)) // range attack
        {
            anim.SetBool("Range", true);
        }
        else
        {
            anim.SetBool("Range", false);
        }
       
        
        if (p1Health <= 0 && current==scene.Arena)
        {
            current = scene.P1;

            GameObject Player2 = GameObject.Find("Player2");
            DontDestroyOnLoad(Player2);
            GameObject theCamera = GameObject.FindWithTag("MainCamera");
            DontDestroyOnLoad(theCamera);
            GameObject floor = GameObject.FindWithTag("Ground");
            DontDestroyOnLoad(floor);

            //GameObject gameManager = GameObject.FindWithTag("gameManager");
            //DontDestroyOnLoad(gameManager);
            //move character
            //collision.gameObject.transform.position = new Vector2(-16.07f, 4.06f);
            
            SceneManager.LoadScene("player1Win");

            Object.Destroy(p1);
        }

        if (Input.GetKey(KeyCode.DownArrow))
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
        if (Input.GetKey(KeyCode.S)) // so if blocking is true, damage should not be done
        {
            blocking = true;
        }
        if (Input.GetKey(KeyCode.Alpha1) && !blocking)
        {
            p1Health = takeDamageLight(p1Health);
        }

        if (Input.GetKey(KeyCode.Alpha2) && blocking) // TODO fix block break
        {
            anim.SetBool("IsBlocking", false);
            p1Health = takeDamageHeavy(p1Health);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            p1Health = takeDamageHeavy(p1Health);
        }

        if (Input.GetKey(KeyCode.Alpha3) && !blocking)
        {
            p1Health = takeRangeDamage(p1Health);
            Debug.Log("Range Attack hit");
        }
    }


    // Functions for doing damage. 
    public int takeDamageLight(int health) // light attack damage
    {
            Debug.Log("Hit dectected");
            health -= 5;
            return health;
    }

    public int takeDamageHeavy(int health) // heavy attack damage
    {
        Debug.Log("Heavy Hit");
        health -= 10;
        return health;
    }

    public int takeRangeDamage(int health) // range attack damage
    {
        Debug.Log("Range Hit");
        health -= 3;
        return health;
    }

}
