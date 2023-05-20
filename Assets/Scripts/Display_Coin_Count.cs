using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Display_Coin_Count : MonoBehaviour 
{
    private Coin_Manager Coin_Manager;

    private TMP_Text text;

    private void Awake()
    {
        Coin_Manager = GameObject.FindWithTag("Player").GetComponent<Coin_Manager>();
        text = GetComponent<TMP_Text>();
    }

    private void Update() 
    {
        text.text = "Coins: " + Coin_Manager.coinCount;
    }
}
