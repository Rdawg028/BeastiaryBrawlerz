using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInstancer : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player1;
    public GameObject IronLeft;
    public GameObject CubertLeft;
    GameObject selector;
    Selector thing;
    public SpriteRenderer playerUno;
    public Sprite iron1;
    public Sprite cube1;
    public bool P1Done;

    public SpriteRenderer back1;
    public Sprite bIron;
    public Sprite bCube;


    GameObject choice;
    CharacterMaker character;
  
    void Start()
    {
        player1 = GameObject.Find("Player1");
        selector = GameObject.Find("Selector");
        thing = selector.GetComponent<Selector>();

        choice = GameObject.Find("CharacterChoices");
        character = choice.GetComponent<CharacterMaker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)&&playerUno.sprite==iron1)
        {
            thing.found = true;
            playerUno.sprite = null;
            back1.sprite = bIron;
            IronLeft.transform.position = new Vector2(-5.97f, -2.55f);
            IronLeft.transform.localScale = new Vector2(.5f, .5f);

            Instantiate(IronLeft);
            character.Iron1 = true;
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && playerUno.sprite == cube1)
        {
            thing.found = true; 
            playerUno.sprite = null;
            back1.sprite = bCube;
            CubertLeft.transform.position = new Vector2(-5.97f, -2.55f);
            Instantiate(CubertLeft);
            character.CubeBert1 = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape)&&GameObject.FindWithTag("Player 1").activeInHierarchy)
        {
            back1.sprite= null;
            Destroy(GameObject.FindWithTag("Player 1"));
            thing.found = false;
            character.Iron1 = false;
            character.CubeBert1 = false;
           
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && GameObject.FindWithTag("Player 1").activeInHierarchy)
        {
            P1Done = true;
            
        }

        
    }

   public void OnTriggerEnter2D(Collider2D select)
    {

        Debug.Log("enter one");
        if (select.gameObject.name == "IronMaiden")
        {
            Debug.Log("enter iron");
            playerUno.sprite = iron1;
            //thing.found = true;
            //IronLeft.transform.position = new Vector2(-5.97f, -2.55f);
            //IronLeft.transform.localScale = new Vector2(.5f, .5f);
            
            //Instantiate(IronLeft);
        }
        else if (select.gameObject.name == "CubeBert")
        {
            playerUno.sprite = cube1;
            //CubertLeft.transform.position = new Vector2(-5.97f, -2.55f);
            //Instantiate(CubertLeft);
        }
    }

    //public void OnTriggerExit2D(Collider2D other)
    //{
    //    Debug.Log("Exit one");
    //    if (other.gameObject.name == "IronMaiden")
    //    {
    //        playerUno.sprite = null;
    //       // Destroy(GameObject.FindWithTag("Player 1"));
    //    }
    //    if (other.gameObject.name == "CubeBert")
    //    {
    //        playerUno.sprite = null;
    //        //Destroy(GameObject.FindWithTag("Player 1"));
    //    }
    //}
}
