using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ParticleSystemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameParticleSystem;
    [SerializeField] private GameObject splash;

    [SerializeField] private AudioSource particleSystemAudioSource;
    [SerializeField] private AudioClip[] clips;

    private void OnEnable()
    {
        VenusFlatrap.onDiedPosition += InclusionParticleSystem;

        Enemy.onKilledPosition += InclusionParticleSystemWithSplash;
        StaminaFlyfire.onDiedPosition += InclusionParticleSystemWithSplash;

        SpiderStamina.onDied += InclusionSpiderParticleSystem;

        Cordyceps.onInfected += InclusionInfecteBloomParticleSystem;
    }

    private void OnDisable()
    {
        VenusFlatrap.onDiedPosition -= InclusionParticleSystem;

        Enemy.onKilledPosition -= InclusionParticleSystemWithSplash;     
        StaminaFlyfire.onDiedPosition -= InclusionParticleSystemWithSplash;

        SpiderStamina.onDied -= InclusionSpiderParticleSystem;

        Cordyceps.onInfected -= InclusionInfecteBloomParticleSystem;
    }

    private void InclusionParticleSystemWithSplash(Vector2 flyfirePosition)
    {
        GameObject newDiePS = Instantiate(gameParticleSystem[0], flyfirePosition, Quaternion.identity);
        Destroy(newDiePS, 1f);

        Instantiate(splash, flyfirePosition, Quaternion.identity);

        particleSystemAudioSource.clip = clips[0];
        particleSystemAudioSource.Play();
    }

    private void InclusionParticleSystem(Vector2 eatingPosition)
    {
        GameObject newDiePS = Instantiate(gameParticleSystem[0], eatingPosition, Quaternion.identity);
        Destroy(newDiePS, 1f);

        particleSystemAudioSource.clip = clips[1];
        particleSystemAudioSource.Play();
    }
    
    private void InclusionSpiderParticleSystem(Vector2 spiderPosition)
    {
        GameObject newDiePS_spider = Instantiate(gameParticleSystem[1], spiderPosition, Quaternion.identity);
        Destroy(newDiePS_spider, 1f);

        particleSystemAudioSource.clip = clips[2];
        particleSystemAudioSource.Play();
    }

    private void InclusionInfecteBloomParticleSystem(GameObject infectedObject)
    {
        GameObject newBlood = Instantiate(gameParticleSystem[2], infectedObject.transform.position, Quaternion.identity);
        newBlood.transform.SetParent(infectedObject.transform);

        particleSystemAudioSource.clip = clips[3];
        particleSystemAudioSource.Play();
    }
}
