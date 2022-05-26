using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class playerhit : MonoBehaviour
{   
    public static Animator anim;
    [SerializeField] public TextMeshProUGUI starttext;
    public GameObject Rankall;
    public GameObject Rank;
    public GameObject anakamera;
    public int finalskor;
    void Start()
    {
        anim = GetComponent<Animator>();
        anakamera = GameObject.Find("Main Camera");
        Rankall = GameObject.Find("RankCubes");
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Para" || other.gameObject.tag == "UcanPara")
        {
            other.gameObject.tag = "ToplananPara";
            other.isTrigger = false;
        }
        if (other.gameObject.name.Contains("M_Conveyor") == true)
        {   
            //fader.SetTrigger("Start");
            StartCoroutine(Bekle(5.0f));
            Movement.hareket = false;
            this.gameObject.transform.position += new Vector3(0, 0.1f, 20f);
            this.gameObject.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
            anim.SetBool("hareket", false);     
            CubeMove();
            starttext.gameObject.SetActive(true);
            int y = SceneManager.GetActiveScene().buildIndex;
            if (y <3) 
            {
            starttext.text = "Next";
            }
            else {
            int a,b,c;
            a = PlayerPrefs.GetInt("Level2", 0);
            b = PlayerPrefs.GetInt("Level1", 0);
            c = PlayerPrefs.GetInt("Level3", 0);
            a = a + b + c;
            starttext.text = "Game Over - Score:" +  a.ToString();
            }
        }
    }
    public void CubeMove()
    {   
        string s = "Level" + SceneManager.GetActiveScene().buildIndex.ToString();
        PlayerPrefs.SetInt(s, text.TotalScore);
        float rounded = (Mathf.Ceil(text.TotalScore/8));
        for (int i = 1; i <= rounded; i++)
            {   
                if (i < 11) {
                string findstr = "RC";
                findstr = findstr + i;
                Rank = Rankall.transform.Find(findstr).gameObject;
                Rank.transform.position += new Vector3(0, 0f, -5f);
                para.player.transform.position += new Vector3(0, 5.0f, 0);
                }
            }    
    }
    IEnumerator Bekle(float a)
    {
        yield return new WaitForSeconds(a);
    }
}