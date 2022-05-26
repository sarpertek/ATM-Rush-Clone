using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject TextContainer;
    private int sonlvl;

    
    public void Pause() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    void Start()
    {

    }

    public void Resume() 
    {   
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Baslat() 
    {   
        if (PlayerPrefs.GetInt("Level1", -1) == -1)
            {
                sonlvl = 1;
            }
        else if (PlayerPrefs.GetInt("Level2", -1) == -1)
            {
                sonlvl = 2;
            }
        else if (PlayerPrefs.GetInt("Level3", -1) == -1)
            {
                sonlvl = 3;
            }
        else 
            {
                Debug.Log("Tüm bölümler tamamlandı baştan başlanıyor...");
                PlayerPrefs.DeleteAll();
            }

        SceneManager.LoadScene(sonlvl);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        TextContainer.SetActive(true);
        text.fixle = false;
        Movement.Skor = 0;
        GameManager.depomiktari = 0; 
        Movement.hareket = true;
    }

    public void Home(int sceneID) 
    {           
        int L1 = PlayerPrefs.GetInt("Level1",-1);
        int L2 = PlayerPrefs.GetInt("Level2",-1);
        int L3 = PlayerPrefs.GetInt("Level3",-1);
        Debug.Log("l1"+L1+"l2"+L2+"l3"+L3);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
        text.fixle = false;
    }

    public void cik()
    {
        Application.Quit();
    }
}
