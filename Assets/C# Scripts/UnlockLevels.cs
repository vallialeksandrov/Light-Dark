using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockLevels : MonoBehaviour
{
    [Header("Номер разблокированного уровня")]
    [SerializeField] private int levelUnlocked;

    [Header("Уровни")]
    [SerializeField] private Button[] levelButtons;

    private void Start()
    {
        if (PlayerPrefs.GetInt("LevelUnlock") == 0)
        {
            levelUnlocked = 1;
            PlayerPrefs.SetInt("LevelUnlock", levelUnlocked);
        }
        else
        {
            levelUnlocked = PlayerPrefs.GetInt("LevelUnlock");
        }

        for (int i = 0; i < levelUnlocked; i++)
        {
            if (levelUnlocked <= 11)
                levelButtons[i].interactable = true;
        }
    }
}
