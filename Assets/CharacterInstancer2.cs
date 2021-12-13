using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInstancer2 : MonoBehaviour
{
    GameObject player2;
    public GameObject IronRight;
    public GameObject CubertRight;
    GameObject selector;
    Selector thing;
    void Start()
    {
        player2 = GameObject.Find("Player2");
        selector = GameObject.Find("Selector");
        thing = selector.GetComponent<Selector>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D select)
    {

        Debug.Log("enter");
        if (select.gameObject.name == "IronMaiden")
        {

            thing.found = true;
            IronRight.transform.position = new Vector2(-5.97f, -2.55f);
            IronRight.transform.localScale = new Vector2(.5f, .5f);
            //IronLeft.GetComponent<Rigidbody2D>().isKinematic = false; 
            Instantiate(IronRight);
        }
        else if (select.gameObject.name == "CubeBert")
        {
            CubertRight.transform.position = new Vector2(5.92f, -2.75f);
            Instantiate(CubertRight);
        }
    }
}
