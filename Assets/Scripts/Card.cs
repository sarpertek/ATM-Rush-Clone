using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{   
    private Vector3 endPos;
    public bool yerinde;
    public GameObject child;
    public Vector3 startPos;

    void Start()
    {
        child = this.gameObject.transform.GetChild(0).gameObject;
        startPos = child.transform.position;
        endPos = startPos + new Vector3(-10.0f,0,0);
        yerinde = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (yerinde == false) 
        {   
            if(startPos != endPos) 
            {   
                child.transform.position = Vector3.MoveTowards(
                    this.gameObject.transform.GetChild(0).gameObject.transform.position,
                    endPos, 15 * Time.fixedDeltaTime); 
            }
        }
    }
    
    void OnTriggerEnter (Collider other)
    {   
        if (other.gameObject.name == "M_Char")  {   
            yerinde = false;
        }

    }
}
