using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    
    GameObject timer;
    TimerScript isRunning;
    GameObject menu;
    GameObject g;

    private void Start()
    {
        timer = GameObject.Find("Timer");
        isRunning = timer.GetComponent<TimerScript>();
        g = GameObject.Find("PauseMenu");
        menu = GameObject.FindWithTag("Pause");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            isRunning.timeRunning = !isRunning.timeRunning;
            // menu.SetActive(true);
            g.SetActive(true);
            
        }
        
            
               
            
            
    }

    void OnGUI()
    {
        //make a panel
        //have it normally disable, enable on key press
        //as many buttons as you want
        //if (!isRunning.timeRunning&&isRunning.timeRemaining>0)
        //{

        //    menu.SetActive(!isRunning.timeRunning);
        //    if (GUILayout.Button("Click me to unpause"))
        //    {
        //        isRunning.timeRunning = !isRunning.timeRunning;
        //        menu.SetActive(!isRunning.timeRunning);
        //    }
            
                
        //}
    }

    
}
