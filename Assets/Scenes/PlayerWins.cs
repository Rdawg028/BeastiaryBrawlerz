using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            P1Sound.clip = Resources.Load<AudioClip>("Cubertwin");
            if (P1Sound.clip == null)
            {
                Debug.Log("null");
            }
            P1Sound.Play();
            P2Sound.clip = p2LoseSound;
            P2Sound.Play();
            
        }
        else if (anim2.GetBool("IsWin"))
        {
            winner.sprite = win2;
        }

    }

 
}
