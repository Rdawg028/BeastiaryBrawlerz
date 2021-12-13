using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    // variables needed for timer
    public float timeRemaining = 180;
    public bool timeRunning = false;
    public Text timeText;
    GameObject tmp;
    GameObject P1;
    GameObject P2;
    RoundsCoutners wins;
    GameObject winTracker;
    scene current;

    // Start is called before the first frame update
    void Start()
    {
        timeRunning = true;
        tmp = GameObject.Find("Timer");
        timeText = tmp.GetComponent<Text>();
        P1 = GameObject.FindWithTag("Player 1");
        P2 = GameObject.FindWithTag("Player 2");

        winTracker = GameObject.Find("RoundCounter");
        wins = winTracker.GetComponent<RoundsCoutners>();
        current = (scene)SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    { 
       if (timeRunning)
        {
            //checking if either of the players is inactive
            if (!P1.activeSelf || !P2.activeSelf)
            {
                DisplayTime(timeRemaining);
            }
           else  if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out");
                timeRemaining = 0;
                timeRunning = false;

                wins.Player1Wins();
                SceneManager.LoadScene((int)current);


            }
        }
       
            
        }

    

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
