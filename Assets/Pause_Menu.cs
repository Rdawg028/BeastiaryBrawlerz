using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    
    GameObject timer;
    TimerScript isRunning;

    private void Start()
    {
        timer = GameObject.Find("Timer");
        isRunning = timer.GetComponent<TimerScript>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            
                isRunning.timeRunning = !isRunning.timeRunning;
            
            
    }

    void OnGUI()
    {
        if (!isRunning.timeRunning&&isRunning.timeRemaining>0)
        {
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Click me to unpause"))
            {
                isRunning.timeRunning = !isRunning.timeRunning;
            }
                
        }
    }

    
}
