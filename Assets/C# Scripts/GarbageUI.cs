using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GarbageUI : MonoBehaviour
{
    [SerializeField] private TMP_Text garbageText;

    private void OnEnable()
    {
        FindGarbage.onFinded += UpdateText;
        FindGarbage.onDeleted += ClearText;
    }

    private void OnDisable()
    {
        FindGarbage.onFinded -= UpdateText;
        FindGarbage.onDeleted -= ClearText;
    }

    private void UpdateText() => garbageText.text = "Вы нашли мусор и сделали лес чище";

    private void ClearText() => garbageText.text = null;
}
