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
    void Start()
    {
        win = GameObject.Find("Player1Wins");
        Pwinner = GameObject.FindWithTag("Player 1");
        p2Winner = GameObject.FindWithTag("Player 2");
        anim2 = GameObject.FindWithTag("Player 2").GetComponent<Animator>();
        anim1 = GameObject.FindWithTag("Player 1").GetComponent<Animator>();


        if (anim1.GetBool("IsWin"))
        {
            winner.sprite = win1;
        }
        else if (anim2.GetBool("IsWin"))
        {
            winner.sprite = win2;
        }

    }

    // Update is called once per frame
    void Update()
    {

        

    }


 
}
