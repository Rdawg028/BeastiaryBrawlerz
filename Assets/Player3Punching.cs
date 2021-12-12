using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player3Punching : MonoBehaviour
{

    Animator anim;
    Animator anim2;
    public float p1Health;
    GameObject tmpHealth;
    Slider HealthBar;
    GameObject p1;
    GameObject p2;
    Player2Punching scr;
    RoundsCoutners wins;
    scene current;
    scene start;
    Player1Punching loader;
    GameObject winTracker;
    int numRounds = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindWithTag("Player 1").GetComponent<Animator>();
        p1Health = 25.0f;
        Physics2D.IgnoreLayerCollision(0, 8);
        
        tmpHealth = GameObject.Find("HealthBar");
        HealthBar = tmpHealth.GetComponent<Slider>();
        HealthBar.value = p1Health;
        
        p1 = GameObject.FindWithTag("Player 1");
        anim.SetBool("IsLose", false);
        anim.SetBool("IsWin", false);

        p2 = GameObject.FindWithTag("Player 2");
        scr = p2.GetComponent<Player2Punching>();

        current = (scene)SceneManager.GetActiveScene().buildIndex;
        start = (scene)SceneManager.GetActiveScene().buildIndex;

        //win tracking
        winTracker = GameObject.Find("RoundCounter");
        wins = winTracker.GetComponent<RoundsCoutners>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T)) // light attack
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

        if (Input.GetKey(KeyCode.S)) // blocking
        {
            anim.SetBool("IsBlocking", true);
            anim.SetBool("BlockHolding", true);
        }
        else
        {
            anim.SetBool("IsBlocking", false);
            anim.SetBool("BlockHolding", false);
        }

        if (Input.GetKeyDown(KeyCode.U)) // range attack
        {
            anim.SetBool("Range", true);
        }
        else
        {
            anim.SetBool("Range", false);
        }

        if (scr.p2Health <= 0 && wins.P1Wins > numRounds && current == start)
        {
            if (wins.P1Wins > 0)
            {
                loadWin();
            }


        }
        else if (scr.p2Health <= 0 && current == start)
        {
            wins.Player1Wins();
            SceneManager.LoadScene((int)current);

            DontDestroyOnLoad(GameObject.FindWithTag("roundCounter"));
        }
        if (p1Health <= 0)
        {
            anim.SetBool("IsLose", true);
        }
        else if (scr.p2Health <= 0)
        {
            anim.SetBool("IsWin", true);
        }

       
        
    }

     void loadWin()
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
