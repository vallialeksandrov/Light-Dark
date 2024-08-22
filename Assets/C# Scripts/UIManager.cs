using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] text;
    private void Start()
    {
        text[0].text = "�������� ���������: " + PlayerPrefs.GetInt("Firefly").ToString();
        text[1].text = "�������� ���������: " + PlayerPrefs.GetInt("Kill").ToString();
        text[2].text = "��������� ����: " + PlayerPrefs.GetInt("Coins").ToString();
        text[3].text = "��������� �����: " + PlayerPrefs.GetInt("Garbage").ToString();
    }
}
