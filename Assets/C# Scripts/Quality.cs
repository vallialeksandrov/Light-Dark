using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quality : MonoBehaviour
{
    [SerializeField] private int levelQuality;

    private void Start()
    {
        QualitySettings.SetQualityLevel(0, true);
    }
    public void DownQuality()
    {
        levelQuality = 0;
        SetQuality();
    }

    public void MiddleQuality()
    {
        levelQuality = 3;
        SetQuality();
    }

    public void HighQuality()
    {
        levelQuality = 5;
        SetQuality();
    }

    private void SetQuality()
    {
        PlayerPrefs.SetInt("Quality", levelQuality);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
