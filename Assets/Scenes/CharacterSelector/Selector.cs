using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    GameObject SelectP1;
    GameObject SelectP2;
    //for the red selector
    float pos1X=3.19f;
    float pos1Y=-4.66f;
    float pos2X=5.92f;
    float pos2Y=-4.66f;
    float pos3X=3.3f;
    float pos3Y=-6.23f;
    float pos4X=5.84f;
    float pos4Y=-6.23f;
    //For the blue selector
    float Bpos1X = -0.79f;
    float Bpos1Y = -4.19f;
    float Bpos2X = 1.81f;
    float Bpos2Y = -4.19f;
    float Bpos3X= -0.71f;
    float Bpos3Y= -5.84f;
    float Bpos4X= 1.83f;
    float Bpos4Y=-5.84f;

    // Start is called before the first frame update
    void Start()
    {
        SelectP1 = GameObject.Find("Player1");
        SelectP2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SelectP1.transform.position = new Vector3(pos1X,pos1Y,0);
           
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectP2.transform.position = new Vector3(Bpos1X, Bpos1Y, 0);
        }

    }
}
