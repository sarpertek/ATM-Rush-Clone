using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{   
    public static bool hareket;
    public static int Skor;
    public GameObject obj1;
    float hor;

    void FixedUpdate()
    {   
        int kenar = 4;
        int t = 1;
        if (hareket == true) {
            if (transform.position.x > kenar & hor > 0) 
            { t = 0;
            }
            if (transform.position.x < -kenar & hor < 0) 
            { t=0;    
            }
            hor = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(hor * 30 * Time.deltaTime * t , 0 , 10*Time.deltaTime)); 
        }
        var paralar = GameObject.FindGameObjectsWithTag("ToplananPara");
        int k = 0;
        //paralari onune kat
        Skor = 0 ;
        obj1 = this.gameObject;
        foreach (var oyyy in paralar) 
        {   

            Vector3 startpos = new Vector3(obj1.transform.position.x, 1, obj1.transform.position.z+0.75f);
            Vector3 targetpos = new Vector3(oyyy.transform.position.x, 1, obj1.transform.position.z+0.75f);
            oyyy.transform.position = Vector3.Lerp(startpos, targetpos, 20*Time.deltaTime);
            obj1 = oyyy;
            foreach (Renderer r in oyyy.transform.GetComponentsInChildren(typeof(Renderer)))
            {   
                if (r.enabled == true) 
                {
                    if (r.name == "M_Gold") {
                        k = 2;
                    }
                    else if (r.name == "M_Diamond") {
                        k = 3;
                    }
                    else {
                        k = 1;
                    }
                }
            }
            Skor = Skor + k;      
        }
        
    }
}