using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuScore : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI menutext;    
    
    void Start()
    {   
        int menuskor, sonlvl;
        menuskor = PlayerPrefs.GetInt("Level3", 0) + PlayerPrefs.GetInt("Level2", 0) + PlayerPrefs.GetInt("Level1", 0);
        if (PlayerPrefs.GetInt("Level3", -1) != -1)
            {
                sonlvl = 3; ;
            }
        else if (PlayerPrefs.GetInt("Level2", -1) != -1)
            {
                sonlvl = 2;
            }
        else if (PlayerPrefs.GetInt("Level1", -1) != -1)
            {
                sonlvl = 1;
            }
        else 
            {
                sonlvl = 0;
            }
        
        if (sonlvl > 0) 
        {
        menutext.text = "Current: Level "+sonlvl+"\nTotal Score: " + menuskor ;
        }
        else 
        {
        menutext.text = "Press Start...";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
