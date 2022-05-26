using UnityEngine;

public class ATM : MonoBehaviour
{   
    public static float depomiktar = 0 ;
    void OnTriggerEnter (Collider other)
    {   
        if (other.gameObject.tag == "ToplananPara" || other.gameObject.tag == "BittiPara")
        {   
            foreach (Renderer r in other.gameObject.transform.GetComponentsInChildren(typeof(Renderer)))
            {   
                if (r.enabled == true) 
                {
                    if (r.name == "M_Gold") {
                        GameManager.depomiktari -= 2;
                    }
                    else if (r.name == "M_Diamond") {
                        GameManager.depomiktari -= 3;
                    }
                    else {
                        GameManager.depomiktari -= 1;
                    }
                }
            }
            Destroy(other.gameObject);
        }
    }
}



