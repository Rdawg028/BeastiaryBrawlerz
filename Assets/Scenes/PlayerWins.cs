using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWins : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject win;
    GameObject Pwinner;
    GameObject p2Winner;
    Animator anim1;
    Animator anim2;
    public Sprite win1;
    public Sprite win2;
    public SpriteRenderer winner;
    bool winne = false;
    bool CubertL, IronL, CubertR, IronR;
    Rigidbody2D Player1Engine;
    Rigidbody2D Player2Engine;

    GameObject winMenu;

    AudioSource CubeWin, IronWin, CubeLose, IronLose;

    public float timeRemaining = 20;
    void Start()
    {
        win = GameObject.Find("Player1Wins");
        Pwinner = GameObject.FindWithTag("Player 1");
        p2Winner = GameObject.FindWithTag("Player 2");
        anim2 = GameObject.FindWithTag("Player 2").GetComponent<Animator>();
        anim1 = GameObject.FindWithTag("Player 1").GetComponent<Animator>();

        CubeWin = GameObject.Find("CubeWin").GetComponent<AudioSource>();
        IronWin = GameObject.Find("IronWin").GetComponent<AudioSource>();
        CubeLose = GameObject.Find("CubeLose").GetComponent<AudioSource>();
        IronLose = GameObject.Find("IronLose").GetComponent<AudioSource>();

        Player1Engine = GameObject.FindWithTag("Player 1").GetComponent<Rigidbody2D>();
        Player2Engine = GameObject.FindWithTag("Player 2").GetComponent<Rigidbody2D>();

        winMenu = GameObject.Find("PlayAgainMenu");
        winMenu.SetActive(false);

        if (Player1Engine.name == "CubertLeft(Clone)")
        {
            CubertL = true;
        }
        else if (Player1Engine.name == "IronMaidenLeft(Clone)")
        {
            IronL = true;
        }

        if (Player2Engine.name == "CubertRight(Clone)")
        {
            CubertR = true;
        }
        else if (Player2Engine.name == "IronMaidenRight(Clone)")
        {
            IronR = true;
        }



        if (anim1.GetBool("IsWin"))
        {
            winner.sprite = win1;
            if (CubertL && CubertR)
            {
                CubeWin.Play();
                CubeLose.Play();
            }
            else if (IronL && IronR)
            {
                IronWin.Play();
                IronLose.Play();
            }
            else if (CubertL && IronR)
            {
                CubeWin.Play();
                IronLose.Play();
            }
            else if (IronL && CubertR)
            {
                IronWin.Play();
                CubeLose.Play();
            }
            
        }
        if (anim2.GetBool("IsWin"))
        {
            winner.sprite = win2;
            if (CubertL && CubertR)
            {
                CubeWin.Play();
                CubeLose.Play();
            }
            else if (IronL && IronR)
            {
                IronWin.Play();
                IronLose.Play();
            }
            else if (CubertL && IronR)
            {
                CubeLose.Play();
                IronWin.Play();
            }
            else if (IronL && CubertR)
            {
                IronLose.Play();
                CubeWin.Play();
            }
        }

    }

    private void Update()
    {
         if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            
        }
        else
        {
            timeRemaining = 0;
            
        }

        if (timeRemaining == 0)
        {
            winMenu.SetActive(true);
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void loadStangeSelect()
    {
        SceneManager.MoveGameObjectToScene(GameObject.Find("Main Camera"), SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(GameObject.Find("RoundCounter"), SceneManager.GetActiveScene());
      
        SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Ground"), SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Player 1"), SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Player 2"), SceneManager.GetActiveScene());

        SceneManager.LoadScene("Menu");
    }

    public void loadCharacterSelect()
    {
        SceneManager.MoveGameObjectToScene(GameObject.Find("Main Camera"), SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(GameObject.Find("RoundCounter"), SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(GameObject.Find("CharacterChoices"), SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Ground"), SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Player 1"), SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Player 2"), SceneManager.GetActiveScene());
        
        SceneManager.LoadScene("Character selecter");
    }



}
