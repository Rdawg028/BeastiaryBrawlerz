using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoundsCoutners : MonoBehaviour
{
    GameObject P1;
    GameObject P2;
    Player1Punching POne;
    Player2Punching PTwo;
    public int P1Wins;
    public int P2Wins;
    
    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.FindWithTag("Player 1");
        P2 = GameObject.FindWithTag("Player 2");
        POne = P1.GetComponent<Player1Punching>();
        PTwo = P2.GetComponent<Player2Punching>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void Player1Wins()
    {
        P1Wins += 1;
    }

    public void Player2Wins()
    {
        P2Wins += 1;
    }
}
