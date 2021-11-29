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
    public SpriteRenderer back;
    public Sprite arena;
    public Sprite temple;

    // Start is called before the first frame update
    void Start()
    {

         sceneChooser = GameObject.Find("SceneChanger").GetComponent<Button>();
        buttonScene = 3;
        button = Resources.Load<Sprite>("Frame 1");
        ButtonChange();
        
        //back = GameObject.Find("Background").GetComponent<SpriteRenderer>();
        // Arena.GetComponentInChildren<Text> = "Yep";
    }

    // Update is called once per frame
    void Update()
    {
       // back.sprite()
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
                back.sprite = temple;
                break;
            case 4:
                GameObject.Find("SceneChanger").GetComponentInChildren<Text>().text = "Arena";
                back.sprite = arena;
                break;

        }
    }

    public void LeftArrrow()
    {
        //changing buttons so it can change which scene is pciked
        //1,0,2,5
            buttonScene--;
            //if it goes to the winning screen it changes to the arena
        //    if (buttonScene == 1)
        //    {
        //        buttonScene = 0;
        //    GameObject.Find("SceneChanger").GetComponentInChildren<Text>().text = "Arena";
        //}

            //loops back around if it goes to max scenes 
            if(buttonScene<=2)
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
                buttonScene = 3;
            }
        ButtonChange();
    }
}
