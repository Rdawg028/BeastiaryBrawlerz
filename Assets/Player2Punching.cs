using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Player2Punching : MonoBehaviour
{
    Animator anim;
    Animator anim2;
    public float p1Health;
    GameObject p1;
    GameObject win1;
    scene current;
    public bool blocking;
    RoundsCoutners wins;
    int numRounds = 1;
    GameObject winTracker;
    GameObject timer;
    TimerScript isRunning;

    GameObject tmpHealth;
    Slider HealthBar;
    public float p2Health;

    GameObject p2; 

    // Start is called before the first frame update
    void Start()
    {
        p2 = GameObject.FindWithTag("Player 2");

        //code for pausing
        timer = GameObject.Find("Timer");
        isRunning = timer.GetComponent<TimerScript>();


        anim = GameObject.FindWithTag("Player 2").GetComponent<Animator>();
        p1Health = 25.0f;
        p1 = GameObject.FindWithTag("Player 1");
        blocking = false;
        // debugging stuff, basically ignoring collisions with colliders on the same layer
        Physics2D.IgnoreLayerCollision(0, 7);

        current = (scene)SceneManager.GetActiveScene().buildIndex;

        //win tracking
        winTracker = GameObject.Find("RoundCounter");
        wins = winTracker.GetComponent<RoundsCoutners>();

        tmpHealth = GameObject.Find("HealthBar2");
        HealthBar = tmpHealth.GetComponent<Slider>();
        p2Health = 25.0f;
        HealthBar.value = p2Health;

    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning.timeRunning)
        {
            if (Input.GetKey(KeyCode.Alpha1)) // light attack
            {
                anim.SetBool("IsLight", true);
            }
            else
            {
                anim.SetBool("IsLight", false);
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


            if (p1Health <= 0 && wins.P2Wins > numRounds && current == (scene)getCurrentScene())
            {
                if (wins.P2Wins > 0)
                {
                    loadWin();
                }
                
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
                blocking = true;
            }
            else
            {
                anim.SetBool("IsBlocking", false);
                anim.SetBool("BlockHolding", false);
                blocking = false;
            }
            
            //if (p2Health <= 0)
            //{
            //    anim.SetBool("IsLose", true);
            //    //Object.Destroy(p2);
            //}
        }
    }

 
     
        

        


    // Functions for doing damage. 
    public float TakeDamageLight(float health) // light attack damage
    {
        Debug.Log("Light Hit");
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

    void loadWin(){
        current = scene.P1;

        GameObject Player2 = GameObject.FindWithTag("Player 2");
        DontDestroyOnLoad(Player2);
        GameObject Player1 = GameObject.FindWithTag("Player 1");
        DontDestroyOnLoad(Player1);
        GameObject theCamera = GameObject.FindWithTag("MainCamera");
        DontDestroyOnLoad(theCamera);
        GameObject floor = GameObject.FindWithTag("Ground");
        DontDestroyOnLoad(floor);
        anim.SetBool("IsWin", true);
        anim2 = GameObject.FindWithTag("Player 1").GetComponent<Animator>();
        anim2.SetBool("IsLose", true);
        wins.P2Wins = -1;

        //GameObject gameManager = GameObject.FindWithTag("gameManager");
        //DontDestroyOnLoad(gameManager);
        //move character
        //collision.gameObject.transform.position = new Vector2(-16.07f, 4.06f);

        SceneManager.LoadScene("player1Win");
        Debug.Log("P1Destroyed");
        Object.Destroy(p1);
    }
 }
