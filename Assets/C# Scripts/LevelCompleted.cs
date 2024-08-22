using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    private void OnEnable()
    {
        CheckerResult.onWin += CompleteLevel;
    }

    private void OnDisable()
    {
        CheckerResult.onWin -= CompleteLevel;
    }

    private void CompleteLevel()
    {
        int completedScene = SceneManager.GetActiveScene().buildIndex - 1;

        if (completedScene >= PlayerPrefs.GetInt("LevelUnlock"))
        {
            PlayerPrefs.SetInt("LevelUnlock", completedScene + 1);
        }
    }
}
