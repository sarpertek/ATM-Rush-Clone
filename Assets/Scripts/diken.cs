using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class diken : MonoBehaviour
{   
    private bool ileriatilacak = true;
    void OnTriggerEnter (Collider other)
    {   
        if (this.gameObject.name.Contains("Card") == true || this.gameObject.name.Contains("M_Obst") == true) 
        {
            ileriatilacak = false; 
        } 
        if (other.gameObject.tag == "ToplananPara") 
        {
            if (ileriatilacak == true) 
            {
                other.gameObject.tag = "UcanPara";
                ileriat(other.gameObject);
            }
            else 
            {
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.name == "M_Char") 
        { 
            StartCoroutine(Crash(other.gameObject));
            other.transform.DOMove(other.transform.position - new Vector3(0, 0, 5), 1).SetEase(Ease.OutBounce);
        }
    }
    public void ileriat(GameObject crashObj)
    {   
        crashObj.GetComponent<BoxCollider>().enabled = false;
        float x = Random.Range(-4, 4);
        float z = Random.Range(10, 15);
        Vector3 rasgeleyer = new Vector3(x, 1, crashObj.transform.position.z + z);
        crashObj.transform.DOMove(rasgeleyer,1).SetEase(Ease.OutBounce);
        crashObj.tag = "Para";
        crashObj.GetComponent<BoxCollider>().enabled = true;
        crashObj.GetComponent<BoxCollider>().isTrigger = true;   
    }

    IEnumerator Crash(GameObject thing)
    {
        thing.GetComponent<Animator>().enabled = false;
        Movement.hareket = false;  
        yield return new WaitForSeconds(1.5f);
        Movement.hareket = true;
        thing.GetComponent<Animator>().enabled = true;
    }
}



