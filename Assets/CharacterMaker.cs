using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMaker : MonoBehaviour
{
    public bool Iron1;
    public bool CubeBert1;
    public bool Iron2;
    public bool CubeBert2;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("CharacterChoices"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
