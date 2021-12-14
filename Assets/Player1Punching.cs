using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum scene { Sample=0,P1=1,P2=2,Arena=3,Temple=4};


public class Player1Punching : MonoBehaviour
{
    Animator anim;
    public float p2Health;
    GameObject p2;
    Player2Punching scr;
    Animator anim2;
    scene current;
    scene start;
    public bool blocking;
    RoundsCoutners wins;
    GameObject winTracker;
    int numRounds=1;
    GameObject timer;
    TimerScript isRunning;

    GameObject tmpHealth;
    Slider HealthBar;
    public float p1Health;

    AudioSource P1Sound;
    public AudioClip p1LoseSound;
    public AudioClip p1WinSound;

    // Start is called before the first frame update
    void Start()
    {
        //code for pausing
        timer = GameObject.Find("Timer");
        isRunning = timer.GetComponent<TimerScript>();

        anim = GameObject.FindWithTag("Player 1").GetComponent<Animator>();
        p2Health = 25.0f;
        
        // ignores collisions of objects on the same layer. 
        Physics2D.IgnoreLayerCollision(0, 6);

         current = (scene)SceneManager.GetActiveScene().buildIndex;
         start= (scene)SceneManager.GetActiveScene().buildIndex;


        //win tracking
        winTracker = GameObject.Find("RoundCounter");
        wins = winTracker.GetComponent<RoundsCoutners>();

        //Health
        tmpHealth = GameObject.Find("HealthBar");
        HealthBar = tmpHealth.GetComponent<Slider>();
        p1Health = 25.0f;
        HealthBar.value = p1Health;

        anim.SetBool("IsWin", false);
        anim.SetBool("IsLose", false);
        p2 = GameObject.FindWithTag("Player 2");
        scr = p2.GetComponent<Player2Punching>();

        blocking = false;

        P1Sound = GameObject.FindWithTag("Player 1").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if game is paused
        if (isRunning.timeRunning)
        {
            if (Input.GetKeyDown(KeyCode.T))  // light attack
            {
                anim.SetBool("IsLight", true);
            }
            else
            {
                anim.SetBool("IsLight", false);
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
                anim.SetBool("IsRange", true);
            }
            else
            {
                anim.SetBool("IsRange", false);
            }


            if (p2Health <= 0 && wins.P1Wins > numRounds && current == start)
            {
                if (wins.P1Wins > 0)
                {
                    loadWin();
                }


            }
            else if (p2Health <= 0 && current == start)
            {
                wins.Player1Wins();
                SceneManager.LoadScene((int)current);

                DontDestroyOnLoad(GameObject.FindWithTag("roundCounter"));
            }

            if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("IsBlocking", true);
                anim.SetBool("BlockHolding", true);
                blocking = true;
                Debug.Log("Blocking");
            }
            else
            {
                anim.SetBool("IsBlocking", false);
                anim.SetBool("BlockHolding", false);
                blocking = false;
               
            }


        } 

    }

    


    public int getCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void loadWin()
    {
        GameObject Player1 = GameObject.FindWithTag("Player 1");
        DontDestroyOnLoad(Player1);
        GameObject Player2 = GameObject.FindWithTag("Player 2");
        DontDestroyOnLoad(Player2);
        GameObject theCamera = GameObject.FindWithTag("MainCamera");
        DontDestroyOnLoad(theCamera);
        GameObject floor = GameObject.FindWithTag("Ground");
        DontDestroyOnLoad(floor);
        anim.SetBool("IsWin", true);
        anim2 = GameObject.FindWithTag("Player 2").GetComponent<Animator>();
        anim2.SetBool("IsLose", true);

        wins.P1Wins = -1;
        //GameObject gameManager = GameObject.FindWithTag("gameManager");
        //DontDestroyOnLoad(gameManager);
        //move character
        //collision.gameObject.transform.position = new Vector2(-16.07f, 4.06f);

        SceneManager.LoadScene("player1Win");
        // SceneManager.LoadScene("SampleScene");
        Debug.Log("Destoyed");
        //Object.Destroy(p2);
        current = scene.P1;
    }

}






