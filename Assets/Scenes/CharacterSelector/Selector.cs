using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour
{
    GameObject SelectP1;
    GameObject SelectP2;
    public SpriteRenderer P1;
    public SpriteRenderer P2;
    public Sprite Player1_1;
    public Sprite Player1_2;
    public Sprite Player1_3;
    public Sprite Player1_4;

    public Sprite Player2_1;
    public Sprite Player2_2;
    public Sprite Player2_3;
    public Sprite Player2_4;

    CharacterInstancer checkDone1;
    CharacterInstancer2 checkDone2;

    //for the red selector
    float pos1X=-4.59f;
    float pos1Y=2.3f;
    float pos2X= -2.1f;
    float pos2Y=2.3f;
    float pos3X= -4.56f;
    float pos3Y=0.44f;
    float pos4X=-2.13f;
    float pos4Y=0.44f;
    //For the blue selector

    Vector3 topRight;
    Vector3 topLeft;
    Vector3 bottomRight;
    Vector3 bottomLeft;

    public bool found=false;

    public bool found2 = false;

    // Start is called before the first frame update
    void Start()
    {
        SelectP1 = GameObject.Find("Player1");
        SelectP2 = GameObject.Find("Player2");
        

        checkDone1 = SelectP1.GetComponent<CharacterInstancer>();
        checkDone2 = SelectP2.GetComponent<CharacterInstancer2>();

        topLeft = new Vector3(pos1X, pos1Y, 0);
        topRight = new Vector3(pos2X, pos2Y, 0);
        bottomLeft = new Vector3(pos3X, pos3Y, 0);
        bottomRight = new Vector3(pos4X, pos4Y, 0);
        //Player1_1 = Resources.Load<Sprite>("Player1_1");
        //Player1_2 = Resources.Load<Sprite>("Player1_2");
        //Player1_3 = Resources.Load<Sprite>("Player1_3");
        //Player1_4 = Resources.Load<Sprite>("Player1_4");
        SelectP1.transform.position = bottomLeft;
        P1.sprite = Player1_3;
        SelectP2.transform.position = bottomRight;
        P2.sprite = Player2_3;
    }

    // Update is called once per frame
    void Update()
    {

        if (checkDone1.P1Done && checkDone2.P2Done)
        {
            SceneManager.LoadScene("Menu");
        }
        if (!found)
        {
            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    if (SelectP1.transform.position == bottomLeft)
            //    {
            //        SelectP1.transform.position = topLeft;

            //        P1.sprite = Player1_4;
            //    }
            //    else if (SelectP1.transform.position == bottomRight)
            //    {
            //        SelectP1.transform.position = topRight;
            //        P1.sprite = Player1_2;
            //    }


            //}
             if (Input.GetKeyDown(KeyCode.D))
            {
                //if (SelectP1.transform.position == topLeft)
                //{
                //    SelectP1.transform.position = topRight;
                //    P1.sprite = Player1_2;
                //}
                 if (SelectP1.transform.position == bottomLeft)
                {
                    SelectP1.transform.position = bottomRight;
                    P1.sprite = Player1_1;
                }

            }
            //else if (Input.GetKeyDown(KeyCode.S))
            //{
            //    if (SelectP1.transform.position == topLeft)
            //    {
            //        SelectP1.transform.position = bottomLeft;
            //        P1.sprite = Player1_3;
            //    }
            //    else if (SelectP1.transform.position == topRight)
            //    {
            //        SelectP1.transform.position = bottomRight;
            //        P1.sprite = Player1_1;
            //    }

            //}
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //if (SelectP1.transform.position == topRight)
                //{
                //    SelectP1.transform.position = topLeft;

                //    P1.sprite = Player1_4;
                //}
                 if (SelectP1.transform.position == bottomRight)
                {
                    SelectP1.transform.position = bottomLeft;
                    P1.sprite = Player1_3;
                }

            }
        }
        if (!found2)
        {
            //if (Input.GetKeyDown(KeyCode.UpArrow))
            //{
            //    if (SelectP2.transform.position == bottomLeft)
            //    {
            //        SelectP2.transform.position = topLeft;
            //        P2.sprite = Player2_4;
            //    }
            //    else if (SelectP2.transform.position == bottomRight)
            //    {
            //        SelectP2.transform.position = topRight;
            //        P2.sprite = Player2_1;
            //    }


            //}
             if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //if (SelectP2.transform.position == topLeft)
                //{
                //    SelectP2.transform.position = topRight;
                //    P2.sprite = Player2_1;
                //}
                 if (SelectP2.transform.position == bottomLeft)
                {
                    SelectP2.transform.position = bottomRight;
                    P2.sprite = Player2_3;
                }

            }
            //else if (Input.GetKeyDown(KeyCode.DownArrow))
            //{
            //    if (SelectP2.transform.position == topLeft)
            //    {
            //        SelectP2.transform.position = bottomLeft;
            //        P2.sprite = Player2_2;
            //    }
            //    else if (SelectP2.transform.position == topRight)
            //    {
            //        SelectP2.transform.position = bottomRight;
            //        P2.sprite = Player2_3;
            //    }

            }
             if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //if (SelectP2.transform.position == topRight)
                //{
                //    SelectP2.transform.position = topLeft;
                //    P2.sprite = Player2_4;
                //}
                 if (SelectP2.transform.position == bottomRight)
                {
                    SelectP2.transform.position = bottomLeft;
                    P2.sprite = Player2_2;
                }
            }

        
    }


    
}


