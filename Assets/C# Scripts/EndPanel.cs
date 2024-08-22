using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private GameObject endPanel;

    [SerializeField] private Button nextLevel;
    [SerializeField] private TMP_Text resultText;


    private void OnEnable()
    {
        CheckerResult.onWin += Win;
        CheckerResult.onLose += Lose;
    }

    private void OnDisable()
    {
        CheckerResult.onWin -= Win;
        CheckerResult.onLose -= Lose;
    }

    private void Win()
    {
        resultText.text = "Уровень пройден";

        endPanel.SetActive(true);
        nextLevel.interactable = true;
    }

    private void Lose()
    {
       resultText.text = "Уровень не пройден";
        endPanel.SetActive(true);
    }
}
