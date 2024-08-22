using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class FillingJar : MonoBehaviour
{
    public static Action<int> onFinished;

    [SerializeField] private ParticleSystem fireflyPS;

    [SerializeField] private AudioSource jarAS;

    [HideInInspector] private int allCountFirefly;

    private void Start() => allCountFirefly = PlayerPrefs.GetInt("Firefly");

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PursuitParent pursuitParent))
        {
            allCountFirefly++;
            PlayerPrefs.SetInt("Firefly", allCountFirefly);

            Destroy(collision.gameObject);
            CountFirefly();

            jarAS.Play();
        }
    }

    private void CountFirefly()
    {
        ParticleSystem.MainModule count = fireflyPS.main;
        count.maxParticles++;

        onFinished?.Invoke(count.maxParticles);
    }
}
