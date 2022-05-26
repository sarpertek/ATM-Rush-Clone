using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public static GameObject TextContainer;
    [SerializeField] public TextMeshProUGUI starttext;
    public float transitionTime = 2f;
    public static GameObject player;
    public static Text myText;
    public static Animator anim;
    public static int depomiktari;

    void Start()
    {
        player = GameObject.Find("M_Char");
        player.GetComponent<Animator>().SetBool("hareket", true);
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (Input.GetMouseButtonUp(0))
        { 
            if (starttext.text == "Next") {
                Next();
                player.GetComponent<Animator>().SetBool("hareket", false);
            }
            else {
                //StartCoroutine(LoadLevel(0));
            }
        }
    }
    public void Next() 
    {   
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        //Movement.hareket = false;
        player.GetComponent<Animator>().SetBool("hareket", false);
        Movement.hareket = true;
        text.fixle = false; 
        Movement.Skor = 0;
        GameManager.depomiktari = 0; 
    }

    public void Baslat() 
    {

    }

    IEnumerator LoadLevel(int levelIndex)
    {   
        SceneManager.LoadScene(levelIndex);  
        yield return new WaitForSeconds(transitionTime);   
        //player.GetComponent<Animator>().SetBool("hareket", false);
    }
}
