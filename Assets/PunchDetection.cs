using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchDetection : MonoBehaviour
{
    Player2Punching p2Script;
    Player1Punching p1Script;
    GameObject player2;
    int p1Health;
    int p2Health = 10;
    bool hitting;
    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.Find("Player2");
        hitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitting)
        {
            p2Health -= 5;
        }
        if (p2Health <= 0)
        {
            Object.Destroy(player2);
        }
    }
}
