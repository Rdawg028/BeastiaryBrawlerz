using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
   
    
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartingGame(int starter)
    {
        if (starter == 1)
        {
            
            SceneManager.LoadScene("Character selecter");
        }
    }
}
