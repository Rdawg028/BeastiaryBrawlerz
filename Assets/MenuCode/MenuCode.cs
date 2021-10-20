using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCode : MonoBehaviour
{
    Text sceneChooser;
    Button Arena;
    // Start is called before the first frame update
    void Start()
    {
        sceneChooser = GameObject.Find("SceneName").GetComponent<Text>();
        sceneChooser.text = "SampleScene";
        Arena = GameObject.Find("SceneChanger").GetComponent<Button>();
       // Arena.GetComponentInChildren<Text> = "Yep";
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

    public void ButtonChange()
    {

    }
}
