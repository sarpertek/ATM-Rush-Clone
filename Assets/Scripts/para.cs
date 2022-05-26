using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class para : MonoBehaviour
{   
    public MoneyState currentMoneyState;
    public GameObject dollar;
    public GameObject gold;
    public GameObject diamond;
    public static GameObject player;
    public string Ara;
    public static int parapuan = 1;
    private bool hop = false;

    public enum MoneyState    {
        Dollar,
        Gold,
        Diamond
    }

    public void ChangeState(MoneyState newState)    {
        if (newState == MoneyState.Gold)
        {
            dollar.SetActive(false);
            gold.SetActive(true);
            Ara = "M_Gold";
            parapuan = 2;
        }
        else if (newState == MoneyState.Diamond)
        {
            gold.SetActive(false);
            diamond.SetActive(true);
            Ara = "M_Diamond";
            parapuan = 3;
        }
        transform.Find(Ara).GetComponent<Renderer>().enabled = true; 
    }

    void OnTriggerEnter (Collider other)
    {   
        if (other.gameObject.tag == "Para" && this.gameObject.tag == "Para") 
        {
            
        }
        else if (other.gameObject.tag == "Para")  // || other.gameObject.tag == "UcanPara")
        {
            other.gameObject.tag = "ToplananPara";
            //text.Skor = text.Skor + 1;
        }
        else if (other.gameObject.tag == "Lens" && this.gameObject.tag == "ToplananPara")
        {   
            foreach (Renderer r in transform.GetComponentsInChildren(typeof(Renderer)))
            {       
                r.enabled = false;
            }
            bool once = false;
            if (currentMoneyState == MoneyState.Dollar && !once)
            {
                ChangeState(MoneyState.Gold);
                currentMoneyState = MoneyState.Gold;
                //text.Skor = text.Skor + 1;
                once = true;    
            }
            else if (currentMoneyState == MoneyState.Gold && !once)
            {
                ChangeState(MoneyState.Diamond);
                currentMoneyState = MoneyState.Diamond;
                //text.Skor = text.Skor + 1;
                once = true;     
            }
            else 
            {
                ChangeState(MoneyState.Diamond);
                currentMoneyState = MoneyState.Diamond;
                //text.Skor = text.Skor + 1;
                once = true;  
            }
        }
        else if (other.gameObject.name == "M_Conveyor" && this.gameObject.tag == "ToplananPara")
        {       
            text.fixle = true;
            this.gameObject.tag = "BittiPara";
            player.GetComponent<BoxCollider>().isTrigger = false;
            hop = true;
        }
        else if (other.gameObject.name == "FinATM")
        {   
            //Destroy(this.gameObject);
        }
    } 
    void FixedUpdate()
    {
        if (hop == true) {
            this.transform.Translate(new Vector3(-5 * Time.deltaTime, 0 , 0)); 
        }
    }

    void Start()
    {
        player = GameObject.Find("M_Char");
    }
}



