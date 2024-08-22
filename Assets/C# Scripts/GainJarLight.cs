using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GainJarLight : MonoBehaviour
{
    [SerializeField] private Light2D jarLight;

    private void OnEnable()
    {
        FillingJar.onFinished += GainLight;
    }

    private void OnDisable()
    {
        FillingJar.onFinished -= GainLight;
    }   

    private void GainLight(int empty)
    {
        jarLight.intensity += 1;
    }
}
