using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textMoney;
    public static int TotalScore;
    public static bool fixle = false;

    private void Update()
    {
        if (fixle == false) {
            TotalScore = (Movement.Skor - GameManager.depomiktari);
            textMoney.text = TotalScore.ToString();
        }
        else 
        {
        }
    }

}
