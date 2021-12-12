using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronMaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    
    void onCollisionEnter(Collision2D select)
    {

        Debug.Log("triggered");
        if (select.gameObject.name == "IronMaiden")
        {
            Debug.Log("Endtered");
           // Instantiate(IronLeft);
        }
    }
}
