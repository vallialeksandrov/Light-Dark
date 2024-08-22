using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] text;
    private void Start()
    {
        text[0].text = "—пасЄнные светл€чки: " + PlayerPrefs.GetInt("Firefly").ToString();
        text[1].text = "ѕогибшие светл€чки: " + PlayerPrefs.GetInt("Kill").ToString();
        text[2].text = "—обранный свет: " + PlayerPrefs.GetInt("Coins").ToString();
        text[3].text = "—обранный мусор: " + PlayerPrefs.GetInt("Garbage").ToString();
    }
}
