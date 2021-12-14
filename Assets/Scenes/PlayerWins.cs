using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWins : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject win;
    GameObject Pwinner;
    GameObject p2Winner;
    Animator anim1;
    Animator anim2;
    public Sprite win1;
    public Sprite win2;
    public SpriteRenderer winner;
    bool winne = false;

    AudioSource P1Sound;
    AudioSource P2Sound;
    public  AudioClip p1WinSound;
    public AudioClip p2WinSound;
    public AudioClip p1LoseSound;
    public AudioClip p2LoseSound;

    float timeRemaining = 20;
    public bool timeRunning = false;


    void Start()
    {
        win = GameObject.Find("Player1Wins");
        Pwinner = GameObject.FindWithTag("Player 1");
        p2Winner = GameObject.FindWithTag("Player 2");
        anim2 = GameObject.FindWithTag("Player 2").GetComponent<Animator>();
        anim1 = GameObject.FindWithTag("Player 1").GetComponent<Animator>();

        P1Sound = GameObject.FindWithTag("Player 1").GetComponent<AudioSource>();
        P2Sound = GameObject.FindWithTag("Player 2").GetComponent<AudioSource>();



        if (anim1.GetBool("IsWin"))
        {
            winner.sprite = win1;
            P1Sound.clip = p1WinSound;
            P1Sound.Play();
            P2Sound.clip = p2LoseSound;
            P2Sound.Play();
            
        }
        if (anim2.GetBool("IsWin"))
        {
            winner.sprite = win2;
        }

    }

    private void Update()
    {
         if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            
        }
        else
        {
            timeRemaining = 0;
            
        }

        if (timeRemaining == 0)
        {
            SceneManager.MoveGameObjectToScene(GameObject.Find("Main Camera"), SceneManager.GetActiveScene());
            SceneManager.MoveGameObjectToScene(GameObject.Find("RoundCounter"), SceneManager.GetActiveScene());
            SceneManager.MoveGameObjectToScene(GameObject.Find("CharacterChoices"), SceneManager.GetActiveScene());
            SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Ground"), SceneManager.GetActiveScene());
            SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Player1"), SceneManager.GetActiveScene());
            SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Player2"), SceneManager.GetActiveScene());
            SceneManager.LoadScene("Character selecter");
        }
        
    }


}
