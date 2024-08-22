using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrameControl : MonoBehaviour
{
    [SerializeField] private int frame;

    private void Start()
    {
        frame = PlayerPrefs.GetInt("Frame");
        Application.targetFrameRate = frame;
    }

    public void Frame30()
    {
        frame = 30;
        SetFrame();
    }
    public void Frame60()
    {
        frame = 60;
        SetFrame();
    }

    public void Frame90()
    {
        frame = 90;
        SetFrame();
    }

    public void Frame144()
    {
        frame = 144;
        SetFrame();
    }

    public void FrameNoLimit()
    {
        frame = 1000;
        SetFrame();
    }

    private void SetFrame()
    {
        PlayerPrefs.SetInt("Frame", frame);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
