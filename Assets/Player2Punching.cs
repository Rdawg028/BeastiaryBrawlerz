using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Player2Punching : MonoBehaviour
{
    Animator anim;
    public float p1Health;
    GameObject p1;
    GameObject win1;
    scene current;
    bool blocking;
    //GameObject tmpHealth;
   // Slider HealthBar;
    RoundsCoutners wins;
    GameObject winTracker;




    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Player2").GetComponent<Animator>();
        p1Health = 25.0f;
        p1 = GameObject.Find("Player1");
        blocking = false;
        // debugging stuff, basically ignoring collisions with colliders on the same layer
        Physics2D.IgnoreLayerCollision(0, 7);

        current = (scene)SceneManager.GetActiveScene().buildIndex;

        //win tracking
        winTracker = GameObject.Find("RoundCounter");
        wins = winTracker.GetComponent<RoundsCoutners>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1)) // light attack
        {
            anim.SetBool("IsPunch", true); 
        }
        else
        {
            anim.SetBool("IsPunch", false);
        }
        if (Input.GetKey(KeyCode.Alpha2)) // heavy attack
        {
            anim.SetBool("Heavy", true);
        }
        else
        {
            anim.SetBool("Heavy", false);
        }
        
        if (Input.GetKey(KeyCode.Alpha3)) // range attack
        {
            anim.SetBool("Range", true);
        }
        else
        {
            anim.SetBool("Range", false);
        }
       
        
        if (p1Health <= 0 && wins.P2Wins > 3 && current ==(scene)getCurrentScene())
        {
            current = scene.P1;

            GameObject Player2 = GameObject.Find("Player2");
            DontDestroyOnLoad(Player2);
            GameObject theCamera = GameObject.FindWithTag("MainCamera");
            DontDestroyOnLoad(theCamera);
            GameObject floor = GameObject.FindWithTag("Ground");
            DontDestroyOnLoad(floor);
            GameObject Timer = GameObject.FindWithTag("UI");
            DontDestroyOnLoad(Timer);

            //GameObject gameManager = GameObject.FindWithTag("gameManager");
            //DontDestroyOnLoad(gameManager);
            //move character
            //collision.gameObject.transform.position = new Vector2(-16.07f, 4.06f);
            
            SceneManager.LoadScene("player1Win");
            Debug.Log("P1Destroyed");
            Object.Destroy(p1);
        }
        else if (p1Health <= 0 && current == (scene)getCurrentScene())
        {
            wins.Player2Wins();
            SceneManager.LoadScene((int)current);

            DontDestroyOnLoad(GameObject.FindWithTag("roundCounter"));
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

    public void OnCollisionEnter2D (Collision2D collision)
    {
        if (Input.GetKey(KeyCode.S)) // so if blocking is true, damage should not be done
        {
            blocking = true;
        }
        else
        {
            blocking = false;
        }
     
        /*
        if (Input.GetKey(KeyCode.Alpha2) && blocking && collision.collider.gameObject.tag == "Player 1") // TODO fix block break
        {
            anim.SetBool("IsBlocking", false);
            p1Health = TakeDamageHeavy(p1Health);
            //HealthBar.value = p1Health;
        }
        */

    }


    // Functions for doing damage. 
    public float TakeDamageLight(float health) // light attack damage
    {
            //Debug.Log("Hit dectected");
            health -= 5;
            return health;
    }

    public float TakeDamageHeavy(float health) // heavy attack damage
    {
        Debug.Log("Heavy Hit");
        health -= 10;
        return health;
    }

    public float TakeRangeDamage(float health) // range attack damage
    {
        Debug.Log("Range Hit");
        health -= 3;
        return health;
    }

    public int getCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
