using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterFireflyUI : MonoBehaviour
{
    [SerializeField] private CheckerResult checkerResult;

    [SerializeField] private TMP_Text[] countText;
    [SerializeField] private int necessaryCountText;

    private void Awake()
    {
        necessaryCountText = checkerResult.nesseryCount;
    }

    private void Start()
    {
        countText[0].text = "0/" + necessaryCountText;
        countText[1].text = null;
    }

    private void OnEnable() => FillingJar.onFinished += Count;
        
    private void OnDisable() => FillingJar.onFinished -= Count;

    private void Count(int countFirefly)
    {
        countText[0].text = countFirefly.ToString() + "/" + necessaryCountText;
        countText[1].text = "—ветл€чки: " + countFirefly.ToString() + "/" + necessaryCountText;
    }
}
