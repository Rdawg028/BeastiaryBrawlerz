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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetBool("IsPunch", true); 
        }
        else
        {
            anim.SetBool("IsPunch", false);
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
        if (Input.GetKey(KeyCode.S))
        {
            blocking = true;
        }
        if (Input.GetKey(KeyCode.Alpha1) && !blocking)
        {
            p1Health = takeDamageLight(p1Health);
        }
  
    }

    public int takeDamageLight(int health)
    {

            Debug.Log("Hit dectected");
            health -= 5;
            return health;
    }

    public int takeDamageHeavy(int health)
    {
        Debug.Log("Heavy Hit");
        anim.SetBool("IsBlocking", false);
        health -= 10;
        return health;
    }


}
