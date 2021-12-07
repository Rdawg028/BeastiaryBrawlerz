using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWins : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject win;
    GameObject Pwinner;
    GameObject p2Winner;
    public Sprite win1;
    public Sprite win2;
    public SpriteRenderer winner;
    bool winne = false;
    void Start()
    {
        win = GameObject.Find("Player1Wins");
        Pwinner = GameObject.FindWithTag("Player 1");
        p2Winner = GameObject.FindWithTag("Player 2");



    }

    // Update is called once per frame
    void Update()
    {

        if (!winne)
        {
           winne= winnerPicked();
        }
        

    }


    bool winnerPicked()
    {
        if (Pwinner.activeInHierarchy)
        {
            winner.sprite = win1;
            return true;
        }
        if(p2Winner.activeInHierarchy)
        {
            winner.sprite = win2;
            return true;
        }
        return false;
        
    }
}
