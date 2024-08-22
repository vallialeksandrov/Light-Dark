using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelDie : MonoBehaviour
{
    private void OnEnable()
    {
        CheckerResult.onWin += Die;
    }

    private void OnDisable()
    {
        CheckerResult.onWin -= Die;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
