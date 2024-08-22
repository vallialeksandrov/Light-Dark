using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] private static bool isPlay;

    [SerializeField] private AudioSource[] AudioSources;

    [SerializeField] private AudioMixerGroup[] mixers;
    [SerializeField] private GameObject[] toggle;

    private void Awake()
    {
        if (isPlay == false)
        {
            AudioSources[0].Play();
            AudioSources[1].Play();

            DontDestroyOnLoad(this);
            isPlay = true;
        }
    }

    private void Start()
    {
        toggle[0].GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("MusicOn") == 0;
        toggle[1].GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("SoundOn") == 0;
    }

    public void PlayMusic(bool isMusicPlay)
    {
        if (isMusicPlay == true)
        {
            mixers[0].audioMixer.SetFloat("MusicVolume", 0);
        }

        if (isMusicPlay == false)
        {
            mixers[0].audioMixer.SetFloat("MusicVolume", -80);
        }

        PlayerPrefs.SetInt("MusicOn", isMusicPlay ? 1 : 0);
    }

    public void PlaySounds(bool isMusicPlay)
    {
        if (isMusicPlay == true)
        {
            mixers[1].audioMixer.SetFloat("Sounds", 0);
        }

        if (isMusicPlay == false)
        {
            mixers[1].audioMixer.SetFloat("Sounds", -80);
        }

        PlayerPrefs.SetInt("SoundOn", isMusicPlay ? 1 : 0);
    }
}
