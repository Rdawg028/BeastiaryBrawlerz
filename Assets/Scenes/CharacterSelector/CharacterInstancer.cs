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
    void Start()
    {
        player1 = GameObject.Find("Player1");
        selector = GameObject.Find("Selector");
        thing = selector.GetComponent<Selector>();
    }

    // Update is called once per frame
    void Update()
    {
    }

   public void OnTriggerEnter2D(Collider2D select)
    {

       
        if (select.gameObject.name == "IronMaiden")
        {
            
            thing.found = true;
            IronLeft.transform.position = new Vector2(-5.97f, -2.55f);
            IronLeft.transform.localScale = new Vector2(.5f, .5f);
            //IronLeft.GetComponent<Rigidbody2D>().isKinematic = false; 
            Instantiate(IronLeft);
        }
        else if (select.gameObject.name == "CubeBert")
        {
            CubertLeft.transform.position = new Vector2(-5.97f, -2.55f);
            Instantiate(CubertLeft);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit");
        if (other.gameObject.name == "IronMaiden")
        {
            Destroy(GameObject.FindWithTag("Player 1"));
        }
        if (other.gameObject.name == "CubeBert")
        {
            Destroy(GameObject.FindWithTag("Player 1"));
        }
    }
}
