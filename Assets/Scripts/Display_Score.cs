using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Display_Score : MonoBehaviour
{
    private Score_Manager Score_Manager;

    private TMP_Text text;

    private void Awake()
    {
        Score_Manager = GameObject.FindWithTag("Player").GetComponent<Score_Manager>();
        text = GetComponent<TMP_Text>();
    }

    private void Update() 
    {
        text.text = "" + Score_Manager.score;
    }
}
