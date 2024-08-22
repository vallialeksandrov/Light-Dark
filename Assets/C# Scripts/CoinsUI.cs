using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsUI : MonoBehaviour
{
    [Header("Тексты для монеток")]
    [SerializeField] private TMP_Text coinsText, endCoinsText;

    [SerializeField] private int currentCoins, necessaryCoins, allCoins;

    [SerializeField] private AudioSource coinAS;

    private void Start() 
    {
        coinsText.text = currentCoins.ToString() + "/3";
        allCoins += PlayerPrefs.GetInt("Coins");
    }

    private void OnEnable() => TakeCoins.onTakedCoin += ShowCoins;

    private void OnDisable() => TakeCoins.onTakedCoin -= ShowCoins;

    private void ShowCoins()
    {
        currentCoins++;
        coinsText.text = currentCoins.ToString() + "/3";

        allCoins++;
        PlayerPrefs.SetInt("Coins", currentCoins);

        coinsText.text = currentCoins.ToString() + "/" + necessaryCoins;
        endCoinsText.text = "Свет: " + currentCoins.ToString() + "/" + necessaryCoins;

        coinAS.Play();
    }
}
