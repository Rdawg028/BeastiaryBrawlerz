using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInstancer2 : MonoBehaviour
{
    GameObject player2;
    public GameObject IronRight;
    public GameObject CubertRight;
    public SpriteRenderer playerDos;
    public Sprite iron;
    public Sprite cube;
    GameObject selector;
    Selector thing;
    public bool P2Done;
    void Start()
    {
        player2 = GameObject.Find("Player2");
        selector = GameObject.Find("Selector");
        thing = selector.GetComponent<Selector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && playerDos.sprite == iron)
        {
            //thing.found = true;
            playerDos.sprite = null;
            IronRight.transform.position = new Vector2(5.92f, -2.75f);
            ////IronRight.transform.localScale = new Vector2(.5f, .5f);
            ////IronLeft.GetComponent<Rigidbody2D>().isKinematic = false; 
            Instantiate(IronRight);
        }
        else if (Input.GetKeyDown(KeyCode.RightControl) && playerDos.sprite == cube)
        {
            //thing.found = true;
            playerDos.sprite = null;
            CubertRight.transform.position = new Vector2(5.92f, -2.75f);
            Instantiate(CubertRight);
        }
        else if (Input.GetKeyDown(KeyCode.Backspace) && GameObject.FindWithTag("Player 2").activeInHierarchy)
        {

            Destroy(GameObject.FindWithTag("Player 2"));
        }

        if (Input.GetKeyDown(KeyCode.RightShift) && GameObject.FindWithTag("Player 2").activeInHierarchy)
        {
            P2Done = true;

        }
    }

    public void OnTriggerEnter2D(Collider2D select)
    {

        
        if (select.gameObject.name == "IronMaiden")
        {
            playerDos.sprite = iron;
            //thing.found = true;
            //IronRight.transform.position = new Vector2(5.92f, -2.75f);
            ////IronRight.transform.localScale = new Vector2(.5f, .5f);
            ////IronLeft.GetComponent<Rigidbody2D>().isKinematic = false; 
            //Instantiate(IronRight);
        }
        else if (select.gameObject.name == "CubeBert")
        {
            playerDos.sprite = cube;
            //CubertRight.transform.position = new Vector2(5.92f, -2.75f);
            //Instantiate(CubertRight);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.name == "IronMaiden")
        {
           // Destroy(GameObject.FindWithTag("Player 2"));
        }
        if (other.gameObject.name == "CubeBert")
        {
           // Destroy(GameObject.FindWithTag("Player 2"));
        }
    }
}
