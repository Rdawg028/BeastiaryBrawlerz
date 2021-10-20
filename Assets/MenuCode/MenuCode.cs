using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCode : MonoBehaviour
{
     Text sceneChooser;
    // Start is called before the first frame update
    void Start()
    {
        sceneChooser = GetComponent<Text>();
        sceneChooser.text = "SampleScene";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void GameStart()
    {
        SceneManager.LoadScene(sceneChooser.text);
    }

    public void ChangeSceneChoice()
    {
        sceneChooser.text = "player1Win";
    }
}
