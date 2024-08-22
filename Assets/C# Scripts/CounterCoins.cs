using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CounterCoins : MonoBehaviour
{
    public static Action<int> onChangeCoins;

    [SerializeField] private int currentCoins;

    private void OnEnable()
    {
        TakeCoins.onTakedCoin += CountCoins;
    }

    private void OnDisable()
    {
        TakeCoins.onTakedCoin -= CountCoins;
    }

    private void CountCoins()
    {
        currentCoins += 1;
    }
}
