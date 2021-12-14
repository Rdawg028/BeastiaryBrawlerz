using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCMaker : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject makerS;
    CharacterMaker choice;

    public GameObject IronLeft;
    public GameObject CubertLeft;
    public GameObject IronRight;
    public GameObject CubertRight;
    void Start()
    {
        makerS= GameObject.Find("CharacterChoices");
        choice =makerS.GetComponent<CharacterMaker>();

        if (choice.Iron1)
        {
            Instantiate(IronLeft);
        }
        else if (choice.CubeBert1)
        {
            Instantiate(CubertLeft);
        }

        if (choice.Iron2)
        {
            Instantiate(IronRight);
        }
        else if (choice.CubeBert2)
        {
            Instantiate(CubertRight);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
