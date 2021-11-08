using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCode : MonoBehaviour
{
    
    Button sceneChooser;
    int buttonScene;
    const int MAX_SCENES=4;
    Sprite button;
    // Start is called before the first frame update
    void Start()
    {

         sceneChooser = GameObject.Find("SceneChanger").GetComponent<Button>();
        buttonScene = 0;
        button = Resources.Load<Sprite>("Frame 1");
        // Arena.GetComponentInChildren<Text> = "Yep";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void GameStart()
    {
        SceneManager.LoadScene(buttonScene);
    }

   

    public void ButtonChange()
    {
        switch (buttonScene)
        {
            case 0:
                GameObject.Find("SceneChanger").GetComponentInChildren<Text>().text = "Tester";
                break;
            case 1:
                GameObject.Find("SceneChanger").GetComponentInChildren<Text>().text = "Player 1 Win Screen";
                sceneChooser.GetComponent<Image>().sprite=button;
                break;
            case 2:
                GameObject.Find("SceneChanger").GetComponentInChildren<Text>().text = "Menu";
                break;
            case 3:
                GameObject.Find("SceneChanger").GetComponentInChildren<Text>().text = "Mountain Temple";
                break;
            case 4:
                GameObject.Find("SceneChanger").GetComponentInChildren<Text>().text = "Arena";
                break;

        }
    }

    public void LeftArrrow()
    {
        //changing buttons so it can change which scene is pciked
        
            buttonScene--;
            //if it goes to the winning screen it changes to the arena
        //    if (buttonScene == 1)
        //    {
        //        buttonScene = 0;
        //    GameObject.Find("SceneChanger").GetComponentInChildren<Text>().text = "Arena";
        //}

            //loops back around if it goes to max scenes 
            if(buttonScene<=-1)
            {
                buttonScene = MAX_SCENES;
            }

        ButtonChange();
        
    }

    public void rightArrow()
    {
        //changing buttons so it can change which scene is pciked
        
            buttonScene++;
            //if it goes to the winning screen it changes to the arena
            //if (buttonScene == 1)
            //{
            //    buttonScene = 0;
            //}

            //loops back around if it goes above MAX_SCENES
            if (buttonScene > MAX_SCENES)
            {
                buttonScene = 0;
            }
        ButtonChange();
    }
}
