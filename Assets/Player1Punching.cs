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
    scene current;
    scene start;
    Player2Punching scr;
    bool blocking;
    Slider HealthBar2;
    GameObject tmpHealth;
    RoundsCoutners wins;
    GameObject winTracker;
    int numRounds=1;
 
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Player1").GetComponent<Animator>();
        p2Health = 25;

        p2 = GameObject.Find("Player2");
        scr = p2.GetComponent<Player2Punching>();
        // ignores collisions of objects on the same layer. 
        Physics2D.IgnoreLayerCollision(0, 6);

         current = (scene)SceneManager.GetActiveScene().buildIndex;
         start= (scene)SceneManager.GetActiveScene().buildIndex;

        //Health Bar stuff
        tmpHealth = GameObject.Find("HealthBar2");
        HealthBar2 = tmpHealth.GetComponent<Slider>();
        HealthBar2.value = p2Health;

        //win tracking
        winTracker = GameObject.Find("RoundCounter");
        wins = winTracker.GetComponent<RoundsCoutners>();
       

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
        
        
        if(p2Health <= 0 && wins.P1Wins > numRounds && current ==start)
        {
            if (wins.P1Wins > 0)
            {
                loadWin();
            }
            
            
        }
        else if(p2Health <= 0 && current == start)
        {
            wins.Player1Wins();
            SceneManager.LoadScene((int)current);

            DontDestroyOnLoad(GameObject.FindWithTag("roundCounter"));
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


        if (Input.GetKey(KeyCode.Y) && blocking && collision.collider.gameObject.tag == "Player 2")
        {
            anim.SetBool("IsBlocking", false); // trying to get block break
            p2Health = scr.TakeDamageHeavy(p2Health);
            HealthBar2.value = p2Health;
        }
        else if (Input.GetKey(KeyCode.Y) && !blocking && collision.collider.gameObject.tag == "Player 2")
        {
            p2Health = scr.TakeDamageHeavy(p2Health);
            HealthBar2.value = p2Health;
        }

        if (Input.GetKey(KeyCode.U) && !blocking && collision.collider.gameObject.tag == "Player 2")
        {
            p2Health = scr.TakeRangeDamage(p2Health);
            HealthBar2.value = p2Health; 
        }
    }


    public int getCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    void loadWin()
    {
        GameObject Player1 = GameObject.Find("Player1");
        DontDestroyOnLoad(Player1);
        GameObject theCamera = GameObject.FindWithTag("MainCamera");
        DontDestroyOnLoad(theCamera);
        GameObject floor = GameObject.FindWithTag("Ground");
        DontDestroyOnLoad(floor);

        wins.P1Wins = -1;
        //GameObject gameManager = GameObject.FindWithTag("gameManager");
        //DontDestroyOnLoad(gameManager);
        //move character
        //collision.gameObject.transform.position = new Vector2(-16.07f, 4.06f);

        SceneManager.LoadScene("player1Win");
        // SceneManager.LoadScene("SampleScene");
        Debug.Log("Destoyed");
        Object.Destroy(p2);
        current = scene.P1;
    }

}






